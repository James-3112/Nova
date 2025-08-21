namespace NovaEngine {
    public class Texture {
        public TextureBackend backend = null!;
        private string path = null!;


        public Texture(string path) {
            this.path = path;
        }


        public void Initialize() {
            backend = RendererLayer.CreateTextureBackend(path);
        }
    }
}
