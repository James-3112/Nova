using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Numerics;

using System.Drawing;

using StbImageSharp;

using Nova.Graphics;
using Nova.Utilities;


class Program {
    private static IWindow window = null!;
    private static GL gl = null!;

    private static IKeyboard primaryKeyboard = null!;

    private static BufferObject<float> vbo = null!;
    private static BufferObject<uint> ebo = null!;
    private static VertexArrayObject<float, uint> vao = null!;

    public static Nova.Graphics.Texture texture = null!;
    private static Nova.Graphics.Shader shader = null!;

    private static Camera camera = null!;
    private static float yaw = -90f;
    private static float pitch = 0f;

    private static Vector2 lastMousePosition;

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
            Title = "Nova"
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


    private unsafe static void OnLoad() {
        // Camera
        camera = new Camera();
        camera.transform.position = new Vector3(0.0f, 0.0f, 3.0f);
        camera.transform.rotationEulerAngles = new Vector3(0.0f, 0.0f, -1.0f);

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
        gl = window.CreateOpenGL();
        gl.ClearColor(Color.CornflowerBlue);

        //Instantiating our new abstractions
        ebo = new BufferObject<uint>(gl, indices, BufferTargetARB.ElementArrayBuffer);
        vbo = new BufferObject<float>(gl, vertices, BufferTargetARB.ArrayBuffer);
        vao = new VertexArrayObject<float, uint>(gl, vbo, ebo);

        //Telling the VAO object how to lay out the attribute pointers
        vao.VertexAttributePointer(0, 3, VertexAttribPointerType.Float, 5, 0);
        vao.VertexAttributePointer(1, 2, VertexAttribPointerType.Float, 5, 3);

        shader = new Nova.Graphics.Shader(gl, "shader.vert", "shader.frag");
        texture = new Nova.Graphics.Texture(gl, "silk.png");
    }


    private static void OnUpdate(double deltaTime) {
        var moveSpeed = 2.5f * (float) deltaTime;

        if (primaryKeyboard.IsKeyPressed(Key.W)) {
            //Move forwards
            camera.transform.position += moveSpeed * camera.transform.rotationEulerAngles;
        }
        if (primaryKeyboard.IsKeyPressed(Key.S)) {
            //Move backwards
            camera.transform.position -= moveSpeed * camera.transform.rotationEulerAngles;
        }
        if (primaryKeyboard.IsKeyPressed(Key.A)) {
            //Move left
            camera.transform.position -= Vector3.Normalize(Vector3.Cross(camera.transform.rotationEulerAngles, Vector3.UnitY)) * moveSpeed;
        }
        if (primaryKeyboard.IsKeyPressed(Key.D)) {
            //Move right
            camera.transform.position += Vector3.Normalize(Vector3.Cross(camera.transform.rotationEulerAngles, Vector3.UnitY)) * moveSpeed;
        }
    }


    private unsafe static void OnRender(double deltaTime) {
        gl.Enable(EnableCap.DepthTest);
        gl.Clear((uint) (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit));

        vao.Bind();
        texture.Bind(TextureUnit.Texture0);
        
        shader.Use();
        shader.SetUniform("uTexture", 0);

        float difference = (float) (window.Time * 100);

        Transform transform = new Transform();
        transform.rotationEulerAngles = new Vector3(difference, difference, 0);
        shader.SetUniform("uModel", transform.matrix);

        camera.CreateMatrices(shader, window.FramebufferSize);

        gl.DrawArrays(PrimitiveType.Triangles, 0, 36);
    }


    private static void OnFramebufferResize(Vector2D<int> newSize) {
        gl.Viewport(newSize);
    }


    private static unsafe void OnMouseMove(IMouse mouse, Vector2 position) {
        var lookSensitivity = 0.1f;
        if (lastMousePosition == default) lastMousePosition = position;
        else {
            var xOffset = (position.X - lastMousePosition.X) * lookSensitivity;
            var yOffset = (position.Y - lastMousePosition.Y) * lookSensitivity;
            lastMousePosition = position;

            yaw += xOffset;
            pitch -= yOffset;

            pitch = Math.Clamp(pitch, -89.0f, 89.0f);

            camera.transform.rotationEulerX = MathF.Cos(MathUtils.DegreesToRadians(yaw)) * MathF.Cos(MathUtils.DegreesToRadians(pitch));
            camera.transform.rotationEulerY = MathF.Sin(MathUtils.DegreesToRadians(pitch));
            camera.transform.rotationEulerZ = MathF.Sin(MathUtils.DegreesToRadians(yaw)) * MathF.Cos(MathUtils.DegreesToRadians(pitch));
        }
    }


    private static void OnClose() {
        vbo.Dispose();
        ebo.Dispose();
        vao.Dispose();
        shader.Dispose();
        texture.Dispose();
    }

    private static void KeyDown(IKeyboard keyboard, Key key, int keyCode) {
        if (key == Key.Escape) {
            window.Close();
        }
    }
}



// To Do
// Back face culling off
// V-sync off
