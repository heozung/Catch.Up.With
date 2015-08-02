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
    public partial class Intro : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

       

        private void Intro_Load(object sender, EventArgs e)
        {
            textBox1.Text = Environment.MachineName;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Idea frm = new Idea();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}