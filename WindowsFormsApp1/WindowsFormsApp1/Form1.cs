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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
         
        public void clearData()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AT4S4F9V;Initial Catalog=Training;Integrated Security=True");
       private BindingSource bs = new BindingSource();

        public void display()
        {
            SqlDataAdapter sqlAdapter = new SqlDataAdapter("Select * from library", con);
            DataTable dt = new DataTable();
            sqlAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
        }

        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;  
        


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into library values(@bookid,@bookname,@studentname,@bookprice)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@bookid", textBox1.Text);
            cmd.Parameters.AddWithValue("@bookname", textBox2.Text);
            cmd.Parameters.AddWithValue("@studentname", textBox3.Text);
            cmd.Parameters.AddWithValue("@bookprice", textBox4.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            clearData();
            MessageBox.Show("Book assigned to student successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AT4S4F9V;Initial Catalog=Training;Integrated Security=True"))
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from library", con);
                /* SqlCommand cm = new SqlCommand("select * from library", con);
                  DataTable dt = new DataTable();

                  con.Open();
                  SqlDataReader rdr = cm.ExecuteReader();

                  dt.Load(rdr);
                  con.Close();
                  dataGridView1.DataSource = dt;
                  dataGridView1.Visible = true;*/
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                dataGridView1.Visible = true;
               // display();
                MessageBox.Show("all records are feteched");
            }
        }

        private void button3_Click(object sender, EventArgs e)

        {

            if (textBox3.Text == null)
            {
                MessageBox.Show("please Enter the name of student");
            }
            else { 
            SqlCommand c = new SqlCommand("delete from library where studentname=@studentname", con);
             c.CommandType = CommandType.Text;
             c.Parameters.AddWithValue("@studentname", textBox3.Text);
             con.Open();
             c.ExecuteNonQuery();
             con.Close();
             clearData();
             MessageBox.Show("Book returned by student and book deleted");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand s = new SqlCommand("update library set bookid=@bookid,bookname=@bookname,studentname=@studentname,bookprice=@bookprice where studentname=@studentname", con);
            s.CommandType = CommandType.Text;
            s.Parameters.AddWithValue("@bookid", textBox1.Text);
            s.Parameters.AddWithValue("@bookname", textBox2.Text);
            s.Parameters.AddWithValue("@studentname", textBox3.Text);
            s.Parameters.AddWithValue("@bookprice", textBox4.Text);
            con.Open();
            s.ExecuteNonQuery();
            con.Close();
            clearData();
            MessageBox.Show("book updated successfully");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
