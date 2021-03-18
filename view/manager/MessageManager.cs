using Clyde.view.msg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde.view.manager
{
    class MessageManager : MsgReceiver
    {
        private ListBox messageCntrl = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public MessageManager(ListBox messageCntrl)
        {
            this.messageCntrl = messageCntrl;

            MsgManager.Instance.Register(this);
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Receive(MsgPost message)
        {
            switch(message.Type)
            {
                case MsgPostType.DISPLAY_MESSAGE:
                    WriteMsg((string)message.Dto);
                    break;
            }
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private void WriteMsg(string text)
        {
            if (text != null)
            {
                messageCntrl.Items.Add(text);
            }
        }
    }
}
