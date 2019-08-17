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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }
        private void Stock_Load(object sender, EventArgs e)
        {
            this.ActiveControl = dateTimePickerStock;
            comboBoxStatus.SelectedIndex = 0;
            LoadData();
            Search();
        }
        private void dateTimePickerStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxProductCode.Focus();
            }
        }
        private void textBoxProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgview.Rows.Count > 0)
                {
                    textBoxProductCode.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                    textBoxProductName.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                    this.dgview.Visible = false;
                    textBoxQuantity.Focus();
                }
                else
                {
                    this.dgview.Visible = false;
                }
            }
        }
        private void textBoxProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxProductName.Text.Length > 0)
                {
                    textBoxQuantity.Focus();
                }
                else
                {
                    textBoxProductName.Focus();
                }
            }
        }

        bool change = true;
        private void proCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (change)
            {
                change = false;
                textBoxProductCode.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                textBoxProductName.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                this.dgview.Visible = false;
                textBoxQuantity.Focus();
                change = true;
            }
        }
        private void textBoxQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxQuantity.Text.Length > 0)
                {
                    comboBoxStatus.Focus();
                }
                else
                {
                    textBoxQuantity.Focus();
                }
            }
        }
        private void comboBoxStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxStatus.SelectedIndex != -1)
                {
                    buttonAdd.Focus();
                }
                else
                {
                    comboBoxStatus.Focus();
                }
            }
        }
        private void textBoxProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }

        }
        private void ResetRecords()
        {
            dateTimePickerStock.Value = DateTime.Now;
            textBoxProductCode.Clear();
            textBoxProductName.Clear();
            textBoxQuantity.Clear();
            comboBoxStatus.SelectedIndex = -1;
            buttonAdd.Text = "Add";
            dateTimePickerStock.Focus();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetRecords();
        }
        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(textBoxProductCode.Text))
            {
                errorProviderStock.Clear();
                errorProviderStock.SetError(textBoxProductCode, "Product Code Required.");
            }
            else if (string.IsNullOrEmpty(textBoxProductName.Text))
            {
                errorProviderStock.Clear();
                errorProviderStock.SetError(textBoxProductName, "Product Name Required.");
            }
            else if (string.IsNullOrEmpty(textBoxQuantity.Text))
            {
                errorProviderStock.Clear();
                errorProviderStock.SetError(textBoxQuantity, "Quantity Required.");
            }
            else if (comboBoxStatus.SelectedIndex == -1)
            {
                errorProviderStock.Clear();
                errorProviderStock.SetError(comboBoxStatus, "Select Status.");
            }
            else
            {
                errorProviderStock.Clear();
                result = true;
            }
            return result;
        }
        private bool IfProductsExists(SqlConnection con, string productCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 From [Stock] WHERE [ProductCode]='" + productCode + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SqlConnection con = Connection.GetConnection();
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
                if (IfProductsExists(con, textBoxQuantity.Text))
                {
                    sqlQuery = @"UPDATE [Stock] SET [ProductName] = '" + textBoxProductName.Text + "' ,[Quantity] = '" + textBoxQuantity.Text + "',[ProductStatus] = '" + status + "' WHERE [ProductCode] = '" + textBoxProductCode.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO Stock (ProductCode, ProductName, TransDate, Quantity, ProductStatus)
                                 VALUES  ('" + textBoxProductCode.Text + "','" + textBoxProductName.Text + "','" + dateTimePickerStock.Value.ToString("MM/dd/yyyy") + "','" + textBoxQuantity.Text + "','" + status + "')";
                }

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Saved Successfully");
                LoadData();
                ResetRecords();
            }
        }
        public void LoadData()
        {
            SqlConnection con = Connection.GetConnection();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [dbo].[Stock]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewStock.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridViewStock.Rows.Add();
                dataGridViewStock.Rows[n].Cells["dgSno"].Value = n + 1;
                dataGridViewStock.Rows[n].Cells["dgProCode"].Value = item["ProductCode"].ToString();
                dataGridViewStock.Rows[n].Cells["dgProName"].Value = item["ProductName"].ToString();
                dataGridViewStock.Rows[n].Cells["dgQuantity"].Value = float.Parse(item["Quantity"].ToString());
                dataGridViewStock.Rows[n].Cells["dgDate"].Value = Convert.ToDateTime(item["TransDate"].ToString()).ToString("MM/dd/yyyy");
                if ((bool)item["ProductStatus"])
                {
                    dataGridViewStock.Rows[n].Cells["dgStatus"].Value = "Active";
                }
                else
                {
                    dataGridViewStock.Rows[n].Cells["dgStatus"].Value = "Deactive";
                }
            }

            if (dataGridViewStock.Rows.Count > 0)
            {
                label7.Text = dataGridViewStock.Rows.Count.ToString();
                float totQty = 0;
                for (int i = 0; i < dataGridViewStock.Rows.Count; ++i)
                {
                    totQty += float.Parse(dataGridViewStock.Rows[i].Cells["dgQuantity"].Value.ToString());
                    label8.Text = totQty.ToString();
                }
            }
            else
            {
                label7.Text = "0";
                label8.Text = "0";
            }
        }
        private void dataGridViewStock_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            buttonAdd.Text = "Update";
            textBoxProductCode.Text = dataGridViewStock.SelectedRows[0].Cells["dgProCode"].Value.ToString();
            textBoxProductName.Text = dataGridViewStock.SelectedRows[0].Cells["dgProName"].Value.ToString();
            textBoxQuantity.Text = dataGridViewStock.SelectedRows[0].Cells["dgQuantity"].Value.ToString();
            dateTimePickerStock.Text = DateTime.Parse(dataGridViewStock.SelectedRows[0].Cells["dgDate"].Value.ToString()).ToString("MM/dd/yyyy");
            if (dataGridViewStock.SelectedRows[0].Cells["dgStatus"].Value.ToString() == "Active")
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
            DialogResult dialogResult = MessageBox.Show("Sure! You Want to Delete?", "Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
                    SqlConnection con = Connection.GetConnection();
                    var sqlQuery = "";
                    if (IfProductsExists(con, textBoxProductCode.Text))
                    {
                        con.Open();
                        sqlQuery = @"DELETE FROM [Stock] WHERE [ProductCode] = '" + textBoxProductCode.Text + "'";
                        SqlCommand cmd = new SqlCommand(sqlQuery, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record Deleted Successfully...!");
                    }
                    else
                    {
                        MessageBox.Show("Record Not Exists...!");
                    }
                    LoadData();
                    ResetRecords();
                }
            }
        }
        private void textBoxProductCode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxProductCode.Text.Length > 0)
            {
                this.dgview.Visible = true;
                dgview.BringToFront();
                Search(150, 105, 430, 200, "Pro Code,Pro Name", "100,0");
                this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.proCode_MouseDoubleClick);
                SqlConnection con = Connection.GetConnection();
                SqlDataAdapter sda = new SqlDataAdapter("Select Top(10) ProductCode,ProductName From [Stock] WHERE [ProductCode] Like '" + textBoxProductCode.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgview.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dgview.Rows.Add();
                    dgview.Rows[n].Cells[0].Value = row["ProductCode"].ToString();
                    dgview.Rows[n].Cells[1].Value = row["ProductName"].ToString();
                }
            }
            else
            {
                dgview.Visible = false;
            }
        }
        private DataGridView dgview;
        private DataGridViewTextBoxColumn dgviewcol1;
        private DataGridViewTextBoxColumn dgviewcol2;
        void Search()
        {
            dgview = new DataGridView();
            dgviewcol1 = new DataGridViewTextBoxColumn();
            dgviewcol2 = new DataGridViewTextBoxColumn();
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgviewcol1, this.dgviewcol2 });
            this.dgview.Name = "dgview";
            dgview.Visible = false;
            this.dgviewcol1.Visible = false;
            this.dgviewcol2.Visible = false;
            this.dgview.AllowUserToAddRows = false;
            this.dgview.RowHeadersVisible = false;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //this.dgview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgview_KeyDown);

            this.Controls.Add(dgview);
            this.dgview.ReadOnly = true;
            dgview.BringToFront();
        }

        //Two Column
        void Search(int LX, int LY, int DW, int DH, string ColName, String ColSize)
        {
            this.dgview.Location = new System.Drawing.Point(LX, LY);
            this.dgview.Size = new System.Drawing.Size(DW, DH);

            string[] ClSize = ColSize.Split(',');
            //Size
            for (int i = 0; i < ClSize.Length; i++)
            {
                if (int.Parse(ClSize[i]) != 0)
                {
                    dgview.Columns[i].Width = int.Parse(ClSize[i]);
                }
                else
                {
                    dgview.Columns[i].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            //Name 
            string[] ClName = ColName.Split(',');

            for (int i = 0; i < ClName.Length; i++)
            {
                this.dgview.Columns[i].HeaderText = ClName[i];
                this.dgview.Columns[i].Visible = true;
            }
        }
    }
}