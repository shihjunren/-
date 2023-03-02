using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MidHW
{
    public partial class 訂單資訊 : Form
    {
        public 訂單資訊()
        {
            InitializeComponent();
        }
        public 訂單資訊(string strPhone)
        {
            InitializeComponent();
            textBox電話.Text = strPhone;
        }
        MyHWEntities mydb = new MyHWEntities();
        OD OD = new OD();
        int myID = 0;
        int int訂單狀態 = 0;
        string 辣度 = "";

        private void 訂單資訊_Load(object sender, EventArgs e)
        {
            
        }

        private void btn搜尋_Click(object sender, EventArgs e)
        {
            if (textBox電話.Text != "")
            {
                string srtMsg = "";
                var result = from s in mydb.OD where s.訂購電話 == textBox電話.Text select s;
                int count = result.Count();
                if (result.Count() > 0)
                {
                    groupBox1.Visible=true;
                    OD = result.FirstOrDefault();                    
                    labID.Text = OD.訂單ID.ToString();                   
                    lab鹹酥雞.Text = OD.鹹酥雞_份.ToString();                    
                    lab雞排.Text = OD.雞排_份.ToString();                    
                    lab雞心.Text = OD.雞心_串.ToString();                   
                    lab雞胗.Text = OD.雞胗_串.ToString();                    
                    lab雞屁股.Text = OD.雞屁股_串.ToString();                    
                    lab甜不辣.Text = OD.甜不辣_份.ToString();                    
                    lab蔬菜.Text = OD.季節蔬菜_份.ToString();                    
                    lab薯條.Text = OD.薯條_份.ToString();                    
                    labtime.Text = OD.訂單時間.ToString();
                    if (OD.訂單狀態.Value == true && OD.外送.Value == false)
                    { labmake.Text = "餐點製作完成,可以領取餐點"; }
                    else if (OD.訂單狀態.Value == true && OD.外送.Value == true)
                    { labmake.Text = "餐點製作完成,正在配送中"; }
                    else if (OD.訂單狀態.Value ==false && OD.外送.Value == false) 
                    { labmake.Text = "餐點製作中,請稍後"; }
                    else
                    { labmake.Text = "餐點製作中,請稍後"; }
                    lab辣度.Text = OD.辣度.ToString();                    

                }
                else
                {
                    MessageBox.Show("請確認有無訂餐");
                    textBox電話.Text = "";
                    groupBox1.Visible = false;
                    
                }
            }
        }
    }
}
