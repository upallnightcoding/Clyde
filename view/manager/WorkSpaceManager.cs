using Clyde.view.form;
using Clyde.view.graphics;
using Clyde.view.msg;
using Clyde.view.windows;
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
        private FormsWindow formsWindow = null;
        private AnimationWindow animationWindow = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public WorkSpaceManager(
            FormsWindow formsWindow, 
            AnimationWindow animationWindow
        )
        {
            this.formsWindow = formsWindow;
            this.animationWindow = animationWindow;

            //CreateTab("Sprite Controls", new WorkSpaceForm(animationWindow));

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
            CreateTab("Sprite - XXX", new SpriteCreatorForm(), null);
        }

        private void CreateTab(string title, Form form, Renderer renderer)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            TabPage newPage = new TabPage(title);

            newPage.Controls.Add(form);

            formsWindow.TabPages.Add(newPage);
            formsWindow.SelectedTab = newPage;

            form.Show();
        }
    }
}
