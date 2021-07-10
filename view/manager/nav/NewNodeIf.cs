using Clyde.view.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.manager.nav
{
    interface NewNodeIf
    {
        void CreateMenuMapping(MenuMapper menuMapper);

        Boolean CreateAMenu();

        /// <summary>
        /// NodeName() - Determines the name of the node. This value should
        /// not be null.  The name is display as the node name when the 
        /// branch containing the node is expanded.
        /// </summary>
        /// <returns></returns>
        string NodeName();
    }
}
