using Silk.NET.OpenGL;
using Silk.NET.Maths;


namespace NovaEngine {
    public class Mesh : Component, IDisposable {
        private GL gl = Application.gl;

        private BufferObject<float> vbo;
        private BufferObject<uint> ebo;
        private VertexArrayObject<float, uint> vao;

        public Texture texture;
        public Shader shader;


        public Mesh(float[] vertices, uint[] indices, string vertexPath, string fragmentPath, string texturePath) {
            vbo = new BufferObject<float>(gl, vertices, BufferTargetARB.ArrayBuffer);
            ebo = new BufferObject<uint>(gl, indices, BufferTargetARB.ElementArrayBuffer);
            vao = new VertexArrayObject<float, uint>(gl, vbo, ebo);

            // Telling the VAO object how to lay out the attribute pointers
            vao.VertexAttributePointer(0, 3, VertexAttribPointerType.Float, 5, 0);
            vao.VertexAttributePointer(1, 2, VertexAttribPointerType.Float, 5, 3);

            shader = new Shader(gl, vertexPath, fragmentPath);
            texture = new Texture(gl, texturePath);
        }


        private void Bind() {
            vao.Bind();
            texture.Bind(TextureUnit.Texture0);
            
            shader.Use();
            shader.SetUniform("uTexture", 0);
        }


        public override void Render(double deltaTime) {
            Bind();
            
            shader.SetUniform("uModel", gameObject.GetComponent<Transform>().matrix);
            SceneManager.currentScene.mainCamera.CreateMatrices(shader, Application.window.FramebufferSize);

            gl.DrawArrays(PrimitiveType.Triangles, 0, 36);
        }


        public void Dispose()  {
            vbo.Dispose();
            ebo.Dispose();
            vao.Dispose();
            shader.Dispose();
            texture.Dispose();
        }
    }
}
