using Clyde.view.action;
using Clyde.view.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.manager.nav
{
    class CreateGameNode : NavNode
    {
        private static string NODE_NAME = "Game Objects";

        public override Boolean CreateAMenu()
        {
            return (true);
        }

        public override void CreateMenuOptions()
        {
            CreateMenuItem("Create/Static Object", new ActionCreateSprite());
            CreateMenuItem("Create/Static/Object", new ActionCreateSprite());
        }

        public override string NodeName()
        {
            return (NODE_NAME);
        }
    }
}
