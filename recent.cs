using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Drawing.Imaging;

namespace Video_Player
{
    public partial class recent : UserControl
       
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "nX9ECkVBWhH7oOKqtqwyDofgKbdg6tWThflaKjdt",
            BasePath = "https://ds-project-7c104-default-rtdb.firebaseio.com/"
        };

        public IFirebaseClient client;
        public recent()
        {
            InitializeComponent();
        }

        private void recent_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show("Connection Established");
            }
            else
            {
                MessageBox.Show("Connection Not Established");
            }
            //populatepanel1();
        }
        
    }
}
