using Clyde.view.graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Clyde.view.entity
{
    class Entity
    {
        // Class Properties
        //-----------------
        public Texture2D Texture { get; set; } = null;

        private Transform transform = null;
        private Behavior behavior = null;

        private float angle = 0.0f;

        public Entity()
        {
            transform = new Transform();
        }

        public void Render(GraphicsUtility ug)
        {
            GL.PushMatrix();

            //GL.Translate(-0.5f, -0.5f, 0.0f);

            GL.Rotate(angle+=1.0f, 0.0f, 0.0f, 1.0f);

            ug.DisplayTexture2D(Texture);

            GL.Begin(PrimitiveType.Triangles);
                GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
                GL.TexCoord2(0, 0); GL.Vertex2(0, 1);
                GL.TexCoord2(1, 1); GL.Vertex2(1, 0);
                GL.TexCoord2(0, 1); GL.Vertex2(0, 0);

                GL.TexCoord2(0, 0); GL.Vertex2(0, 1);
                GL.TexCoord2(1, 0); GL.Vertex2(1, 1);
                GL.TexCoord2(1, 1); GL.Vertex2(1, 0);
            GL.End();

            GL.PopMatrix();
        }
    }
}
