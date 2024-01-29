using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace batchHandle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void btn_run_Click(object sender, EventArgs e)
        {
            try
            {
                string[] advices = { 
                "对该IP进行溯源后，发现并未受到影响。",
                "跟踪发现，该攻击并未持续，未受到影响",
                "在边界设备上将其加入黑名单封30分钟" };
                string[] str = new string[textBox2.Lines.Length];
                for (int i = 0; i < textBox2.Lines.Length; i++)
                {
                    str[i] = textBox2.Lines[i].Trim();
                    if (!httpPost.Post(str[i], advices[i % 3], textBox1.Text).Contains("成功"))
                    {
                        MessageBox.Show("批量处理失败！" + str[i].ToString());
                    }
                }
                MessageBox.Show("批量处理全部完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序出现错误");
            }
          
        }
    }
}
