namespace NovaEngine {
    public class Shader {
        public ShaderBackend backend;
        
        public Shader(string vertexPath, string fragmentPath) {
            backend = RendererLayer.CreateShaderBackend(vertexPath, fragmentPath);
        }

        public Shader(ShaderBackend backend) {
            this.backend = backend;
        }
    }
}
