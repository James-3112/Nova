using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Numerics;

using System.Drawing;

using StbImageSharp;

using Nova.Graphics;
using Nova.Utilities;


namespace Nova.ECS {
    public class Entity: IDisposable {
        public Transform transform = new Transform();
        private Mesh mesh;

        public Entity(Mesh mesh) {
            this.mesh = mesh;
        }

        public void Render(Camera camera, Vector2D<int> size) {
            mesh.Bind();

            mesh.shader.SetUniform("uModel", transform.matrix);
            camera.CreateMatrices(mesh.shader, size);

            mesh.Render();
        }

        public void Dispose() {
            mesh.Dispose();
        }
    }
}
