using Clyde.view.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.manager.nav
{
    class CreateEnvironmentNode : NavNode
    {
        private static string NODE_NAME = "Environment";

        public override Boolean CreateAMenu()
        {
            return (false);
        }

        public override void CreateMenuOptions()
        {
            throw new NotImplementedException();
        }

        public override string NodeName()
        {
            return (NODE_NAME);
        }
    }
}
