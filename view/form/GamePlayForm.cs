using Clyde.view.graphics.renderer;
using System;
using System.Windows.Forms;

namespace Clyde
{
    public partial class WorkSpaceForm : Form
    {
        private AnimationWindow animationWindow = null;

        public WorkSpaceForm(AnimationWindow animationWindow)
        {
            InitializeComponent();

            this.animationWindow = animationWindow;

            this.animationWindow.SetRenderer(new RenderInitialize());
        }

        private void GamePlayForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// StartBtn_Click() - 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartBtn_Click(object sender, EventArgs e)
        {
            animationWindow.StartAnimation();
        }

        /// <summary>
        /// StopBtn_Click() - 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopBtn_Click(object sender, EventArgs e)
        {
            animationWindow.StopAnimation();
        }
    }
}
