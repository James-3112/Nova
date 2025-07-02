using System.Drawing;
using System.Numerics;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;


namespace NovaEngine {
    public class GLRenderer : Renderer {
        private GL gl = null!;
        private IWindow window = null!;


        public GLRenderer(IWindow window) {
            this.window = window;
            gl = window.CreateOpenGL();

            gl.ClearColor(Color.Black);

            // Enable blending for textures transpanrency and set the blend to use the alpha to subtract
            gl.Enable(EnableCap.Blend);
            gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            // Enable backface culling
            gl.Enable(GLEnum.CullFace);

            // Enable draw by depth
            gl.Enable(EnableCap.DepthTest);
        }


        public override void Clear() {
            gl.Clear((uint) (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit));
        }


        public override void ResizeWindow(int width, int height) {
            gl.Viewport(new Vector2D<int>(width, height));
        }


        public override void ResizeWindow(Vector2 size) {
            ResizeWindow((int)size.X, (int)size.Y);
        }


        public override void DrawMesh(Mesh mesh, Shader shader, Texture texture, Matrix4x4 modelMatrix) {
            mesh.backend.Bind();
            texture.backend.Bind();
            
            shader.backend.Use();
            shader.backend.SetUniform("uTexture", 0);
            
            shader.backend.SetUniform("uModel", modelMatrix);
            SceneManager.currentSceneLayer?.scene.mainCamera.CreateMatrices(shader, new Vector2(window.FramebufferSize.X, window.FramebufferSize.Y));
            
            // Need to change to base on the number of vertices and indices
            gl.DrawArrays(PrimitiveType.Triangles, 0, 36);
        }


        public override MeshBackend CreateMeshBackend(float[] vertices, uint[] indices) {
            return new GLMeshBackend(gl, vertices, indices);
        }


        public override ShaderBackend CreateShaderBackend(string vertexPath, string fragmentPath) {
            return new GLShaderBackend(gl, vertexPath, fragmentPath);
        }


        public override TextureBackend CreateTextureBackend(string path) {
            return new GLTextureBackend(gl, path);
        }
    }
}
