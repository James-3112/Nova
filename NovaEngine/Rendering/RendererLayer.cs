using Silk.NET.Windowing;


namespace NovaEngine {
    public class RendererLayer : Layer {
        public enum Backend {OpenGL, DirectX, Vulkan}
        private static Backend backend;

        private static Renderer renderer = null!;


        public RendererLayer(Backend backend, IWindow window) {
            switch (backend) {
                case Backend.OpenGL:
                    renderer = new GLRenderer(window);
                    break;
                case Backend.DirectX:
                    Debug.LogError("DirectX is not support yet");
                    break;
                case Backend.Vulkan:
                    Debug.LogError("Vulkan is not support yet");
                    break;
                default:
                    Debug.LogError("Failed to load backend");
                    break;
            }
        }


        public override void Start() {
            if (SceneManager.sceneLayer?.scene.mainCamera == null) Debug.LogWarn("No main camera selected within the current scene");
        }


        public override void Update(double deltaTime) {
            renderer.Clear();

            if (SceneManager.sceneLayer?.scene.gameObjects == null) return;

            foreach (GameObject gameObject in SceneManager.sceneLayer.scene.gameObjects) {
                MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer == null) continue;

                Mesh mesh = gameObject.GetComponent<Mesh>();
                Transform transform = gameObject.GetComponent<Transform>();

                renderer.DrawMesh(mesh, meshRenderer.shader, meshRenderer.texture, transform.matrix);
            }
        }


        public override void Dispose() {}


        public static MeshBackend CreateMeshBackend(float[] vertices, uint[] indices) {
            return backend switch {
                Backend.OpenGL => renderer.CreateMeshBackend(vertices, indices),
                _ => throw new NotImplementedException()
            };
        }


        public static ShaderBackend CreateShaderBackend(string vertexPath, string fragmentPath) {
            return backend switch {
                Backend.OpenGL => renderer.CreateShaderBackend(vertexPath, fragmentPath),
                _ => throw new NotImplementedException()
            };
        }


        public static TextureBackend CreateTextureBackend(string path) {
            return backend switch {
                Backend.OpenGL => renderer.CreateTextureBackend(path),
                _ => throw new NotImplementedException()
            };
        }
    }
}
