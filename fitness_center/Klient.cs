using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fitness_center
{
    public partial class Klient : Form
    {
        public Klient()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=WIN-PB603G4B235;Initial Catalog=diplom;Integrated Security=True");




        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.Client_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string status = "";
            if (radioButton1.Checked = true)
            {
                status = radioButton1.Text;
            }
            else
            {
                status = radioButton2.Text;
            }
            SqlCommand cmd = new SqlCommand("exec dbo.Client_Insert '" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + status + "','" + textBox5.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "'", con);
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Saved");
            LoadAllRecords();
            EmptyText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string status = "";
            if (radioButton1.Checked = true)
            {
                status = radioButton1.Text;
            }
            else
            {
                status = radioButton2.Text;
            }
            SqlCommand cmd = new SqlCommand("exec dbo.Client_Update '" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + status + "','" + textBox5.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Update");
            LoadAllRecords();
            EmptyText();
        }

        private void Klient_Load(object sender, EventArgs e)
        {
            LoadAllRecords();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if (MessageBox.Show("Are you confirm to delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("exec dbo.Client_Delete '" + int.Parse(textBox1.Text) + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Update");
                LoadAllRecords();
                EmptyText(); 
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("exec dbo.Client_Search '" + textBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            EmptyText();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        void EmptyText()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            dateTimePicker1.Text = string.Empty;
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin AdminForm = new Admin();
            AdminForm.Show();
        }   
    }

}
