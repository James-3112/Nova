namespace NovaEngine {
    public static class SceneManager {
        public static SceneLayer? sceneLayer { get; private set; }


        public static void Initialize(SceneLayer sceneLayer) {
            SceneManager.sceneLayer = sceneLayer;
        }


        public static void LoadScene(Scene scene) {
            if (sceneLayer == null) {
                Debug.LogError("SceneLayer has not been initialized");
                return;
            }

            sceneLayer.scene?.Dispose(); // Dispose current scene
            sceneLayer.scene = scene;
            scene.Start();
        }


        public static void UnloadScene() {
            if (sceneLayer == null) {
                Debug.LogWarn("Tried to unload a scene, but no scene is currently loaded");
                return;
            }

            sceneLayer.scene.Dispose();
            sceneLayer.scene = null!;
        }
    }
}
