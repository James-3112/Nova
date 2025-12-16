using Raylib_cs;

namespace Nova;


public class RaylibInput : InputBackend {
    public override bool IsKeyPressed(Input.KeyCode key) {
        return Raylib.IsKeyPressed(keyCodeToKeyboardKey[key]);
    }

    public override bool IsKeyPressedRepeat(Input.KeyCode key) {
        return Raylib.IsKeyPressedRepeat(keyCodeToKeyboardKey[key]);
    }

    public override bool IsKeyDown(Input.KeyCode key) {
        return Raylib.IsKeyDown(keyCodeToKeyboardKey[key]);
    }

    public override bool IsKeyReleased(Input.KeyCode key) {
        return Raylib.IsKeyReleased(keyCodeToKeyboardKey[key]);
    }

    public override bool IsKeyUp(Input.KeyCode key) {
        return Raylib.IsKeyUp(keyCodeToKeyboardKey[key]);
    }

    public override Input.KeyCode GetKeyPressed() {
        return keyboardKeyToKeyCode[(KeyboardKey)Raylib.GetKeyPressed()];
    }


    private static readonly Dictionary<Input.KeyCode, KeyboardKey> keyCodeToKeyboardKey = new() {
        {Input.KeyCode.Null, KeyboardKey.Null},

        // Alphanumeric keys
        {Input.KeyCode.Apostrophe, KeyboardKey.Apostrophe},
        {Input.KeyCode.Comma, KeyboardKey.Comma},
        {Input.KeyCode.Minus, KeyboardKey.Minus},
        {Input.KeyCode.Period, KeyboardKey.Period},
        {Input.KeyCode.Slash, KeyboardKey.Slash},
        {Input.KeyCode.Zero, KeyboardKey.Zero},
        {Input.KeyCode.One, KeyboardKey.One},
        {Input.KeyCode.Two, KeyboardKey.Two},
        {Input.KeyCode.Three, KeyboardKey.Three},
        {Input.KeyCode.Four, KeyboardKey.Four},
        {Input.KeyCode.Five, KeyboardKey.Five},
        {Input.KeyCode.Six, KeyboardKey.Six},
        {Input.KeyCode.Seven, KeyboardKey.Seven},
        {Input.KeyCode.Eight, KeyboardKey.Eight},
        {Input.KeyCode.Nine, KeyboardKey.Nine},
        {Input.KeyCode.Semicolon, KeyboardKey.Semicolon},
        {Input.KeyCode.Equal, KeyboardKey.Equal},

        {Input.KeyCode.A, KeyboardKey.A},
        {Input.KeyCode.B, KeyboardKey.B},
        {Input.KeyCode.C, KeyboardKey.C},
        {Input.KeyCode.D, KeyboardKey.D},
        {Input.KeyCode.E, KeyboardKey.E},
        {Input.KeyCode.F, KeyboardKey.F},
        {Input.KeyCode.G, KeyboardKey.G},
        {Input.KeyCode.H, KeyboardKey.H},
        {Input.KeyCode.I, KeyboardKey.I},
        {Input.KeyCode.J, KeyboardKey.J},
        {Input.KeyCode.K, KeyboardKey.K},
        {Input.KeyCode.L, KeyboardKey.L},
        {Input.KeyCode.M, KeyboardKey.M},
        {Input.KeyCode.N, KeyboardKey.N},
        {Input.KeyCode.O, KeyboardKey.O},
        {Input.KeyCode.P, KeyboardKey.P},
        {Input.KeyCode.Q, KeyboardKey.Q},
        {Input.KeyCode.R, KeyboardKey.R},
        {Input.KeyCode.S, KeyboardKey.S},
        {Input.KeyCode.T, KeyboardKey.T},
        {Input.KeyCode.U, KeyboardKey.U},
        {Input.KeyCode.V, KeyboardKey.V},
        {Input.KeyCode.W, KeyboardKey.W},
        {Input.KeyCode.X, KeyboardKey.X},
        {Input.KeyCode.Y, KeyboardKey.Y},
        {Input.KeyCode.Z, KeyboardKey.Z},

        // Function keys
        {Input.KeyCode.Space, KeyboardKey.Space},
        {Input.KeyCode.Escape, KeyboardKey.Escape},
        {Input.KeyCode.Enter, KeyboardKey.Enter},
        {Input.KeyCode.Tab, KeyboardKey.Tab},
        {Input.KeyCode.Backspace, KeyboardKey.Backspace},
        {Input.KeyCode.Insert, KeyboardKey.Insert},
        {Input.KeyCode.Delete, KeyboardKey.Delete},
        {Input.KeyCode.Right, KeyboardKey.Right},
        {Input.KeyCode.Left, KeyboardKey.Left},
        {Input.KeyCode.Down, KeyboardKey.Down},
        {Input.KeyCode.Up, KeyboardKey.Up},
        {Input.KeyCode.PageUp, KeyboardKey.PageUp},
        {Input.KeyCode.PageDown, KeyboardKey.PageDown},
        {Input.KeyCode.Home, KeyboardKey.Home},
        {Input.KeyCode.End, KeyboardKey.End},
        {Input.KeyCode.CapsLock, KeyboardKey.CapsLock},
        {Input.KeyCode.ScrollLock, KeyboardKey.ScrollLock},
        {Input.KeyCode.NumLock, KeyboardKey.NumLock},
        {Input.KeyCode.PrintScreen, KeyboardKey.PrintScreen},
        {Input.KeyCode.Pause, KeyboardKey.Pause},
        {Input.KeyCode.F1, KeyboardKey.F1},
        {Input.KeyCode.F2, KeyboardKey.F2},
        {Input.KeyCode.F3, KeyboardKey.F3},
        {Input.KeyCode.F4, KeyboardKey.F4},
        {Input.KeyCode.F5, KeyboardKey.F5},
        {Input.KeyCode.F6, KeyboardKey.F6},
        {Input.KeyCode.F7, KeyboardKey.F7},
        {Input.KeyCode.F8, KeyboardKey.F8},
        {Input.KeyCode.F9, KeyboardKey.F9},
        {Input.KeyCode.F10, KeyboardKey.F10},
        {Input.KeyCode.F11, KeyboardKey.F11},
        {Input.KeyCode.F12, KeyboardKey.F12},
        {Input.KeyCode.LeftShift, KeyboardKey.LeftShift},
        {Input.KeyCode.LeftControl, KeyboardKey.LeftControl},
        {Input.KeyCode.LeftAlt, KeyboardKey.LeftAlt},
        {Input.KeyCode.LeftSuper, KeyboardKey.LeftSuper},
        {Input.KeyCode.RightShift, KeyboardKey.RightShift},
        {Input.KeyCode.RightControl, KeyboardKey.RightControl},
        {Input.KeyCode.RightAlt, KeyboardKey.RightAlt},
        {Input.KeyCode.RightSuper, KeyboardKey.RightSuper},
        {Input.KeyCode.KeyboardMenu, KeyboardKey.KeyboardMenu},
        {Input.KeyCode.LeftBracket, KeyboardKey.LeftBracket},
        {Input.KeyCode.Backslash, KeyboardKey.Backslash},
        {Input.KeyCode.RightBracket, KeyboardKey.RightBracket},
        {Input.KeyCode.Grave, KeyboardKey.Grave},

        // Keypad keys
        {Input.KeyCode.Keypad0, KeyboardKey.Kp0},
        {Input.KeyCode.Keypad1, KeyboardKey.Kp1},
        {Input.KeyCode.Keypad2, KeyboardKey.Kp2},
        {Input.KeyCode.Keypad3, KeyboardKey.Kp3},
        {Input.KeyCode.Keypad4, KeyboardKey.Kp4},
        {Input.KeyCode.Keypad5, KeyboardKey.Kp5},
        {Input.KeyCode.Keypad6, KeyboardKey.Kp6},
        {Input.KeyCode.Keypad7, KeyboardKey.Kp7},
        {Input.KeyCode.Keypad8, KeyboardKey.Kp8},
        {Input.KeyCode.Keypad9, KeyboardKey.Kp9},
        {Input.KeyCode.KeypadDecimal, KeyboardKey.KpDecimal},
        {Input.KeyCode.KeypadDivide, KeyboardKey.KpDivide},
        {Input.KeyCode.KeypadMultiply, KeyboardKey.KpMultiply},
        {Input.KeyCode.KeypadSubtract, KeyboardKey.KpSubtract},
        {Input.KeyCode.KeypadAdd, KeyboardKey.KpAdd},
        {Input.KeyCode.KeypadEnter, KeyboardKey.KpEnter},
        {Input.KeyCode.KeypadEqual, KeyboardKey.KpEqual},
    };

    private static readonly Dictionary<KeyboardKey, Input.KeyCode> keyboardKeyToKeyCode = keyCodeToKeyboardKey.ToDictionary(pair => pair.Value, pair => pair.Key);
}
