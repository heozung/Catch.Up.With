using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading;

namespace ChildrenRandom
{
    public partial class FormLoad : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormLoad()
        {
            InitializeComponent();
        }

        WhenStartAg frmMenu = new WhenStartAg();

        Login frmLogin = new Login();
        public void showForm(int index)
        {
            switch (index)
            {
                case 0:
                    frmMenu.MdiParent = this;
                    frmMenu.Show();
                    break;
                case 1:
                    frmLogin.MdiParent = this;
                    frmLogin.ShowDialog();
                    break;
            }
        }
        ScreenCapture cscp = new ScreenCapture();
        private void FormLoad_Load(object sender, EventArgs e)
        {
            WhenStartAg frm = new WhenStartAg();
            frmMenu.MdiParent = this;
            frmMenu.Show();
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }





        public void MinimizeToTray()
        {
            try
            {
                notifyIcon1.BalloonTipTitle = "Chương trình đang chạy";
                notifyIcon1.BalloonTipText = "Chương trình đang chạy";

                if (FormWindowState.Normal == this.WindowState)
                {
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(500);
                    this.Hide();
                }
                else if (FormWindowState.Normal == this.WindowState)
                {
                    notifyIcon1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FormLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                MinimizeToTray();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowDialog();
        }


        ConnectMySQL cn = new ConnectMySQL();
        //void CheckSTT()
        //{
        //    DataTable dt = new DataTable();
        //    dt = cn.Select("SELECT action FROM ChildrenCode where username='" + Session.TenDN + "' and password='" + Session.MatKhau + "' ");
        //    if (dt.Rows.Count != 0)
        //    {
        //        int step = 5;
        //        for (int i = 0; i <= step; i++)
        //        {
        //            if (i == step)
        //            {
        //                i = 0;
        //            }
        //            else
        //            {
        //                string a = dt.Rows[0][0].ToString();
        //                MessageBox.Show(dt.Rows[0][0].ToString());
        //            }

        //        }

        //    }
        //}
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Thread luong = new Thread(new ThreadStart(CheckSTT));
            //luong.Start();       
        }
    }
}