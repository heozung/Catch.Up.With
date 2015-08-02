using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.OleDb;

namespace ChildrenRandom
{
    public partial class HistoryOfTime : DevComponents.DotNetBar.Metro.MetroForm
    {
        public HistoryOfTime()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    string query = " Delete From LimitTimeFrTo Where FromHour ='" + listView1.SelectedItems[0].Text + "'";
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
                    string query = " Delete From LimitTime Where Hours ='" + listView2.SelectedItems[0].Text + "'";
                    MessageBox.Show("Đã xóa bản ghi thành công", "Thông báo", MessageBoxButtons.OK);

                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                    listView2.Items.RemoveAt(listView1.SelectedIndices[0]);

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

        private void HistoryOfTime_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();

            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                string query = "Select FromHour,FromMinute,ToHour, Minute from LimitTimeFrTo";
                OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                OleDbDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    //int i = sqlCommand.ExecuteNonQuery;
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = reader[0].ToString();
                    lvi.SubItems.Add(reader[1].ToString());
                    lvi.SubItems.Add(reader[2].ToString());
                    lvi.SubItems.Add(reader[3].ToString());
                    listView1.Items.Add(lvi);

                }

                query = "Select Hours,Minute from LimitTime";
                sqlCommand = new OleDbCommand(query, conn);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem lvi1 = new ListViewItem();
                    lvi1.Text = reader[0].ToString();
                    lvi1.SubItems.Add(reader[1].ToString());
                    listView2.Items.Add(lvi1);

                }
            }

            catch
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimerSetting frm = new TimerSetting();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}