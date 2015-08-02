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
    public partial class BlockWebQickSt : DevComponents.DotNetBar.Metro.MetroForm
    {
        public BlockWebQickSt()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

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
                if (checkBox1.Checked )
                {
                    query = "INSERT INTO BlockWebQickSt(Game) VALUES('Game1')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();

                }
                if (checkBox2.Checked)
                {
                    query = "INSERT INTO BlockWebQickSt(Shopping) VALUES('Shopping')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                }

                if (checkBox3.Checked)
                {
                    query = "INSERT INTO BlockWebQickSt(Sexxxx) VALUES('Sexxxx')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                }

                if (checkBox4.Checked)
                {
                    query = "INSERT INTO BlockWebQickSt(Weapon) VALUES('Weapon')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                }
                if (checkBox5.Checked)
                {
                    query = "INSERT INTO BlockWebQickSt(Social) VALUES('Social')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                }
                if (checkBox6.Checked)
                {
                    query = "INSERT INTO BlockWebQickSt(Violent) VALUES('Violent')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                }
                if (checkBox7.Checked)
                {
                    query = "INSERT INTO BlockWebQickSt(Alocol) VALUES('Alocol')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                }
                if (checkBox8.Checked)
                {
                    query = "INSERT INTO BlockWebQickSt(Crime) VALUES('Crime')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                }
                if (checkBox9.Checked)
                {
                    query = "INSERT INTO BlockWebQickSt(Drug) VALUES('Drug')";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                }

                if (checkBox1.Checked == false)
                {
                    query = "DELETE FROM BlockWebQickSt WHERE Game='Game1' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();

                }

                if (checkBox2.Checked == false)
                {
                    query = "DELETE FROM BlockWebQickSt WHERE Shopping='Shopping' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();

                }

                if (checkBox3.Checked == false)
                {
                    query = "DELETE FROM BlockWebQickSt WHERE Sexxxx='Sexxxx' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();

                }

                if (checkBox4.Checked == false)
                {
                    query = "DELETE FROM BlockWebQickSt WHERE Weapon='Weapon'";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();

                }

                if (checkBox5.Checked == false)
                {
                    query = "DELETE FROM BlockWebQickSt WHERE Social='Social' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();

                }

                if (checkBox6.Checked == false)
                {
                    query = "DELETE FROM BlockWebQickSt WHERE Violent='Violent' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();

                }

                if (checkBox7.Checked == false)
                {
                    query = "DELETE FROM BlockWebQickSt WHERE Alocol='Alocol' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();

                }

                if (checkBox8.Checked == false)
                {
                    query = "DELETE FROM BlockWebQickSt WHERE Crime='Crime' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();

                }

                if (checkBox9.Checked == false)
                {
                    query = "DELETE FROM BlockWebQickSt WHERE Drug='Drug' ";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();

                }
                
                
                MessageBox.Show("Đã Cài Đặt Chặn Nội Dung Web Theo Yêu Cầu Người Dùng");
                TienIchKhac frm = new TienIchKhac();
                frm.MdiParent = this.ParentForm;
                this.Close();
                frm.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            TienIchKhac frm = new TienIchKhac();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void BlockWebQickSt_Load(object sender, EventArgs e)
        {
            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                string query = "Select BlockWebQuickly from Status";
                OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                OleDbDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == "BlockWebQuickly")
                    {
                        checkBox1.Checked = true;

                    }
                }
                conn.Close();
                query = "Select Game,Violent,Sexxxx,Alocol,Crime,Weapon,Social,Drug,Shopping from BlockWebQickSt";
                
                sqlCommand = new OleDbCommand(query, conn);
                conn.Open();
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == "Game1")
                    {
                        checkBox1.Checked = true;

                    }

                    if (reader[1].ToString() == "Violent")
                    {
                        checkBox6.Checked = true;

                    }

                    if (reader[2].ToString() == "Sexxxx")
                    {
                        checkBox3.Checked = true;

                    }

                    if (reader[3].ToString() == "Alocol")
                    {
                        checkBox7.Checked = true;

                    }

                    if (reader[4].ToString() == "Crime")
                    {
                        checkBox8.Checked = true;

                    }

                    if (reader[5].ToString() == "Weapon")
                    {
                        checkBox4.Checked = true;

                    }

                    if (reader[6].ToString() == "Social")
                    {
                        checkBox5.Checked = true;

                    }

                    if (reader[7].ToString() == "Drug")
                    {
                        checkBox9.Checked = true;

                    }

                    if (reader[8].ToString() == "Shopping")
                    {
                        checkBox2.Checked = true;

                    }

                    

                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi không xác định");

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            string query = string.Empty;


            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                if (checkBox10.Checked)
                {
                    query = "UPDATE Status Set BlockWebQuickly = 'BlockWebQuickly'";
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    int i = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Đã Kích Hoạt Chức Năng Chặn Web Từ Người Dùng !!");

                }

                if (checkBox10.Checked == false)
                {
                    query = "UPDATE Status Set BlockWebQuickly = ''";
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