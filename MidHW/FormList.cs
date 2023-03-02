using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MidHW
{
    public partial class FormList : Form
    {
        int strID = 0;

        
        public FormList()
        {
            InitializeComponent();
            
        }
        public FormList(string Phone,int ID,string Name)
        {
            InitializeComponent();
            lab電話.Text = Phone;
            lab姓名.Text = Name;
            strID = ID;
            if (ID == 0)
            {
                panel登入.Visible = true;
                panel登出.Visible = false;
            }
            else
            {
                panel登出.Visible = true;
                panel登入.Visible = false;
            }


            if (ID == 0 || ID > 11)
            {
                btn會員維護.Visible = false;
                panel維護.Visible=false;

            }
            else
            {
                
                btn會員維護.Visible = true;
                panel維護.Visible=true;
            }


        }

        void 單獨顯示() 
        {
            if (panel會員.Visible == true)
            { panel會員.Visible = false; }
            if (panel訂單.Visible == true)
            { panel訂單.Visible = false; }           
        }
        void 顯示Panel資訊(Panel 表單) 
        {
            if (表單.Visible == false)
            {
                單獨顯示();
                表單.Visible = true;
            }
            else
            { 
                表單.Visible = false; 
            }
        }

        private void FormList_Load(object sender, EventArgs e)
        {
           // btn會員維護.Visible = false;
        }

        private void btn訂單_Click(object sender, EventArgs e)
        {
            顯示Panel資訊(panel訂單);
        }

        private void btn商品訂購_Click(object sender, EventArgs e)
        {
            if (strID == 0)
            { openChildForm(new 訂單()); }
            else if( strID > 0)
            { openChildForm(new 訂單(lab電話.Text)); }
            單獨顯示();
        }

        private void btn訂單搜尋_Click(object sender, EventArgs e)
        {
            if (strID == 0)
            { openChildForm(new 訂單資訊()); }
            else if (strID > 0)
            { openChildForm(new 訂單資訊(lab電話.Text)); }
            單獨顯示();
        }

        private void btn會員_Click(object sender, EventArgs e)
        {
            顯示Panel資訊(panel會員);
        }

        private void btn新增會員_Click(object sender, EventArgs e)
        {
            openChildForm(new 新增會員());
            單獨顯示();
        }

        private void btn會員修改_Click(object sender, EventArgs e)
        {
            if (strID == 0)
            { openChildForm(new 修改會員資料()); }
            else if (strID > 0)
            { openChildForm(new 修改會員資料(lab電話.Text)); }

            單獨顯示();
        }

        private void btn維護_Click(object sender, EventArgs e)
        {
            顯示Panel資訊(panel維護);
        }

        private void btn訂單維護_Click(object sender, EventArgs e)
        {
            openChildForm(new 訂單維護());
            單獨顯示();
        }

        private void btn會員維護_Click(object sender, EventArgs e)
        {
            openChildForm(new 會員資料維護());
            單獨顯示();
        }

        private void btn離開_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private Form activeForm =null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panel主要頁面.Controls.Add(childForm);
                panel主要頁面.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn登入_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            會員登入 myLoginForm = new 會員登入();
            myLoginForm.ShowDialog();
        }

        private void btn登出_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormList myLoginForm = new FormList();
            myLoginForm.ShowDialog();
        }

        private void btn維護新增_Click(object sender, EventArgs e)
        {
            openChildForm(new 新增會員());
            單獨顯示();
        }

        private void btn營收狀態_Click(object sender, EventArgs e)
        {
            openChildForm(new 營業額());
            單獨顯示();
        }
    }
}
