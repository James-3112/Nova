using System.Numerics;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;


namespace NovaEngine {
    public class GLRenderer : Renderer {
        private GL gl = null!;

        public override void Initialize(IWindow window) {
            gl = window.CreateOpenGL();
        }

        public override void Dispose() {}

        public override void Clear(float r, float g, float b, float a) {}
        public override void ResizeWindow(int width, int height) {}

        public override void DrawMesh(Mesh mesh, Shader shader, Texture texture, Matrix4x4 modelMatrix) {
            mesh.buffer.Bind();
            texture.buffer.Bind();
            
            shader.buffer.Use();
            shader.buffer.SetUniform("uTexture", 0);
            
            shader.buffer.SetUniform("uModel", modelMatrix);
            SceneManager.currentScene.mainCamera.CreateMatrices(shader, Application.window.FramebufferSize);
            
            // Need to change to base on the number of vertices and indices
            gl.DrawArrays(PrimitiveType.Triangles, 0, 36);
        }
    }
}
