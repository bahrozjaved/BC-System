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
    public partial class updatepassword : Form
    {
       public string con = (@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");


        public updatepassword()
        {
            InitializeComponent();
        }
       

        private void btnmin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Show_pass_CheckedChanged(object sender, EventArgs e)
        {

            if (Show_pass.Checked)
            {
                txtpass.UseSystemPasswordChar = false;
                txtconfirm.UseSystemPasswordChar = false;


            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
                txtconfirm.UseSystemPasswordChar = true;
            }
        }


    private void btn_change_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != txtconfirm.Text)
            {
                MessageBox.Show("pass donot matched");
            }
            else if (txtconfirm.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("please filled the required mandatory field");

            }
            else
            {
                try
                {
                    string Query = "update Registered_users set Pasword ='"+txtpass.Text+"'where username = '"+Program.user+"'";
                    SqlConnection MyConn2 = new SqlConnection(con);
                    SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                    SqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("password Updated");
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                    this.Close();
                    this.Hide();
                    new login().Show();

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("some error ocurred while update the password:" + ex.ToString());
                }
            }
        }

        
    }
}
