namespace Nova;


public abstract class Window {
    public abstract void Open();
    public abstract void Close();
    public abstract bool WindowShouldClose();


    public enum Backend {Raylib}

    public static Window CreateWindow(Backend backend) {
        Window? window;

        switch (backend) {
            case Backend.Raylib:
                window = new RaylibWindow();
                break;
            default:
                throw new ArgumentException("Unsupported platform");
        }

        return window;
    }
}
