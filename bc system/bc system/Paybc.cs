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
    public partial class Paybc : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");

        public Paybc()
        {
            InitializeComponent();
            Fill();
            /* try
             {
                 string query = "SELECT Status FROM Req_member where Username = '" + Program.username + "' ";
                 SqlCommand commandDatabase = new SqlCommand(query, con);
                 SqlDataReader reader;
                 con.Open();
                 reader = commandDatabase.ExecuteReader();
                 if (reader.HasRows)
                 {
                     while (reader.Read())
                     {
                         if (reader.GetString(2).ToString() == "Pending" || reader.GetString(2).ToString() == "Rejected")
                         {

                             button2.Enabled = false;


                         }
                         else
                         {
                             button2.Enabled = true;
                         }



                     }
                 }
                 con.Close();
             }
             catch (System.Exception ex)
             {

                 MessageBox.Show("some error ocurred during the registration:" + ex.ToString());

             }*/

        }
        public void Fill()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Amount from  Req_member where Username = '" + Program.username + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["Amount"].ToString());
                }
                String qry2 = "Update Req_member set Ispaid = '0' where Username = '" + Program.username + "' ";
                SqlDataReader reader2;
                SqlCommand cmd2 = new SqlCommand(qry2, con);

                reader2 = cmd2.ExecuteReader();



                con.Close();


            }
            catch (System.Exception ex)
            {

                MessageBox.Show("Error:" + ex.ToString());
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
            SqlConnection con3 = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
            try
            {




                con2.Open();
                String qry = " select count(NOBC) from Req_member where Username = '" + Program.username + "'And Amount = '" + comboBox1.SelectedItem.ToString() + "' ";

                SqlCommand cmd = new SqlCommand(qry, con2);

                SqlDataReader reader;

                reader = cmd.ExecuteReader();
                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                      int a = Int32.Parse(reader.GetInt32(0).ToString());
                        Program.no = a;
                        int b = Int32.Parse(comboBox1.SelectedItem.ToString());
                        int total = a * b;
                        label2.Text = total.ToString();
                        con3.Open();
                        String qry2 = "Update Req_member set Total = '" + label2.Text + "' , Ispaid = '0' where Username = '" + Program.username + "'And Amount = '" + comboBox1.SelectedItem.ToString() + "' ";
                        SqlDataReader reader2;
                        SqlCommand cmd2 = new SqlCommand(qry2, con3);

                        reader2 = cmd2.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                            }
                            con3.Close();
                        }



                    }





                    con2.Close();



                }




            }

            catch (System.Exception ex)
            {
                MessageBox.Show("error" + ex.ToString());

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
            SqlConnection con3 = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
            try
            {
                con2.Open();
                String qry2 = "Select* from Req_member where Username = '" + Program.username + "' ";
                SqlDataReader reader2;
                SqlCommand cmd2 = new SqlCommand(qry2, con2);

                reader2 = cmd2.ExecuteReader();

                if (reader2.HasRows)
                {
                    while (reader2.Read())

                    {
                        try
                        {
                            con3.Open();
                            String qry3 = "Update Req_member set  Pay_status = 'Unpaid', Ispaid = '1',DOP = CONVERT(date, getdate()) where Username = '" + Program.username + "' ";
                            SqlDataReader reader3;
                            SqlCommand cmd3 = new SqlCommand(qry3, con3);

                            reader3 = cmd3.ExecuteReader();
                            MessageBox.Show("Successful");
                            con3.Close();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("Error" + ex.ToString());
                        }
                    }
                    con2.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }
    }
}