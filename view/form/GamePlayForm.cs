using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde
{
    public partial class GamePlayForm : Form
    {
        private AnimationWindow animationWindow = null;

        public GamePlayForm(AnimationWindow animationWindow)
        {
            InitializeComponent();

            this.animationWindow = animationWindow;
        }

        private void GamePlayForm_Load(object sender, EventArgs e)
        {

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            animationWindow.StartAnimation();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            animationWindow.StopAnimation();
        }
    }
}
