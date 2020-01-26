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
    public partial class adminresult : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
        SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");

       
        public adminresult()
        {
            InitializeComponent();
            fillcombo();

        }

        public void load()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            string sql;
            sql = "select * from data ";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
           
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[2], dr[0], dr[1], dr[3]);

                    i++;
                  

                }
            
          
         
            con.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void fillcombo()
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Ammount from Bc";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["Ammount"].ToString());
                }



                con.Close();


            }
            catch (System.Exception ex)
            {

                MessageBox.Show("Error:" + ex.ToString());
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String qry = "select * from data ";
                SqlCommand cmd2 = new SqlCommand(qry, con);

                SqlDataReader reader2;

                reader2 = cmd2.ExecuteReader();
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        MessageBox.Show("readed");

                    }
                }
                else
                {

                    try
                    {
                        con2.Open();
                        String qry2 = "INSERT INTO data (Id,Username,Bcid,Amount) select Id,Username,bc_id,Amount from Req_member where Status = 'Accepted'";
                        SqlCommand cmd = new SqlCommand(qry2, con2);

                        SqlDataReader reader;

                        reader = cmd.ExecuteReader();


                        MessageBox.Show("Inserted");
                        button3.Enabled = false;

                        con2.Close();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("error" + ex.ToString());

                    }

                }
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("error" + ex.ToString());


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            
           
                load();
            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
            SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
            SqlConnection con3 = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
            try
            {
                con.Open();
                String qry2 = "INSERT INTO result (Id,Username,Bcid,Amount) select Id,Username,Bcid,Amount from data where Username = '" + textBox1.Text + "' And Bcid= '" + textBox2.Text + "' And Amount= '" + comboBox1.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(qry2, con);

                SqlDataReader reader;

                reader = cmd.ExecuteReader();


                MessageBox.Show("one position Inserted");

                try
                {
                    con2.Open();
                    String qry1 = "INSERT INTO result (Id,Username,Bcid,Amount) select * from data where Bcid <> '" + textBox2.Text + "'order by newid()  ";
                    SqlCommand cmd1 = new SqlCommand(qry1, con2);

                    SqlDataReader reader1;

                    reader1 = cmd1.ExecuteReader();


                    MessageBox.Show("Inserted");


                    con2.Close();

                    try
                    {
                        con3.Open();
                        String q3 = "  update ncheck set Isresult = 'true' ";
                        SqlCommand cmd3 = new SqlCommand(q3,con3);
                        SqlDataReader reader3;
                        reader3 = cmd3.ExecuteReader();
                        MessageBox.Show("Updated");
                        con3.Close();



                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("error"+ex.ToString());
                        throw;
                    }



                }
                catch (System.Exception ex)
                {

                    MessageBox.Show("error" + ex.ToString());
                }
                con.Close();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("error"+ex.ToString());
            }
        }

       
    }
}
