using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer;
using System.IO;
using System.Windows.Forms;


namespace DynamicsTools
{
    class SQLFunctions
    {

        private SqlConnection con;
        private string conString;

        public SQLFunctions(string _conString)
        {
            ConectDatabase(_conString);
        }

        private  void ConectDatabase(string _conString)
        {
            conString = _conString;
            
        }

        /*
         *                  DRAFT !!!!!!   Still in progress...
         * 
         * Function description: transferring data between tables with the same name
         */
        public void DataTransfer(string _FromDB, string _ToDB, string _FromCompany, string _ToCompany, string _Table )
        {

            using (con = new SqlConnection(conString))
            {
          

            string QueryToTable = "SELECT COLUMN_NAME, DATA_TYPE  " +
                                     "FROM [" + _ToDB + "].INFORMATION_SCHEMA.COLUMNS " +
                                     "WHERE TABLE_NAME = '" + _ToCompany + "$" + _Table + "' ";


            string QuerySelectInsert = "SELECT INTO [" + _ToDB + "].[dbo].'" + _ToCompany + "$" + _Table + "' (";
           



            ////////////////////////////////////////////////////////////////////

            string QueryFieldsInsert = "";
            string QueryInColums = "SELECT  REPLACE(REPLACE(COLUMN_NAME COLLATE Latin1_General_BIN, '%', '_'),'.', '_') , COLUMN_NAME, DATA_TYPE " +
                                     "FROM [" + _ToDB + "].INFORMATION_SCHEMA.COLUMNS " +
                                     "WHERE TABLE_NAME = '" +_Table + "' " +
                                     "AND REPLACE(REPLACE(COLUMN_NAME COLLATE Latin1_General_BIN, '%', '_'),'.', '_') COLLATE Latin1_General_BIN IN ( " +
                                                                    "SELECT REPLACE(REPLACE(COLUMN_NAME COLLATE Latin1_General_BIN, '%', '_'),'.', '_') " +
                                                                    "FROM [" + _FromDB + "].INFORMATION_SCHEMA.COLUMNS " +
                                                                    "WHERE TABLE_NAME = '" + _Table + "') ";
            //using (con = new SqlConnection(conString))
            //{
                con.Open();
                using (SqlCommand cmd = new SqlCommand(QueryInColums, con))
                {
                    using (IDataReader IntoColums = cmd.ExecuteReader())
                    {
                        QueryFieldsInsert = " (";
                        while (IntoColums.Read())
                        {
                            if (QueryFieldsInsert != " (")
                            {
                                QueryFieldsInsert += ", ";
                            }

                            QueryFieldsInsert += IntoColums[0].ToString();
                        }
                        QueryFieldsInsert = " ) ";
                    }
                }
                con.Close();
               //}

                string QueryFieldsFrom= "";
                string QueryFromTable = "SELECT COLUMN_NAME, DATA_TYPE  " +
                                         "FROM [" + _FromDB + "].INFORMATION_SCHEMA.COLUMNS " +
                                         "WHERE TABLE_NAME = '" + _Table + "' " +
                                         "AND REPLACE(REPLACE(COLUMN_NAME COLLATE Latin1_General_BIN, '%', '_'),'.', '_') IN " + QueryFieldsInsert;
                con.Open();
                using (SqlCommand cmd = new SqlCommand(QueryFromTable, con))
                {
                    using (IDataReader FromColums = cmd.ExecuteReader())
                    {
                        QueryFieldsFrom = " (";
                        while (FromColums.Read())
                        {
                            if (QueryFieldsFrom != " (")
                            {
                                QueryFieldsFrom += ", ";
                            }

                            QueryFieldsFrom += FromColums[0].ToString();
                        }
                        QueryFieldsFrom = " ) ";
                    }
                }
                con.Close();

                string ExecuteQuery = "INSERT INTO [" + _ToDB + "].[dbo].'" + _ToCompany + "$" + _Table + "' " + QueryFieldsInsert +" "+
                                      "SELECT "+ QueryFieldsFrom +
                                      "FROM [" + _FromDB + "].[dbo].'" + _FromCompany + "$" + _Table + "' ";

                MessageBox.Show(ExecuteQuery);
            }
        }
    }
}


/*
 * 
 * 
 * 
SELECT  COLUMN_NAME ,  DATA_TYPE, * FROM [InTo_DB].INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'COMPANY TEST$Item'
AND COLUMN_NAME COLLATE Latin1_General_BIN  IN (
					 SELECT REPLACE(COLUMN_NAME COLLATE Latin1_General_BIN, '%', '_') FROM From_DB.INFORMATION_SCHEMA.COLUMNS
					 WHERE TABLE_NAME = 'COMPANY PROD$Item')





SELECT  COLUMN_NAME ,  DATA_TYPE, * FROM [MszuBCLS Entw].INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Müller Schiesszentrum Ulm$Item'
AND COLUMN_NAME COLLATE Latin1_General_BIN  NOT IN (
					 SELECT REPLACE(COLUMN_NAME COLLATE Latin1_General_BIN, '%', '_') FROM From_DB.INFORMATION_SCHEMA.COLUMNS
					 WHERE TABLE_NAME = 'COMPANY PROD$Item')

---  From_DB  >>>>  InTo_DB - Company:: COMPANY TEST


 * 
 * 
 * 
--------------------------------------------------------------------------
--------------------------------------------------------------------------
 
            THE IDEA  !!!
 
--------------------------------------------------------------------------
--------------------------------------------------------------------------
--Tables
--------------------------------------------------------------------------
DECLARE @Tabele_Name varchar(100)

DECLARE @Field_Name  varchar(100)
DECLARE @Field_Type  varchar(100)

DECLARE @FieldImport_Name  varchar(100)

DECLARE @default_wert  varchar(MAX)

DECLARE @Query_SELECT_INSERT varchar (MAX)
DECLARE @ALL_FIELDS varchar (MAX)
DECLARE @ALL_FIELDS_INSERT varchar (MAX)

DECLARE @MANDANTE_Name  varchar(100)
DECLARE @Count int


DECLARE @DDBB_Import varchar(100)
DECLARE @DDBB_Quelle varchar(100)

---
SET @DDBB_Import = 'InTo_DB'

DECLARE Tables_Cursor CURSOR 
	LOCAL STATIC READ_ONLY FORWARD_ONLY
	FOR	SELECT TABLE_NAME
		FROM InTo_DB.INFORMATION_SCHEMA.TABLES
		--WHERE TABLE_NAME LIKE  'COMPANY TEST$%Item%'   
		WHERE TABLE_NAME LIKE  'TEST JR$Inventory Setup' 

OPEN Tables_Cursor
FETCH NEXT FROM Tables_Cursor INTO @Tabele_Name
WHILE @@FETCH_STATUS = 0
BEGIN 

	SET @Count = 0
    SET @ALL_FIELDS = ''
	SET @ALL_FIELDS_INSERT = ''

	--SET @MANDANTE_Name = REPLACE(@Tabele_Name , 'COMPANY TEST', 'COMPANY PROD')
	--SET @MANDANTE_Name = @Tabele_Name 

	DECLARE Fields_Cursor CURSOR 
		LOCAL STATIC READ_ONLY FORWARD_ONLY
		FOR	SELECT COLUMN_NAME, DATA_TYPE
			FROM InTo_DB.INFORMATION_SCHEMA.COLUMNS
			WHERE TABLE_NAME = @Tabele_Name
			--AND COLUMN_NAME <> 'Picture'
			--AND COLUMN_NAME <> 'Id'
			--AND COLUMN_NAME <> 'Unit of Measure Id'
			--AND COLUMN_NAME <> 'Tax Group Id'
			--AND COLUMN_NAME <> 'Item Category Id'

	OPEN Fields_Cursor
	FETCH NEXT FROM Fields_Cursor INTO @Field_Name, @Field_Type
	WHILE @@FETCH_STATUS = 0
	BEGIN

	
		--------------------------
		SET @Count += 1
		IF @Count > 2 
			SET @ALL_FIELDS = @ALL_FIELDS + ','
		IF @Count > 1 
			SET @ALL_FIELDS = @ALL_FIELDS + '[' + @Field_Name + ']'

	
		SET @MANDANTE_Name = REPLACE(@Tabele_Name , 'COMPANY TEST', 'COMPANY PROD')

		DECLARE FieldsImport_Cursor CURSOR 
		LOCAL STATIC READ_ONLY FORWARD_ONLY
		FOR SELECT COLUMN_NAME
			FROM From_DB.INFORMATION_SCHEMA.COLUMNS
			WHERE TABLE_NAME = @MANDANTE_Name
			AND COLUMN_NAME = @Field_Name
		OPEN FieldsImport_Cursor
		FETCH NEXT FROM FieldsImport_Cursor INTO @FieldImport_Name
		WHILE @@FETCH_STATUS = 0
		BEGIN
			
			FETCH NEXT FROM FieldsImport_Cursor INTO @FieldImport_Name
		END	
		CLOSE FieldsImport_Cursor
		DEALLOCATE FieldsImport_Cursor


		IF @FieldImport_Name = '' 
		BEGIN
			
			SET @default_wert  = 0

			IF @Field_Type = 'nvarchar'
				 SET @default_wert  = ''''''

			--IF @Field_Type = 'uniqueidentifier'
			--	SET @default_wert  = 'NEWID()'	

			IF @Field_Type = 'image'
				SET @default_wert  = 'NULL'
		 END

		IF @Field_Type = 'uniqueidentifier' BEGIN
			SET @default_wert  = 'NEWID()'	
			SET @FieldImport_Name = ''
		END


		IF @Count > 2 
				SET @ALL_FIELDS_INSERT = @ALL_FIELDS_INSERT + ','

		IF @Count > 1 
			IF @FieldImport_Name <> '' 
				SET @ALL_FIELDS_INSERT = @ALL_FIELDS_INSERT + '[' + @FieldImport_Name + ']'
			ELSE
				SET @ALL_FIELDS_INSERT = @ALL_FIELDS_INSERT + @default_wert

		SET @FieldImport_Name = ''
		----------------------------

		SET @Field_Name = ''
		SET @Field_Type = ''
		FETCH NEXT FROM Fields_Cursor INTO @Field_Name, @Field_Type

	END	
	CLOSE Fields_Cursor
	DEALLOCATE Fields_Cursor


    --SET @MANDANTE_Name = REPLACE(@Tabele_Name , 'COMPANY TEST', 'COMPANY PROD')

	SET @Query_SELECT_INSERT = 'INSERT INTO '+ @DDBB_Import +'.[dbo].[' + @Tabele_Name + '] ('+ @ALL_FIELDS +') SELECT ' + @ALL_FIELDS_INSERT + ' FROM  [From_DB].[dbo].['+ @MANDANTE_Name +']'
	
	PRINT '-----------------------------'
	PRINT 'INSERT INTO '+ @DDBB_Import +'.[dbo].[' + @Tabele_Name + '] ('+ @ALL_FIELDS +')'
	PRINT 'SELECT ' + @ALL_FIELDS_INSERT + ' FROM  [From_DB].[dbo].['+ @MANDANTE_Name +']'
	PRINT '-----------------------------'


	--------------------------------------------------------------
	IF NOT (@Query_SELECT_INSERT LIKE '%VSIFT%')
		begin
			PRINT '-----------------------------'
			PRINT 'DELETE FROM ['+ @DDBB_Import +'].[dbo].[' + @Tabele_Name + ']'
			PRINT @Query_SELECT_INSERT
	
			--EXECUTE('SET IDENTITY_INSERT [Fischer71Demo].[dbo].['+ @Tabele_Name +'] ON')
			EXECUTE('DELETE FROM ['+ @DDBB_Import +'].[dbo].[' + @Tabele_Name + ']')
			EXECUTE(@Query_SELECT_INSERT)
		end
	--------------------------------------------------------------

	
	SET  @Tabele_Name = ''
    FETCH NEXT FROM Tables_Cursor INTO @Tabele_Name
END
CLOSE Tables_Cursor
DEALLOCATE Tables_Cursor

*/