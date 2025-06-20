using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Numerics;

using System.Drawing;

using Nova.Core;
using Nova.Utilities;
using Nova.ObjectOrientedArchitecture;


class Program {
    private static IWindow window = null!;

    private static IKeyboard primaryKeyboard = null!;

    private static GameObject cameraObject = null!;
    private static float yaw = -90f;
    private static float pitch = 0f;

    private static Vector2 lastMousePosition;

    private static GameObject gameObject1 = new GameObject();
    private static GameObject gameObject2 = new GameObject();

    private static readonly float[] vertices = {
        //X    Y      Z     U   V
        -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,
         0.5f, -0.5f, -0.5f,  1.0f, 0.0f,
         0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
         0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
        -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
        -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,

        -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
         0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
         0.5f,  0.5f,  0.5f,  1.0f, 1.0f,
         0.5f,  0.5f,  0.5f,  1.0f, 1.0f,
        -0.5f,  0.5f,  0.5f,  0.0f, 1.0f,
        -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,

        -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
        -0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
        -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
        -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
        -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
        -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,

         0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
         0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
         0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
         0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
         0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
         0.5f,  0.5f,  0.5f,  1.0f, 0.0f,

        -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
         0.5f, -0.5f, -0.5f,  1.0f, 1.0f,
         0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
         0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
        -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
        -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,

        -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
         0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
         0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
         0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
        -0.5f,  0.5f,  0.5f,  0.0f, 0.0f,
        -0.5f,  0.5f, -0.5f,  0.0f, 1.0f
    };

    private static readonly uint[] indices = {
        0, 1, 3,
        1, 2, 3
    };


    static void Main(string[] args) {
        WindowOptions options = WindowOptions.Default with {
            Size = new Vector2D<int>(800, 600),
            Title = "Nova",
            VSync = false
        };

        window = Window.Create(options);

        window.Load += OnLoad;
        window.Update += OnUpdate;
        window.Render += OnRender;
        window.FramebufferResize += OnFramebufferResize;
        window.Closing += OnClose;

        window.Run();
        window.Dispose();
    }


    private static void OnLoad() {
        // Camera
        cameraObject = new GameObject();
        cameraObject.AddComponent(new Transform());
        cameraObject.GetComponent<Transform>().position = new Vector3(0.0f, 0.0f, 3.0f);
        cameraObject.GetComponent<Transform>().rotationEulerAngles = new Vector3(0.0f, 0.0f, -1.0f);

        cameraObject.AddComponent(new Camera());

        // Input Init
        IInputContext input = window.CreateInput();

        primaryKeyboard = input.Keyboards.FirstOrDefault()!;
        if (primaryKeyboard != null) {
            primaryKeyboard.KeyDown += KeyDown;
        }

        for (int i = 0; i < input.Mice.Count; i++) {
            input.Mice[i].Cursor.CursorMode = CursorMode.Raw;
            input.Mice[i].MouseMove += OnMouseMove;
        }

        // OpenGL Init
        Engine.gl = window.CreateOpenGL();
        Engine.gl.ClearColor(Color.CornflowerBlue);

        // Enable blending for textures and set the blend to use the alpha to subtract
        Engine.gl.Enable(EnableCap.Blend);
        Engine.gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

        // Enable backface culling
        Engine.gl.Enable(GLEnum.CullFace);

        // Add Game Objects
        gameObject1.AddComponent(new Transform());
        gameObject1.AddComponent(new Mesh(vertices, indices, "shader.vert", "shader.frag", "silk.png"));

        gameObject2.AddComponent(new Transform());
        gameObject2.AddComponent(new Mesh(vertices, indices, "shader.vert", "shader.frag", "silk.png"));

        gameObject2.GetComponent<Transform>().position = new Vector3(3, 0, 3);
    }


    private static void OnUpdate(double deltaTime) {
        Transform cameraTransform = cameraObject.GetComponent<Transform>();

        var moveSpeed = 2.5f * (float) deltaTime;

        if (primaryKeyboard.IsKeyPressed(Key.W)) {
            //Move forwards
            cameraTransform.position += moveSpeed * cameraTransform.rotationEulerAngles;
        }
        if (primaryKeyboard.IsKeyPressed(Key.S)) {
            //Move backwards
            cameraTransform.position -= moveSpeed * cameraTransform.rotationEulerAngles;
        }
        if (primaryKeyboard.IsKeyPressed(Key.A)) {
            //Move left
            cameraTransform.position -= Vector3.Normalize(Vector3.Cross(cameraTransform.rotationEulerAngles, Vector3.UnitY)) * moveSpeed;
        }
        if (primaryKeyboard.IsKeyPressed(Key.D)) {
            //Move right
            cameraTransform.position += Vector3.Normalize(Vector3.Cross(cameraTransform.rotationEulerAngles, Vector3.UnitY)) * moveSpeed;
        }
    }


    private static void OnRender(double deltaTime) {
        Engine.gl.Enable(EnableCap.DepthTest);
        Engine.gl.Clear((uint) (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit));


        float difference = (float) (window.Time * 100);
        gameObject1.GetComponent<Transform>().rotationEulerAngles = new Vector3(difference, difference, 0);

        gameObject1.GetComponent<Mesh>().Render(cameraObject.GetComponent<Camera>(), window.FramebufferSize);
        gameObject2.GetComponent<Mesh>().Render(cameraObject.GetComponent<Camera>(), window.FramebufferSize);
    }


    private static void OnFramebufferResize(Vector2D<int> newSize) {
        Engine.gl.Viewport(newSize);
    }


    private static void OnMouseMove(IMouse mouse, Vector2 position) {
        Transform cameraTransform = cameraObject.GetComponent<Transform>();

        var lookSensitivity = 0.1f;
        if (lastMousePosition == default) lastMousePosition = position;
        else {
            var xOffset = (position.X - lastMousePosition.X) * lookSensitivity;
            var yOffset = (position.Y - lastMousePosition.Y) * lookSensitivity;
            lastMousePosition = position;

            yaw += xOffset;
            pitch -= yOffset;

            pitch = Math.Clamp(pitch, -89.0f, 89.0f);

            cameraTransform.rotationEulerX = MathF.Cos(MathUtils.DegreesToRadians(yaw)) * MathF.Cos(MathUtils.DegreesToRadians(pitch));
            cameraTransform.rotationEulerY = MathF.Sin(MathUtils.DegreesToRadians(pitch));
            cameraTransform.rotationEulerZ = MathF.Sin(MathUtils.DegreesToRadians(yaw)) * MathF.Cos(MathUtils.DegreesToRadians(pitch));
        }
    }


    private static void OnClose() {
        gameObject1.Dispose();
        gameObject2.Dispose();
    }


    private static void KeyDown(IKeyboard keyboard, Key key, int keyCode) {
        if (key == Key.Escape) {
            window.Close();
        }
    }
}



// To Do List
// Implement the 'Scene' class for rendering
// Move the example file to the main Program file
// Create a Debug class
// Fix VertexAttributePointer and Mesh Render method so they are more useable
// Lighting - Ambient, Diffuse, Specular
