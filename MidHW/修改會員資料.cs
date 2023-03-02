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
    public partial class 修改會員資料 : Form
    {

        SqlConnectionStringBuilder scsb;
        string strDBConnectString = "";
        List<int> SearchIDs = new List<int>();


        public 修改會員資料()
        {
            InitializeComponent();
        }
        public 修改會員資料(string strPhone)
        {
            InitializeComponent();
            textBox會員帳號.Text = strPhone;
        }
        private void 修改會員資料_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"."; //伺服器名稱
            scsb.InitialCatalog = "MyHW"; //資料庫名稱
            scsb.IntegratedSecurity = true; //windows驗證
            strDBConnectString = scsb.ToString();


        }
        void 清空欄位()
        {
            會員ID.Text = "";
            textBox會員帳號.Clear();
            textBox會員密碼.Clear();
            textBox會員姓名.Clear();
            textBoxEmail.Clear();
            dtp生日.Value = DateTime.Now;
        }

        private void btn帳號搜尋_Click(object sender, EventArgs e)
        {
            if (textBox會員帳號.Text != "")
            {
                SqlConnection con = new SqlConnection(strDBConnectString);
                con.Open();
                string strSQL = "select * from persons where 帳號_電話 = @SearchPhone;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchPhone", "" + textBox會員帳號.Text + "");
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    會員ID.Text = reader["ID"].ToString();
                    textBox會員帳號.Text = reader["帳號_電話"].ToString();
                    textBox會員密碼.Text = reader["密碼"].ToString();
                    textBox會員姓名.Text = reader["姓名"].ToString();
                    textBoxEmail.Text = reader["Email"].ToString();
                    dtp生日.Value = Convert.ToDateTime(reader["生日"]);
                }
                else
                {
                    MessageBox.Show("查無此人");
                    清空欄位();
                }
                reader.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入電話搜尋");
            }
        }


        private void btn清空欄位_Click(object sender, EventArgs e)
        {
            清空欄位();
        }

        private void btn會員刪除_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(會員ID.Text, out intID);

            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(strDBConnectString);
                con.Open();
                string strSQL = "delete from persons where ID= @DeleteID;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@DeleteID", intID);

                int rows = cmd.ExecuteNonQuery();
                con.Close();
                清空欄位();
                MessageBox.Show("已刪除該會員資料");
            }
        }

        private void btn會員修改_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(會員ID.Text, out intID);

            if ((intID > 0) && (textBox會員帳號.Text != "") && (textBox會員密碼.Text != ""))
            {
                SqlConnection con = new SqlConnection(strDBConnectString);
                con.Open();
                string strSQL = "update persons set 帳號_電話=@NewPhone, 密碼=@NewPassword, 姓名=@NewName, Email=@NewEmail, 生日=@NewBirth where ID = @SearchID;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewPhone", textBox會員帳號.Text);
                cmd.Parameters.AddWithValue("@NewPassword", textBox會員密碼.Text);
                cmd.Parameters.AddWithValue("@NewName", textBox會員姓名.Text);
                cmd.Parameters.AddWithValue("@NewEmail", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@NewBirth", dtp生日.Value);

                cmd.Parameters.AddWithValue("@SearchID", intID);

                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("已更新該會員資料");
                清空欄位();
            }
        }




        

        private void 修改會員資料_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Application.ExitThread();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            { textBox會員密碼.PasswordChar = default(char); }
            else
            { textBox會員密碼.PasswordChar = '*'; }
        }
    }
}
