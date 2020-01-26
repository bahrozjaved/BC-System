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
    public partial class AddBc : UserControl
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
        public AddBc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text =="")
            {
                MessageBox.Show("Value not entered");
            }
            else
            {
                try
                {
                    String Bc = textBox1.Text;
                    con.Open();


                    String qry = "Insert into Bc(Ammount) Values('" + Bc + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bc added successfully");
                    con.Close();


                }
                catch (System.Exception Exception)
                {
                    MessageBox.Show("error:" + Exception.ToString());
                }


            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled=! char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("onlu numeric value is allowed");
            }
        }
    }
}
