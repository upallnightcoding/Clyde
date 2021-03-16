using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde.view.manager
{
    class NavigationManager
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
        }

        public void createNewProject()
        {
            projectNode = new TreeNode("Project - <UnNamed> ");

            navigationCntrl.Nodes.Add(projectNode);

            environmentNode = CreateEnvironmentNode();
            gameObjectNode = CreateGameObjectNode();

            projectNode.Nodes.Add(environmentNode);
            projectNode.Nodes.Add(gameObjectNode);
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private TreeNode CreateEnvironmentNode()
        {
            TreeNode environmentNode = new TreeNode("Environment");

            return (environmentNode);
        }

        private TreeNode CreateGameObjectNode()
        {
            // Create Menu Items
            ToolStripMenuItem staticObjectMenuItem = new ToolStripMenuItem("Static Object");
            ToolStripMenuItem spriteObjectMenuItem = new ToolStripMenuItem("Sprite");
            ToolStripMenuItem dynObjectMenuItem = new ToolStripMenuItem("Dynamic Object");
            ToolStripMenuItem animSpriteObjectMenuItem = new ToolStripMenuItem("Animated Sprite");
            ToolStripMenuItem createMenuItem = new ToolStripMenuItem("Create");

            //Apply Menu Item Actions
            spriteObjectMenuItem.Click += new System.EventHandler(this.CreateStaticSprite_Click);

            // Create Menu Pulldowns
            staticObjectMenuItem.DropDownItems.Add(spriteObjectMenuItem);
            dynObjectMenuItem.DropDownItems.Add(animSpriteObjectMenuItem);

            createMenuItem.DropDownItems.Add(staticObjectMenuItem);
            createMenuItem.DropDownItems.Add(dynObjectMenuItem);

            // Create Context Menu
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add(createMenuItem);

            // Create Tree Node and Apply Context Menu
            TreeNode gameObjectNode = new TreeNode("Game Objects");
            gameObjectNode.ContextMenuStrip = contextMenu;

            return (gameObjectNode);
        }

        /*****************************/
        /*** Menu Options Commands ***/
        /*****************************/

        private void CreateStaticSprite_Click(object sender, EventArgs e)
        {
            if (staticObjectNode == null)
            {
                staticObjectNode = new TreeNode("Static Objects");
                staticObjectNode.Tag = "Static Object Tab";

                gameObjectNode.Nodes.Add(staticObjectNode);
            }

            staticObjectNode.Nodes.Add(new TreeNode("New Static Object"));
        
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show(e.Node.Text + ":" + ((string)(e.Node.Tag)));
        }
    }
}
