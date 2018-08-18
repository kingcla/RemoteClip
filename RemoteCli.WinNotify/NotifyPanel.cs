using RemoteCli.WinNotify.Properties;
using RemoteClip.Client.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteCli.WinNotify
{
    public partial class NotifyPanel : Form
    {
        public NotifyPanel()
        {
            InitializeComponent();            

            Visible = false;

            CodeGenerator cg = new CodeGenerator();
            
            pictureBox1.Image = cg.GetCodeImage("TESTINGGG TESTINGGG TESTINGGG TESTINGGG TESTINGGG TESTINGGG");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        internal void PopUp(Point position)
        {            
            Location = new Point(position.X - (Width), position.Y - (Height + 5));
   

            ShowDialog();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Hide();
        }
    }
}


