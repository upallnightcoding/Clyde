using Clyde.view.action;
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
        private MenuManager menuManager = null;

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

            menuManager = new MenuManager(menuStrip1);

            menuManager.CreateMenu("Test/Menu1/Project1", new ActionNewProject());
            menuManager.CreateMenu("Test/Menu2/Project2/ProjectA", new ActionNewProject());
            menuManager.CreateMenu("Test/Menu3/Project3/ProjectB", new ActionNewProject());

            menuManager.CreateMenu("File ...", new ActionNewProject());
        }

        /*********************/
        /*** Menu Commands ***/
        /*********************/

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
