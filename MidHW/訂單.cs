using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MidHW
{
    public partial class 訂單 : Form
    {
        SqlConnectionStringBuilder scsb;      //建立資料庫連線字串
        string strDBconnectString = "";
        public int ID = 0;
        List<string> 辣度 = new List<string>();
        

        int 所選商品總價 = 0;
        
        string 所選商品辣度 = "";
        bool is外送 = false;
        string 訂購電話 = "";
        

        int 雞排數量 = 0;
        int 雞排小計 = 0;
        int 鹹酥雞數量 = 0;
        int 鹹酥雞小計 = 0;
        int 雞心數量 = 0;
        int 雞心小計 = 0;
        int 雞胗數量 = 0;
        int 雞胗小計 = 0;
        int 雞屁股數量 = 0;
        int 雞屁股小計 = 0;
        int 甜不辣數量 = 0;
        int 甜不辣小計 = 0;
        int 薯條數量 = 0;
        int 薯條小計 = 0;
        int 蔬菜數量 = 0;
        int 蔬菜小計 = 0;

        public 訂單()
        {
            InitializeComponent();
        }
        public 訂單(string strPhone)
        {
            InitializeComponent();
            textBox訂購電話.Text=strPhone;
        }


        private void 訂單_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";         //伺服器名稱  @表示忽略特殊符號
            scsb.InitialCatalog = "MyHW"; //資料庫名稱
            scsb.IntegratedSecurity = true; //windows 驗證 (整合驗證)
            strDBconnectString = scsb.ToString();

            辣度.Add("不辣");
            辣度.Add("微辣");
            辣度.Add("小辣");
            辣度.Add("中辣");
            辣度.Add("大辣");
            辣度.Add("地獄辣");



            foreach (string item in 辣度)
            {
                comboBox辣度.Items.Add(item);
            }
            comboBox辣度.SelectedIndex = 0;
            所選商品辣度 = comboBox辣度.SelectedItem.ToString();
            is外送 = false;
            
            check甜不辣.Checked = false;
            check蔬菜.Checked = false;
            check薯條.Checked = false;
            check雞屁股.Checked = false;
            check雞心.Checked = false;
            check雞排.Checked = false;
            check雞胗.Checked = false;
            check鹹酥雞.Checked = false;
             
            textBox雞排.Text = "0";
            雞排數量 = 0;
            textBox鹹酥雞.Text = "0";
            鹹酥雞數量 = 0;
            textBox雞心.Text = "0";
            雞心數量 = 0;
            textBox雞胗.Text = "0";
            雞胗數量 = 0;
            textBox雞屁股.Text = "0";
            雞屁股數量 = 0;
            textBox甜不辣.Text = "0";
            甜不辣數量 = 0;
            textBox薯條.Text = "0";
            薯條數量 = 0;
            textBox蔬菜.Text = "0";
            蔬菜數量 = 0;
        }
        void 清空() 
        {
            lab總金額.Text = "0000元";
            
            textBox鹹酥雞.Text = "";
            textBox甜不辣.Text = "";
            textBox蔬菜.Text = "";
            textBox薯條.Text = "";
            textBox雞屁股.Text = "";
            textBox雞心.Text = "";
            textBox雞排.Text = "";
            textBox雞胗.Text = "";            
            comboBox辣度.Text = "";   
            check雞排.Checked = false;
            check鹹酥雞.Checked = false;
            check雞胗.Checked = false;
            check雞心.Checked = false;
            check雞屁股.Checked = false;
            check薯條.Checked = false;
            check蔬菜.Checked = false;
            check甜不辣.Checked = false;
        }
        void 總價() 
        {
            if(check雞排.Checked==true ||check甜不辣.Checked==true||check蔬菜.Checked==true||check薯條.Checked==true||check雞屁股.Checked==true||check雞心.Checked==true||check雞胗.Checked==true||check鹹酥雞.Checked==true)
            { 
                所選商品總價 = 雞排小計 + 鹹酥雞小計 + 雞心小計 + 雞胗小計 + 雞屁股小計 + 甜不辣小計 + 薯條小計 + 蔬菜小計; 
                lab總金額.Text =$"{ 所選商品總價.ToString()}元";

            }
            
        }
        void 小計1() 
        {
            if (check雞排.Checked == true) 
            {                
                雞排小計 = 60 * 雞排數量;
                lab雞排.Text = $"{雞排小計.ToString()}元";

            }
        }
        void 小計2() 
        {
            if (check鹹酥雞.Checked == true)
            {
                
                鹹酥雞小計 = 50 * 鹹酥雞數量;
                lab鹹酥雞.Text = $"{鹹酥雞小計.ToString()}元";
            }
        }
        void 小計3() 
        {
            if (check雞心.Checked == true)
            {
                
                雞心小計 = 30 * 雞心數量;
                lab雞心.Text = $"{雞心小計.ToString()}元";
            }
        }
        void 小計4() 
        {
            if (check雞胗.Checked == true)
            {
               
                雞胗小計 = 30 * 雞胗數量;
                lab雞胗.Text = $"{雞胗小計.ToString()}元";
            }
        }
        void 小計5() 
        {
            if (check雞屁股.Checked == true)
            {
               
                雞屁股小計 = 30 * 雞屁股數量;
                lab雞屁股.Text = $"{雞屁股小計.ToString()}元";
            }
        }
        void 小計6() 
        {
            if (check甜不辣.Checked == true)
            {
                甜不辣小計 = 30 * 甜不辣數量;
                lab甜不辣.Text = $"{甜不辣小計.ToString()}元";
            }
        }
        void 小計7() 
        {
            if (check蔬菜.Checked == true)
            {
                蔬菜小計 = 30 * 蔬菜數量;
                lab蔬菜.Text = $"{蔬菜小計.ToString()}元";
            }
        }
        void 小計8() {
            if (check薯條.Checked == true)
            {
                薯條小計 = 30 * 薯條數量;
                lab薯條.Text = $"{薯條小計.ToString()}元";
            }
        }


        

        private void btn送出訂單_Click(object sender, EventArgs e)
        {
            if (textBox訂購電話.Text != "" )
            {
                訂購電話 = textBox訂購電話.Text;
                
                SqlConnection con = new SqlConnection(strDBconnectString);
                con.Open();
                string strSQL = "insert into OD values(@NewPhone, @NewA, @NewB, @NewC, @NewD, @NewE, @NewF, @NewG, @NewH, @NewSpicy, @NewToGo, @NewPrice, @NewDate, @NewState)";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewPhone", 訂購電話);
                //int m雞排 =Convert.ToInt32(textBox雞排.Text);
                //int m鹹酥雞 = Convert.ToInt32(textBox鹹酥雞.Text);
                //int m雞心 = Convert.ToInt32(textBox雞心.Text);
                //int m雞胗 = Convert.ToInt32(textBox雞胗.Text);
                //int m雞屁股 = Convert.ToInt32(textBox雞屁股.Text);
                //int m甜不辣 = Convert.ToInt32(textBox甜不辣.Text);
                //int m薯條 = Convert.ToInt32(textBox薯條.Text);
                //int m蔬菜 = Convert.ToInt32(textBox蔬菜.Text);
                //cmd.Parameters.AddWithValue("@NewA", m雞排);
                //cmd.Parameters.AddWithValue("@NewB", m鹹酥雞);
                //cmd.Parameters.AddWithValue("@NewC", m雞心);
                //cmd.Parameters.AddWithValue("@NewD", m雞胗);
                //cmd.Parameters.AddWithValue("@NewE", m雞屁股);
                //cmd.Parameters.AddWithValue("@NewF", m甜不辣);
                //cmd.Parameters.AddWithValue("@NewG", m薯條);
                //cmd.Parameters.AddWithValue("@NewH", m蔬菜);
                cmd.Parameters.AddWithValue("@NewA", textBox雞排.Text);
                cmd.Parameters.AddWithValue("@NewB", textBox鹹酥雞.Text);
                cmd.Parameters.AddWithValue("@NewC", textBox雞心.Text);
                cmd.Parameters.AddWithValue("@NewD", textBox雞胗.Text);
                cmd.Parameters.AddWithValue("@NewE", textBox雞屁股.Text);
                cmd.Parameters.AddWithValue("@NewF", textBox甜不辣.Text);
                cmd.Parameters.AddWithValue("@NewG", textBox薯條.Text);
                cmd.Parameters.AddWithValue("@NewH", textBox蔬菜.Text);
                cmd.Parameters.AddWithValue("@NewSpicy", comboBox辣度.Text);
                cmd.Parameters.AddWithValue("@NewToGo", is外送);
                
                cmd.Parameters.AddWithValue("@NewPrice", 所選商品總價);
                cmd.Parameters.AddWithValue("@NewDate", new SqlDateTime(DateTime.Now));
                bool state = false;
                cmd.Parameters.AddWithValue("@NewState", state);
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show($"訂購成功,共{rows}筆");
                清空();

            }
            else
            {
                MessageBox.Show("訂單不成立");
            }

            //Application.ExitThread();
        }

        
        private void 訂單_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.ExitThread();
        }

        private void btn會員登入_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            會員登入 myLoginForm = new 會員登入();
            myLoginForm.ShowDialog();
        }

        private void check雞排_CheckedChanged(object sender, EventArgs e)
        {
            if (check雞排.Checked == true) 
            {
                if (textBox雞排.Text.Length > 0)
                {
                    bool is數字 = Int32.TryParse(textBox雞排.Text, out 雞排數量);
                    if (is數字) { 小計1();總價(); }
                     
                }

            }
            else { lab雞排.Text = "0000元"; }
            
        }

        private void check鹹酥雞_CheckedChanged(object sender, EventArgs e)
        {
            if (check鹹酥雞.Checked == true) 
            {
                if (textBox鹹酥雞.Text.Length > 0)
                {
                    bool is數字 = Int32.TryParse(textBox鹹酥雞.Text, out 鹹酥雞數量);
                    if (is數字) { 小計2(); 總價();}
                }
            }
            else { lab鹹酥雞.Text = "0000元"; }
            
        }

        private void check雞心_CheckedChanged(object sender, EventArgs e)
        {
            if (check雞心.Checked == true) 
            {
                if (textBox雞心.Text.Length > 0)
                {
                    bool is數字 = Int32.TryParse(textBox雞心.Text, out 雞心數量);
                    if (is數字) { 小計3(); 總價();}
                }
            }
            else { lab雞心.Text = "0000元"; }
            
        }

        private void check雞胗_CheckedChanged(object sender, EventArgs e)
        {
            if (check雞胗.Checked == true) 
            {
                if (textBox雞胗.Text.Length > 0)
                {
                    bool is數字 = Int32.TryParse(textBox雞胗.Text, out 雞胗數量);
                    if (is數字) { 小計4();總價(); }
                }
            }
            else { lab雞胗.Text = "0000元"; }
            
        }

        private void check雞屁股_CheckedChanged(object sender, EventArgs e)
        {
            if (check雞屁股.Checked == true) 
            {
                if (textBox雞屁股.Text.Length > 0)
                {
                    bool is數字 = Int32.TryParse(textBox雞屁股.Text, out 雞屁股數量);
                    if (is數字) { 小計5(); 總價();}
                }
            }
            else { lab雞屁股.Text = "0000元"; }
            
        }

        private void check甜不辣_CheckedChanged(object sender, EventArgs e)
        {
            if (check甜不辣.Checked == true) 
            {
                if (textBox甜不辣.Text.Length > 0)
                {
                    bool is數字 = Int32.TryParse(textBox甜不辣.Text, out 甜不辣數量);
                    if (is數字) { 小計6();總價(); }
                }
            }
            else { lab甜不辣.Text = "0000元"; }
            
        }

        private void check薯條_CheckedChanged(object sender, EventArgs e)
        {
            if (check薯條.Checked == true) 
            {
                if (textBox薯條.Text.Length > 0)
                {
                    bool is數字 = Int32.TryParse(textBox薯條.Text, out 薯條數量);
                    if (is數字) { 小計8(); 總價();}
                }
            }
            else { lab薯條.Text = "0000元"; }
            
        }

        private void check蔬菜_CheckedChanged(object sender, EventArgs e)
        {
            if (check蔬菜.Checked == true) 
            {
                if (textBox蔬菜.Text.Length > 0)
                {
                    bool is數字 = Int32.TryParse(textBox蔬菜.Text, out 蔬菜數量);
                    if (is數字) { 小計7();總價(); }
                }
            }
            else { lab蔬菜.Text = "0000元"; }
            
        }

        private void textBox雞排_TextChanged(object sender, EventArgs e)
        {
            if (textBox雞排.Text.Length > 0)
            {
                bool is數字 = Int32.TryParse(textBox雞排.Text, out 雞排數量);
                if (is數字) { 小計1(); 總價(); }
            }
            else { lab雞排.Text = "0000元"; }
            
        }

        private void textBox鹹酥雞_TextChanged(object sender, EventArgs e)
        {
            if (textBox鹹酥雞.Text.Length > 0)
            {
                bool is數字 = Int32.TryParse(textBox鹹酥雞.Text, out 鹹酥雞數量);
                if (is數字) { 小計2(); 總價(); }
            }
            else { lab鹹酥雞.Text = "0000元"; }
            
        }

        private void textBox雞心_TextChanged(object sender, EventArgs e)
        {
            if (textBox雞心.Text.Length > 0)
            {
                bool is數字 = Int32.TryParse(textBox雞心.Text, out 雞心數量);
                if (is數字) { 小計3(); 總價(); }
            }
            else { lab雞心.Text = "0000元"; }
            
        }

        private void textBox雞胗_TextChanged(object sender, EventArgs e)
        {
            if (textBox雞胗.Text.Length > 0)
            {
                bool is數字 = Int32.TryParse(textBox雞胗.Text, out 雞胗數量);
                if (is數字) { 小計4(); 總價(); }
            }
            else 
            { lab雞胗.Text = "0000元"; }
            
        }

        private void textBox雞屁股_TextChanged(object sender, EventArgs e)
        {
            if (textBox雞屁股.Text.Length > 0)
            {
                bool is數字 = Int32.TryParse(textBox雞屁股.Text, out 雞屁股數量);
                if (is數字) { 小計5(); 總價(); }
            }
            else 
            { lab雞屁股.Text = "0000元"; }
            
        }

        private void textBox甜不辣_TextChanged(object sender, EventArgs e)
        {
            if (textBox甜不辣.Text.Length > 0)
            {
                bool is數字 = Int32.TryParse(textBox甜不辣.Text, out 甜不辣數量);
                if (is數字) { 小計6(); 總價(); }
            }
            else
            { lab甜不辣.Text = "0000元"; }
            
        }

        private void textBox薯條_TextChanged(object sender, EventArgs e)
        {
            if (textBox薯條.Text.Length > 0)
            {
                bool is數字 = Int32.TryParse(textBox薯條.Text, out 薯條數量);
                if (is數字) { 小計8(); 總價(); }
            }
            else
            { lab薯條.Text = "0000元"; }
            
        }

        private void textBox蔬菜_TextChanged(object sender, EventArgs e)
        {
            if (textBox蔬菜.Text.Length > 0)
            {
                bool is數字 = Int32.TryParse(textBox蔬菜.Text, out 蔬菜數量);
                if (is數字) { 小計7(); 總價(); }
            }
            else
            { lab蔬菜.Text = "0000元"; }
            
        }

        private void radio自取_CheckedChanged(object sender, EventArgs e)
        {
            is外送 = false;
        }

        private void radio外送_CheckedChanged(object sender, EventArgs e)
        {
            is外送 = true;
        }

        
        private void btn清空_Click(object sender, EventArgs e)
        {
            清空();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox辣度_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
