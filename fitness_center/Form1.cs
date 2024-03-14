using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.Sql;
using System.Data.SqlClient;

namespace fitness_center
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=WIN-PB603G4B235;Initial Catalog=diplom;Integrated Security=True");

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit(); //выход из приложения
        }

        private void button1_Click(object sender, EventArgs e)
        {
           con.Open();

            SqlCommand cmd = new SqlCommand("select * from users2 inner join role on users2.userrole = role.roleid where username = @username and password =  @password", con);
            cmd.Parameters.AddWithValue("@username",textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dataTable= new DataTable();
            sda.Fill(dataTable);
            if(dataTable.Rows.Count>0)
            {
                string usertype = dataTable.Rows[0][5].ToString();
                if(usertype =="admin")
                {
                    Admin AdminForm = new Admin();
                    AdminForm.Show();
                }
            }



            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel3.BackColor = SystemColors.Control;
            textBox1.BackColor = SystemColors.Control;

   
        }

        private void mouse_down(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar= false;
        }

        private void mouse_up(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
