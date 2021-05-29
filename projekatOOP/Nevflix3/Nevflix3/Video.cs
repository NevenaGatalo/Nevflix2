using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nevflix3
{
    public partial class Video : Form
    {

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public Video()
        {
            InitializeComponent();
            PustiVideo();
        }

        private void PustiVideo()
        {
            url = forma.prosledi;
            webBrowser.Navigate(url);
        }
    }
}
