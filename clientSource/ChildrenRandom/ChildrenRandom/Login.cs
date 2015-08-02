using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data;
using System.Management.Instrumentation;
using System.Data.OleDb;
using Microsoft.Win32;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

 namespace ChildrenRandom
{
    public partial class Login : DevComponents.DotNetBar.Metro.MetroForm
    {
        [DllImport("user32.dll")]

        [return: MarshalAs(UnmanagedType.Bool)]

        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public Login()
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

        

        public void Login_Load(object sender, EventArgs e)
        {
            //  Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\", "DisableTaskMgr", "1", Microsoft.Win32.RegistryValueKind.DWord);
            //  Registry.SetValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\System\\", "DisableCMD", "1", Microsoft.Win32.RegistryValueKind.DWord);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.BringToFront();
            ShowTaskbar();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            {
            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection cnn = new OleDbConnection(strCnn);
            try
            {
                cnn.Open();

                string strSql = "SELECT COUNT(*) FROM UserOffline WHERE UserName = @username AND Password = @password";
                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.AddWithValue("@username", textBoxX1.Text);
                cmd.Parameters.AddWithValue("@password", MaHoa.MD5Hash(MaHoa.MD5Hash(textBoxX2.Text)));
                Session.MatKhau = MaHoa.MD5Hash(MaHoa.MD5Hash(textBoxX2.Text));
                if (Convert.ToBoolean(cmd.ExecuteScalar()))
                {
                    MessageBox.Show("Login successful");
                    //Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\", "DisableTaskMgr", "0", Microsoft.Win32.RegistryValueKind.DWord);
                    //Registry.SetValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\System\\", "DisableCMD", "0", Microsoft.Win32.RegistryValueKind.DWord);
                    string abc = "Select ProcessorId From Win32_processor ";
                    string efg = " Select Hwid From UserOffline";
                    if( abc == efg)
                    {
 
                    }

                    else
                    {
                        string fhi = "INSERT INTO UserOffline(Hwid) VALUES('" + abc + "')";
                        MessageBox.Show(abc);
                    }

                    Application.Exit();
                    Application.ExitThread();
                    
                }
                else
                {
                    MessageBox.Show("Error Password Or UserName");
                }
                cnn.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void CreateMyPasswordTextBox()
        {
            // Create an instance of the TextBox control.
            TextBox textBoxX2_TextChanged = new TextBox();
            // Set the maximum length of text in the control to eight.
            textBoxX2_TextChanged.MaxLength = 15;
            // Assign the asterisk to be the password character.
            textBoxX2_TextChanged.PasswordChar = '*';
            
        }
    }
}