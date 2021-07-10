using Clyde.view.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.manager.nav
{
    class CreateEnvironmentNode : NewNodeIf
    {
        public bool CreateAMenu()
        {
            return (false);
        }

        public void CreateMenuMapping(MenuMapper menuMapper)
        {
            throw new NotImplementedException();
        }

        public string NodeName()
        {
            return ("Environment");
        }
    }
}
