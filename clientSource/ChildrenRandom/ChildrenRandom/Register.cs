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
    public partial class Register : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox8.Text = Environment.MachineName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            MenuLogin frm = new MenuLogin();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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
                string aaa = MaHoa.MD5Hash(MaHoa.MD5Hash(textBox6.Text));
                query = "INSERT INTO UserOffline(Email, Username , [Password], NameCPT,LastName,PhoneNumber) VALUES('" + textBox3.Text + "','" + textBox5.Text + "', '" +aaa + "','" + textBox8.Text + "','" + textBox2.Text + "','" + textBox4.Text + "')";
                if (textBox7.Text == textBox6.Text)
                {
                    OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                    sqlCommand.ExecuteScalar();
                    MessageBox.Show("Đã Hoàn Tất Đăng Ký Thông Tin !!! - Cám Ơn Bạn Đã Sử Dụng Chương Trình");

                }

                else
                {
                    MessageBox.Show("Vui Lòng Nhập Lại Password");
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}