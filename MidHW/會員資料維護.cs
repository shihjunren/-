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

namespace MidHW
{
    public partial class 會員資料維護 : Form
    {
        SqlConnectionStringBuilder scsb;
        string strDBConnectString = "";
        List<int> SearchIDs = new List<int>();
        public 會員資料維護()
        {
            InitializeComponent();
        }

        private void 會員資料維護_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.ExitThread();
        }

        private void 會員資料維護_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"."; //伺服器名稱
            scsb.InitialCatalog = "MyHW"; //資料庫名稱
            scsb.IntegratedSecurity = true;
            strDBConnectString = scsb.ToString();
            產生會員資料列表();
        }

        void 產生會員資料列表()
        {
            SqlConnection con = new SqlConnection(strDBConnectString);
            con.Open();
            //string strSQL = "select * from persons;";
            string strSQL = "select id as ID, 帳號_電話, 姓名, Email, 生日 from persons";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dgv會員資料列表.DataSource = dt;
            }
            reader.Close();
            con.Close();
        }

        
    }
}
