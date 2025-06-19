using System.Numerics;
using Silk.NET.Input;


namespace Nova.Core {
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
            Input.keyboard = keyboard;
            Input.mouse = mouse;

            keyboard.KeyDown += OnKeyDown;
            keyboard.KeyUp += OnKeyUp;
            mouse.MouseDown += OnMouseDown;
            mouse.MouseUp += OnMouseUp;
            mouse.MouseMove += OnMouseMove;

            mousePosition = mouse.Position;
            lastMousePosition = mousePosition;
        }


        private static void OnKeyDown(IKeyboard _, Key key, int scancode) {
            if (!keysHeld.Contains(key)) {
                keysPressed.Add(key);
                keysHeld.Add(key);
            }
        }

        private static void OnKeyUp(IKeyboard _, Key key, int scancode) {
            keysReleased.Add(key);
            keysHeld.Remove(key);
        }

        private static void OnMouseDown(IMouse _, MouseButton button) {
            if (!mouseHeld.Contains(button)) {
                mousePressed.Add(button);
                mouseHeld.Add(button);
            }
        }

        private static void OnMouseUp(IMouse _, MouseButton button) {
            mouseReleased.Add(button);
            mouseHeld.Remove(button);
        }

        private static void OnMouseMove(IMouse _, Vector2 position) {
            mousePosition = position;
        }


        public static bool IsKeyPressed(Key key) => keysPressed.Contains(key);
        public static bool IsKeyReleased(Key key) => keysReleased.Contains(key);
        public static bool IsKeyHeld(Key key) => keysHeld.Contains(key);

        public static bool IsMouseButtonPressed(MouseButton button) => mousePressed.Contains(button);
        public static bool IsMouseButtonReleased(MouseButton button) => mouseReleased.Contains(button);
        public static bool IsMouseButtonHeld(MouseButton button) => mouseHeld.Contains(button);


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
