using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.Data.OleDb;
namespace ChildSecService
{
    public partial class Form1 : Form
    {
         [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);
         string sqlDB;
         static string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
         static string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
         OleDbCommand cmd,cmdDB;
         OleDbDataReader readerDB;
         OleDbConnection conDB = new OleDbConnection(strCnn);
         string blockweb,blockprogram,limittime;
         int countMinute = 0;
         string sql, lastWindowTitle;
        public Form1()
        {
            InitializeComponent();
        }
        void runprotect()
        {
           
        }
        public void doProcess()
        {
            while (true)
            {
                bgProtectAppWeb.RunWorkerAsync();
                while (bgProtectAppWeb.IsBusy)
                {
                }
                Thread.Sleep(500);
            }
        }
        public void doProtect()
        {
            try
            {
                sqlDB = "Select BlockWebQuickly from Status where BlockWebQuickly='BlockWebQuickly'";
                cmd = new OleDbCommand(sqlDB, conDB);
                readerDB = cmd.ExecuteReader();
                while (readerDB.Read())
                {
                    blockweb = "True";
                }
                sqlDB = "Select BlockProgram from Status where BlockProgram='BlockProgram'";
                cmd = new OleDbCommand(sqlDB, conDB);
                readerDB = cmd.ExecuteReader();
                while (readerDB.Read())
                {
                    blockprogram = "True";
                }
                sqlDB = "Select LimitTime from Status where LimitTime='LimitTime'";
                cmd = new OleDbCommand(sqlDB, conDB);
                readerDB = cmd.ExecuteReader();
                while (readerDB.Read())
                {
                    limittime = "True";
                }
                if (limittime == "True")
                {
                    sqlDB = "Select Hours,Minutes from LimitTime";
                    cmd = new OleDbCommand(sqlDB, conDB);
                    readerDB = cmd.ExecuteReader();
                    while (readerDB.Read())
                    {
                        if (countMinute >= Convert.ToInt16(readerDB[0].ToString()) * 60 + Convert.ToInt16(readerDB[1].ToString()))
                        {
                            runprotect();
                        }   
                    }
                }

            }
            catch
            {

            }
            finally
            {
                         
            }
        }
      
         static void Enable(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.StartInfo = psi;
            p.Start();
        }
        static void Disable(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.StartInfo = psi;
            p.Start();
        }
        public string getcontent(string url)
        {
            System.Net.WebClient Client = new WebClient();
            Client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
            Stream strm = Client.OpenRead(url);
            StreamReader sr = new StreamReader(strm);
            string line = sr.ReadLine();
            strm.Close();
            return line.Trim();
        }
        public void disconectinternet()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                Disable(nic.Name);
            }
        }
        public void connectinternet()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                Enable(nic.Name);
            }
        }

        public void BlockWebAndApp()
        {
            string windowTitle = "", fileName = "";
            Int32 processId = 0;         
            string sqlDB;
            try
            {
                IntPtr hwnd = APIFuncs.getforegroundWindow();
                processId = APIFuncs.GetWindowProcessID(hwnd);
                Process p = Process.GetProcessById(processId);
                fileName = p.ProcessName + ".exe";
                windowTitle = APIFuncs.ActiveApplTitle().Trim().Replace("\0", "");
            }
            catch (Exception ex)
            {
            }
            #region Get App
            if (lastWindowTitle != windowTitle && fileName != "" && processId != 0)
            {              
                if (blockprogram == "True")
                {
                    sqlDB = @"Select LinkProgram from BlockProgram where LinkProgram='" + fileName.ToLower() + "'";
                    cmdDB = new OleDbCommand(sqlDB, conDB);
                    readerDB = cmdDB.ExecuteReader();
                    while (readerDB.Read())
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                }
             
            #endregion
                #region Black List Web Module
                if (blockweb == "True")
                {
                    if (windowTitle.IndexOf("sex") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("hardsextube") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("tube8") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("keandra") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("redtube") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("youjizz") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("spankwire") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("pornhub") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("fakku") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("xhamster") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("xvideos") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("asian sex") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Asian sex") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("asian xxx") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Asian xxx") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("anal") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Anal") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("abuse") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Abuse") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Blonde") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("blonde") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Blowjob") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("blowjob") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Bukkake") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("bukkake") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("brunete") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Brunete") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("creampie") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Creampie") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("cumshot") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Cumshot") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("gangbang") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Gangbang") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Gang Bang") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("gang bang") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Gay") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("gay") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("hentai") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("interracial") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Intterracial") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("japanese sex") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("japan sex") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Japanese sex") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("Japan sex") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("seks") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("porn") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else if (windowTitle.IndexOf("latina") != -1)
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                }
                #endregion
                lastWindowTitle = windowTitle;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                Hide();
            }));
            conDB.Open();
            doProtect();

            Thread t = new Thread(doProcess);
            t.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countMinute++;
            doProtect();
        }

        private void bgProtectAppWeb_DoWork(object sender, DoWorkEventArgs e)
        {
            BlockWebAndApp();
        }
    }
}
