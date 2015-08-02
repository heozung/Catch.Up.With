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
    public partial class Thanks : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Thanks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Thanks_Load(object sender, EventArgs e)
        {

        }
    }
}