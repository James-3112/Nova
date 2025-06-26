namespace NovaEngine {
    public interface TextureBackend : IDisposable {
        public void Bind(int textureSlot = 0);
    }
}
