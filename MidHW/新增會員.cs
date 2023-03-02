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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MidHW
{
    public partial class 新增會員 : Form
    {
        public 新增會員()
        {
            InitializeComponent();
        }

        SqlConnectionStringBuilder scsb;
        string strDBConnectString = "";
        List<int> SearchIDs = new List<int>(); //進階搜尋結果

        private void 新增會員_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"."; //伺服器名稱
            scsb.InitialCatalog = "MyHW"; //資料庫名稱
            scsb.IntegratedSecurity = true; //windows驗證
            strDBConnectString = scsb.ToString();
        }

        private void btn加入會員_Click(object sender, EventArgs e)
        {
            if ((textBox會員帳號.Text != "") && (textBox密碼.Text != ""))
            {
                SqlConnection con1 = new SqlConnection(strDBConnectString);
                con1.Open();


                string str帳號 = textBox會員帳號.Text;
                
                string strSQL1 = "select * from persons where 帳號_電話 = @SearchPhone ;";

                SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                cmd1.Parameters.AddWithValue("@SearchPhone", "" + textBox會員帳號.Text + "");
               
                SqlDataReader reader = cmd1.ExecuteReader();


                if (reader.Read() ==true)
                {
                    
                    MessageBox.Show("此帳號已使用");
                    con1.Close();
                    清空欄位();
                }

                else
                {
                 SqlConnection con2 = new SqlConnection(strDBConnectString);
                 con2.Open();

                string strSQL2 = "insert into persons values (@NewPhone,@NewPassword,@NewName,@NewEmail,@NewBirth);";
                SqlCommand cmd2 = new SqlCommand(strSQL2, con2);
                cmd2.Parameters.AddWithValue("@NewPhone", textBox會員帳號.Text);
                cmd2.Parameters.AddWithValue("@NewPassword", textBox密碼.Text);
                cmd2.Parameters.AddWithValue("@NewName", textBox會員姓名.Text);
                cmd2.Parameters.AddWithValue("@NewEmail", textBoxEmail.Text);

                cmd2.Parameters.AddWithValue("@NewBirth", dtp生日.Value);
               

                int rows = cmd2.ExecuteNonQuery();
                    con1.Close();
                    con2.Close();
                MessageBox.Show("會員資料已更新");
                清空欄位();
                }

        }
        }

       

        void 清空欄位()
        {
            textBox會員帳號.Clear();
            textBox密碼.Clear();
            textBox會員姓名.Clear();
            textBoxEmail.Clear();
            dtp生日.Value = DateTime.Now;
            
        }

        private void btn清空欄位_Click(object sender, EventArgs e)
        {
            清空欄位();
        }

       
        private void 新增會員_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            { textBox密碼.PasswordChar = default(char); }
            else
            { textBox密碼.PasswordChar = '*'; }
        }
    }
}
