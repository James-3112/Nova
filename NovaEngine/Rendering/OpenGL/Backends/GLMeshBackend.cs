using Silk.NET.OpenGL;


namespace NovaEngine {
    public class GLMeshBackend : MeshBackend {
        public BufferObject<float> vbo;
        public BufferObject<uint> ebo;
        public VertexArrayObject<float, uint> vao;

        public GLMeshBackend(GL gl, float[] vertices, uint[] indices) {
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
