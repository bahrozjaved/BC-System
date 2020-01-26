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

namespace bc_system
{
    public partial class forgetpassword : Form
    {
        public string MyConnectionString = @"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True";

        public forgetpassword()
        {
            InitializeComponent();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            Program.user = txtusername.Text;
            string query = "SELECT * FROM Registered_Users where username = '"+txtusername.Text+"' ";
            SqlConnection databaseConnection = new SqlConnection(MyConnectionString);
            SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            SqlDataReader reader;
           
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
              

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       
                        this.Hide();
                        new updatepassword().Show();
                        break;

                        /*if ( reader.GetString(3).ToString() == "txtusername.Text")
                        {
                            this.Hide();
                            new updatepassword().Show();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("no data found"); 
                            break;
                        }*/
                    }
                }
                else
                {
                    MessageBox.Show("No rows found.");
                }
                databaseConnection.Close();
            }

    catch (System.Exception ex)
                 {

               MessageBox.Show("some error ocurred during the registration:" + ex.ToString());

                       }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}

