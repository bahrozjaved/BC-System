using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bc_system
{
    public partial class User_Panel : Form
    {
        public User_Panel()
        {
            InitializeComponent();
            customizedesign();
            firstUserControl11.BringToFront();
        }

       private void customizedesign()
        {
            Requestsubmenu.Visible = false;
            paymentsubmenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (Requestsubmenu.Visible ==true)
            {
                Requestsubmenu.Visible = false;
            }
            if (paymentsubmenu.Visible == true)
            {
                paymentsubmenu.Visible = false;
            }
        }
        private void showSubMenu(Panel submenu)
        {
            if (submenu.Visible==false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        private void btn_rq_Click(object sender, EventArgs e)
        {
            showSubMenu(Requestsubmenu);
            
            requestusercontrol1.BringToFront();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            reqControl.BringToFront();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            viewStatus1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showSubMenu(paymentsubmenu);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            paybc1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            paystatus1.BringToFront();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmin_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            label1.Text = Program.username;
            label2.Text = Program.Id;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            firstUserControl11.BringToFront();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            result1.BringToFront();
        }
    }
}
