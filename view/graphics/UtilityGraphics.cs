using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;

namespace Clyde.view.graphics
{
    class UtilityGraphics
    {
        // Class Constants
        private static float XY_PLANE = 0.0f;

        /************************/
        /*** Public Functions ***/
        /************************/

        public void BoxRectangle(Color color)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(color);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.End();
        }

        public void BoxRectangle(PointF p, float size, Color color)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(color);
            GL.Vertex3(p.X, p.Y, 1.02f);
            GL.Vertex3(p.X, p.Y-size, 1.02f);
            GL.Vertex3(p.X+size, p.Y-size, 1.02f);
            GL.Vertex3(p.X+size, p.Y, 1.02f);
            GL.End();
        }

        public void Line()
        {
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(-1.0f, 0.0f, 1.0f);
            GL.Vertex3(1.0f, 0.0f, 1.0f);
            GL.End();
        }

        public void BackGroundGrid()
        {

        }

        public void Grid(int nBlocks)
        {
            float space = 2.0f / nBlocks;
            float y = 1.0f;
            float x = -1.0f;

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);

            for (int n = 0; n <= nBlocks; n++)
            {
                GL.Vertex3(x, 1.0, 1.01f);
                GL.Vertex3(x, -1.0, 1.01f);
                x += space;
            }

            for (int n = 0; n <= nBlocks; n++)
            {
                GL.Vertex3(-1.0f, y, 1.01f);
                GL.Vertex3(1.0f, y, 1.01f);
                y -= space;
            }

            GL.End();
        }

        public Vector3 UnProject(
            Vector3 mouse, 
            Matrix4 projection, 
            Matrix4 view, 
            Size viewport
        )
        {
            Vector4 vec;

            vec.X = 2.0f * mouse.X / (float)viewport.Width - 1;
            vec.Y = -(2.0f * mouse.Y / (float)viewport.Height - 1);
            vec.Z = mouse.Z;
            vec.W = 1.0f;

            Matrix4 viewInv = Matrix4.Invert(view);
            Matrix4 projInv = Matrix4.Invert(projection);

            Vector4.Transform(ref vec, ref projInv, out vec);
            Vector4.Transform(ref vec, ref viewInv, out vec);

            if (vec.W > 0.000001f || vec.W < -0.000001f)
            {
                vec.X /= vec.W;
                vec.Y /= vec.W;
                vec.Z /= vec.W;
            }

            return vec.Xyz;
        }

        /*public Vector3 UnProject(
            ref Matrix4 projection,
            Matrix4 view,
            Size viewport,
            Vector3 mouse
        )
        {
            Vector4 vec;

            vec.X = 2.0f * mouse.X / (float)viewport.Width - 1;
            vec.Y = -(2.0f * mouse.Y / (float)viewport.Height - 1);
            vec.Z = mouse.Z;
            vec.W = 1.0f;

            Matrix4 viewInv = Matrix4.Invert(view);
            Matrix4 projInv = Matrix4.Invert(projection);

            Vector4.Transform(ref vec, ref projInv, out vec);
            Vector4.Transform(ref vec, ref viewInv, out vec);

            if (vec.W > float.Epsilon || vec.W < -float.Epsilon)
            {
                vec.X /= vec.W;
                vec.Y /= vec.W;
                vec.Z /= vec.W;
            }

            return new Vector3(vec.X, vec.Y, vec.Z);
        }

        public Vector3 UnProject(Vector3 windowCoords, Matrix4 modelView, Matrix4 projection, float[] viewPort)
        {
            // First, convert from window coordinates to NDC coordinates
            Vector4 ndcCoords = new Vector4(windowCoords.X, windowCoords.Y, windowCoords.Z, 1.0f);
            ndcCoords.X = (ndcCoords.X - viewPort[0]) / viewPort[2]; // Range 0 to 1: (windowX - viewX) / viewWidth
            ndcCoords.Y = (ndcCoords.Y - viewPort[1]) / viewPort[3]; // Range 0 to 1: (windowY - viewY) / viewHeight
                                                                     // Remember, NDC ranges from -1 to 1, not 0 to 1
            ndcCoords.X = ndcCoords.X * 2f - 1f; // Range: -1 to 1
            ndcCoords.Y = 1f - ndcCoords.Y * 2f; // Range: -1 to 1 - Flipped!
            ndcCoords.Z = ndcCoords.Z * 2f - 1f; // Range: -1 to 1

            // Next, from NDC space to eye / view space.
            // We get here by multiplying the inverse of the projection matrix
            // by NDC coords. Note, this leaves a scalar in the W component!
            Vector4 eyeCoords = Matrix4.Invert(projection) * ndcCoords;

            // Next, from eye space to world space.
            // Remember, eye space assumes the camera is at the center of the world,
            // this is not the case, let's move the actual point into world space
            Vector4 worldCoords = Matrix4.Invert(modelView) * eyeCoords;

            // Finally, undo the perspective divide!
            // When we multiplied by the inverse of the projection matrix, that
            // multiplication left the inverse of the perspective divide in the 
            // W component of the resulting vector. This could be 0
            if (Math.Abs(0.0f - worldCoords.W) > 0.00001f)
            {
                // This is the same as dividing every component by W
                worldCoords *= 1.0f / worldCoords.W;
            }

            // Now we have a proper 4D vector with a W of 1 (or 0)
            return new Vector3(worldCoords.X, worldCoords.Y, worldCoords.Z);
        }*/
    }
}
