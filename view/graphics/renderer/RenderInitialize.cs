using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.graphics.renderer
{
    class RenderInitialize : Renderer
    {
        public override void Initialize()
        {
            Config(RenderConfig.BG_COLOR, ConsoleColor.Green);
        }

        public override void Scene(GraphicsUtility graphicsUtility)
        {
            
        }
    }
}
