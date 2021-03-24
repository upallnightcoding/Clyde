using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private bool mouseClicked = false;

        private Texture2D texture;

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

            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.ProgramPointSize);
            GL.Enable(EnableCap.Blend);
            //GL.BlendFunc(BlendingFactor.OneMinusSrcColor, BlendingFactor.OneMinusDstColor);
            GL.DepthFunc(DepthFunction.Lequal);
            GL.Enable(EnableCap.Texture2D);

            Application.Idle += Application_Idle;

            VSync = true;

            glControl_Resize(this, null);

            texture = graphics.LoadTexture("D:\\Projects\\c#\\Clyde\\view\\content\\PlatformC.png");
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

            GL.Rotate(angle, 0.0f, 1.0f, 0.0f);
            //angle += 0.5f;

            RenderScene();

            SwapBuffers();
        }

        private void RenderScene()
        {
            //if (mouseClicked)
            //{
                mouseClicked = false;

            Vector3 pm = graphics.UnProject(mouse);

            GL.Begin(PrimitiveType.Points);
            GL.Color3(Color.Silver);
            GL.PointSize(5.0f);
            GL.Vertex3(pm.X, pm.Y, pm.Z);
            GL.End();
            //}

            graphics.CrossHair(pm);

            graphics.Grid(4);

            PointF pp = new PointF(pm.X, pm.Y);
            graphics.BoxRectangle(pm, 0.25f, Color.Red);

            GL.BindTexture(TextureTarget.Texture2D, texture.Id);

            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
            GL.TexCoord2(0, 0); GL.Vertex2(0, 1);
            GL.TexCoord2(1, 1); GL.Vertex2(1, 0);
            GL.TexCoord2(0, 1); GL.Vertex2(0, 0);

            GL.TexCoord2(0, 0); GL.Vertex2(0, 1);
            GL.TexCoord2(1, 0); GL.Vertex2(1, 1);
            GL.TexCoord2(1, 1); GL.Vertex2(1, 0);
            GL.End();

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
