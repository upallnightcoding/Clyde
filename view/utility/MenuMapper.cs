using Clyde.view.action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde.view.utility
{
    class MenuMapper
    {
        private Dictionary<string, ToolStripMenuItem> menuMap = null;

        private Dictionary<string, Perform> actionMap = null;

        private MenuStrip menuStrip = null;
        private ContextMenuStrip contextMenu = null;

        private int menuId = 0;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public MenuMapper(MenuStrip menuStrip) : this()
        {
            this.menuStrip = menuStrip;
        }

        public MenuMapper(ContextMenuStrip contextMenu) : this()
        {
            this.contextMenu = contextMenu;
        }

        private MenuMapper()
        {
            this.menuMap = new Dictionary<string, ToolStripMenuItem>();
            this.actionMap = new Dictionary<string, Perform>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void CreateMenu(string path, Perform action)
        {
            string[] menuItemText = (path + '/' + action.Title()).Split('/');
            int menuLevels = menuItemText.Length;
            int level = 1;
            string key = "", separator = "";
            ToolStripMenuItem parent = null;

            foreach (string menuItemName in menuItemText)
            {
                Boolean isLastMenuItem = (menuLevels == level++);

                key += separator + menuItemName;

                if (!menuMap.TryGetValue(key, out ToolStripMenuItem menuItem))
                {
                    menuItem = CreateMenuItem(key, menuItemName, isLastMenuItem, action);

                    AttachMenuItemOption(parent, menuItem);
                }

                parent = menuItem;

                separator = "/";
            }
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        /// <summary>
        /// AttachMenuItemOption() - 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="menuItem"></param>
        private void AttachMenuItemOption(ToolStripMenuItem parent, ToolStripMenuItem menuItem)
        {
            if (parent == null)
            {
                if (menuStrip != null)
                {
                    menuStrip.Items.Add(menuItem);
                }
                else
                {
                    contextMenu.Items.Add(menuItem);
                }
            }
            else
            {
                parent.DropDownItems.Add(menuItem);
            }
        }

        /// <summary>
        /// CreateMenuItem() - 
        /// </summary>
        /// <param name="menuItemName"></param>
        /// <param name="isLastMenuItem"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private ToolStripMenuItem CreateMenuItem(string key, string menuItemName, Boolean isLastMenuItem, Perform action)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();

            item.Name = (++menuId).ToString();
            item.Text = menuItemName;

            if (isLastMenuItem)
            {
                item.Click += new EventHandler(Execute);
            }

            actionMap.Add(item.Name, action);

            menuMap.Add(key, item);

            return (item);
        }

        /// <summary>
        /// Execute() - 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Execute(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            string menuItemName = item.Name;

            if (actionMap.TryGetValue(menuItemName, out Perform action))
            {
                action.Execute();
            }
        }
    }
}
