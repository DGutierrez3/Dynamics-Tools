using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Data.SqlClient;
using Microsoft.SqlServer;
using System.IO;

using System.Net;
using System.Xml;




//I need here another solution  !!!
using BaCoe.Eam.Gui.Controles.Menus;


namespace DynamicsTools
{

    public partial class Login : Form
    {
        private PopupMenu oMenu;
        private SqlConnection con;
        string conString;

        public Login()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox4.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetDatabaseList();

            BuildMenu();
            SetSysTray();
            this.Hide();

        }


        #region Menu Rutines

        private void BuildMenu()
        {

            try
            {

                oMenu = new PopupMenu();
                oMenu.MenuCommands.ExtraText = "Dynamics Tools";
                oMenu.MenuCommands.ExtraBackBrush = System.Drawing.Brushes.DarkBlue;
                oMenu.MenuCommands.ExtraTextColor = System.Drawing.Color.White;

                //Hide the menu
                oMenu.MenuCommands.Add(new MenuCommand("&Close menu", ilsIcons, 8, new System.EventHandler(mnu_Close)));
                oMenu.MenuCommands.Add(new MenuCommand("-"));



                //The idea is to validate the user profile. For example 2 = admin, 1 = normal               
                string strUserRol = "2"; //dbFunctions.GetUserRol(Session, this.txtUSR.Text);
                
                if (strUserRol == "2")
                {
                    oMenu.MenuCommands.Add(new MenuCommand("&Users", ilsIcons, 0, new System.EventHandler(mnu_EmptyUsers)));
                    oMenu.MenuCommands.Add(new MenuCommand("&Transfer Date", ilsIcons, 0, new System.EventHandler(mnu_DatenTransfer)));
                }

                // Go out
                oMenu.MenuCommands.Add(new MenuCommand("-", new System.EventHandler(mnu_Clicked)));
                oMenu.MenuCommands.Add(new MenuCommand("&Go out", ilsIcons, 7, new System.EventHandler(mnu_Exit)));
            }
            catch (System.Exception a)
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
                MessageBox.Show("Error - Menu loading: " + a.Message);
            }
        }

        #endregion Rutinas de Menu


        #region Menu Functions
        

        private void mnu_Exit(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnu_Clicked(object sender, System.EventArgs e)
        {

        }

        private void mnu_DatenTransfer(object sender, System.EventArgs e)
        {
            Form_2.Daten_Transfer DB = new Form_2.Daten_Transfer(conString);
            DB.Show();
        }

        private void mnu_Close(object sender, System.EventArgs e)
        {
            oMenu.Dismiss();
        }

    
        private void mnu_EmptyUsers(object sender, System.EventArgs e)
        {
            Form_2.Empty_Users EmptyUsers = new Form_2.Empty_Users(conString);
            EmptyUsers.Show();
        }

        #endregion Menu Functions


        #region Systray Events
        private void sysTray_Click(object sender, EventArgs e)
        {
        }
        private void sysTray_DoubleClick(object sender, EventArgs e)
        {
        }
        private void sysTray_KeySelect(object sender, EventArgs e)
        {
        }
        private void sysTray_EnterSelect(object sender, EventArgs e)
        {
        }
        private void sysTray_MouseDown(object sender, MouseEventArgs e)
        {
        }
        private void sysTray_MouseMove(object sender, MouseEventArgs e)
        {
        }
        private void sysTray_MouseUp(object sender, MouseEventArgs e)
        {
            System.Drawing.Point pos = new Point(e.X - 50, e.Y);
            oMenu.TrackPopup(pos, true);
        }
        private void sysTray_BalloonClicked(object sender, EventArgs e)
        {
        }
        private void sysTray_BalloonShow(object sender, EventArgs e)
        {
        }
        private void sysTray_BalloonHide(object sender, EventArgs e)
        {
        }
        private void sysTray_BalloonTimeOut(object sender, EventArgs e)
        {
        }
        #endregion Systray Events

        private void SetSysTray()
        {
            // Assign the SysTray object to this form
            SysTray sysTray = new SysTray(this);

            // Set the Icon:
            NotifyIcon notifyIcon1 = new NotifyIcon();
            notifyIcon1.Icon = new System.Drawing.Icon("admin.ico");
            ImageList ImageList1 = new ImageList();
            ImageList1.Images.Add(notifyIcon1.Icon); 
            sysTray.IconImageList = ImageList1;
            sysTray.IconIndex = 0;

            // dp - 10/11/2009
            // Set the tooltip text:
            string strLocalContext = string.Empty;


            sysTray.ToolTipText = "Dynamics Tools";
            
            // events:
            sysTray.MouseDown += new MouseEventHandler(sysTray_MouseDown);
            sysTray.MouseUp += new MouseEventHandler(sysTray_MouseUp);
            sysTray.MouseMove += new MouseEventHandler(sysTray_MouseMove);
            sysTray.Click += new EventHandler(sysTray_Click);
            sysTray.DoubleClick += new EventHandler(sysTray_DoubleClick);
            sysTray.KeySelect += new EventHandler(sysTray_KeySelect);
            sysTray.EnterSelect += new EventHandler(sysTray_EnterSelect);
            sysTray.BalloonClicked += new EventHandler(sysTray_BalloonClicked);
            sysTray.BalloonHide += new EventHandler(sysTray_BalloonHide);
            sysTray.BalloonShow += new EventHandler(sysTray_BalloonShow);
            sysTray.BalloonTimeOut += new EventHandler(sysTray_BalloonTimeOut);

            // Show:
            sysTray.ShowInSysTray = true;
            sysTray.ShowBalloonTip("Click on the icon to access the menu.", NotifyIconBalloonIconFlags.NIIF_INFO, "Attention", 500);
            oMenu.Dismiss();

        }



        public void GetDatabaseList()
        {

            // Open connection to the database
            //string conString = "server=xeon;uid=sa;pwd=manager; database=northwind";
            //string conString = "Data Source=.; Integrated Security=True;";

            conString = "Server= "+textBox1.Text +"; Integrated Security=True;";

            using (con = new SqlConnection(conString))
            {
                con.Open();

            }
           // return list;

        }

     }
}
