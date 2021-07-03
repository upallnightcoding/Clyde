using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Clyde.view.entity
{
    class Transform
    {
        private Vector3 translate;
        private float rotationX;
        private float rotationY;
        private float rotationZ;
        private Vector3 scale;

        public Transform()
        {
            translate = Vector3.Zero;
            rotationZ = 0.0f;
            scale = new Vector3(1.0f);
        }

        public Matrix4 getTransform()
        {
            Matrix4 transform =
                Matrix4.CreateScale(scale) *
                Matrix4.CreateRotationZ(rotationZ) *
                Matrix4.CreateTranslation(translate);

            return (transform);
        }

        public void Render()
        {
            GL.Rotate(rotationX, 1.0f, 0.0f, 0.0f);
            GL.Rotate(rotationY, 0.0f, 1.0f, 0.0f);
            GL.Rotate(rotationZ, 0.0f, 0.0f, 1.0f);
        }
    }
}
