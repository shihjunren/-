using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidHW
{
    public partial class 營業額 : Form
    {
        MyHWEntities mydb = new MyHWEntities();
        OD OD = new OD();
        public 營業額()
        {
            InitializeComponent();
        }

        private void 營業額_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = mydb.OD.ToList<OD>();            

        }
        

        void sum_年()
        {
            var result = from s in mydb.OD select s;
            int year = Convert.ToInt32(textBox年.Text);
            DateTime startDate = new DateTime(year, 1, 1, 0, 0, 0);
            DateTime endDate = new DateTime(year, 12, 31, 23, 59, 59);
            result = mydb.OD.Where(s => s.訂單時間 >= startDate && s.訂單時間 <= endDate);
            dataGridView1.DataSource = result.ToList<OD>();
            List<int> a = new List<int>();
            foreach (var member in result)
            {
                a.Add((int)member.總金額);
            }
            int Asum = a.Sum();
            lab金額.Text = Asum.ToString();
        }
        void sum_月()
        {
            var result = from s in mydb.OD select s;
            int year = Convert.ToInt32(textBox年.Text);
            int month = Convert.ToInt32(textBox月.Text);
            DateTime startDate = new DateTime(year, month, 1, 0, 0, 0);
            DateTime endDate = new DateTime(year, month, 31, 23, 59, 59);
            result = mydb.OD.Where(s => s.訂單時間 >= startDate && s.訂單時間 <= endDate);
            dataGridView1.DataSource = result.ToList<OD>();
            List<int> b = new List<int>();
            foreach (var member in result)
            {
                b.Add((int)member.總金額);
            }
            int Asum = b.Sum();
            lab金額.Text = Asum.ToString();
        }
        void sum_日()
        {
            var result = from s in mydb.OD select s;
            int year = Convert.ToInt32(textBox年.Text);
            int month = Convert.ToInt32(textBox月.Text);
            int day = Convert.ToInt32(textBox日.Text);
            DateTime startDate = new DateTime(year, month, day, 0, 0, 0);
            DateTime endDate = new DateTime(year, month, day, 23, 59, 59);
            
            result = mydb.OD.Where(s => s.訂單時間 >= startDate && s.訂單時間 <= endDate);
            dataGridView1.DataSource = result.ToList<OD>();
            List<int> c = new List<int>();
            foreach (var member in result)
            {
                c.Add((int)member.總金額);
            }
            int Asum = c.Sum();
            lab金額.Text=Asum.ToString();
        }

        

        private void btn年_Click(object sender, EventArgs e)
        {
            if (textBox年.Text != "")
            {
                sum_年();
            }
            else 
            {
                MessageBox.Show("請重新輸入");
            }
        }

        private void btn月_Click(object sender, EventArgs e)
        {
            if (textBox年.Text != "" && textBox月.Text != "")
            { 
                sum_月(); 
            }
            else
            {
                MessageBox.Show("請重新輸入");
            }
        }

        private void btn日_Click(object sender, EventArgs e)
        {
            if (textBox年.Text != "" && textBox月.Text != "" && textBox日.Text != "")
            { 
                sum_日(); 
            }
            else
            {
                MessageBox.Show("請重新輸入");
            }
        }
    }
}
