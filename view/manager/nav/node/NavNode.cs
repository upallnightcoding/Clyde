using Clyde.view.action;
using Clyde.view.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde.view.manager.nav
{
    abstract class NavNode
    {
        private MenuMapper menuMapper = null;

        /**************************/
        /*** Abstract Functions ***/
        /**************************/

        /// <summary>
        /// CreateMenuOptions() - 
        /// </summary>
        abstract public void CreateMenuOptions();

        /// <summary>
        /// CreateAMenu() - Retures a true or false, if the node is to have
        /// a menu assoicated with it.  The menu is initiated by a right 
        /// click.  
        /// </summary>
        /// <returns></returns>
        abstract public Boolean CreateAMenu();

        /// <summary>
        /// NodeName() - Determines the name of the node. This value should
        /// not be null.  The name is displayed as the node name when the 
        /// branch containing the node is expanded.
        /// </summary>
        /// <returns></returns>
        abstract public string NodeName();

        /***************************/
        /*** Protected Functions ***/
        /***************************/

        /// <summary>
        /// CreateMenuItem() - 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="action"></param>
        protected void CreateMenuItem(string path, Perform action)
        {
            if (menuMapper != null)
            {
                menuMapper.CreateMenu(path, action);
            }
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        /// <summary>
        /// CreateTreeNode() - 
        /// </summary>
        /// <returns></returns>
        public TreeNode CreateTreeNode()
        {
            TreeNode newNode = new TreeNode(NodeName());

            if (CreateAMenu())
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                menuMapper = new MenuMapper(contextMenu);

                newNode.ContextMenuStrip = contextMenu;

                CreateMenuOptions();
            }

            return (newNode);
        } 
    }
}
