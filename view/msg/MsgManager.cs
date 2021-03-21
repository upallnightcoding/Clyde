using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.msg
{
    class MsgManager
    {
        // Single instance of message manager
        private static MsgManager instance = null;

        // List of all receivers that can receive a message
        private List<MsgReceiver> msgReceivers = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        private MsgManager()
        {
            msgReceivers = new List<MsgReceiver>();
        }

        /***********************/
        /*** Public Function ***/
        /***********************/

        public static MsgManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MsgManager();
                }

                return (instance);
            }
        }

        public void Register(MsgReceiver receiver)
        {
            if (receiver != null)
            {
                msgReceivers.Add(receiver);
            }
        }

        public void Post(MsgPostType type, object dto)
        {
            MsgPost message = new MsgPost(type, dto);

            foreach(MsgReceiver receiver in msgReceivers)
            {
                receiver.Receive(message);
            }
        }

        public void Post(MsgPostType type)
        {
            Post(type, null);
        }


    }
}
