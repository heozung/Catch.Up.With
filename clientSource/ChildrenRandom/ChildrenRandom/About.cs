using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Diagnostics;

namespace ChildrenRandom
{
    public partial class About : DevComponents.DotNetBar.Metro.MetroForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            MenuOffical frm = new MenuOffical();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
 
            
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            Intro frm = new Intro();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
 

        }

        private void metroTilePanel1_ItemClick(object sender, EventArgs e)
        {

        }

        private void metroTileItem3_Click(object sender, EventArgs e)
        {
            Process.Start("baocao.docx", "C:\\Users\\Hung\\Documents\\Visual Studio 2013\\Projects\\ChildrenRandom\\ChildrenRandom\\bin\\Release\\baocao.docx");

        }

        private void metroTileItem5_Click(object sender, EventArgs e)
        {
            UpdateSucess frm = new UpdateSucess();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();

        }
    }
}