using Silk.NET.Input;


namespace NovaEngine {
    public enum KeyCode {
        Unknown = -1,

        Space,
        Apostrophe,
        Comma,
        Minus,
        Period,
        Slash,

        Number0,
        Number1,
        Number2,
        Number3,
        Number4,
        Number5,
        Number6,
        Number7,
        Number8,
        Number9,

        Semicolon,
        Equal,

        A, B, C, D, E, F, G, H, I, J,
        K, L, M, N, O, P, Q, R, S, T,
        U, V, W, X, Y, Z,

        LeftBracket,
        BackSlash,
        RightBracket,
        GraveAccent,

        World1,
        World2,

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

        F1, F2, F3, F4, F5, F6,
        F7, F8, F9, F10, F11, F12,
        F13, F14, F15, F16, F17, F18,
        F19, F20, F21, F22, F23, F24,
        F25,

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

        ShiftLeft,
        ControlLeft,
        AltLeft,
        SuperLeft,
        ShiftRight,
        ControlRight,
        AltRight,
        SuperRight,

        Menu,

        Oem1,       // ';:' for US
        Oem2,       // '/?' for US
        Oem3,       // '`~' for US
        Oem4,       // '[{' for US
        Oem5,       // '\|' for US
        Oem6,       // ']}' for US
        Oem7,       // ''"' for US
        Oem8,
        Oem102,     // "<>" or "\|" on some keyboards

        VolumeMute,
        VolumeDown,
        VolumeUp,
        MediaNextTrack,
        MediaPrevTrack,
        MediaStop,
        MediaPlayPause,

        BrowserBack,
        BrowserForward,
        BrowserRefresh,
        BrowserStop,
        BrowserSearch,
        BrowserFavorites,
        BrowserHome,

        LaunchMail,
        LaunchMediaSelect,
        LaunchApp1,
        LaunchApp2,

        Kana,
        Hangul,
        Junja,
        Final,
        Hanja,
        Kanji,
        Convert,
        NonConvert,
        Accept,
        ModeChange,
        Process,
        Packet,

        Sleep,
        Select,
        Execute,
        Help,
        Print,
        Clear,
        Separator,

        LeftMouseButton,
        RightMouseButton,
        MiddleMouseButton,
        MouseButton4,
        MouseButton5,
        MouseButton6,
        MouseButton7,
        MouseButton8,
        MouseButton9,
        MouseButton10,
        MouseButton11,
        MouseButton12
    }

    public static class KeyCodes {
        public static Key KeyCodeToKey(KeyCode keyCode) {
            switch (keyCode) {
                case KeyCode.Unknown: return Key.Unknown;

                case KeyCode.Space: return Key.Space;
                case KeyCode.Apostrophe: return Key.Apostrophe;
                case KeyCode.Comma: return Key.Comma;
                case KeyCode.Minus: return Key.Minus;
                case KeyCode.Period: return Key.Period;
                case KeyCode.Slash: return Key.Slash;

                case KeyCode.Number0: return Key.Number0;
                case KeyCode.Number1: return Key.Number1;
                case KeyCode.Number2: return Key.Number2;
                case KeyCode.Number3: return Key.Number3;
                case KeyCode.Number4: return Key.Number4;
                case KeyCode.Number5: return Key.Number5;
                case KeyCode.Number6: return Key.Number6;
                case KeyCode.Number7: return Key.Number7;
                case KeyCode.Number8: return Key.Number8;
                case KeyCode.Number9: return Key.Number9;

                case KeyCode.Semicolon: return Key.Semicolon;
                case KeyCode.Equal: return Key.Equal;

                case KeyCode.A: return Key.A;
                case KeyCode.B: return Key.B;
                case KeyCode.C: return Key.C;
                case KeyCode.D: return Key.D;
                case KeyCode.E: return Key.E;
                case KeyCode.F: return Key.F;
                case KeyCode.G: return Key.G;
                case KeyCode.H: return Key.H;
                case KeyCode.I: return Key.I;
                case KeyCode.J: return Key.J;
                case KeyCode.K: return Key.K;
                case KeyCode.L: return Key.L;
                case KeyCode.M: return Key.M;
                case KeyCode.N: return Key.N;
                case KeyCode.O: return Key.O;
                case KeyCode.P: return Key.P;
                case KeyCode.Q: return Key.Q;
                case KeyCode.R: return Key.R;
                case KeyCode.S: return Key.S;
                case KeyCode.T: return Key.T;
                case KeyCode.U: return Key.U;
                case KeyCode.V: return Key.V;
                case KeyCode.W: return Key.W;
                case KeyCode.X: return Key.X;
                case KeyCode.Y: return Key.Y;
                case KeyCode.Z: return Key.Z;

                case KeyCode.LeftBracket: return Key.LeftBracket;
                case KeyCode.BackSlash: return Key.BackSlash;
                case KeyCode.RightBracket: return Key.RightBracket;
                case KeyCode.GraveAccent: return Key.GraveAccent;

                case KeyCode.World1: return Key.World1;
                case KeyCode.World2: return Key.World2;

                case KeyCode.Escape: return Key.Escape;
                case KeyCode.Enter: return Key.Enter;
                case KeyCode.Tab: return Key.Tab;
                case KeyCode.Backspace: return Key.Backspace;
                case KeyCode.Insert: return Key.Insert;
                case KeyCode.Delete: return Key.Delete;

                case KeyCode.Right: return Key.Right;
                case KeyCode.Left: return Key.Left;
                case KeyCode.Down: return Key.Down;
                case KeyCode.Up: return Key.Up;
                case KeyCode.PageUp: return Key.PageUp;
                case KeyCode.PageDown: return Key.PageDown;
                case KeyCode.Home: return Key.Home;
                case KeyCode.End: return Key.End;

                case KeyCode.CapsLock: return Key.CapsLock;
                case KeyCode.ScrollLock: return Key.ScrollLock;
                case KeyCode.NumLock: return Key.NumLock;
                case KeyCode.PrintScreen: return Key.PrintScreen;
                case KeyCode.Pause: return Key.Pause;

                case KeyCode.F1: return Key.F1;
                case KeyCode.F2: return Key.F2;
                case KeyCode.F3: return Key.F3;
                case KeyCode.F4: return Key.F4;
                case KeyCode.F5: return Key.F5;
                case KeyCode.F6: return Key.F6;
                case KeyCode.F7: return Key.F7;
                case KeyCode.F8: return Key.F8;
                case KeyCode.F9: return Key.F9;
                case KeyCode.F10: return Key.F10;
                case KeyCode.F11: return Key.F11;
                case KeyCode.F12: return Key.F12;
                case KeyCode.F13: return Key.F13;
                case KeyCode.F14: return Key.F14;
                case KeyCode.F15: return Key.F15;
                case KeyCode.F16: return Key.F16;
                case KeyCode.F17: return Key.F17;
                case KeyCode.F18: return Key.F18;
                case KeyCode.F19: return Key.F19;
                case KeyCode.F20: return Key.F20;
                case KeyCode.F21: return Key.F21;
                case KeyCode.F22: return Key.F22;
                case KeyCode.F23: return Key.F23;
                case KeyCode.F24: return Key.F24;
                case KeyCode.F25: return Key.F25;

                case KeyCode.Keypad0: return Key.Keypad0;
                case KeyCode.Keypad1: return Key.Keypad1;
                case KeyCode.Keypad2: return Key.Keypad2;
                case KeyCode.Keypad3: return Key.Keypad3;
                case KeyCode.Keypad4: return Key.Keypad4;
                case KeyCode.Keypad5: return Key.Keypad5;
                case KeyCode.Keypad6: return Key.Keypad6;
                case KeyCode.Keypad7: return Key.Keypad7;
                case KeyCode.Keypad8: return Key.Keypad8;
                case KeyCode.Keypad9: return Key.Keypad9;
                case KeyCode.KeypadDecimal: return Key.KeypadDecimal;
                case KeyCode.KeypadDivide: return Key.KeypadDivide;
                case KeyCode.KeypadMultiply: return Key.KeypadMultiply;
                case KeyCode.KeypadSubtract: return Key.KeypadSubtract;
                case KeyCode.KeypadAdd: return Key.KeypadAdd;
                case KeyCode.KeypadEnter: return Key.KeypadEnter;
                case KeyCode.KeypadEqual: return Key.KeypadEqual;

                case KeyCode.ShiftLeft: return Key.ShiftLeft;
                case KeyCode.ControlLeft: return Key.ControlLeft;
                case KeyCode.AltLeft: return Key.AltLeft;
                case KeyCode.SuperLeft: return Key.SuperLeft;
                case KeyCode.ShiftRight: return Key.ShiftRight;
                case KeyCode.ControlRight: return Key.ControlRight;
                case KeyCode.AltRight: return Key.AltRight;
                case KeyCode.SuperRight: return Key.SuperRight;

                case KeyCode.Menu: return Key.Menu;

                default: return Key.Unknown;
            }
        }
        
        public static MouseButton KeyCodeToMouseButton(KeyCode keyCode) {
            switch (keyCode) {
                case KeyCode.LeftMouseButton: return MouseButton.Left;
                case KeyCode.RightMouseButton: return MouseButton.Right;
                case KeyCode.MiddleMouseButton: return MouseButton.Middle;
                case KeyCode.MouseButton4: return MouseButton.Button4;
                case KeyCode.MouseButton5: return MouseButton.Button5;
                case KeyCode.MouseButton6: return MouseButton.Button6;
                case KeyCode.MouseButton7: return MouseButton.Button7;
                case KeyCode.MouseButton8: return MouseButton.Button8;
                case KeyCode.MouseButton9: return MouseButton.Button9;
                case KeyCode.MouseButton10: return MouseButton.Button10;
                case KeyCode.MouseButton11: return MouseButton.Button11;
                case KeyCode.MouseButton12: return MouseButton.Button12;
                default: return MouseButton.Unknown;
            }
        }

        public static KeyCode KeyToKeyCode(Key key) {
            switch (key) {
                case Key.Unknown: return KeyCode.Unknown;

                case Key.Space: return KeyCode.Space;
                case Key.Apostrophe: return KeyCode.Apostrophe;
                case Key.Comma: return KeyCode.Comma;
                case Key.Minus: return KeyCode.Minus;
                case Key.Period: return KeyCode.Period;
                case Key.Slash: return KeyCode.Slash;

                case Key.Number0: return KeyCode.Number0;
                case Key.Number1: return KeyCode.Number1;
                case Key.Number2: return KeyCode.Number2;
                case Key.Number3: return KeyCode.Number3;
                case Key.Number4: return KeyCode.Number4;
                case Key.Number5: return KeyCode.Number5;
                case Key.Number6: return KeyCode.Number6;
                case Key.Number7: return KeyCode.Number7;
                case Key.Number8: return KeyCode.Number8;
                case Key.Number9: return KeyCode.Number9;

                case Key.Semicolon: return KeyCode.Semicolon;
                case Key.Equal: return KeyCode.Equal;

                case Key.A: return KeyCode.A;
                case Key.B: return KeyCode.B;
                case Key.C: return KeyCode.C;
                case Key.D: return KeyCode.D;
                case Key.E: return KeyCode.E;
                case Key.F: return KeyCode.F;
                case Key.G: return KeyCode.G;
                case Key.H: return KeyCode.H;
                case Key.I: return KeyCode.I;
                case Key.J: return KeyCode.J;
                case Key.K: return KeyCode.K;
                case Key.L: return KeyCode.L;
                case Key.M: return KeyCode.M;
                case Key.N: return KeyCode.N;
                case Key.O: return KeyCode.O;
                case Key.P: return KeyCode.P;
                case Key.Q: return KeyCode.Q;
                case Key.R: return KeyCode.R;
                case Key.S: return KeyCode.S;
                case Key.T: return KeyCode.T;
                case Key.U: return KeyCode.U;
                case Key.V: return KeyCode.V;
                case Key.W: return KeyCode.W;
                case Key.X: return KeyCode.X;
                case Key.Y: return KeyCode.Y;
                case Key.Z: return KeyCode.Z;

                case Key.LeftBracket: return KeyCode.LeftBracket;
                case Key.BackSlash: return KeyCode.BackSlash;
                case Key.RightBracket: return KeyCode.RightBracket;
                case Key.GraveAccent: return KeyCode.GraveAccent;

                case Key.World1: return KeyCode.World1;
                case Key.World2: return KeyCode.World2;

                case Key.Escape: return KeyCode.Escape;
                case Key.Enter: return KeyCode.Enter;
                case Key.Tab: return KeyCode.Tab;
                case Key.Backspace: return KeyCode.Backspace;
                case Key.Insert: return KeyCode.Insert;
                case Key.Delete: return KeyCode.Delete;

                case Key.Right: return KeyCode.Right;
                case Key.Left: return KeyCode.Left;
                case Key.Down: return KeyCode.Down;
                case Key.Up: return KeyCode.Up;
                case Key.PageUp: return KeyCode.PageUp;
                case Key.PageDown: return KeyCode.PageDown;
                case Key.Home: return KeyCode.Home;
                case Key.End: return KeyCode.End;

                case Key.CapsLock: return KeyCode.CapsLock;
                case Key.ScrollLock: return KeyCode.ScrollLock;
                case Key.NumLock: return KeyCode.NumLock;
                case Key.PrintScreen: return KeyCode.PrintScreen;
                case Key.Pause: return KeyCode.Pause;

                case Key.F1: return KeyCode.F1;
                case Key.F2: return KeyCode.F2;
                case Key.F3: return KeyCode.F3;
                case Key.F4: return KeyCode.F4;
                case Key.F5: return KeyCode.F5;
                case Key.F6: return KeyCode.F6;
                case Key.F7: return KeyCode.F7;
                case Key.F8: return KeyCode.F8;
                case Key.F9: return KeyCode.F9;
                case Key.F10: return KeyCode.F10;
                case Key.F11: return KeyCode.F11;
                case Key.F12: return KeyCode.F12;
                case Key.F13: return KeyCode.F13;
                case Key.F14: return KeyCode.F14;
                case Key.F15: return KeyCode.F15;
                case Key.F16: return KeyCode.F16;
                case Key.F17: return KeyCode.F17;
                case Key.F18: return KeyCode.F18;
                case Key.F19: return KeyCode.F19;
                case Key.F20: return KeyCode.F20;
                case Key.F21: return KeyCode.F21;
                case Key.F22: return KeyCode.F22;
                case Key.F23: return KeyCode.F23;
                case Key.F24: return KeyCode.F24;
                case Key.F25: return KeyCode.F25;

                case Key.Keypad0: return KeyCode.Keypad0;
                case Key.Keypad1: return KeyCode.Keypad1;
                case Key.Keypad2: return KeyCode.Keypad2;
                case Key.Keypad3: return KeyCode.Keypad3;
                case Key.Keypad4: return KeyCode.Keypad4;
                case Key.Keypad5: return KeyCode.Keypad5;
                case Key.Keypad6: return KeyCode.Keypad6;
                case Key.Keypad7: return KeyCode.Keypad7;
                case Key.Keypad8: return KeyCode.Keypad8;
                case Key.Keypad9: return KeyCode.Keypad9;
                case Key.KeypadDecimal: return KeyCode.KeypadDecimal;
                case Key.KeypadDivide: return KeyCode.KeypadDivide;
                case Key.KeypadMultiply: return KeyCode.KeypadMultiply;
                case Key.KeypadSubtract: return KeyCode.KeypadSubtract;
                case Key.KeypadAdd: return KeyCode.KeypadAdd;
                case Key.KeypadEnter: return KeyCode.KeypadEnter;
                case Key.KeypadEqual: return KeyCode.KeypadEqual;

                case Key.ShiftLeft: return KeyCode.ShiftLeft;
                case Key.ControlLeft: return KeyCode.ControlLeft;
                case Key.AltLeft: return KeyCode.AltLeft;
                case Key.SuperLeft: return KeyCode.SuperLeft;
                case Key.ShiftRight: return KeyCode.ShiftRight;
                case Key.ControlRight: return KeyCode.ControlRight;
                case Key.AltRight: return KeyCode.AltRight;
                case Key.SuperRight: return KeyCode.SuperRight;

                case Key.Menu: return KeyCode.Menu;

                default: return KeyCode.Unknown;
            }
        }
    
        public static KeyCode MouseButtonToKeyCode(MouseButton button) {
            switch (button) {
                case MouseButton.Left: return KeyCode.LeftMouseButton;
                case MouseButton.Right: return KeyCode.RightMouseButton;
                case MouseButton.Middle: return KeyCode.MiddleMouseButton;
                case MouseButton.Button4: return KeyCode.MouseButton4;
                case MouseButton.Button5: return KeyCode.MouseButton5;
                case MouseButton.Button6: return KeyCode.MouseButton6;
                case MouseButton.Button7: return KeyCode.MouseButton7;
                case MouseButton.Button8: return KeyCode.MouseButton8;
                case MouseButton.Button9: return KeyCode.MouseButton9;
                case MouseButton.Button10: return KeyCode.MouseButton10;
                case MouseButton.Button11: return KeyCode.MouseButton11;
                case MouseButton.Button12: return KeyCode.MouseButton12;
                default: return KeyCode.Unknown;
            }
        }
    }
}
