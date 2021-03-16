using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde.view.manager
{
    class MessageManager
    {
        private ListBox messageCntrl = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public MessageManager(ListBox messageCntrl)
        {
            this.messageCntrl = messageCntrl;
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private void WriteMsg(string text)
        {

        }
    }
}
