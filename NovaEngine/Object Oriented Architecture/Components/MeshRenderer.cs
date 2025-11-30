namespace NovaEngine {
    public class MeshRenderer : Component {
        public Shader shader;
        public Texture texture;

        public MeshRenderer(Shader shader, Texture texture) {
            this.shader = shader;
            this.texture = texture;
        }

        public override void Start() {
            shader.Initialize();
            texture.Initialize();
        }
    }
}
