using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.OleDb;
using System.Diagnostics;

namespace ChildrenRandom
{
    public partial class History : DevComponents.DotNetBar.Metro.MetroForm
    {
        public History()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            //string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            //OleDbConnection conn = new OleDbConnection(strCnn);
            //try
            //{
            //    conn.Open();
            //    string query = "Select Activities AND Hour AND Minutes from History";
            //    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
            //    OleDbDataReader reader = sqlCommand.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        //int i = sqlCommand.ExecuteNonQuery
            //        listView1.Items.Add(reader[0].ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.StackTrace);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TienIchKhac frm = new TienIchKhac();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            //string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            //OleDbConnection conn = new OleDbConnection(strCnn);
            //if (MessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        conn.Open();
            //        string query = " Delete From History Where Activities ='" + listView1.SelectedItems[0].Text + "'";
            //        MessageBox.Show("Đã xóa bản ghi thành công", "Thông báo", MessageBoxButtons.OK);

            //        OleDbCommand sqlCommand = new OleDbCommand(query, conn);
            //        sqlCommand.ExecuteNonQuery();
            //        listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                    

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Không thể xóa bản ghi này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        MessageBox.Show(ex.Message);
            //        conn.Close();
            //        conn.Dispose();
            //        return;
            //    }
            //}
            //return;
        }
        public void ReadLogs()
        {
            //logType can be Application, Security, System or any other Custom Log.
            string logType = "Application";

            DataTable dtable = new DataTable("EventViewer");

            DataColumn column;
            DataRow row;
            int i = 0;
            int LastLogToShow = 0;

            // Create new DataColumn, set DataType,
            // ColumnName and add to DataTable.   

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "InstanceID";
            column.ReadOnly = true;

            // Add the Column to the DataColumnCollection.
            dtable.Columns.Add(column);

            // Create new DataColumn, set DataType,
            // ColumnName and add to DataTable.   
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Source";
            column.ReadOnly = true;

            // Add the Column to the DataColumnCollection.
            dtable.Columns.Add(column);

            // Create new DataColumn, set DataType,
            // ColumnName and add to DataTable.   
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EntryType";
            column.ReadOnly = true;

            // Add the Column to the DataColumnCollection.
            dtable.Columns.Add(column);

            // Create new DataColumn, set DataType,
            // ColumnName and add to DataTable.   
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "Date";
            column.ReadOnly = true;

            // Add the Column to the DataColumnCollection.
            dtable.Columns.Add(column);


            // Create new DataColumn, set DataType,
            // ColumnName and add to DataTable.   
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Message";
            column.ReadOnly = true;

            // Add the Column to the DataColumnCollection.
            dtable.Columns.Add(column);


            try
            {

                EventLog ev = new EventLog(logType, System.Environment.MachineName);
                LastLogToShow = ev.Entries.Count;

                if (LastLogToShow <= 0)
                {
                    msds.DataSource = null;
                    MessageBox.Show("No log in the Event Viewer");
                    return;
                }


                for (i = ev.Entries.Count - 1; i > 0; i--)
                {
                    EventLogEntry CurrentEntry = ev.Entries[i];

                    row = dtable.NewRow();

                    row["InstanceID"] = CurrentEntry.InstanceId;
                    row["EntryType"] = Convert.ToString(CurrentEntry.EntryType);
                    row["Date"] = Convert.ToDateTime(CurrentEntry.TimeGenerated);
                    row["Source"] = Convert.ToString(CurrentEntry.Source);
                    row["Message"] = Convert.ToString(CurrentEntry.Message);

                    dtable.Rows.Add(row);


                }
                ev.Close();


                if (dtable.Rows.Count > 0)
                {

                    msds.DataSource = dtable;

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void History_Load(object sender, EventArgs e)
        {
            ReadLogs();
            //listView1.Items.Clear();
                    
            //string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            //string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            //OleDbConnection conn = new OleDbConnection(strCnn);
            //try
            //{
            //    conn.Open();
            //    string query = "Select Activities,Hours,Minutes from BlockWeb";
            //    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
            //    OleDbDataReader reader = sqlCommand.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        ListViewItem lvi1 = new ListViewItem();
            //        lvi1.Text = reader[0].ToString();
            //        lvi1.SubItems.Add(reader[1].ToString());
            //        lvi1.SubItems.Add(reader[2].ToString());
            //        listView1.Items.Add(lvi1);

            //    }
            //}

            //catch
            //{
            //    MessageBox.Show("Không có lược sử nào được ghi");
            //    conn.Close();
            //    conn.Dispose();

            //}
        }
    }
}