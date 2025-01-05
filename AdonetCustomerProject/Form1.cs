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

namespace AdonetCustomerProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-0OSOKF2\\SQLEXPRESS;initial " +
           "catalog=DbCustomer;integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {
        
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * From TblCity", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("insert into TblCity" +
                "(CityName, CityCountry) values (@cityName, @cityCountry)", sqlConnection);
            command.Parameters.AddWithValue("@cityName", textBox2.Text);
            command.Parameters.AddWithValue("@cityCountry", textBox3.Text);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Şehir başarılı bir şekilde eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Delete From TblCity Where CityId=@cityId", sqlConnection);
            command.Parameters.AddWithValue("@cityId", textBox1.Text);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Silme işlemi başarılı!!","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Update TblCity Set CityName=@cityName,CityCountry=@cityCountry Where CityId=@cityId", sqlConnection);
            command.Parameters.AddWithValue("@cityId", textBox1.Text);
            command.Parameters.AddWithValue("@cityName", textBox2.Text);
            command.Parameters.AddWithValue("@cityCountry", textBox3.Text);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Başarılı şekilde güncellendi!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * From TblCity Where CityName=@cityName", sqlConnection);
            command.Parameters.AddWithValue("@cityName", textBox2.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
    }
}
