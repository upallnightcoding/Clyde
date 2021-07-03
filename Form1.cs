using Clyde.view.manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde
{
    public partial class Form1 : Form
    {
        private WorkSpaceManager workSpaceManager = null;
        private NavigationManager navigationManager = null;
        private MessageManager messageManager = null;

        public Form1()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            animationWindow.Initialize();

            // Define the manager objects that control the panels
            //---------------------------------------------------
            workSpaceManager = new WorkSpaceManager(workSpaceTabCntrl, animationWindow);
            navigationManager = new NavigationManager(navigationCntrl);
            messageManager = new MessageManager(messageCntrl);
        }

        /*********************/
        /*** Menu Commands ***/
        /*********************/

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigationManager.createNewProject();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
