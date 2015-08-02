using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading;


namespace ChildrenRandom
{
    public partial class MenuOffical : DevComponents.DotNetBar.Metro.MetroForm
    {
        public MenuOffical()
        {
            InitializeComponent();
        }
        


        private void metroTileItem4_Click(object sender, EventArgs e)
        {
            


        }

        private void itemPanel1_ItemClick(object sender, EventArgs e)
        {

        }

        private void metroTileItem3_Click(object sender, EventArgs e)
        {

            About frm = new About();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
 

        }

        private void metroTileItem5_Click(object sender, EventArgs e)
        {

            TimerSetting frm = new TimerSetting();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            Tienich frm = new Tienich();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();

        }

        private void metroTileItem7_Click(object sender, EventArgs e)
        {
            TimerSetting frm = new TimerSetting();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();

        }

        private void metroStatusBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            MenuLogin frm = new MenuLogin();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void metroTileItem5_Click_1(object sender, EventArgs e)
        {
            TienIchKhac frm = new TienIchKhac();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void metroTileItem3_Click_1(object sender, EventArgs e)
        {

            
            
        }

         public void buttonX1_Click(object sender, EventArgs e)
        {
            Thanks frm = new Thanks();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
            
        }
        

        private void metroTilePanel1_ItemClick(object sender, EventArgs e)
        {
            
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }

        private void MenuOffical_Load(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            ChangePass frm = new ChangePass();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void metroTileItem4_Click_1(object sender, EventArgs e)
        {
            WindowsSettingMain frm = new WindowsSettingMain();

            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();

        }

        private void metroTileItem6_Click(object sender, EventArgs e)
        {
            Status frm = new Status();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();

        }

        private void metroTileItem3_Click_2(object sender, EventArgs e)
        {
            About frm = new About();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
 

        }

        void CheckSTT()
        {

            DataTable dt = new DataTable();
            GetMac frm1 = new GetMac();
            Session.Mac = frm1.GetMACAddress();
            string a = frm1.GetMACAddress();
            
            dt = cn.Select("SELECT action,inforOfMess FROM ChildrenCode where username='" + Session.TenDN + "' and password='" + Session.MatKhau + "' ");
            if (dt.Rows.Count == 1)
            {
                int step = 5;
                for (int i = 0; i <= step; i++)
                {
                    if (i == step)
                    {
                        i = 0;
                    }
                    else
                    {
                        if (dt.Rows[0][0].ToString() == "lock")
                        {
                            cn.ExecuteSQL("Update ChildrenCode set action='' where username='" + Session.TenDN + "' and password='" + Session.MatKhau + "'");
                            Login fr = new Login();
                            fr.ShowDialog();

                        }


                        if (dt.Rows[0][0].ToString() == "tatmay")
                        {
                            cn.ExecuteSQL("Update ChildrenCode set action='' where username='" + Session.TenDN + "' and password='" + Session.MatKhau + "'");
                            System.Diagnostics.Process.Start("Shutdown", "-s -f -t 1");
                        }

                        if (dt.Rows[0][0].ToString() == "khoidong")
                        {
                            cn.ExecuteSQL("Update ChildrenCode set action='' where username='" + Session.TenDN + "' and password='" + Session.MatKhau + "'");
                            System.Diagnostics.Process.Start("Shutdown", "-r -f -t 1");
                        }

                        if (dt.Rows[0][0].ToString() == "chup")
                        {
                            cn.ExecuteSQL("Update ChildrenCode set action='' where username='" + Session.TenDN + "' and password='" + Session.MatKhau + "'");
                            ScreenCapture chup = new ScreenCapture();
                            chup.Chup();

                        }

                        if (dt.Rows[0][1].ToString() != "")
                        {
                            cn.ExecuteSQL("Update ChildrenCode set inforOfMess='' where username='" + Session.TenDN + "' and password='" + Session.MatKhau + "'");
                            MessageBox.Show(dt.Rows[0][1].ToString(), "Thong Bao");
                            
                        }
                        else
                        {

                        }


                    }

                }

            }
        }
        ConnectMySQL cn = new ConnectMySQL();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread luong = new Thread(new ThreadStart(CheckSTT));
            luong.Start();
        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            Register frm = new Register();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void metroStatusBar1_ItemClick_1(object sender, EventArgs e)
        {

        }
    }
}
