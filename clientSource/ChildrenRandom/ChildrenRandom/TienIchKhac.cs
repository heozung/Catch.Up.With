using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace ChildrenRandom
{
    public partial class TienIchKhac : DevComponents.DotNetBar.Metro.MetroForm
    {
        [DllImport("user32.dll")]
        public static extern void LockWorkStation();
        public TienIchKhac()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuOffical frm = new MenuOffical();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BlockWebFromUser frm = new BlockWebFromUser();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void TienIchKhac_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            BlockProgram frm = new BlockProgram();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BlockWebQickSt frm = new BlockWebQickSt();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MenuOffical frm = new MenuOffical();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Shutdown", "-s -f -t 1");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LimitSoft frm = new LimitSoft();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            History frm = new History();
            frm.MdiParent = this.ParentForm;
            this.Close();
            frm.Show();

        }
        // Enable Connection ( using offline )
        static void button4_Click(object sender, EventArgs e,string interfaceName)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LockMay();
        }

        

        static void LockMay()
        {
            LockWorkStation();
        }
    }
}