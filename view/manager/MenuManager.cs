using Clyde.view.action;
using Clyde.view.utility;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Clyde.view.manager
{
    class MenuManager
    {
        private MenuMapper menuMapper = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public MenuManager(MenuStrip menuStrip)
        {
            this.menuMapper = new MenuMapper(menuStrip);
        }

        public MenuManager()
        {

        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// createMenu() - 
        /// </summary>
        /// <param name="path"></param>
        public void CreateMenuItem(string path, Perform action)
        {
            menuMapper.CreateMenu(path, action);
        }
    }
}
