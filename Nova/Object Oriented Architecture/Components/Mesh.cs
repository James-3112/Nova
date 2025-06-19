using Silk.NET.OpenGL;
using Silk.NET.Maths;

using Nova.Core;
using Nova.Graphics;

using Texture = Nova.Graphics.Texture;
using Shader = Nova.Graphics.Shader;


namespace Nova.ObjectOrientedArchitecture {
    public class Mesh : Component, IDisposable {
        private GL gl;

        private BufferObject<float> vbo;
        private BufferObject<uint> ebo;
        private VertexArrayObject<float, uint> vao;

        public Texture texture;
        public Shader shader;


        public Mesh(GL gl, float[] vertices, uint[] indices, string vertexPath, string fragmentPath, string texturePath) {
            this.gl = gl;

            ebo = new BufferObject<uint>(gl, indices, BufferTargetARB.ElementArrayBuffer);
            vbo = new BufferObject<float>(gl, vertices, BufferTargetARB.ArrayBuffer);
            vao = new VertexArrayObject<float, uint>(gl, vbo, ebo);

            // Telling the VAO object how to lay out the attribute pointers
            vao.VertexAttributePointer(0, 3, VertexAttribPointerType.Float, 5, 0);
            vao.VertexAttributePointer(1, 2, VertexAttribPointerType.Float, 5, 3);

            shader = new Shader(gl, vertexPath, fragmentPath);
            texture = new Texture(gl, texturePath);
        }


        public void Bind() {
            vao.Bind();
            texture.Bind(TextureUnit.Texture0);
            
            shader.Use();
            shader.SetUniform("uTexture", 0);
        }


        public void Render(Camera camera, Vector2D<int> size) {
            Bind();
            
            shader.SetUniform("uModel", gameObject.GetComponent<Transform>().matrix);
            camera.CreateMatrices(shader, size);

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
