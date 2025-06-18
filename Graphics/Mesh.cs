using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Numerics;

using System.Drawing;

using StbImageSharp;

using Nova.Graphics;
using Nova.Utilities;


namespace Nova.Graphics {
    public class Mesh: IDisposable {
        private GL gl;

        private BufferObject<float> vbo = null!;
        private BufferObject<uint> ebo = null!;
        private VertexArrayObject<float, uint> vao = null!;

        public Texture texture = null!;
        public Shader shader = null!;


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


        public void Render() {
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
