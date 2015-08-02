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
using System.Windows;
using Microsoft.Win32;

namespace ChildrenRandom
{
    public partial class WindowsSettingMain : DevComponents.DotNetBar.Metro.MetroForm
    {
        public WindowsSettingMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = string.Empty;

                        string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                if (checkBox10.Checked == true)
                {

                    query = "UPDATE Status Set WindowsSetting = 'WindowsSetting'";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Đã Bật Kích Hoạt Chức Năng Chặn Chức Năng Windows Từ Người Dùng !!");

                }

                if (checkBox10.Checked == false)
                {
                    query = "UPDATE Status Set WindowsSetting = ''";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Đã Tắt Kích Hoạt Chức Năng Chặn Chức Năng Windows Từ Người Dùng !!");
                }
                if (checkBox1.Checked)
                {
                    query = "INSERT INTO WindowsSetting(SystemRestore) VALUES('SystemRestore')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                     
                }
                if (checkBox2.Checked)
                {
                    query = "INSERT INTO WindowsSetting(Service) VALUES('Service')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                }

                if (checkBox3.Checked)
                {
                    query = "INSERT INTO WindowsSetting(MsDos) VALUES('MsDos')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                }

                if (checkBox4.Checked)
                {
                    query = "INSERT INTO WindowsSetting(CP) VALUES('CP')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                }
                if (checkBox5.Checked)
                {
                    query = "INSERT INTO WindowsSetting(SafeBoot) VALUES('SafeBoot')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                }
                if (checkBox6.Checked)
                {
                    query = "INSERT INTO WindowsSetting(SwitchUser) VALUES('SwitchUser')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                }
                if (checkBox7.Checked)
                {
                    query = "INSERT INTO WindowsSetting(ProgramFuture) VALUES('ProgramFuture')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                }
                if (checkBox8.Checked)
                {
                    query = "INSERT INTO WindowsSetting(Registry) VALUES('Registry')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                }
                if (checkBox9.Checked)
                {
                    query = "INSERT INTO WindowsSetting(Search) VALUES('Search')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                }

                if (checkBox1.Checked == false)
                {
                    query = "DELETE FROM WindowsSetting WHERE SystemRestore='SystemRestore' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();

                }

                if (checkBox2.Checked == false)
                {
                    query = "DELETE FROM WindowsSetting WHERE Service='Service' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();

                }

                if (checkBox3.Checked == false)
                {
                    query = "DELETE FROM WindowsSetting WHERE MsDos='MsDos' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();

                }

                if (checkBox4.Checked == false)
                {
                    query = "DELETE FROM WindowsSetting WHERE CP='CP' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();

                }

                if (checkBox5.Checked == false)
                {
                    query = "DELETE FROM WindowsSetting WHERE SafeBoot='SafeBoot' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();

                }

                if (checkBox6.Checked == false)
                {
                    query = "DELETE FROM WindowsSetting WHERE SwitchUser='SwitchUser' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();

                }

                if (checkBox7.Checked == false)
                {
                    query = "DELETE FROM WindowsSetting WHERE ProgramFuture='ProgramFuture' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();

                }

                if (checkBox8.Checked == false)
                {
                    query = "DELETE FROM WindowsSetting WHERE Registry='Registry' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();

                }

                if (checkBox9.Checked == false)
                {
                    query = "DELETE FROM WindowsSetting WHERE Search='Search' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();

                }


                MessageBox.Show("Đã Cài Đặt Chặn Nội Dung Web Theo Yêu Cầu Người Dùng");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void WindowsSettingMain_Load(object sender, EventArgs e)
        {

            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                string query = "Select WindowsSetting from Status";
                OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                OleDbDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == "WindowsSetting")
                    {
                        checkBox10.Checked=true;

                    }
                }
                query = "Select SystemRestore,SafeBoot,CP,MsDos,Service,SwitchUser,Registry,Search,ProgramFuture from WindowsSetting";
                sqlCommand = new OleDbCommand(query, conn);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == "SystemRestore")
                    {
                        checkBox1.Checked = true;

                    }

                    if (reader[1].ToString() == "SafeBoot")
                    {
                        checkBox5.Checked = true;

                    }

                    if (reader[2].ToString() == "CP")
                    {
                        checkBox4.Checked = true;

                    }

                    if (reader[3].ToString() == "MsDos")
                    {
                        checkBox3.Checked = true;

                    }

                    if (reader[4].ToString() == "Service")
                    {
                        checkBox2.Checked = true;

                    }

                    if (reader[5].ToString() == "SwitchUser")
                    {
                        checkBox6.Checked = true;

                    }

                    if (reader[6].ToString() == "Registry")
                    {
                        checkBox8.Checked = true;

                    }

                    if (reader[7].ToString() == "Search")
                    {
                        checkBox9.Checked = true;

                    }

                    if (reader[8].ToString() == "ProgramFuture")
                    {
                        checkBox7.Checked = true;

                    }

                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                conn.Close();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuOffical frm = new MenuOffical();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(checkBox9.Checked == true) 
            {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\", "DisableTaskMgr", "1", Microsoft.Win32.RegistryValueKind.DWord);
            }
            else
            {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\", "DisableTaskMgr", "0", Microsoft.Win32.RegistryValueKind.DWord);
            }

            if (checkBox4.Checked == true)
            {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\System\\", "DisableCMD", "1", Microsoft.Win32.RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\System\\", "DisableCMD", "0", Microsoft.Win32.RegistryValueKind.DWord);
            }

            if (checkBox7.Checked == true)
            {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\", "NoControlPanel", "1", Microsoft.Win32.RegistryValueKind.DWord);
            }
            else
            {
           Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\", "NoControlPanel", "0", Microsoft.Win32.RegistryValueKind.DWord);
            }
            if (checkBox8.Checked == true)
            {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\", "DisableRegistryTools", "1", Microsoft.Win32.RegistryValueKind.DWord);
            }
            else
            {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\", "DisableRegistryTools", "0", Microsoft.Win32.RegistryValueKind.DWord);
            }

            MessageBox.Show("Successly !!");

            
            }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuOffical frm = new MenuOffical();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}