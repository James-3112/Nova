using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Numerics;

using System.Drawing;

using StbImageSharp;

using Nova.Graphics;
using Nova.Utilities;


public class Camera {
    public Transform transform = new Transform();

    public float fov;
    public float nearPlaneDistance;
    public float farPlaneDistance;

    public Camera(float fov = 70f, float nearPlaneDistance = 0.1f, float farPlaneDistance = 100f) {
        this.fov = fov;
        this.nearPlaneDistance = nearPlaneDistance;
        this.farPlaneDistance = farPlaneDistance;
    }

    public void CreateMatrices(Nova.Graphics.Shader shader, Vector2D<int> size) {
        Matrix4x4 view = Matrix4x4.CreateLookAt(transform.position, transform.position + Vector3.Normalize(transform.rotationEulerAngles), Vector3.UnitY);
        Matrix4x4 projection = Matrix4x4.CreatePerspectiveFieldOfView(MathUtils.DegreesToRadians(fov), (float)size.X / size.Y, nearPlaneDistance, farPlaneDistance);

        shader.SetUniform("uView", view);
        shader.SetUniform("uProjection", projection);
    }
}
