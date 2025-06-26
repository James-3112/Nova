using Silk.NET.OpenGL;


namespace NovaEngine {
    public class GLMeshBuffer : MeshBuffer {
        private GL gl;

        private BufferObject<float> vbo;
        private BufferObject<uint> ebo;
        private VertexArrayObject<float, uint> vao;

        public GLMeshBuffer(GL gl, float[] vertices, uint[] indices) {
            this.gl = gl;

            vbo = new BufferObject<float>(gl, vertices, BufferTargetARB.ArrayBuffer);
            ebo = new BufferObject<uint>(gl, indices, BufferTargetARB.ElementArrayBuffer);
            vao = new VertexArrayObject<float, uint>(gl, vbo, ebo);

            // Telling the VAO object how to lay out the attribute pointers
            vao.VertexAttributePointer(0, 3, VertexAttribPointerType.Float, 5, 0);
            vao.VertexAttributePointer(1, 2, VertexAttribPointerType.Float, 5, 3);
        }

        public void Bind() => vao.Bind();

        public void Dispose() {
            vbo.Dispose();
            ebo.Dispose();
            vao.Dispose();
        }
    }
}
