using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ChildrenRandom
{
    public partial class MenuLogin : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        public MenuLogin()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MenuOffical frm = new MenuOffical();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();

        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            Register frm = new Register();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
            
        }

        private void metroTilePanel1_ItemClick(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void metroTileItem3_Click(object sender, EventArgs e)
        {

            ForgetPass frm = new ForgetPass();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show(); 
        }
        public void MenuLogin_Load(object sender , EventArgs e)
        {

        }
    }
}