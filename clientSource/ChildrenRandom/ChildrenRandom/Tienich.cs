using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using Microsoft.Win32;
using Microsoft.VisualBasic;

namespace ChildrenRandom
{
    public partial class Tienich : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        public Tienich()
        {
            InitializeComponent();
        }

        private void metroTabPanel1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void metroShell1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MenuLogin frm = new MenuLogin();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuOffical frm = new MenuOffical();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RequestFailed frm = new RequestFailed();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RequestSuccess frm = new RequestSuccess();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        public void Tienich_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(String.Empty);
            String os = Environment.OSVersion.Version.ToString();
            textBox2.Text = os;
            textBox1.Text = Environment.MachineName;
            String bit = Environment.OSVersion.Platform.ToString();
            textBox3.Text = bit;
            String sppedcpu = Environment.Version.ToString();
            textBox4.Text = sppedcpu;
            //ebBrowser wb = new WebBrowser();
            //wb.AllowNavigation = true;
            //wb.Navigate("http://www.google.com/");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://childrensecurity.tk");
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}