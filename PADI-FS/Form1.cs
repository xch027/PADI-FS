using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PuppetMaster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcStart_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\ChenXiao\Documents\Visual Studio 2010\Projects\DS\DS\bin\Debug\DS.exe");
        }
    }
}
