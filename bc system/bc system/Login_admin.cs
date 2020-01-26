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
    public partial class Login_admin : Form
    {
        public Login_admin()
        {
            InitializeComponent();
        }

        

        private void txtusername_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
        }

        private void txtpass_Click(object sender, EventArgs e)
        {
            txtpass.Clear();
        }

        

        private void btnclose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnmin_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {/*
            if (txtusername.Text == "admin"||txtusername.Text=="admin"&&txtpass.Text=="admin"||txtpass.Text == "Admin")
            {
                this.Hide();
                new Admin_panel().Show();
            }
            else
            {
                MessageBox.Show("You are not a admin ask the admin to add new admin");
            }
            */

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT count (*) FROM Registered_Users WHERE username ='" + txtusername.Text + "' AND pasword='" + txtpass.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (txtusername.Text == "admin" || txtusername.Text == "admin" && txtpass.Text == "admin" || txtpass.Text == "Admin")
                    {
                        this.Hide();
                        new Admin_panel().Show();
                    }
                    else
                    {
                        MessageBox.Show("You are not a admin ask the admin to add new admin");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
                con.Close();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("some error ocurred during the registration:" + ex.ToString());

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }
    }
}
