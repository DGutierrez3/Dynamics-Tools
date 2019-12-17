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
    public partial class Empty_Users : Form
    {
        private SqlConnection con;
        string conString;

        public Empty_Users(string _conString)
        {
            InitializeComponent();

            conString = _conString;
            comboBox1.Items.Add("Dynamics NAV 2009 R2");
            comboBox1.Items.Add("Dynamics NAV 2015");
            comboBox1.SelectedIndex = 0;
            GetDatabaseList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete_NAV_Users();
        }

        private void Empty_Users_Load(object sender, EventArgs e)
        {

        }




        #region DB_Querys
        //LOAD: Database List
        private void GetDatabaseList()
        {

            using (con = new SqlConnection(conString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            comboBox2.Items.Add(dr[0].ToString());
                        }
                    }
                }
                comboBox2.SelectedIndex = 0;
                con.Close();
            }
        }

        private void Delete_NAV_Users()
        {
            string sqlTrunc;

            if (comboBox1.SelectedIndex == 0)
            {
                //Dynamics NAV 2009 R2
                sqlTrunc = "TRUNCATE TABLE  [" + comboBox2.SelectedItem + "].[dbo].[Windows Access Control]; " +
                            "TRUNCATE TABLE [" + comboBox2.SelectedItem + "].[dbo].[Member Of]; " +
                            "TRUNCATE TABLE [" + comboBox2.SelectedItem + "].[dbo].[User]; ";
            }
            else
            {
                //Ab Dynamics NAV 2015
                sqlTrunc = "TRUNCATE TABLE  ["+ comboBox2.SelectedItem +"].[dbo].[Access Control]; " +
                            "TRUNCATE TABLE ["+ comboBox2.SelectedItem +"].[dbo].[User Personalization]; " +
                            "TRUNCATE TABLE [" + comboBox2.SelectedItem + "].[dbo].[User]; ";
            }

            
            
            using (con = new SqlConnection(conString))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand(sqlTrunc, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("OK..  :)");
                }
                catch 
                {
                    MessageBox.Show("Invalid NAV version", "ERROR",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                con.Close();
            }
             
        }

        #endregion DB_Querys
    }
}
