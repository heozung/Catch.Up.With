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
    public partial class Idea : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Idea()
        {
            InitializeComponent();
        }

        private void Windows_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Cám Ơn Bạn Đã Ghé Thăm");
            MenuOffical frm = new MenuOffical();
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
                query = "INSERT INTO About(Name, Version , FromDate , ToDate ,IdeaFr , Email) VALUES('" + textBox1.Text + "','1.0.0.2','unlimited', 'unlimited','" + textBox2.Text + "')";
                OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                int i = sqlCommand.ExecuteNonQuery();
                //button1.Items.Add(textBox1);
               // button1.Items.Add(textBox2);
                
                MessageBox.Show("Cám ơn bạn đã góp ý cho chúng tôi");
                MessageBox.Show("Mọi ý kiến của bạn sẽ được lắng nghe giúp phần mềm phát triển ");
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