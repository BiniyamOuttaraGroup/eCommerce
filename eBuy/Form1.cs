using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eBuy
{
    public partial class Form1 : Form
    {
      
        bool hided = true;
        login login = null;
        public Form1()
        {
            InitializeComponent();
            settingPanel.Width = 0;
        }

        private void goLogin_Click(object sender, EventArgs e)
        {
            if(login == null)
            {
                login = new login();
            }
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Timer Here
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hided)
            {
                settingPanel.Width = 200;
                if(settingPanel.Width > 0)
                {
                    timer1.Stop();
                    hided = false;
                    this.Refresh();
                }
            }
            else
            {
                settingPanel.Width = 0;
                timer1.Stop();
                hided = true;
                this.Refresh();
            }
        }


       
    }
}
