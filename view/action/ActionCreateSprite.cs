using Clyde.view.msg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde.view.action
{
    class ActionCreateSprite : Perform
    {
        // Class Constants
        //----------------
        private const string TITLE = "Create Sprite";

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Execute()
        {
            PostManager.Instance.Post(PostType.CREATE_SPITE_TAB);
        }

        public string Title()
        {
            return (TITLE);
        }
    }
}
