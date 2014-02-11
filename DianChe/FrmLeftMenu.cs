using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DianChe
{
    public partial class FrmLeftMenu : DockContent
    {
        public FrmLeftMenu()
        {
            InitializeComponent();
        }

        private void FrmLeftMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
