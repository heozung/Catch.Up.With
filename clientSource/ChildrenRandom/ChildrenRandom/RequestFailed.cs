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
    public partial class RequestFailed : DevComponents.DotNetBar.RibbonForm
    {
        public RequestFailed()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Tienich frm = new Tienich();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }
    }
}