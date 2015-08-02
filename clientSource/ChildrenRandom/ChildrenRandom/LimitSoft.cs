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

namespace ChildrenRandom
{
    public partial class LimitSoft : DevComponents.DotNetBar.Metro.MetroForm
    {
        public LimitSoft()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TienIchKhac frm = new TienIchKhac();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                folderBrowserDialog1.ShowDialog();
                query = "INSERT INTO BlockFolder(LinkFolder, Status) VALUES('" + folderBrowserDialog1.SelectedPath + "','bat')";
                Directory.Move(folderBrowserDialog1.SelectedPath, folderBrowserDialog1.SelectedPath + ".{20D04FE0-3AEA-1069-A2D8-08002B30309D}");
                // tren day là lệnh khóa máy folder à ? dung r a
                //truyền vào là cái gì ? truyen vao day ky tu do do'a
                OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                int i = sqlCommand.ExecuteNonQuery();
                listView1.Items.Add(folderBrowserDialog1.SelectedPath);
                MessageBox.Show("Đã Nhập Vào Folder Cần Chặn !!!");
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

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            if (MessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();// day la ket noi CSDL
                    string query = " Delete From BlockFolder Where LinkFolder ='" + listView1.SelectedItems[0].Text + "'"; // 
                    MessageBox.Show("Đã xóa bản ghi thành công", "Thông báo", MessageBoxButtons.OK);
                    Directory.Move(listView1.SelectedItems[0].Text + ".{20D04FE0-3AEA-1069-A2D8-08002B30309D}", listView1.SelectedItems[0].Text);
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa bản ghi này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(ex.Message);
                    conn.Close();
                    conn.Dispose();
                    return;
                }
            }
            return;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string query = string.Empty;


            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                if (checkBox1.Checked)
                {
                    
                    query = "UPDATE Status Set BlockFolder = 'BlockFolder'";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Đã Kích Hoạt Chức Năng Chặn Folder Từ Người Dùng !!");

                }

                if (checkBox1.Checked == false)
                {
                    query = "UPDATE Status Set BlockFolder = ''";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Đã Tắt Kích Hoạt Chức Năng Chặn Folder Từ Người Dùng !!");
                }

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

        private void LimitSoft_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                string query = "Select LinkFolder from BlockFolder";
                OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                OleDbDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    //int i = sqlCommand.ExecuteNonQuery;
                    listView1.Items.Add(reader[0].ToString());
                    listView1.Items.Clear();
                    
                }

                query = "Select BlockFolder from Status";
                sqlCommand = new OleDbCommand(query, conn);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == "BlockFolder")
                    {
                        checkBox1.Checked = true;

                    }
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                conn.Dispose();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}