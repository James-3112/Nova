using System.Numerics;
using Silk.NET.Input;


namespace NovaEngine {
    public static class Input {
        private static IKeyboard keyboard = null!;
        private static IMouse mouse = null!;

        private static HashSet<Key> keysPressed = new();
        private static HashSet<Key> keysReleased = new();
        private static HashSet<Key> keysHeld = new();

        private static HashSet<MouseButton> mousePressed = new();
        private static HashSet<MouseButton> mouseReleased = new();
        private static HashSet<MouseButton> mouseHeld = new();

        public static Vector2 mousePosition { get; private set; }
        public static Vector2 mouseDeltaPosition { get; private set; }

        private static Vector2 lastMousePosition;


        public static void Initialize(IKeyboard keyboard, IMouse mouse) {
            Input.keyboard = keyboard; // Don't need to save keyboard
            Input.mouse = mouse;

            keyboard.KeyDown += OnKeyDown;
            keyboard.KeyUp += OnKeyUp;
            mouse.MouseDown += OnMouseDown;
            mouse.MouseUp += OnMouseUp;
            mouse.MouseMove += OnMouseMove;

            mousePosition = mouse.Position;
            lastMousePosition = mousePosition;
        }


        private static void OnKeyDown(IKeyboard keyboard, Key key, int scancode) {
            if (!keysHeld.Contains(key)) {
                keysPressed.Add(key);
                keysHeld.Add(key);
            }
        }

        private static void OnKeyUp(IKeyboard keyboard, Key key, int scancode) {
            keysReleased.Add(key);
            keysHeld.Remove(key);
        }

        private static void OnMouseDown(IMouse keyboard, MouseButton button) {
            if (!mouseHeld.Contains(button)) {
                mousePressed.Add(button);
                mouseHeld.Add(button);
            }
        }

        private static void OnMouseUp(IMouse keyboard, MouseButton button) {
            mouseReleased.Add(button);
            mouseHeld.Remove(button);
        }

        private static void OnMouseMove(IMouse keyboard, Vector2 position) {
            mousePosition = position;
        }


        public static bool IsKeyPressed(KeyCode key) => keysPressed.Contains(KeyCodes.KeyCodeToKey(key));
        public static bool IsKeyReleased(KeyCode key) => keysReleased.Contains(KeyCodes.KeyCodeToKey(key));
        public static bool IsKeyHeld(KeyCode key) => keysHeld.Contains(KeyCodes.KeyCodeToKey(key));

        public static bool IsMouseButtonPressed(KeyCode button) => mousePressed.Contains(KeyCodes.KeyCodeToMouseButton(button));
        public static bool IsMouseButtonReleased(KeyCode button) => mouseReleased.Contains(KeyCodes.KeyCodeToMouseButton(button));
        public static bool IsMouseButtonHeld(KeyCode button) => mouseHeld.Contains(KeyCodes.KeyCodeToMouseButton(button));

        public static void SetMouseMode(MouseMode mouseMode) => mouse.Cursor.CursorMode = MouseModes.MouseModeToCursorMode(mouseMode);


        public static void Update() {
            keysPressed.Clear();
            keysReleased.Clear();
            mousePressed.Clear();
            mouseReleased.Clear();

            mouseDeltaPosition = mousePosition - lastMousePosition;
            lastMousePosition = mousePosition;
        }
    }
}
