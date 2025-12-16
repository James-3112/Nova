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


    public static bool IsKeyDown(KeyCode key) => backend?.IsKeyDown(key) ?? false;
    public static bool IsKeyPressed(KeyCode key) => backend?.IsKeyPressed(key) ?? false;
    

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
