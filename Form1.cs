using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace batchHandle
{
    public partial class Form1 : Form
    {
   
        public Form1()
        {
            InitializeComponent();
        }

        static string incident_id_flag = "";

        private void btn_run_Click(object sender, EventArgs e)
        {
            try
            {
                Business business = new Business(textBox1.Text.Trim());
                string[] str = new string[textBox2.Lines.Length];
                for (int i = 0; i < textBox2.Lines.Length; i++)
                {
                    str[i] = textBox2.Lines[i].Trim();
                    business.Update_incident(str[i]);
                }
                MessageBox.Show("批量处理全部完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序出现错误");
            }
        }

        private void btn_auto_Click(object sender, EventArgs e)
        {
            try
            {
                Business business = new Business(textBox1.Text.Trim());
                string incident_id = business.Query_30day_incident();
                if (business.Check_time() && incident_id_flag != incident_id && business.Update_incident(incident_id))
                {
                    incident_id_flag = incident_id;
                    lbl_num.Text = (Convert.ToInt32(lbl_num.Text) + 1).ToString();
                }
                Console.WriteLine("success " + incident_id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error "+ ex.ToString());                
            }
        }
    }
}
