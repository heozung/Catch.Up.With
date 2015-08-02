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
    public partial class TimerSetting : DevComponents.DotNetBar.Metro.MetroForm
    {
        public TimerSetting()
        {
            InitializeComponent();
        }

        private void TimerSetting_Load(object sender, EventArgs e)
        {
            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                string query = "Select LimitTime from Status where LimitTime='LimitTime'";
                OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                OleDbDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == "LimitTime")
                    {
                        checkBox9.Checked = true;

                    }
                }
                conn.Close();
                query = "Select Thu From Ngay";
                sqlCommand = new OleDbCommand(query, conn);
                conn.Open();
                reader = sqlCommand.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == "Sunday")
                        {
                            checkBox1.Checked = true;

                        }

                        if (reader[0].ToString() == "Tuesday")
                        {
                            checkBox2.Checked = true;

                        }

                        if (reader[0].ToString() == "Wednesday")
                        {
                            checkBox4.Checked = true;

                        }

                        if (reader[0].ToString() == "Thursday")
                        {
                            checkBox5.Checked = true;

                        }

                        if (reader[0].ToString() == "Friday")
                        {
                            checkBox6.Checked = true;

                        }

                        if (reader[0].ToString() == "Sat")
                        {
                            checkBox7.Checked = true;

                        }

                        if (reader[0].ToString() == "Monday")
                        {
                            checkBox3.Checked = true;

                        }


                    }
                }
                catch
                { }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                conn.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuOffical frm = new MenuOffical();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            OleDbCommand sqlCommand;

            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                if (radioButton1.Checked)
                {
                    query = "INSERT INTO LimitTime(Hours1,Minutes1)  VALUES('" + textBox5.Text + "', '" + textBox3.Text + "')";
                }
                else
                {
                    query = "INSERT INTO LimitTimeFrTo(FromHour,FromMinute,ToHour,Minute) VALUES ('" + textBox4.Text + "', '" + textBox2.Text + "','" + textBox1.Text + "','" + textBox6.Text + "')";
                }

                sqlCommand = new OleDbCommand(query, conn);
                sqlCommand.ExecuteNonQuery();
                conn.Close();

                if ( checkBox8.Checked == true)
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                }
                else
                {
                    string checkpro = string.Empty;
                    if ( checkBox1.Checked == true)
                    {
                        conn.Open();
                        checkpro = "INSERT INTO Ngay(Thu) VALUES('Sunday')";
                        sqlCommand = new OleDbCommand(checkpro, conn);
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }

                    if (checkBox2.Checked == true)
                    {
                        conn.Open();
                        checkpro = "INSERT INTO Ngay(Thu) VALUES('Tuesday')";
                        sqlCommand = new OleDbCommand(checkpro, conn);
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }

                    if (checkBox3.Checked == true)
                    {
                        conn.Open();
                        checkpro = "INSERT INTO Ngay(Thu) VALUES('Monday')";
                        sqlCommand = new OleDbCommand(checkpro, conn);
                         sqlCommand.ExecuteNonQuery();
                         conn.Close();
                    }

                    if (checkBox4.Checked == true)
                    {
                        conn.Open();
                        checkpro = "INSERT INTO Ngay(Thu) VALUES('Wednesday')";
                        sqlCommand = new OleDbCommand(checkpro, conn);
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }

                    if (checkBox5.Checked == true)
                    {
                        conn.Open();
                        checkpro = "INSERT INTO Ngay(Thu) VALUES('Thursday')";
                        sqlCommand = new OleDbCommand(checkpro, conn);
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }

                    if (checkBox6.Checked == true)
                    {
                        conn.Open();
                        checkpro = "INSERT INTO Ngay(Thu) VALUES('Friday')";
                        sqlCommand = new OleDbCommand(checkpro, conn);
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }

                    if (checkBox7.Checked == true)
                    {
                        conn.Open();
                        checkpro = "INSERT INTO Ngay(Thu) VALUES('Sat')";
                        sqlCommand = new OleDbCommand(checkpro, conn);
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }


                }

                string uncheck = string.Empty;
               
                    if(checkBox1.Checked == false)
                    {
                        conn.Open();
                        query = "DELETE  From Ngay WHERE Thu='Sunday'";
                        sqlCommand = new OleDbCommand(query, conn);
                       sqlCommand.ExecuteNonQuery();
                       conn.Close();
                    }

                    if (checkBox2.Checked == false)
                    {
                        conn.Open();
                        query = "DELETE From Ngay WHERE Thu='Tuesday' ";
                        sqlCommand = new OleDbCommand(query, conn);
                       sqlCommand.ExecuteNonQuery();
                       conn.Close();
                    }
                    if (checkBox3.Checked == false)
                    {
                        conn.Open();
                        query = "DELETE From Ngay WHERE Thu='Monday' "; // sai chinh ta nay
                        sqlCommand = new OleDbCommand(query, conn);
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (checkBox4.Checked == false)
                    {
                        conn.Open();
                        query = "DELETE From Ngay WHERE Thu='Wednesday' "; // ko duoc dung day, Day
                        sqlCommand = new OleDbCommand(query, conn);
                       sqlCommand.ExecuteNonQuery();
                       conn.Close();
                    }
                    if (checkBox5.Checked == false)
                    {
                        conn.Open();
                        query = "DELETE From Ngay WHERE Thu='Thursday' ";
                        sqlCommand = new OleDbCommand(query, conn);
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (checkBox6.Checked == false)
                    {
                        conn.Open();
                        query = "DELETE From Ngay WHERE Thu='Friday' ";
                        sqlCommand = new OleDbCommand(query, conn);
                       sqlCommand.ExecuteNonQuery();
                       conn.Close();
                    }
                    if (checkBox7.Checked == false)
                    {
                        conn.Open();
                        query = "DELETE From Ngay WHERE Thu='Sat' ";
                        sqlCommand = new OleDbCommand(query, conn);
                       sqlCommand.ExecuteNonQuery();
                       conn.Close();
                    }

               
                   MessageBox.Show("Đã Nhập Thời Gian Cần Chặn Theo Người Dùng");
                   conn.Open();
               
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox4.Enabled = true;
                textBox6.Enabled = true;
                textBox5.Enabled = false;
                textBox3.Enabled = false;
            }
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox4.Enabled = false;
                textBox6.Enabled = false;
                textBox5.Enabled = true;
                textBox3.Enabled = true;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            string query = string.Empty;


            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                if (checkBox9.Checked == true)
                {
                    query = "UPDATE Status Set LimitTime = 'LimitTime'";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Time Setting Is Enable From User !!");


                }

                if (checkBox9.Checked == false)
                {
                    query = "UPDATE Status Set LimitTime = ''";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("TurnOff Time Is Disabled From User !!");
                }
                conn.Close();
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

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuOffical frm = new MenuOffical();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HistoryOfTime frm = new HistoryOfTime();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}