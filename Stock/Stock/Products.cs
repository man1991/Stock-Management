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

namespace Stock
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            comboBoxStatus.SelectedIndex = 0;
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=ADMINRG-TSF729J\\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            SqlConnection con = Connection.GetConnection();
            //Insert Logic
            con.Open();
            bool status = false;
            if (comboBoxStatus.SelectedIndex == 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            var sqlQuery = "";

            if (IfProductExists(con, textBoxProductCode.Text))
            {
                //@ is used as it support multi lines
                sqlQuery = @"UPDATE [Products]
                             SET [ProductName] = '" + textBoxlProductName.Text + "', [ProductStatus] = '" + status + "' WHERE [ProductCode] = '" + textBoxProductCode.Text +"'";
            }
            else
            {
                sqlQuery = @"INSERT INTO [dbo].[Products] ([ProductCode], [ProductName], [ProductStatus]) 
                             VALUES ('" + textBoxProductCode.Text + "', '" + textBoxlProductName.Text + "', '" + status + "')";
            }

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();

            //Reading Data
            LoadData();
        }
        private bool IfProductExists(SqlConnection con, string productCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT 1 FROM [dbo].[Products] WHERE [ProductCode] = '"+ productCode +"' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void LoadData()
        {
            //SqlConnection con = new SqlConnection("Data Source=ADMINRG-TSF729J\\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            SqlConnection con = Connection.GetConnection();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [dbo].[Products]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewProducts.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridViewProducts.Rows.Add();
                dataGridViewProducts.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridViewProducts.Rows[n].Cells[1].Value = item["ProductName"].ToString();

                if ((bool)item["ProductStatus"])
                {
                    dataGridViewProducts.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridViewProducts.Rows[n].Cells[2].Value = "Deactive";
                }
            }
        }
        private void dataGridViewProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxProductCode.Text = dataGridViewProducts.SelectedRows[0].Cells[0].Value.ToString();
            textBoxlProductName.Text = dataGridViewProducts.SelectedRows[0].Cells[1].Value.ToString();

            if (dataGridViewProducts.SelectedRows[0].Cells[2].Value.ToString() == "Active")
            {
                comboBoxStatus.SelectedIndex = 0;
            }
            else
            {
                comboBoxStatus.SelectedIndex = 1;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=ADMINRG-TSF729J\\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            SqlConnection con = Connection.GetConnection();
            var sqlQuery = "";

            if (IfProductExists(con, textBoxProductCode.Text))
            {
                //@ is used as it support multi lines
                con.Open();
                sqlQuery = @"DELETE FROM [Products] WHERE [ProductCode] = '" + textBoxProductCode.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Record Does Not Exists...");
            }

            //Reading Data
            LoadData();
        }
    }
}
