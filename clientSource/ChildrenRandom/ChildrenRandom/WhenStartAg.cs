using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;


namespace ChildrenRandom

{
    public partial class WhenStartAg : DevComponents.DotNetBar.Metro.MetroForm
    {
        [DllImport("user32.dll")]

        [return: MarshalAs(UnmanagedType.Bool)]

        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        
        public WhenStartAg()
        {
            InitializeComponent();

        }

        private IntPtr taskbar = FindWindow("Shell_traywnd", "");
        const int SWP_HIDEWINDOW = 0x80;
        const int SWP_SHOWWINDOW = 0x40;
        public void HideTaskBar()
        {
            SetWindowPos(taskbar, 0, 0, 0, 0, 0, SWP_HIDEWINDOW);
        }
        public void ShowTaskbar()
        {
            SetWindowPos(taskbar, 0, 0, 0, 0, 0, SWP_SHOWWINDOW);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Left = 0;
            this.Top = 0;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            ShowTaskbar();

        }
       /* MenuOffical frmMenu = new MenuOffical();

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
                    {
                        frmLogin.MdiParent = this;
                        frmLogin.ShowDialog();
                        break;
                    }
            }
         }
        
     */
        ConnectMySQL cn = new ConnectMySQL();
        private void button4_Click(object sender, EventArgs e)
        {
            //lay computer name: System.Environment.MachineName
            string tendn = textBox1.Text;
            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection cnn = new OleDbConnection(strCnn);

            DataTable dtt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from UserOffline", cnn);
            da.Fill(dtt);
            if (dtt.Rows.Count == 0)
            {
                DataTable dt = new DataTable();
                dt = cn.Select("SELECT * FROM ChildrenCode where username='" + tendn + "' and password='" + MaHoa.MD5Hash(MaHoa.MD5Hash(textBox2.Text)) + "' ");
                if (dt.Rows.Count == 1)
                {

                    Session.TenDN = textBox1.Text;
                    Session.MatKhau = MaHoa.MD5Hash(MaHoa.MD5Hash(textBox2.Text));
                    GetMac frm1 = new GetMac();
                    Session.Mac = frm1.GetMACAddress();
                    string a = frm1.GetMACAddress();
                    
                    cn.ExecuteSQL("Update ChildrenCode set cpname='" + System.Environment.MachineName + "' where username='" + tendn + "' and password='" + MaHoa.MD5Hash(MaHoa.MD5Hash(textBox2.Text)) + "'");
                    DataTable dttt = new DataTable();
                    dttt = cn.Select("SELECT email, name, username, password, phone, cpname,phone FROM ChildrenCode where username='" + tendn + "' and password='" + MaHoa.MD5Hash(MaHoa.MD5Hash(textBox2.Text)) + "' ");
                    if (dttt.Rows.Count == 1)
                    {
                        try
                        {
                            string email = dt.Rows[0]["email"].ToString();
                            string pass = dt.Rows[0]["password"].ToString();
                            string cpname = dt.Rows[0]["cpname"].ToString();
                            string name = dt.Rows[0]["name"].ToString();
                            string username = dt.Rows[0]["username"].ToString();
                            string phone = dt.Rows[0]["phone"].ToString();



                            string duongdan = Application.StartupPath + @"\CodeChildren1Offical.mdb";
                            string strCn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + duongdan;
                            OleDbConnection con = new OleDbConnection(strCn);

                            string sql = @"INSERT INTO UserOffline VALUES  (@p1,@p2,@p3,@p4,@p5,@p6)";
                            OleDbCommand cmd = new OleDbCommand(sql, con);
                            con.Open();
                            cmd.Parameters.AddWithValue("@p1", email); // if you have date time column give DateTime object as value
                            cmd.Parameters.AddWithValue("@p2", username);
                            cmd.Parameters.AddWithValue("@p3", pass);
                            cmd.Parameters.AddWithValue("@p4", cpname);
                            cmd.Parameters.AddWithValue("@p5", name);
                            cmd.Parameters.AddWithValue("@p6", phone);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }

                    ShowTaskbar();
                    //Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\", "DisableTaskMgr", "0", Microsoft.Win32.RegistryValueKind.DWord);
                    //Registry.SetValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\System\\", "DisableCMD", "0", Microsoft.Win32.RegistryValueKind.DWord);
                    MenuOffical frm = new MenuOffical();
                    frm.MdiParent = this.ParentForm;
                    this.Close();
                    frm.Show();
                }
            }

            else
            {
                if (dtt.Rows.Count == 1)
                {
                    try
                    {

                        cnn.Open();

                        string strSql = "SELECT COUNT(*) FROM UserOffline WHERE UserName = @textBox1 AND Password = @textBox2";
                        OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                        cmd.Parameters.AddWithValue("@textBox1", textBox1.Text);
                        cmd.Parameters.AddWithValue("@textBox2", MaHoa.MD5Hash(MaHoa.MD5Hash(textBox2.Text)));
                        Session.TenDN = textBox1.Text;
                        Session.MatKhau = MaHoa.MD5Hash(MaHoa.MD5Hash(textBox2.Text));
                        

                        if (Convert.ToBoolean(cmd.ExecuteScalar()))
                        {

                            MessageBox.Show("Login successful !!!");
                            ShowTaskbar();
                            //Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\", "DisableTaskMgr", "0", Microsoft.Win32.RegistryValueKind.DWord);
                            //Registry.SetValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\System\\", "DisableCMD", "0", Microsoft.Win32.RegistryValueKind.DWord);
                            MenuOffical frm = new MenuOffical();
                            frm.MdiParent = this.ParentForm;
                            this.Close();
                            frm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username Or Password - Please Login Again !!");

                        }
                        cnn.Close();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
                else
                {
                    
                }


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Shutdown", "-s -f -t 1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("restart", "-r -f -t 0");
        }

        private void WhenStartAg_Load(object sender, EventArgs e)
        {
            //HideTaskBar();
//           Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\", "DisableTaskMgr", "1", Microsoft.Win32.RegistryValueKind.DWord);
//           Registry.SetValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\System\\", "DisableCMD", "1", Microsoft.Win32.RegistryValueKind.DWord);
           
            // this.Focus();
            //this.BringToFront();
            //this.TopMost = true;
           // this.Bounds = Screen.PrimaryScreen.Bounds;
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;  
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.BringToFront();



            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection cnn = new OleDbConnection(strCnn);

            DataTable dtt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from UserOffline", cnn);
            da.Fill(dtt);
            if (dtt.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa có thông tin đăng nhập. Xin đăng vào web để đăng ký");
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}