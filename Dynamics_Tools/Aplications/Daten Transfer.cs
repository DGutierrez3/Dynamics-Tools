using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer;
using System.IO;

namespace DynamicsTools.Form_2
{
    public partial class Daten_Transfer : Form
    {

        private SqlConnection con;
        string conString;

        public Daten_Transfer(string _conString)
        {
            InitializeComponent();

            conString = _conString;

            LoadDataIntoComponents();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCompanyList(comboBox_FromCompany, comboBox_FromDatabase.SelectedItem.ToString());

            comboBox_InDatabase.Enabled = true;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCompanyList(comboBox_InCompany, comboBox_InDatabase.SelectedItem.ToString());

            comboBox_FromCompany.Enabled = true;

        }


        private void LoadDataIntoComponents()
        {
            GetServerName(textBox4);
            GetDatabaseList(comboBox_FromDatabase);
            GetDatabaseList(comboBox_InDatabase);
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_InCompany.Enabled = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
                GetTableList(comboBox_TableName,
                             comboBox_InDatabase.SelectedItem.ToString(),
                             comboBox_InCompany.SelectedItem.ToString());

                comboBox_TableName.Enabled = true;
        }


        private void comboBox_TableName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_DataTransfer_Click(object sender, EventArgs e)
        {
            SQLFunctions sqlfunction = new SQLFunctions(conString);
            sqlfunction.DataTransfer(comboBox_FromDatabase.SelectedItem.ToString(),
                                     comboBox_InDatabase.SelectedItem.ToString(),
                                     comboBox_FromCompany.SelectedItem.ToString(),
                                     comboBox_InCompany.SelectedItem.ToString(),
                                     comboBox_TableName.SelectedItem.ToString());
        }


        #region Querys

        private void GetTableList(ComboBox _comboBox, string _DatabaseName, string _Company)
        {
            _comboBox.Items.Clear();
            using (con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME "+
                                                       "FROM [" + _DatabaseName + "].INFORMATION_SCHEMA.TABLES " +
                                                       "WHERE TABLE_NAME LIKE '" + _Company + "$%' " +
                                                       "AND TABLE_TYPE = 'BASE TABLE' ", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _comboBox.Items.Add(dr[0].ToString());
                        }
                    }
                }
                con.Close();
            }
        }



        private void GetDatabaseList(ComboBox _comboBox)
        {
            _comboBox.Items.Clear();
            using (con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases WHERE HAS_DBACCESS(name) = 1", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _comboBox.Items.Add(dr[0].ToString());
                        }
                    }
                }
                con.Close();
            }
            
        }


        private void GetCompanyList(ComboBox _comboBox, string _DatabaseName)
        {
            _comboBox.Items.Clear();
            using (con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Name FROM [" + _DatabaseName + "].[dbo].[Company]", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _comboBox.Items.Add(dr[0].ToString());
                        }
                    }
                }
                con.Close();
            }
            
            // return list;

        }


        private void GetServerName(TextBox _ServerName)
        {
            
            using (con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT @@SERVERNAME AS 'Server Name' ", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _ServerName.Text = dr[0].ToString();
                        }
                    }
                }
                con.Close();
            }

        }




        #endregion Querys

    }
}
