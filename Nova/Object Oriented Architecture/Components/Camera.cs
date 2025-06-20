using Silk.NET.Maths;
using System.Numerics;

using Nova.Utilities;
using Nova.ObjectOrientedArchitecture;


namespace Nova.Core {
    public class Camera : Component {
        public float fov;
        public float nearPlaneDistance;
        public float farPlaneDistance;

        private Transform transform = null!;


        public Camera(float fov = 70f, float nearPlaneDistance = 0.1f, float farPlaneDistance = 100f) {
            this.fov = fov;
            this.nearPlaneDistance = nearPlaneDistance;
            this.farPlaneDistance = farPlaneDistance;
        }


        public override void OnAdd() {
            transform = gameObject.GetComponent<Transform>();
        }


        public void CreateMatrices(Nova.Graphics.Shader shader, Vector2D<int> size) {
            Matrix4x4 view = Matrix4x4.CreateLookAt(transform.position, transform.position + Vector3.Normalize(transform.rotationEulerAngles), Vector3.UnitY);
            Matrix4x4 projection = Matrix4x4.CreatePerspectiveFieldOfView(MathUtils.DegreesToRadians(fov), (float)size.X / size.Y, nearPlaneDistance, farPlaneDistance);

            shader.SetUniform("uView", view);
            shader.SetUniform("uProjection", projection);
        }
    }
}
