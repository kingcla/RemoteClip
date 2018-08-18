using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteCli.WinNotify
{
    internal partial class AppContext : ApplicationContext
    {
        NotifyPanel menu;

        public AppContext()
        {
            InitializeComponent();

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            remoteClipIcon.Visible = true;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //Cleanup so that the icon will be removed when the application is closed
            remoteClipIcon.Visible = false;
        }

        private void RemoteClipIcon_Click(object sender, EventArgs e)
        {
            if (menu == null)
            {
                menu = new NotifyPanel();                
            }
            
            if (!menu.Visible)
            {
                menu.PopUp(Cursor.Position);
            }
            
        }
    }
}
