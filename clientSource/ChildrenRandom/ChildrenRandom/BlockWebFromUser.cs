using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;



namespace ChildrenRandom
{
    public partial class BlockWebFromUser : DevComponents.DotNetBar.Metro.MetroForm
    {
        public BlockWebFromUser()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                string[] words;
                string newwords = "";
                Boolean chkiKid = false;
                string FileName = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\drivers\etc\hosts";
                if (File.Exists(FileName))
                {
                    words = File.ReadAllLines(FileName, Encoding.Default);
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i] != "#iKidStart")
                        {
                            if (chkiKid == false)
                            {
                                newwords += words[i] + "\n";
                            }
                        }
                        else if (words[i] == "#iKidStart")
                        {
                            chkiKid = true;
                        }
                        else if (words[i] == "#iKidEnd")
                        {
                            chkiKid = false;
                        }
                    }
                }
                newwords += "#iKidStart\n";
                
                conn.Open();
                string sql = "DELETE from BlockWeb";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteScalar();
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    sql = "Insert Into BlockWeb(LinkWeb,Status) values('" + listView1.Items[i].Text + "','bat')";
                    //newwords += "210.211.126.218 " + listView1.Items[i].Text + "\n";
                    // newwords += "210.211.126.218 www." + listView1.Items[i].Text + "\n";
                    newwords += "127.0.0.1 " + listView1.Items[i].Text + "\n";
                    newwords += "127.0.0.1 www." + listView1.Items[i].Text + "\n";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteScalar();
                }
                newwords += "#iKidEnd";
                StreamWriter writer = new StreamWriter(FileName);
                writer.Write(newwords);
                writer.Close();               
                MessageBox.Show("Đã lưu trữ danh sách TRANG WEB CẤM thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi của chương trình");
            }
            finally
            {
                conn.Close();
            }
            



            TienIchKhac frm = new TienIchKhac();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }
        public void Delete(string txt)
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
                    conn.Open();
                    string query = " Delete From BlockWeb Where LinkWeb ='" + listView1.SelectedItems[0].Text+ "'"; 
                    MessageBox.Show("Đã xóa bản ghi thành công", "Thông báo", MessageBoxButtons.OK);
                   
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

        private void button1_Click(object sender, EventArgs e)
        {
           
                listView1.Items.Add(LinkWeb.Text);

        }

        private void BlockWebFromUser_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
                    
            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                string query = "Select LinkWeb from BlockWeb";
                OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                OleDbDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    //int i = sqlCommand.ExecuteNonQuery;
                    listView1.Items.Add(reader[0].ToString());
                    
                }

                query = "Select BlockWeb from Status";
                sqlCommand = new OleDbCommand(query, conn);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == "BlockWeb")
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
                    query = "UPDATE Status Set BlockWeb = 'BlockWeb'";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Đã Kích Hoạt Chức Năng Chặn Web Từ Người Dùng !!");

                }

                if (checkBox1.Checked == false)
                {
                    query = "UPDATE Status Set BlockWeb = ''";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Đã Tắt Kích Hoạt Chức Năng Chặn Web Từ Người Dùng !!");
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