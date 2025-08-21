namespace NovaEngine {
    public class Shader {
        public ShaderBackend backend = null!;
        private string vertexPath = null!;
        private string fragmentPath = null!;
        
        
        public Shader(string vertexPath, string fragmentPath) {
            this.vertexPath = vertexPath;
            this.fragmentPath = fragmentPath;
        }


        public void Initialize() {
            backend = RendererLayer.CreateShaderBackend(vertexPath, fragmentPath);
        }
    }
}
