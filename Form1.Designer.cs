namespace batchHandle
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_run = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_auto = new System.Windows.Forms.Button();
            this.lbl_count = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_num = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_run
            // 
            this.btn_run.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_run.Location = new System.Drawing.Point(309, 262);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(45, 48);
            this.btn_run.TabIndex = 0;
            this.btn_run.Text = "手动处置";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 60);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJydG0iLCJpZCI6MSwibmFtZSI6ImFkbWluIiwiaWF0IjoxNzA2" +
    "NzQ3NDU5LCJleHAiOjE3MDczNTIyNTl9.Q1bERBO-mKj-wadUrXDtYYEPMi7MBRfni8shxSvG4Og";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 11F);
            this.textBox2.Location = new System.Drawing.Point(13, 117);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(290, 201);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "b4cf472d1f25e06c0d327a17ffb55ae8\r\nes_index_id\":\"([^\"]*)";
            // 
            // btn_auto
            // 
            this.btn_auto.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_auto.Location = new System.Drawing.Point(148, 78);
            this.btn_auto.Name = "btn_auto";
            this.btn_auto.Size = new System.Drawing.Size(190, 33);
            this.btn_auto.TabIndex = 3;
            this.btn_auto.Text = "自动挂机/每5分钟处置";
            this.btn_auto.UseVisualStyleBackColor = true;
            this.btn_auto.Click += new System.EventHandler(this.btn_auto_Click);
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(12, 90);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(89, 12);
            this.lbl_count.TabIndex = 4;
            this.lbl_count.Text = "挂机累计处置：";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 180000;
            this.timer1.Tick += new System.EventHandler(this.btn_auto_Click);
            // 
            // lbl_num
            // 
            this.lbl_num.AutoSize = true;
            this.lbl_num.Location = new System.Drawing.Point(101, 90);
            this.lbl_num.Name = "lbl_num";
            this.lbl_num.Size = new System.Drawing.Size(11, 12);
            this.lbl_num.TabIndex = 5;
            this.lbl_num.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(353, 322);
            this.Controls.Add(this.lbl_num);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.btn_auto);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_run);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "中国通建态势日志批处理V1.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_auto;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_num;
    }
}

