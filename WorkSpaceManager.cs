using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde
{
    class WorkSpaceManager
    {
        private TabControl workSpaceTabCntrl = null;
        private AnimationWindow animationWindow = null;

        public WorkSpaceManager(
            TabControl workSpaceTabCntrl, 
            AnimationWindow animationWindow
        )
        {
            this.workSpaceTabCntrl = workSpaceTabCntrl;
            this.animationWindow = animationWindow;

            createTab("Game Play", new GamePlayForm(animationWindow));
        }

        public void Add(string title, Form form)
        {

        }

        private void createTab(string title, Form form)
        {
            TabPage newPage = new TabPage(title);

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            newPage.Controls.Add(form);

            workSpaceTabCntrl.TabPages.Add(newPage);

            form.Show();
        }
    }
}
