namespace NovaEngine {
    public static class Input {
        public static bool IsKeyPressed(KeyCode key) => InputLayer.keysPressed.Contains(KeyCodes.KeyCodeToKey(key));
        public static bool IsKeyReleased(KeyCode key) => InputLayer.keysReleased.Contains(KeyCodes.KeyCodeToKey(key));
        public static bool IsKeyHeld(KeyCode key) => InputLayer.keysHeld.Contains(KeyCodes.KeyCodeToKey(key));

        public static bool IsMouseButtonPressed(KeyCode button) => InputLayer.mousePressed.Contains(KeyCodes.KeyCodeToMouseButton(button));
        public static bool IsMouseButtonReleased(KeyCode button) => InputLayer.mouseReleased.Contains(KeyCodes.KeyCodeToMouseButton(button));
        public static bool IsMouseButtonHeld(KeyCode button) => InputLayer.mouseHeld.Contains(KeyCodes.KeyCodeToMouseButton(button));

        public static void SetMouseMode(MouseMode mouseMode) => InputLayer.mouse.Cursor.CursorMode = MouseModes.MouseModeToCursorMode(mouseMode);
    }
}
