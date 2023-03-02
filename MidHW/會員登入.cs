using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidHW
{
    public partial class 會員登入 : Form
    {
        bool is認證成功 = false;
        SqlConnectionStringBuilder scsb;
        string strDBConnectString = "";
        List<int> SearchIDs = new List<int>();
        public 會員登入()
        {
            InitializeComponent();
        }
        void 清空欄位() 
        {
            textBox帳號.Clear();
            textBox密碼.Clear();
        }
        private void 會員登入_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"."; //伺服器名稱
            scsb.InitialCatalog = "MyHW"; //資料庫名稱
            scsb.IntegratedSecurity = true; //windows驗證
            strDBConnectString = scsb.ToString();

           

        }
       


        

        private void 會員登入_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        

        private void btn登入_Click(object sender, EventArgs e)
        {
            
            if ((textBox帳號.Text != "") && (textBox密碼.Text != ""))
            {

                SqlConnection con = new SqlConnection(strDBConnectString);
                con.Open();
                string str帳號 = textBox帳號.Text;
                string str密碼 = textBox密碼.Text;
                string strSQL = "select * from persons where 帳號_電話 = @SearchPhone and 密碼 = @SearchPassword ;";
                
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchPhone", "" + textBox帳號.Text + "");
                cmd.Parameters.AddWithValue("@SearchPassword", "" + textBox密碼.Text + "");
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    int ID = (int)reader["ID"];
                    string 姓名 = reader["姓名"].ToString();

                    is認證成功 = true;
                    MessageBox.Show("登入成功"); 
                    this.Visible = false;

                    FormList NewList = new FormList(textBox帳號.Text , ID ,姓名);
                    NewList.ShowDialog();
                   


                    //this.Visible = false;
                    //訂單 myLoginForm = new 訂單(textBox帳號.Text, ID, 姓名);
                    //if (myLoginForm.ShowDialog() == DialogResult.OK)
                    //{ 
                    //    this.textBox帳號.Text = str帳號;                         
                    //}

                }

                else
                {
                    MessageBox.Show("登入失敗");
                    清空欄位();
                }
            }
            else
            {
                MessageBox.Show("請輸入帳號密碼");
                清空欄位();
            }
        }

       

        private void 會員登入_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            FormList Home = new FormList();
            Home.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormList Home = new FormList();
            Home.ShowDialog();
        }
    }
}
