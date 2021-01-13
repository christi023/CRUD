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

namespace CRUD
{
    public partial class Form1 : Form
    {

        // database connection string
        string connectionString = "Data Source=DESKTOP-V0HUUUF;Initial Catalog=Crud;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // call method to bind in the form
            BindData();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Add / Insert button
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            // open connection
            connection.Open();
            SqlCommand command = new SqlCommand("insert into ProductInfo values ('"+int.Parse(textBox11.Text) + "', '" + textBox5.Text + "', '" + textBox9.Text + "', '" + comboBox1.Text + "', getdate( ), getdate())", connection);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted!");
            // close connection
            connection.Close();

            // calling method to bind
            BindData();
           
        }
        // show data in the grid window
        void BindData()
        {SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("select * from ProductInfo", connection);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        // Update button
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("update ProductInfo set ItemName = '"+textBox5.Text+"', Design = '" + textBox9.Text + "', Color = '"+comboBox1.Text + "',UpdateDate = '"+DateTime.Parse(dateTimePicker1.Text)+"' where ProductID = '" + int.Parse(textBox11.Text) + "' " , connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Updated!");
            BindData();

        }

        // Delete button
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("delete ProductInfo where ProductID = '" + int.Parse(textBox11.Text) + "'", connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Successfully Deleted!");
                BindData();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("select * from ProductInfo where ProductID = '"+int.Parse(textBox11.Text)+"' ", connection);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
