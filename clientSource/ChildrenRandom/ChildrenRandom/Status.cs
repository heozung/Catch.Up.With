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
    public partial class Status : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Status()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Status_Load(object sender, EventArgs e)
        {
            
            string strDbPath = Application.StartupPath + @"\CodeChildren1Offical.mdb";
            string strCnn = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = " + strDbPath;
            OleDbConnection conn = new OleDbConnection(strCnn);
            try
            {
                conn.Open();
                string query = "Select LimitTime,BlockWeb,BlockWebQuickly,BlockProgram,WindowsSetting,BlockFolder,Status from Status";
                OleDbCommand sqlCommand = new OleDbCommand(query, conn);
                OleDbDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {


                    if (reader[0].ToString() == "LimitTime")
                    {
                        pictureBox1.Image = imageList1.Images[0];

                    }
                    else
                    {
                        pictureBox1.Image = imageList1.Images[1];
                    }

                    if (reader[1].ToString() == "BlockWeb")
                    {
                        pictureBox3.Image = imageList1.Images[0];

                    }
                    else
                    {
                        pictureBox3.Image = imageList1.Images[1];
                    }

                    
                    if (reader[2].ToString() == "BlockWebQuickly")
                    {
                        pictureBox8.Image = imageList1.Images[0];

                    }
                    else
                    {
                        pictureBox8.Image = imageList1.Images[1];
                    }
                    if (reader[3].ToString() == "BlockProgram")
                    {
                        pictureBox4.Image = imageList1.Images[0];

                    }
                    else
                    {
                        pictureBox4.Image = imageList1.Images[1];
                    }
                    if (reader[4].ToString() == "WindowsSetting")
                    {
                        pictureBox5.Image = imageList1.Images[0];

                    }
                    else
                    {
                        pictureBox5.Image = imageList1.Images[1];
                    }
                    if (reader[5].ToString() == "BlockFolder")
                    {
                        pictureBox2.Image = imageList1.Images[0];

                    }
                    else
                    {
                        pictureBox2.Image = imageList1.Images[1];
                    }

                    if (reader[6].ToString() == "bat")
                    {
                        pictureBox7.Image = imageList1.Images[0];

                    }
                    else
                    {
                        pictureBox7.Image = imageList1.Images[1];
                    }
                    if (reader[6].ToString() == "bat")
                    {
                        pictureBox6.Image = imageList1.Images[0];

                    }
                    else
                    {
                        pictureBox6.Image = imageList1.Images[1];
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuOffical frm = new MenuOffical();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}