using System.Numerics;


namespace NovaEngine {
    public interface ShaderBackend : IDisposable {
        public void Use();
        public void SetUniform(string name, int value);
        public void SetUniform(string name, float value);
        public unsafe void SetUniform(string name, Matrix4x4 value);
    }
}
