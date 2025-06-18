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
        private BufferObject<float> vbo = null!;
        private BufferObject<uint> ebo = null!;
        private VertexArrayObject<float, uint> vao = null!;

        public Mesh() {

        }

        public void Dispose()  {
            
        }
    }
}
