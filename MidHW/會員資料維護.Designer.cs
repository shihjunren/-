namespace MidHW
{
    partial class 會員資料維護
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv會員資料列表 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv會員資料列表)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv會員資料列表
            // 
            this.dgv會員資料列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv會員資料列表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv會員資料列表.Location = new System.Drawing.Point(11, 55);
            this.dgv會員資料列表.Margin = new System.Windows.Forms.Padding(2);
            this.dgv會員資料列表.Name = "dgv會員資料列表";
            this.dgv會員資料列表.RowHeadersWidth = 51;
            this.dgv會員資料列表.RowTemplate.Height = 27;
            this.dgv會員資料列表.Size = new System.Drawing.Size(662, 464);
            this.dgv會員資料列表.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "會員資料";
            // 
            // 會員資料維護
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 530);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv會員資料列表);
            this.Name = "會員資料維護";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.會員資料維護_FormClosed);
            this.Load += new System.EventHandler(this.會員資料維護_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv會員資料列表)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv會員資料列表;
        private System.Windows.Forms.Label label1;
    }
}