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
            if (Validation())
            {
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
                             SET [ProductName] = '" + textBoxProductName.Text + "', [ProductStatus] = '" + status + "' WHERE [ProductCode] = '" + textBoxProductCode.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [dbo].[Products] ([ProductCode], [ProductName], [ProductStatus]) 
                             VALUES ('" + textBoxProductCode.Text + "', '" + textBoxProductName.Text + "', '" + status + "')";
                }

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();

                //Reading Data
                LoadData();
                ResetRecords(); 
            }
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
            buttonAdd.Text = "Update";
            textBoxProductCode.Text = dataGridViewProducts.SelectedRows[0].Cells[0].Value.ToString();
            textBoxProductName.Text = dataGridViewProducts.SelectedRows[0].Cells[1].Value.ToString();

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
            DialogResult dialogResult = MessageBox.Show("Sure! You Want To Delete?","Message",MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
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
                    ResetRecords();
                }
            }
        }

        //to clear records and updating Add button
        private void ResetRecords()
        {
            textBoxProductCode.Clear();
            textBoxProductName.Clear();
            comboBoxStatus.SelectedIndex = -1;
            buttonAdd.Text = "Add";
            textBoxProductCode.Focus();
        }

        //To Clear values if don't want to add or update
        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetRecords();
        }

        //method to prevent empty record insert
        private bool Validation()
        {
            bool result = false;
            if(string.IsNullOrEmpty(textBoxProductCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxProductCode, "Product Code Required.");
            }
            else if (string.IsNullOrEmpty(textBoxProductName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxProductName, "Product Name Required.");
            }
            else if (comboBoxStatus.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(comboBoxStatus, "Select Status.");
            }
            else
            {
                return true;
            }
            return result;
        }
    }
}
