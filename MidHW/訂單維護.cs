using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MidHW
{
    public partial class 訂單維護 : Form
    {
        MyHWEntities mydb = new MyHWEntities();
        OD OD = new OD();
        int myID = 0;
        int int訂單狀態 = 0;
        int int外送 = 0;
        List<string> 辣度 = new List<string>();
        string 所選商品辣度 = "";
        int 所選總價 = 0;
        int a =0;
        int b =0;
        int c =0;
        int d =0;
        int E =0;
        int f =0;
        int g =0;
        int h =0;
        public 訂單維護()
        {
            InitializeComponent();
        }

        void 清空欄位()
        {
            labID.Text = "0";
            lab時間.Text = "時間";
            textBox訂購電話.Text = "";
            textBox鹹酥雞.Text = "0";
            textBox甜不辣.Text = "0";
            textBox蔬菜.Text = "0";
            textBox薯條.Text = "0";
            textBox雞屁股.Text = "0";
            textBox雞心.Text = "0";
            textBox雞排.Text = "0";
            textBox雞胗.Text = "0";
            textBox更新金額.Text = "";
            comboBox辣度.Text = "";
            checkBox外送.Checked = false;
            checkBox製作完成.Checked = false;
            checkBox雞排.Checked = false;
            checkBox鹹酥雞.Checked = false;
            checkBox雞胗.Checked = false;
            checkBox雞心.Checked = false;
            checkBox雞屁股.Checked = false;
            checkBox薯條.Checked = false;
            checkBox蔬菜.Checked = false;
            checkBox甜不辣.Checked = false;
            lab總金額.Text = "0000元";
        }
        private void 訂單維護_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = mydb.OD.ToList<OD>();


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
            

        }

        private void 訂單維護_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.ExitThread();
        }

        private void btn清空_Click(object sender, EventArgs e)
        {
            清空欄位();
        }

        
        private void btn刪除_Click(object sender, EventArgs e)
        {
            if (myID > 0)
            {
                mydb.OD.Remove(OD);
                mydb.SaveChanges();
                清空欄位();
                dataGridView1.DataSource = mydb.OD.ToList<OD>();
                MessageBox.Show("此訂單已刪除");
            }
        }

        private void btn搜尋_Click(object sender, EventArgs e)
        {
            if (textBox訂購電話.Text != "")
            {
                
                var result = from s in mydb.OD where s.訂購電話 == textBox訂購電話.Text select s;
                int count = result.Count();
                if (result.Count() > 0)
                {
                    dataGridView1.DataSource = result.ToList<OD>();
                    OD = result.FirstOrDefault();
                    myID = OD.訂單ID;
                    labID.Text = OD.訂單ID.ToString();
                    textBox訂購電話.Text = OD.訂購電話;
                    textBox鹹酥雞.Text = OD.鹹酥雞_份.ToString();
                    if (textBox鹹酥雞.Text != "0")
                    {
                        checkBox鹹酥雞.Checked = true;
                    }
                    textBox雞排.Text = OD.雞排_份.ToString();
                    if (textBox雞排.Text != "0")
                    {
                        checkBox雞排.Checked = true;
                    }
                    textBox雞心.Text = OD.雞心_串.ToString();
                    if (textBox雞心.Text != "0")
                    {
                        checkBox雞心.Checked = true;
                    }
                    textBox雞胗.Text = OD.雞胗_串.ToString();
                    if (textBox雞胗.Text != "0")
                    {
                        checkBox雞胗.Checked = true;
                    }
                    textBox雞屁股.Text = OD.雞屁股_串.ToString();
                    if (textBox雞屁股.Text != "0")
                    {
                        checkBox雞屁股.Checked = true;
                    }
                    textBox甜不辣.Text = OD.甜不辣_份.ToString();
                    if (textBox甜不辣.Text != "0")
                    {
                        checkBox甜不辣.Checked = true;
                    }
                    textBox蔬菜.Text = OD.季節蔬菜_份.ToString();
                    if (textBox蔬菜.Text != "0")
                    {
                        checkBox蔬菜.Checked = true;
                    }
                    textBox薯條.Text = OD.薯條_份.ToString();
                    if (textBox薯條.Text != "0")
                    {
                        checkBox薯條.Checked = true;
                    }
                    lab時間.Text = OD.訂單時間.ToString();
                    checkBox外送.Checked = OD.外送.Value;
                    checkBox製作完成.Checked = OD.訂單狀態.Value;
                    comboBox辣度.Text = OD.辣度.ToString();
                    lab總金額.Text = OD.總金額.ToString();

                }
                else
                {
                    MessageBox.Show("查無此人");
                    清空欄位();
                }
            }
        }
        

       

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            清空欄位();
            if (e.RowIndex >= 0)
            {
                string strID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                bool isID = Int32.TryParse(strID, out myID);
                if (isID)
                {
                    var result = from s in mydb.OD where s.訂單ID == myID select s;
                    OD = result.FirstOrDefault();
                    labID.Text = OD.訂單ID.ToString();
                    textBox訂購電話.Text = OD.訂購電話;
                    textBox鹹酥雞.Text = OD.鹹酥雞_份.ToString();
                    if (textBox鹹酥雞.Text != "0")
                    {
                        checkBox鹹酥雞.Checked = true;
                    }

                    textBox雞排.Text = OD.雞排_份.ToString();
                    if (textBox雞排.Text != "0")
                    {
                        checkBox雞排.Checked = true;
                    }
                    textBox雞心.Text = OD.雞心_串.ToString();
                    if (textBox雞心.Text != "0")
                    {
                        checkBox雞心.Checked = true;
                    }

                    textBox雞胗.Text = OD.雞胗_串.ToString();
                    if (textBox雞胗.Text != "0")
                    {
                        checkBox雞胗.Checked = true;
                    }
                    textBox雞屁股.Text = OD.雞屁股_串.ToString();
                    if (textBox雞屁股.Text != "0")
                    {
                        checkBox雞屁股.Checked = true;
                    }
                    textBox甜不辣.Text = OD.甜不辣_份.ToString();
                    if (textBox甜不辣.Text != "0")
                    {
                        checkBox甜不辣.Checked = true;
                    }
                    textBox蔬菜.Text = OD.季節蔬菜_份.ToString();
                    if (textBox蔬菜.Text != "0")
                    {
                        checkBox蔬菜.Checked = true;
                    }
                    textBox薯條.Text = OD.薯條_份.ToString();
                    if (textBox薯條.Text != "0")
                    {
                        checkBox薯條.Checked = true;
                    }
                    lab時間.Text = OD.訂單時間.ToString();
                    checkBox外送.Checked = OD.外送.Value;
                    checkBox製作完成.Checked = OD.訂單狀態.Value;
                    comboBox辣度.Text = OD.辣度.ToString();
                    lab總金額.Text = OD.總金額.ToString();
                    //清空欄位();
                }

            }
        }
        void 計算() 
        {
            if (textBox雞排.Text.Length > 0 && textBox鹹酥雞.Text.Length>0 && textBox雞心.Text.Length>0&& textBox雞胗.Text.Length>0&& textBox雞屁股.Text.Length>0&& textBox薯條.Text.Length>0&& textBox甜不辣.Text.Length>0&& textBox蔬菜.Text.Length>0) 
            { 
                a = Convert.ToInt32(textBox雞排.Text);
            b = Convert.ToInt32(textBox鹹酥雞.Text);
            c = Convert.ToInt32(textBox雞心.Text);
            d = Convert.ToInt32(textBox雞胗.Text);
            E = Convert.ToInt32(textBox雞屁股.Text);
            f = Convert.ToInt32(textBox薯條.Text);
            g = Convert.ToInt32(textBox甜不辣.Text);
            h = Convert.ToInt32(textBox蔬菜.Text);
            int total = a * 60 + b * 50 + (c + d + E + f + g + h) * 30;
            textBox更新金額.Text = total.ToString();

            }
            
        }

        private void checkBox製作完成_CheckedChanged(object sender, EventArgs e)
        { }

        private void checkBox外送_CheckedChanged(object sender, EventArgs e)
        { }

        private void btn儲存_Click(object sender, EventArgs e)
        {
            if (myID >0) 
            {
                int idxRow =dataGridView1.CurrentRow.Index;
                
                OD.訂購電話 = textBox訂購電話.Text;
                OD.鹹酥雞_份 =Convert.ToInt32(textBox鹹酥雞.Text);
                OD.雞排_份 = Convert.ToInt32(textBox雞排.Text);                
                OD.雞心_串 = Convert.ToInt32(textBox雞心.Text);
                OD.雞胗_串 = Convert.ToInt32(textBox雞胗.Text);                
                OD.雞屁股_串 = Convert.ToInt32(textBox雞屁股.Text);                
                OD.甜不辣_份 = Convert.ToInt32(textBox甜不辣.Text);                
                OD.季節蔬菜_份 = Convert.ToInt32(textBox蔬菜.Text);
                OD.薯條_份 = Convert.ToInt32(textBox薯條.Text);
                OD.外送 = checkBox外送.Checked;
                OD.訂單狀態 = checkBox製作完成.Checked;
                OD.辣度 = comboBox辣度.Text;             
                OD.總金額 = Convert.ToInt32(textBox更新金額.Text);
                mydb.Entry(OD).State = EntityState.Modified;
                mydb.SaveChanges();
                dataGridView1.DataSource= mydb.OD.ToList<OD>();
                dataGridView1.CurrentCell = dataGridView1.Rows[idxRow].Cells[0];

                清空欄位();
            }
        }

        private void checkBox雞排_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox雞排.Checked == true)
            {
                if (textBox雞排.Text.Length > 0)
                {

                    計算();

                }

            }
            else
            {
                textBox雞排.Text = "0"; 計算();
            }
        }

        private void textBox雞排_TextChanged(object sender, EventArgs e)
        {
            if (checkBox雞排.Checked == true)
            {
                if (textBox雞排.Text.Length > 0)
                {

                    計算();

                }

            }
            
        }

        private void checkBox鹹酥雞_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox鹹酥雞.Checked == true)
            {
                if (textBox鹹酥雞.Text.Length > 0)
                {

                    計算();

                }

            }
            else
            {
                textBox鹹酥雞.Text = "0"; 計算();
            }
        }

        private void textBox鹹酥雞_TextChanged(object sender, EventArgs e)
        {
            if (checkBox鹹酥雞.Checked == true)
            {
                if (textBox鹹酥雞.Text.Length > 0)
                {

                    計算();

                }

            }; }

        private void checkBox雞心_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox雞心.Checked == true)
            {
                if (textBox雞心.Text.Length > 0)
                {

                    計算();

                }

            }
            else
            {
                textBox雞心.Text = "0";
                計算();
            }
        }

        private void textBox雞心_TextChanged(object sender, EventArgs e)
        {
            if (checkBox雞心.Checked == true)
            {
                if (textBox雞心.Text.Length > 0)
                {

                    計算();

                }

            }
        }

        private void checkBox雞胗_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox雞胗.Checked == true)
            {
                if (textBox雞胗.Text.Length > 0)
                {

                    計算();

                }

            }
            else
            {
                textBox雞胗.Text = "0";
                計算();
            }
        }

        private void textBox雞胗_TextChanged(object sender, EventArgs e)
        {
            if (checkBox雞胗.Checked == true)
            {
                if (textBox雞胗.Text.Length > 0)
                {

                    計算();

                }

            }
        }

        private void checkBox雞屁股_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox雞屁股.Checked == true)
            {
                if (textBox雞屁股.Text.Length > 0)
                {

                    計算();

                }

            }
            else
            {
                textBox雞屁股.Text = "0";
                計算();
            }
        }

        private void textBox雞屁股_TextChanged(object sender, EventArgs e)
        {
            if (checkBox雞屁股.Checked == true)
            {
                if (textBox雞屁股.Text.Length > 0)
                {

                    計算();

                }

            }
        }
        private void checkBox甜不辣_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox甜不辣.Checked == true)
            {
                if (textBox甜不辣.Text.Length > 0)
                {

                    計算();

                }

            }
            else
            {
                textBox甜不辣.Text = "0";
                計算();
            }
        }

        private void textBox甜不辣_TextChanged(object sender, EventArgs e)
        {
            if (checkBox甜不辣.Checked == true)
            {
                if (textBox甜不辣.Text.Length > 0)
                {

                    計算();

                }

            }
        }

        private void checkBox薯條_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox薯條.Checked == true)
            {
                if (textBox薯條.Text.Length > 0)
                {

                    計算();

                }

            }
            else
            {
                textBox薯條.Text = "0";
                計算();
            }
        }

        private void textBox薯條_TextChanged(object sender, EventArgs e)
        {
            if (checkBox薯條.Checked == true)
            {
                if (textBox薯條.Text.Length > 0)
                {

                    計算();

                }

            }
        }

        private void checkBox蔬菜_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox蔬菜.Checked == true)
            {
                if (textBox蔬菜.Text.Length > 0)
                {

                    計算();

                }

            }
            else
            {
                textBox蔬菜.Text = "0";
                計算();
            }
        }

            private void textBox蔬菜_TextChanged(object sender, EventArgs e)
        {
            if (checkBox蔬菜.Checked == true)
            {
                if (textBox蔬菜.Text.Length > 0)
                {

                    計算();

                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn新增_Click(object sender, EventArgs e)
        {
            if (textBox訂購電話.Text != "")
            {
                
                OD = new OD();               
                OD.訂購電話 = textBox訂購電話.Text;
                OD.鹹酥雞_份 = Convert.ToInt32(textBox鹹酥雞.Text);
                OD.雞排_份 = Convert.ToInt32(textBox雞排.Text);
                OD.雞心_串 = Convert.ToInt32(textBox雞心.Text);
                OD.雞胗_串 = Convert.ToInt32(textBox雞胗.Text);
                OD.雞屁股_串 = Convert.ToInt32(textBox雞屁股.Text);
                OD.甜不辣_份 = Convert.ToInt32(textBox甜不辣.Text);
                OD.季節蔬菜_份 = Convert.ToInt32(textBox蔬菜.Text);
                OD.薯條_份 = Convert.ToInt32(textBox薯條.Text);
                OD.外送 = checkBox外送.Checked;
                OD.辣度 = comboBox辣度.Text;
                SqlDateTime NewTime = new SqlDateTime(DateTime.Now);
                OD.訂單時間 = NewTime.Value;
                OD.總金額 = Convert.ToInt32(textBox更新金額.Text);
                OD.訂單狀態 = checkBox製作完成.Checked;

                mydb.OD.Add(OD);
                mydb.SaveChanges();

                dataGridView1.DataSource = mydb.OD.ToList<OD>();

                MessageBox.Show("新增訂單成功");
                清空欄位();

            }
            else
            {
                MessageBox.Show("訂單不成立");
            }
        }
    }
    }

