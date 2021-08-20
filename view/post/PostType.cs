using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.msg
{
    enum PostType
    {
        // Default posting type
        UNKNOWN,

        // Sets the current color for drawing
        SET_DRAWING_COLOR,

        // Display a message in the message panel
        DISPLAY_MESSAGE,
        CREATE_PROJECT,
        CREATE_SPITE_TAB
    }
}
