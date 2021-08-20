using Clyde.view.msg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clyde.view.form
{
    public partial class SpriteCreatorForm : Form
    {
        public SpriteCreatorForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.AllowFullOpen = false;
            dialog.ShowHelp = true;
            dialog.Color = textBox1.ForeColor;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectColorBtn.BackColor = dialog.Color;

                PostManager.Instance.Post(PostType.SET_DRAWING_COLOR, dialog.Color);
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
