namespace NovaEngine {
    public class Texture {
        public TextureBackend backend;

        public Texture(string path) {
            backend = RendererLayer.CreateTextureBackend(path);
        }

        public Texture(TextureBackend backend) {
            this.backend = backend;
        }
    }
}
