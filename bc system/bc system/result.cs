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
    public partial class result : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-AEI4R09;Initial Catalog=committee;Integrated Security=True");
        public result()
        {
            InitializeComponent();
        }

        public void load()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            string sql;
            sql = "select * from Result ";
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


        private void button1_Click(object sender, EventArgs e)
        {
            load();
        }
    }
}