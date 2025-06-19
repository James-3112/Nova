using Silk.NET.OpenGL;


namespace Nova.Graphics {
    public class BufferObject<DataType> : IDisposable
        where DataType : unmanaged
    {
        private GL gl;
        private BufferTargetARB bufferType;
        private uint handle;

        public unsafe BufferObject(GL gl, Span<DataType> data, BufferTargetARB bufferType) {
            this.gl = gl;
            this.bufferType = bufferType;

            // Create the buffer and bind it
            handle = gl.GenBuffer();
            Bind();

            // Add the data to the buffer
            fixed (void* buf = data) {
                gl.BufferData(bufferType, (nuint) (data.Length * sizeof(DataType)), buf, BufferUsageARB.StaticDraw);
            }
        }

        public void Bind() {
            gl.BindBuffer(bufferType, handle);
        }

        public void Dispose() {
            gl.DeleteBuffer(handle);
        }
    }
}
