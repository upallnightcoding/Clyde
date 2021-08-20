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
            InitializeGlobalObjects();

            CreateManagerObjects();

            CreateMenuSystem();
        }

        /*********************/
        /*** Menu Commands ***/
        /*********************/

        /// <summary>
        /// InitializeGlobalObjects() - 
        /// </summary>
        private void InitializeGlobalObjects()
        {
            animationWindow.Initialize();
        }

        /// <summary>
        /// CreateManagerObjects() - Create all of the manager objects that 
        /// are used to control the components in the different panels.  
        /// These objects must be create during startup of the application.
        /// </summary>
        private void CreateManagerObjects()
        {
            // Define the manager objects that control the panels
            //---------------------------------------------------
            workSpaceManager = new WorkSpaceManager(formsWindow, animationWindow);
            navigationManager = new NavigationManager(navigationCntrl);
            messageManager = new MessageManager(messageCntrl);
            menuManager = new MenuManager(menuStrip1);
        }

        /// <summary>
        /// CreateMenuSystem() - 
        /// </summary>
        private void CreateMenuSystem()
        {
            menuManager.CreateMenuItem("File", new ActionNewProject());

            menuManager.CreateMenuItem("Test/Menu1/Project1", new ActionNewProject());
            menuManager.CreateMenuItem("Test/Menu2/Project2/ProjectA", new ActionNewProject());
            menuManager.CreateMenuItem("Test/Menu3/Project3/ProjectB", new ActionNewProject());
        }
    }
}
