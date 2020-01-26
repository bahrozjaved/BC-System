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
    public partial class AcceptRequest : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
        public AcceptRequest()
        {
            InitializeComponent();
        }

        public void load()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 6;
            string sql;
            sql = "select * from Req_member";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
               
                i++;

            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {                 try
                            {
                                string Query = "update Req_member set Status ='" + comboBox1.SelectedItem.ToString() + "'where username = '" + textBox1.Text + "'";
                                SqlConnection MyConn2 = new SqlConnection("Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
                                SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                                SqlDataReader MyReader2;
                                MyConn2.Open();
                                MyReader2 = MyCommand2.ExecuteReader();
                                MessageBox.Show("Status updated");
                                while (MyReader2.Read())
                                {

                                }
                                MyConn2.Close();
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show("some error ocurred while update the password:" + ex.ToString());
                            }
                        }
         
        }
    }

