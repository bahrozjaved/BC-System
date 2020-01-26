using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bc_system
{
    public partial class viewStatus : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
        
        public viewStatus()
        {
            InitializeComponent();
            
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Req_member where Username = '" + Program.username + "' ";
                SqlCommand commandDatabase = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        label2.Text = reader.GetString(2).ToString();
                        
                    }
                }
                else
                {
                    label2.Text="You are not requested yet.";
                }
                con.Close();
            }
        

            catch (System.Exception ex)
            {

                MessageBox.Show("some error ocurred during the registration:" + ex.ToString());

            }

        }

        private void viewStatus_Load(object sender, EventArgs e)
        {
            
        }
    }
}
