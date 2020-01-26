using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace bc_system
{

    public partial class login : Form
    {

  

        public login()
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

        private void cb_show_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_show.Checked)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }

       

        private void btn_login_Click(object sender, EventArgs e)
        {
            
            try
            {
              
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT count(*) FROM Registered_Users WHERE username ='" + txtusername.Text + "' AND pasword='" + txtpass.Text + "'", con);
                
                DataTable dt = new DataTable();
                sda.Fill(dt);
              
            


                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (txtusername.Text == "admin" || txtusername.Text == "Admin" && txtpass.Text== "admin" || txtpass.Text == "Admin")
                    {
                        MessageBox.Show("ADMIN DONOT HAVE RIGHT TO LOGIN AS USER");
                                           }
                    else
                    {
                        try
                        {
                            string query = "SELECT * FROM Registered_Users where username = '" + txtusername.Text + "' ";
                            SqlCommand commandDatabase = new SqlCommand(query, con);
                            SqlDataReader reader;
                            reader = commandDatabase.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Program.Id=reader.GetString(7).ToString();
                            Program.username = txtusername.Text;

                            this.Hide();
                            new User_Panel().Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No rows found.");
                            }

                        }

                        catch (System.Exception ex)
                        {

                            MessageBox.Show("some error ocurred during the registration:" + ex.ToString());

                        }
                       
                       
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

        private void btn_signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            new signup().Show();
        }

        private void usernametext_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
        }

        private void passtxt_Click(object sender, EventArgs e)
        {
            txtpass.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login_admin().Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new forgetpassword().Show();
        }
    }
}
