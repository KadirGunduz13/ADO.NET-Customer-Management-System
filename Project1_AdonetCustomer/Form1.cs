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

namespace Project1_AdonetCustomer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // SQL Server bağlantısı oluşturma
        SqlConnection sqlConnection = new SqlConnection("Server=KADIR13\\SQLEXPRESS02;initial catalog=DBCustomer;integrated security=true");

        private void btnList_Click(object sender, EventArgs e)
        {
            // SQL Server bağlantısını açma
            sqlConnection.Open();

            // SQL sorgusunu oluşturma
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TblCity", sqlConnection);

            // SQL sorgusunu çalıştırma ve sonuçları DataTable'a doldurma
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            // DataTable (Sanal bir tablo) oluşturma ve verileri doldurma
            DataTable dataTable = new DataTable();

            // DataAdapter ile verileri DataTable'a doldurma
            sqlDataAdapter.Fill(dataTable);

            // DataGridView'e verileri bağlama
            dataGridView1.DataSource = dataTable;

            // SQL bağlantısını kapatma
            sqlConnection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // SQL Server bağlantısını açma
            sqlConnection.Open();

            // SQL sorgusunu oluşturma
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblCity (CityName,CityCountry) VALUES (@cityName,@cityCountry)", sqlConnection);

            // Parametreleri ekleme
            sqlCommand.Parameters.AddWithValue("@cityName", txtCityName.Text);
            sqlCommand.Parameters.AddWithValue("@cityCountry", txtCityCountry.Text);

            // SQL sorgusunu çalıştırma
            sqlCommand.ExecuteNonQuery();

            // SQL bağlantısını kapatma
            sqlConnection.Close();

            // Mesaj kutusu ile kullanıcıya bilgi verme
            MessageBox.Show("Şehir başarıyla eklendi!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // SQL Server bağlantısını açma
            sqlConnection.Open();

            // SQL sorgusunu oluşturma
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM TblCity WHERE CityID=@cityID", sqlConnection);

            // Parametreleri ekleme
            sqlCommand.Parameters.AddWithValue("@cityID", txtCityId.Text);

            // SQL sorgusunu çalıştırma
            sqlCommand.ExecuteNonQuery();

            // SQL bağlantısını kapatma
            sqlConnection.Close();

            // Mesaj kutusu ile kullanıcıya bilgi verme
            MessageBox.Show("Şehir başarıyla silindi!","Uyarı!",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // SQL Server bağlantısını açma
            sqlConnection.Open();

            // SQL sorgusunu oluşturma
            SqlCommand sqlCommand = new SqlCommand("UPDATE TblCity SET CityName = @cityName, CityCountry = @cityCountry WHERE CityID = @cityID", sqlConnection);

            // Parametreleri ekleme
            sqlCommand.Parameters.AddWithValue("@cityName", txtCityName.Text);
            sqlCommand.Parameters.AddWithValue("@cityCountry", txtCityCountry.Text);
            sqlCommand.Parameters.AddWithValue("@cityID", txtCityId.Text);

            // SQL sorgusunu çalıştırma
            sqlCommand.ExecuteNonQuery();

            // SQL bağlantısını kapatma
            sqlConnection.Close();

            // Mesaj kutusu ile kullanıcıya bilgi verme
            MessageBox.Show("Şehir başarıyla güncellendi!","Uyarı!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // SQL Server bağlantısını açma
            sqlConnection.Open();

            // SQL sorgusunu oluşturma
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TblCity WHERE CityName=@cityName", sqlConnection);

            // Parametreleri ekleme
            sqlCommand.Parameters.AddWithValue("@cityName", txtCityName.Text);

            // SQL sorgusunu çalıştırma ve sonuçları DataTable'a doldurma
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            // DataTable (Sanal bir tablo) oluşturma ve verileri doldurma
            DataTable dataTable = new DataTable();

            // DataAdapter ile verileri DataTable'a doldurma
            sqlDataAdapter.Fill(dataTable);

            // DataGridView'e verileri bağlama
            dataGridView1.DataSource = dataTable;

            // SQL bağlantısını kapatma
            sqlConnection.Close();


        }
    }
}
