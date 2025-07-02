using System.Numerics;


namespace NovaEngine {
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


        public override void Start() {
            transform = gameObject.GetComponent<Transform>();
        }


        public void CreateMatrices(Shader shader, Vector2 size) {
            Matrix4x4 view = Matrix4x4.CreateLookAt(transform.position, transform.position + Vector3.Normalize(transform.rotationEulerAngles), Vector3.UnitY);
            Matrix4x4 projection = Matrix4x4.CreatePerspectiveFieldOfView(MathUtils.DegreesToRadians(fov), size.X / size.Y, nearPlaneDistance, farPlaneDistance);

            shader.backend.SetUniform("uView", view);
            shader.backend.SetUniform("uProjection", projection);
        }
    }
}
