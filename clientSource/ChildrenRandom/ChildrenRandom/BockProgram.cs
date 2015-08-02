using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.OleDb;
using System.Data;

namespace ChildrenRandom
{
    public partial class BlockProgram : DevComponents.DotNetBar.Metro.MetroForm
    {
        public BlockProgram()
        {
            InitializeComponent();
        }

        private void BockProgram_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                string query = "Select LinkProgram from BlockProgram";
                OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                OleDbDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    //int i = sqlCommand.ExecuteNonQuery
                    listView1.Items.Add(reader[0].ToString());
                }

                query = "Select BlockProgram from Status";
                sqlCommand = new OleDbCommand(query, conn);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == "BlockProgram")
                    {
                        checkBox1.Checked = true;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                conn.Close();
                conn.Dispose();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            RequestSuccess frm = new RequestSuccess();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            if (MessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    string query = " Delete From BlockProgram Where LinkProgram ='" + listView1.SelectedItems[0].Text + "'";
                    MessageBox.Show("Đã xóa bản ghi thành công", "Thông báo", MessageBoxButtons.OK);

                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                    // bi dien hay rang ma them cai nay listView1.Items.Clear();
                    // đó đúng ko a

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

        private void button3_Click(object sender, EventArgs e)
        {
            string query = string.Empty;


            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                openFileDialog1.ShowDialog();
                query = "INSERT INTO BlockProgram(LinkProgram, Status) VALUES('" + System.IO.Path.GetFileName(openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1)) + "','bat')";
                if (System.IO.Path.GetFileName(openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1)) == "openFileDialog1")
                {
                    MessageBox.Show("Bạn đã không nhập gì cả ");
                    RequestFailed frm = new RequestFailed();
                    frm.MdiParent = this.ParentForm;
                    this.Close();
                    frm.Show();

                }

                else
                {
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                    listView1.Items.Add(System.IO.Path.GetFileName(openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1)));
                    MessageBox.Show("Đã Nhập Vào Chương Trình Cần Chặn !!!");
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

        private void button4_Click(object sender, EventArgs e)
        {
            TienIchKhac frm = new TienIchKhac();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    
                    query = "UPDATE Status Set BlockProgram = 'BlockProgram'";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Đã Kích Hoạt Chức Năng Chặn Chương Trình Từ Người Dùng !!");

                }

                if (checkBox1.Checked == false)
                {
                    query = "UPDATE Status Set BlockProgram = ''";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Đã Tắt Kích Hoạt Chức Năng Chặn Chương Trình Từ Người Dùng !!");
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
    }
}