using Silk.NET.Input;


namespace NovaEngine {
    public enum MouseMode {
        /// <summary>
        /// Cursor is visible and has no restrictions on mobility.
        /// </summary>
        Normal,

        /// <summary>
        /// Cursor is invisible, and has no restrictions on mobility.
        /// </summary>
        Hidden,

        /// <summary>
        /// Cursor is invisible, and is restricted to the center of the screen.
        /// </summary>
        /// <remarks>
        /// Only supported by GLFW, throws on SDL if used.
        /// </remarks>
        Disabled,

        /// <summary>
        /// Cursor is invisible, and is restricted to the center of the screen. Mouse motion is not scaled.
        /// </summary>
        Raw
    }

    public static class MouseModes {
        public static MouseMode CursorModeToMouseMode(CursorMode cursorMode) {
            switch (cursorMode) {
                case CursorMode.Normal: return MouseMode.Normal;
                case CursorMode.Hidden: return MouseMode.Hidden;
                case CursorMode.Disabled: return MouseMode.Disabled;
                case CursorMode.Raw: return MouseMode.Raw;
                default: return MouseMode.Normal;
            }
        }

        public static CursorMode MouseModeToCursorMode(MouseMode mouseMode) {
            switch (mouseMode) {
                case MouseMode.Normal: return CursorMode.Normal;
                case MouseMode.Hidden: return CursorMode.Hidden;
                case MouseMode.Disabled: return CursorMode.Disabled;
                case MouseMode.Raw: return CursorMode.Raw;
                default: return CursorMode.Normal;
            }
        }
    }
}
