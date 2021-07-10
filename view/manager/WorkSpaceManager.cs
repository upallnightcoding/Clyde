using Clyde.view.form;
using Clyde.view.msg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde
{
    class WorkSpaceManager : PostReceiver
    {
        private TabControl workSpaceTabCntrl = null;
        private AnimationWindow animationWindow = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public WorkSpaceManager(
            TabControl workSpaceTabCntrl, 
            AnimationWindow animationWindow
        )
        {
            this.workSpaceTabCntrl = workSpaceTabCntrl;
            this.animationWindow = animationWindow;

            CreateTab("Game Play", new GamePlayForm(animationWindow));

            PostManager.Instance.Register(this);
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Receive() - Receiver of posted message.
        /// </summary>
        /// <param name="message"></param>
        public void Receive(PostMsg message)
        {
            switch(message.Type)
            {
                case PostType.CREATE_SPITE_TAB:
                    CreateEditSprite("New Sprite");
                    break;
            }
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private void CreateEditSprite(string title)
        {
            CreateTab("Sprite - XXX", new SpriteCreatorForm());
        }

        private void CreateTab(string title, Form form)
        {
            TabPage newPage = new TabPage(title);

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            newPage.Controls.Add(form);

            workSpaceTabCntrl.TabPages.Add(newPage);
            workSpaceTabCntrl.SelectedTab = newPage;

            form.Show();
        }
    }
}
