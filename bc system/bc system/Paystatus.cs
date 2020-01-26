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
    public partial class Paystatus : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
        SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");

        public Paystatus()
        {

            InitializeComponent();
         /*   try
            {
                string query2 = "SELECT * FROM Req_member where Username = '" + Program.username + "' ";
                SqlCommand commandDatabase2 = new SqlCommand(query2, con2);
                SqlDataReader reader2;
                con2.Open();
                reader2 = commandDatabase2.ExecuteReader();
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        if (reader2.GetString(2).ToString() == "Pending" || reader2.GetString(2).ToString() == "Rejected")
                        {
                            button1.Enabled = false;
                        }
                        else
                        {
                            button1.Enabled = true;
                        }
                    }
                }
                con2.Close();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("some error ocurred during the registration:" + ex.ToString());

            }*/

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
                        
                        label2.Text = reader.GetString(7).ToString();

                    }
                }
                else
                {
                    label2.Text = "You are not paid the payment yet.";
                }
                con.Close();
            }


            catch (System.Exception ex)
            {

                MessageBox.Show("some error ocurred during the registration:" + ex.ToString());

            }
        }

        private void Paystatus_Load(object sender, EventArgs e)
        {

        }
    }
}
