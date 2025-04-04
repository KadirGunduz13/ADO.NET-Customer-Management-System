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
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
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
            SqlCommand sqlCommand = new SqlCommand("SELECT CustomerID, CustomerName, CustomerSurname, CustomerBalance, CustomerStatus, CityName FROM TblCustomer INNER JOIN TblCity ON TblCity.CityID = TblCustomer.CustomerCity", sqlConnection);

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

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            // SQL Server bağlantısını açma
            sqlConnection.Open();

            // SQL sorgusunu oluşturma
            SqlCommand sqlCommand = new SqlCommand("EXEC CustomerListWithCity", sqlConnection);

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

        private void FrmCustomer_Load(object sender, EventArgs e)
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

            // ComboBox'a verileri bağlama
            cmbCity.ValueMember = "CityID";
            cmbCity.DisplayMember = "CityName";

            // ComboBox'a verileri doldurma
            cmbCity.DataSource = dataTable;

            // SQL bağlantısını kapatma
            sqlConnection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblCustomer (CustomerName, CustomerSurname, CustomerBalance, CustomerStatus, CustomerCity) VALUES (@customerName, @customerSurname, @customerBalance, @customerStatus, @customerCity)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            sqlCommand.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            sqlCommand.Parameters.AddWithValue("@customerBalance", txtBalance.Text);
            sqlCommand.Parameters.AddWithValue("@customerCity", cmbCity.SelectedValue);

            if (rdbActive.Checked)
            {
                sqlCommand.Parameters.AddWithValue("@customerStatus", true);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@customerStatus", false);
            }

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            MessageBox.Show("Müşteri başarıyla eklendi!");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("DELETE FROM TblCustomer WHERE CustomerID = @customerID", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@customerID", txtCustomerId.Text);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            MessageBox.Show("Müşteri başarıyla silindi!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("UPDATE TblCustomer SET CustomerName = @customerName, CustomerSurname = @customerSurname, CustomerBalance = @customerBalance, CustomerStatus = @customerStatus, CustomerCity = @customerCity WHERE CustomerID = @customerID", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@customerID", txtCustomerId.Text);
            sqlCommand.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            sqlCommand.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            sqlCommand.Parameters.AddWithValue("@customerBalance", txtBalance.Text);
            sqlCommand.Parameters.AddWithValue("@customerCity", cmbCity.SelectedValue);

            if (rdbActive.Checked)
            {
                sqlCommand.Parameters.AddWithValue("@customerStatus", true);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@customerStatus", false);
            }

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            MessageBox.Show("Müşteri başarıyla güncellendi!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // SQL Server bağlantısını açma
            sqlConnection.Open();

            // SQL sorgusunu oluşturma
            SqlCommand sqlCommand = new SqlCommand("SELECT CustomerID, CustomerName, CustomerSurname, CustomerBalance, CustomerStatus, CityName FROM TblCustomer INNER JOIN TblCity ON TblCity.CityID = TblCustomer.CustomerCity WHERE CustomerName = @customerName", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@customerName", txtCustomerName.Text);

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
