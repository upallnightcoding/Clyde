using Clyde.view.msg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde.view.manager
{
    class MessageManager : PostReceiver
    {
        private ListBox messageCntrl = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public MessageManager(ListBox messageCntrl)
        {
            this.messageCntrl = messageCntrl;

            PostManager.Instance.Register(this);
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Receive() - 
        /// </summary>
        /// <param name="message"></param>
        public void Receive(PostMsg message)
        {
            switch(message.Type)
            {
                case PostType.DISPLAY_MESSAGE:
                    WriteMsg((string)message.Dto);
                    break;
            }
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        /// <summary>
        /// WriteMsg() - Displays the text of a message the text message controller.
        /// If the text is null the message is not displayed.
        /// </summary>
        /// <param name="text"></param>
        private void WriteMsg(string text)
        {
            if (text != null)
            {
                messageCntrl.Items.Add(text);
            }
        }
    }
}
