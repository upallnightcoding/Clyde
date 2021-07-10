using System.Collections.Generic;

namespace Clyde.view.msg
{
    class PostManager
    {
        // Single instance of message manager
        private static PostManager instance = null;

        // List of all receivers that can receive a message
        private List<PostReceiver> msgReceivers = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        private PostManager()
        {
            msgReceivers = new List<PostReceiver>();
        }

        /***********************/
        /*** Public Function ***/
        /***********************/

        public static PostManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PostManager();
                }

                return (instance);
            }
        }

        /// <summary>
        /// Register() - Allows for the registration of a object that that can
        /// receive a posted message.  If the receiver is null, it can not be
        /// added to the registration list.  The receiver must be created with
        /// the MsgReceiver interface.
        /// </summary>
        /// <param name="receiver"></param>
        public void Register(PostReceiver receiver)
        {
            if (receiver != null)
            {
                msgReceivers.Add(receiver);
            }
        }

        public void Post(PostType type, object dto)
        {
            PostMsg message = new PostMsg(type, dto);

            foreach(PostReceiver receiver in msgReceivers)
            {
                receiver.Receive(message);
            }
        }

        public void Post(PostType type)
        {
            Post(type, null);
        }
    }
}
