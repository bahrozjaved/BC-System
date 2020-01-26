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
using System.Text.RegularExpressions;

namespace bc_system
{
    public partial class signup : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
        
        public string pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
        public string nopatern = @"^[0-9]{4}[0-9]{7}$";
        public signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
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

        private void btn_signup_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != txtconfirm.Text)
            {
                MessageBox.Show("pass donot matched");
            }
            else if (txtuser.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("please filled the required mandatory field");

            }

            else
            {

                try
                {
                    String Firstname = txtname.Text;
                    String Lastname = txtlast.Text;
                    String Username = txtuser.Text;
                    String Password = txtpass.Text;
                    String Email = txtemail.Text;
                    String MobileNo = txtmobile.Text;
                    con.Open();
                    if (Regex.IsMatch(txtemail.Text, pattern) &&
                        Regex.IsMatch(txtmobile.Text, nopatern))
                    {
                        


                            String qry = "Insert into Registered_users(Firstname,Lastname,Username,Pasword,Email,MobileNo) Values('" + Firstname + "','" + Lastname + "','" + Username + "','" + Password + "','" + Email + "','" + MobileNo + "')";
                            SqlCommand cmd = new SqlCommand(qry, con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("user created successfully");

                            clear();
                            this.Hide();
                            new login().Show();
                        }
                        else
                        {
                            error1.Text = "plzz check the email OR MOBILENO 0301XXXXXXX";
                        }
                        con.Close();

                    }
                   
                    
                

                catch (System.Exception ex)
                {
                    MessageBox.Show("some error ocurred during the registration:" + ex.ToString());

                }

            }
        
           


        } 
        public void clear()
        {
            txtuser.Text = txtpass.Text = txtname.Text = txtlast.Text = txtemail.Text = txtconfirm.Text = txtmobile.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

       
    }
       

    }

