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

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //To-DO: Check UserName and Password
            //SqlConnection con = new SqlConnection("Data Source=ADMINRG-TSF729J\\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            SqlConnection con = Connection.GetConnection();

            //SqlDataAdapter automatically opens and closes a connection
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM [dbo].[Login] 
                                                    Where [UserName] = '"+ txtUserName.Text +"' and [Passsword] = '"+ txtPassword.Text +"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count == 1)
            {
                this.Hide();//this will hide Login Form

                //This will open Stock Main Form
                StockMain main = new StockMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid UserName and Password..!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnClear_Click(sender, e);
            }

        }
    }
}
