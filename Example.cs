using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Numerics;

using System.Drawing;

using Nova.Core;
using Nova.Utilities;
using Nova.ObjectOrientedArchitecture;


class Example {
    private static Engine engine = null!;

    private static Camera camera = null!;
    private static float yaw = -90f;
    private static float pitch = 0f;
    private static float lookSensitivity = 0.1f;

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


    static void ExampleInit(string[] args) {
        engine = new Engine();
        engine.startEvent += Start;
        engine.updateEvent += Update;

        engine.Run();
    }


    private static void Start() {
        // Camera
        camera = new Camera();
        camera.transform.position = new Vector3(0.0f, 0.0f, 3.0f);
        camera.transform.rotationEulerAngles = new Vector3(0.0f, 0.0f, -1.0f);

        // Add Game Objects
        gameObject1.AddComponent(new Transform());
        gameObject1.AddComponent(new Mesh(vertices, indices, "shader.vert", "shader.frag", "silk.png"));

        gameObject2.AddComponent(new Transform());
        gameObject2.AddComponent(new Mesh(vertices, indices, "shader.vert", "shader.frag", "silk.png"));

        gameObject2.GetComponent<Transform>().position = new Vector3(3, 0, 3);
    }


    private static void Update(double deltaTime) {
        // Movement
        float moveSpeed = 2.5f * (float)deltaTime;

        if (Input.IsKeyPressed(Key.W)) {
            camera.transform.position += moveSpeed * camera.transform.rotationEulerAngles;
        }
        if (Input.IsKeyPressed(Key.S)) {
            camera.transform.position -= moveSpeed * camera.transform.rotationEulerAngles;
        }
        if (Input.IsKeyPressed(Key.A)) {
            camera.transform.position -= Vector3.Normalize(Vector3.Cross(camera.transform.rotationEulerAngles, Vector3.UnitY)) * moveSpeed;
        }
        if (Input.IsKeyPressed(Key.D)) {
            camera.transform.position += Vector3.Normalize(Vector3.Cross(camera.transform.rotationEulerAngles, Vector3.UnitY)) * moveSpeed;
        }

        // Camera
        yaw += Input.mouseDeltaPosition.X * lookSensitivity;
        pitch -= Input.mouseDeltaPosition.Y * lookSensitivity;

        pitch = Math.Clamp(pitch, -89.0f, 89.0f);

        camera.transform.rotationEulerX = MathF.Cos(MathUtils.DegreesToRadians(yaw)) * MathF.Cos(MathUtils.DegreesToRadians(pitch));
        camera.transform.rotationEulerY = MathF.Sin(MathUtils.DegreesToRadians(pitch));
        camera.transform.rotationEulerZ = MathF.Sin(MathUtils.DegreesToRadians(yaw)) * MathF.Cos(MathUtils.DegreesToRadians(pitch));

        // Quiting
        if (Input.IsKeyPressed(Key.Escape)) engine.Close();
    }
}
