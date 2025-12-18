namespace Nova;


public abstract class Input {
    public enum Backend {Raylib}
    public static InputBackend? backend;

    public static void SetBackend(Backend backend) {
        switch (backend) {
            case Backend.Raylib:
                Input.backend = new RaylibInput();
                break;
            default:
                throw new ArgumentException("Unsupported platform");
        }
    }


    public static bool IsKeyPressed(KeyCode key) => backend?.IsKeyPressed(key) ?? false;                // Check if a key has been pressed once
    public static bool IsKeyPressedRepeat(KeyCode key) => backend?.IsKeyPressedRepeat(key) ?? false;    // Check if a key has been pressed again
    public static bool IsKeyDown(KeyCode key) => backend?.IsKeyDown(key) ?? false;                      // Check if a key is being pressed
    public static bool IsKeyReleased(KeyCode key) => backend?.IsKeyReleased(key) ?? false;              // Check if a key has been released once
    public static bool IsKeyUp(KeyCode key) => backend?.IsKeyUp(key) ?? false;                          // Check if a key is NOT being pressed
    public static KeyCode GetKeyPressed() => backend?.GetKeyPressed() ?? KeyCode.Null;                  // Get key pressed (keycode), call it multiple times for keys queued, returns 0 when the queue is empty
    

    public enum KeyCode {
        /// NULL, used for no key pressed
        Null,

        // Alphanumeric keys
        Apostrophe,
        Comma,
        Minus,
        Period,
        Slash,
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Semicolon,
        Equal,

        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,

        // Function keys
        Space,
        Escape,
        Enter,
        Tab,
        Backspace,
        Insert,
        Delete,
        Right,
        Left,
        Down,
        Up,
        PageUp,
        PageDown,
        Home,
        End,
        CapsLock,
        ScrollLock,
        NumLock,
        PrintScreen,
        Pause,
        F1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        F11,
        F12,
        LeftShift,
        LeftControl,
        LeftAlt,
        LeftSuper,
        RightShift,
        RightControl,
        RightAlt,
        RightSuper,
        KeyboardMenu,
        LeftBracket,
        Backslash,
        RightBracket,
        Grave,

        // Keypad keys
        Keypad0,
        Keypad1,
        Keypad2,
        Keypad3,
        Keypad4,
        Keypad5,
        Keypad6,
        Keypad7,
        Keypad8,
        Keypad9,
        KeypadDecimal,
        KeypadDivide,
        KeypadMultiply,
        KeypadSubtract,
        KeypadAdd,
        KeypadEnter,
        KeypadEqual,
    }
}
