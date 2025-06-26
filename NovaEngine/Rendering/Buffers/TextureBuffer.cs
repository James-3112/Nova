namespace NovaEngine {
    public interface TextureBuffer : IDisposable {
        public void Bind(int textureSlot = 0);
    }
}
