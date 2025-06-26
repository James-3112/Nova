using Silk.NET.Windowing;


namespace NovaEngine {
    public class RendererLayer : Layer {
        public enum Backend {OpenGL, DirectX, Vulkan}
        private static Backend backend;

        private Renderer renderer = null!;


        public RendererLayer(Backend backend, IWindow window) {
            switch (backend) {
                case Backend.OpenGL:
                    renderer = new GLRenderer();
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

            renderer.Initialize(window);
        }


        public override void OnUpdate(float dt) {
            renderer.Clear();

            foreach (GameObject gameObject in SceneManager.currentScene.gameObjects) {
                MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer == null) return;

                Mesh mesh = gameObject.GetComponent<Mesh>();
                Transform transform = gameObject.GetComponent<Transform>();

                renderer.DrawMesh(mesh, meshRenderer.shader, meshRenderer.texture, transform.matrix);
            }
        }


        public override void Dispose() {}


        public static MeshBackend CreateMeshBackend(float[] vertices, uint[] indices) {
            return backend switch {
                Backend.OpenGL => new GLMeshBackend(Application.gl, vertices, indices),
                _ => throw new NotImplementedException()
            };
        }


        public static ShaderBackend CreateShaderBackend(string vertexPath, string fragmentPath) {
            return backend switch {
                Backend.OpenGL => new GLShaderBackend(Application.gl, vertexPath, fragmentPath),
                _ => throw new NotImplementedException()
            };
        }


        public static TextureBackend CreateTextureBackend(string path) {
            return backend switch {
                Backend.OpenGL => new GLTextureBackend(Application.gl, path),
                _ => throw new NotImplementedException()
            };
        }
    }
}
