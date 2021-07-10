using Clyde.view.action;
using Clyde.view.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.manager.nav
{
    class CreateGameNode : NewNodeIf
    {
        public bool CreateAMenu()
        {
            return (true);
        }

        public void CreateMenuMapping(MenuMapper menuMapper)
        {
            menuMapper.CreateMenu("Create/Static Object", new ActionCreateSprite());
            menuMapper.CreateMenu("Create/Static/Object", new ActionCreateSprite());
        }

        public string NodeName()
        {
            return ("Game Objects");
        }
    }
}
