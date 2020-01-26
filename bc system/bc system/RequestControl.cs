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
    public partial class RequestControl : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
        public RequestControl()
        {
            InitializeComponent();
            fillcombo();
           
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

                MessageBox.Show("Error:"+ex.ToString());
            }
          








        }


        private void button1_Click(object sender, EventArgs e)
        {
            
         
            SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");

            try
            {
                int a = int.Parse(comboBox2.SelectedItem.ToString());
                for (int i = 0; i < a; i++)
                {


                    String Username = Program.username;
                    String Id = Program.Id;
                    String Status = "Pending";

                    String Nobc = "1";
                    String Amount = comboBox1.SelectedItem.ToString();

                    con2.Open();
                    String qry = " insert into Req_member (Id,Username,Status,NOBC,Amount) values ('" + Id + "','" + Username + "','" + Status + "','" + Nobc + "','" + Amount + "') ";
                    SqlCommand cmd = new SqlCommand(qry, con2);
                    cmd.ExecuteNonQuery();


                    con2.Close();


                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Some error occure while request:" + ex.ToString());

            }

                        MessageBox.Show("successfully requested");


        }

        private void RequestControl_Load(object sender, EventArgs e)
        {
            
        }
    }
}
