using Silk.NET.OpenGL;


namespace NovaEngine {
    public class VertexArrayObject<VertexType, IndexType> : IDisposable
        where VertexType : unmanaged
        where IndexType : unmanaged
    {
        private GL gl;
        private uint handle;


        public VertexArrayObject(GL gl, BufferObject<VertexType> vbo, BufferObject<IndexType> ebo) {
            this.gl = gl;

            handle = gl.GenVertexArray();
            Bind();

            vbo.Bind();
            ebo.Bind();
        }


        public unsafe void VertexAttributePointer(uint index, int count, VertexAttribPointerType type, uint vertexSize, int offSet) {
            //Setting up a vertex attribute pointer
            gl.VertexAttribPointer(index, count, type, false, vertexSize * (uint)sizeof(VertexType), (void*) (offSet * sizeof(VertexType)));
            gl.EnableVertexAttribArray(index);
        }


        public void Bind() {
            gl.BindVertexArray(handle);
        }


        public void Dispose()  {
            // We dont delete the VBO and EBO here, as you can have one VBO stored under multiple VAO's.
            gl.DeleteVertexArray(handle);
        }
    }
}
