using RemoteCli.WinNotify.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteCli.WinNotify
{
    internal partial class AppContext
    {
        private void InitializeComponent()
        {
            this.remoteClipIcon = new NotifyIcon();


            this.remoteClipIcon.Icon = Resources.paper_clip;
            this.remoteClipIcon.Visible = true;
            this.remoteClipIcon.Click += RemoteClipIcon_Click;

        }

        private NotifyIcon remoteClipIcon;
    }
}
