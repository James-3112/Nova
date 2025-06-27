namespace NovaEngine {
    public abstract class Layer {
        public virtual void Start() {}
        public virtual void Update(double deltaTime) {}
        public virtual void Dispose() {}
    }
}
