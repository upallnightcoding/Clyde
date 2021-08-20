using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.graphics
{
    class RendererCreateSprite : Renderer
    {
        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Scene(GraphicsUtility graphicsUtility)
        {
            graphicsUtility.SpriteGrid(8, 8);
        }
    }
}
