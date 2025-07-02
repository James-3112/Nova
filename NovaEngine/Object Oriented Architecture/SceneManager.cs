namespace NovaEngine {
    public static class SceneManager {
        public static SceneLayer? currentSceneLayer { get; private set; }

        public static void LoadScene(Scene scene) {
            // Unload current scene if it exists
            if (currentSceneLayer != null) {
                Application.Instance.RemoveLayer(currentSceneLayer);
                currentSceneLayer.Dispose();
                currentSceneLayer = null;
            }

            // Add and start new scene layer
            currentSceneLayer = (SceneLayer)Application.Instance.AddAndStartLayer<SceneLayer>(scene);
        }

        public static void UnloadScene() {
            if (currentSceneLayer == null) {
                Debug.LogWarn("Tried to unload a scene, but no scene is currently loaded.");
                return;
            }

            Application.Instance.RemoveLayer(currentSceneLayer);
            currentSceneLayer.Dispose();
            currentSceneLayer = null;
        }
    }
}
