using Silk.NET.Maths;
using System.Numerics;


namespace NovaEngine {
    public class MeshRenderer : Component {
        public Shader shader;
        public Texture texture;

        public MeshRenderer(Shader shader, Texture texture) {
            this.shader = shader;
            this.texture = texture;
        }
    }
}
