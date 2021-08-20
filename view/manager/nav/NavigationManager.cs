using Clyde.view.action;
using Clyde.view.manager.nav;
using Clyde.view.msg;
using Clyde.view.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde.view.manager
{
    class NavigationManager : PostReceiver
    {
        // Root navigation tree object
        private TreeView navigationCntrl = null;

        // Project Node
        private TreeNode projectNode = null;
        private TreeNode environmentNode = null;
        private TreeNode staticObjectNode = null;

        // Object Object Node
        private TreeNode gameObjectNode = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public NavigationManager(TreeView navigationCntrl)
        {
            this.navigationCntrl = navigationCntrl;

            navigationCntrl.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);

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
            switch (message.Type)
            {
                case PostType.CREATE_PROJECT:
                    CreateNewProject();
                    break;
                case PostType.CREATE_SPITE_TAB:
                    CreateStaticObject();
                    break;
            }
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private void CreateNewProject()
        {
            environmentNode = CreateTreeNode(new CreateEnvironmentNode());
            gameObjectNode = CreateTreeNode(new CreateGameNode());

            projectNode = new TreeNode("Project - <UnNamed> ");
            projectNode.Nodes.Add(environmentNode); 
            projectNode.Nodes.Add(gameObjectNode);

            navigationCntrl.Nodes.Add(projectNode);
        }

        /// <summary>
        /// CreateStaticObject() - 
        /// </summary>
        private void CreateStaticObject()
        {
            if (staticObjectNode == null)
            {
                staticObjectNode = new TreeNode("Static Objects");

                gameObjectNode.Nodes.Add(staticObjectNode);
            }

            staticObjectNode.Nodes.Add(new TreeNode("New Static Object"));
        }

        /// <summary>
        /// CreateTreeNode() - 
        /// </summary>
        /// <returns></returns>
        private TreeNode CreateTreeNode(NavNode node)
        {
            return (node.CreateTreeNode());
        }

        /*****************************/
        /*** Menu Options Commands ***/
        /*****************************/

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string msg = e.Node.Text + ":" + ((string)(e.Node.Tag));

            PostManager.Instance.Post(PostType.DISPLAY_MESSAGE, msg);
        }
    }
}
