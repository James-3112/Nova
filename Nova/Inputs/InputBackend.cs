namespace Nova;


public abstract class InputBackend {
    public abstract bool IsKeyPressed(Input.KeyCode key);       // Check if a key has been pressed once
    public abstract bool IsKeyPressedRepeat(Input.KeyCode key); // Check if a key has been pressed again
    public abstract bool IsKeyDown(Input.KeyCode key);          // Check if a key is being pressed
    public abstract bool IsKeyReleased(Input.KeyCode key);      // Check if a key has been released once
    public abstract bool IsKeyUp(Input.KeyCode key);            // Check if a key is NOT being pressed
    public abstract Input.KeyCode GetKeyPressed();              // Get key pressed (keycode), call it multiple times for keys queued, returns 0 when the queue is empty
}
