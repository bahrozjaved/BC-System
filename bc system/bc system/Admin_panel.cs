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
    public partial class Admin_panel : Form
    {
        public Admin_panel()
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
            if (Requestsubmenu.Visible == true)
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
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        private void Admin_panel_Load(object sender, EventArgs e)
        {

        }

        private void btn_rq_Click(object sender, EventArgs e)
        {
            showSubMenu(Requestsubmenu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            acceptRequest1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            addBc1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showSubMenu(paymentsubmenu);



        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            viewpayment1.BringToFront();

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
          

            System.Windows.Forms.Application.Exit();
        }

        private void btnmin_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            firstUserControl11.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login_admin().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            adminresult1.BringToFront();
        }
    }
}
