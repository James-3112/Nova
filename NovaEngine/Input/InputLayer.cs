using System.Numerics;
using Silk.NET.Input;


namespace NovaEngine {
    public class InputLayer : Layer {
        public static IKeyboard keyboard = null!;
        public static IMouse mouse = null!;

        public static HashSet<Key> keysPressed = new();
        public static HashSet<Key> keysReleased = new();
        public static HashSet<Key> keysHeld = new();

        public static HashSet<MouseButton> mousePressed = new();
        public static HashSet<MouseButton> mouseReleased = new();
        public static HashSet<MouseButton> mouseHeld = new();

        public static Vector2 mousePosition { get; private set; }
        public static Vector2 mouseDeltaPosition { get; private set; }

        private static Vector2 lastMousePosition;

        private IInputContext inputContext = null!;


        public InputLayer() {
            inputContext = Application.window.silkWindow.CreateInput();
            
            keyboard = inputContext.Keyboards.FirstOrDefault()!;
            mouse = inputContext.Mice.FirstOrDefault()!;;

            keyboard.KeyDown += OnKeyDown;
            keyboard.KeyUp += OnKeyUp;
            mouse.MouseDown += OnMouseDown;
            mouse.MouseUp += OnMouseUp;
            mouse.MouseMove += OnMouseMove;

            mousePosition = mouse.Position;
            lastMousePosition = mousePosition;
        }


        private void OnKeyDown(IKeyboard keyboard, Key key, int scancode) {
            if (!keysHeld.Contains(key)) {
                keysPressed.Add(key);
                keysHeld.Add(key);
            }
        }

        private void OnKeyUp(IKeyboard keyboard, Key key, int scancode) {
            keysReleased.Add(key);
            keysHeld.Remove(key);
        }

        private void OnMouseDown(IMouse keyboard, MouseButton button) {
            if (!mouseHeld.Contains(button)) {
                mousePressed.Add(button);
                mouseHeld.Add(button);
            }
        }

        private void OnMouseUp(IMouse keyboard, MouseButton button) {
            mouseReleased.Add(button);
            mouseHeld.Remove(button);
        }

        private void OnMouseMove(IMouse keyboard, Vector2 position) {
            mousePosition = position;
        }


        public override void Update(double deltaTime) {
            keysPressed.Clear();
            keysReleased.Clear();
            mousePressed.Clear();
            mouseReleased.Clear();

            mouseDeltaPosition = mousePosition - lastMousePosition;
            lastMousePosition = mousePosition;
        }


        public override void Dispose() {
            inputContext.Dispose();
        }
    }
}
