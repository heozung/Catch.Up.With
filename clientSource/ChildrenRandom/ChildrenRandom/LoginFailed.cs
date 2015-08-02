using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace ChildrenRandom
{
    public partial class LoginFailed : DevComponents.DotNetBar.Metro.MetroForm
    {
        public LoginFailed()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            MenuLogin frm = new MenuLogin();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            Login frm = new Login();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}