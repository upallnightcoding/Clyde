using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clyde.application;
using Clyde.view.entity;
using Clyde.view.graphics;
using Clyde.view.msg;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Clyde
{
    public partial class AnimationWindow : OpenTK.GLControl
    {
        private bool play = false;
        static float angle = 0.0f;
        private UtilityGraphics graphics = null;
        private PointF p = new PointF(0.0f, 0.0f);
        private Vector3 mouse = new Vector3();

        private Entity entity = null;

        private bool mouseClicked = false;

        public AnimationWindow()
        {
            InitializeComponent();
            graphics = new UtilityGraphics();
        }

        public void Initialize()
        {
            Resize += new EventHandler(glControl_Resize);
            Paint += new PaintEventHandler(glControl_Paint);
            MouseDown += new MouseEventHandler(Control_MouseDown);

            graphics.Initialize();

            Application.Idle += Application_Idle;

            VSync = true;

            glControl_Resize(this, null);

            entity = new Entity();
            entity.Texture = graphics.LoadTexture(AppConstant.TEST01_IMAGE);
        }

        public void StartAnimation()
        {
            play = true;
        }

        public void StopAnimation()
        {
            play = false;
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            MsgManager.Instance.Post(MsgPostType.DISPLAY_MESSAGE, "Mouse Down: " + e.X + ":" + e.Y);

            mouse.X = e.X;
            mouse.Y = e.Y;
            mouse.Z = 0.0f;
            mouseClicked = true;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            while (IsIdle && play)
            {
                Render();
            }
        }

        private void glControl_Resize(object sender, EventArgs e)
        {
            OpenTK.GLControl client = sender as OpenTK.GLControl;

            graphics.Resize(client.ClientSize.Width, client.ClientSize.Height);

            /*if (c.ClientSize.Height == 0)
                c.ClientSize = new System.Drawing.Size(c.ClientSize.Width, 1);

            GL.Viewport(0, 0, c.ClientSize.Width, c.ClientSize.Height);

            viewport = new Size(c.ClientSize.Width, c.ClientSize.Height);
            //vp = new float[] { 0.0f, 0.0f, c.ClientSize.Width, c.ClientSize.Height};

            //float aspect_ratio = Width / (float)Height;
            float aspect_ratio = c.ClientSize.Width / (float)c.ClientSize.Height;
            perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);*/
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void Render()
        {
            //Matrix4 lookat = Matrix4.LookAt(0, 5, 5, 0, 0, 0, 0, 1, 0);
            //lookat = Matrix4.LookAt(0, 0, -5, 0, 0, 0, 0, 1, 0);

            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadMatrix(ref lookat);

            //GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            graphics.Render();

            RenderScene();

            SwapBuffers();
        }

        private void RenderScene()
        {
            mouseClicked = false;

            Vector3 lowerLeft = new Vector3(1.0f, graphics.viewPort.Height-1, 0.0f);
            Vector3 ch = graphics.UnProject(lowerLeft);

            GL.Translate(ch.X, ch.Y, 0.0);
            GL.PushMatrix();

            Vector3 pm = graphics.UnProject(mouse);

            GL.Begin(PrimitiveType.Points);
            GL.Color3(Color.Silver);
            GL.PointSize(5.0f);
            GL.Vertex3(pm.X, pm.Y, pm.Z);
            GL.End();

            graphics.CrossHair(pm);

            graphics.SpriteGrid(8, 8);

            //PointF pp = new PointF(pm.X, pm.Y);
            graphics.BoxRectangle(pm, 0.25f, Color.Red);

            entity.Render(graphics);

            GL.PopMatrix();

            //GL.Begin(BeginMode.Quads);
            /*   GL.Begin(PrimitiveType.Quads);

               GL.Color3(Color.Silver);
               GL.Vertex3(-1.0f, -1.0f, -1.0f);
               GL.Vertex3(-1.0f, 1.0f, -1.0f);
               GL.Vertex3(1.0f, 1.0f, -1.0f);
               GL.Vertex3(1.0f, -1.0f, -1.0f);

               GL.Color3(Color.Honeydew);
               GL.Vertex3(-1.0f, -1.0f, -1.0f);
               GL.Vertex3(1.0f, -1.0f, -1.0f);
               GL.Vertex3(1.0f, -1.0f, 1.0f);
               GL.Vertex3(-1.0f, -1.0f, 1.0f);

               GL.Color3(Color.Moccasin);
               GL.Vertex3(-1.0f, -1.0f, -1.0f);
               GL.Vertex3(-1.0f, -1.0f, 1.0f);
               GL.Vertex3(-1.0f, 1.0f, 1.0f);
               GL.Vertex3(-1.0f, 1.0f, -1.0f);*/

            /*GL.Color3(Color.IndianRed);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);*/
            //graphics.BoxRectangle(Color.Blue);

            /* GL.Begin(PrimitiveType.Quads);

             GL.Color3(Color.PaleVioletRed);
             GL.Vertex3(-1.0f, 1.0f, -1.0f);
             GL.Vertex3(-1.0f, 1.0f, 1.0f);
             GL.Vertex3(1.0f, 1.0f, 1.0f);
             GL.Vertex3(1.0f, 1.0f, -1.0f);

             GL.Color3(Color.ForestGreen);
             GL.Vertex3(1.0f, -1.0f, -1.0f);
             GL.Vertex3(1.0f, 1.0f, -1.0f);
             GL.Vertex3(1.0f, 1.0f, 1.0f);
             GL.Vertex3(1.0f, -1.0f, 1.0f);

             GL.End();*/
        }
    }
}
