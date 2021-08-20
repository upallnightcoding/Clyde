using Clyde.view.graphics.renderer;
using System;
using System.Drawing;

namespace Clyde.view.graphics
{
    public abstract class Renderer
    {
        public ConsoleColor BgColor { get; set; } = ConsoleColor.Black;

        /**************************/
        /*** Abstract Functions ***/
        /**************************/

        abstract public void Initialize();

        abstract public void Scene(GraphicsUtility graphicsUtility);

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Config(RenderConfig configure, object data)
        {
            switch(configure)
            {
                case RenderConfig.BG_COLOR:
                    BgColor = (ConsoleColor)data;
                    break;
            }
        }
    }
}
