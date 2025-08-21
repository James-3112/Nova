﻿using System.Numerics;
using NovaEngine;


class Program {
    private static float[] vertices = {
        // Front face
        -0.5f, -0.5f,  0.5f,  0f, 0f,
        0.5f, -0.5f,  0.5f,  1f, 0f,
        0.5f,  0.5f,  0.5f,  1f, 1f,
        -0.5f,  0.5f,  0.5f,  0f, 1f,

        // Back face
        0.5f, -0.5f, -0.5f,  0f, 0f,
        -0.5f, -0.5f, -0.5f,  1f, 0f,
        -0.5f,  0.5f, -0.5f,  1f, 1f,
        0.5f,  0.5f, -0.5f,  0f, 1f,

        // Left face
        -0.5f, -0.5f, -0.5f,  0f, 0f,
        -0.5f, -0.5f,  0.5f,  1f, 0f,
        -0.5f,  0.5f,  0.5f,  1f, 1f,
        -0.5f,  0.5f, -0.5f,  0f, 1f,

        // Right face
        0.5f, -0.5f,  0.5f,  0f, 0f,
        0.5f, -0.5f, -0.5f,  1f, 0f,
        0.5f,  0.5f, -0.5f,  1f, 1f,
        0.5f,  0.5f,  0.5f,  0f, 1f,

        // Top face
        -0.5f,  0.5f,  0.5f,  0f, 0f,
        0.5f,  0.5f,  0.5f,  1f, 0f,
        0.5f,  0.5f, -0.5f,  1f, 1f,
        -0.5f,  0.5f, -0.5f,  0f, 1f,

        // Bottom face
        -0.5f, -0.5f, -0.5f,  0f, 0f,
        0.5f, -0.5f, -0.5f,  1f, 0f,
        0.5f, -0.5f,  0.5f,  1f, 1f,
        -0.5f, -0.5f,  0.5f,  0f, 1f
    };

    private static uint[] indices = {
        // Front
        0, 1, 2,  2, 3, 0,
        // Back
        4, 5, 6,  6, 7, 4,
        // Left
        8, 9,10, 10,11, 8,
        // Right
    12,13,14, 14,15,12,
        // Top
    16,17,18, 18,19,16,
        // Bottom
    20,21,22, 22,23,20
    };

    static void Main(string[] args) {
        Application application = new Application();
        
        application.AddLayer<SceneLayer>();
        application.AddLayer<GameLayer>();
        application.AddLayer<InputLayer>();
        application.AddLayer<RendererLayer>(RendererLayer.Backend.OpenGL);

        application.Start();
    }

    private class GameLayer : Layer {
        GameObject cameraGameObject = new GameObject();
        Camera camera = new Camera();
        private static float yaw = -90f;
        private static float pitch = 0f;
        private static float lookSensitivity = 0.1f;

        public override void Start() {
            cameraGameObject.AddComponent(new Transform());
            cameraGameObject.GetComponent<Transform>().position = new Vector3(0.0f, 0.0f, 3.0f);
            cameraGameObject.GetComponent<Transform>().rotationEulerAngles = new Vector3(0.0f, 0.0f, -1.0f);

            cameraGameObject.AddComponent(camera);

            GameObject gameObject = new GameObject();
            gameObject.AddComponent(new Transform());
            gameObject.AddComponent(new Mesh(vertices, indices));
            gameObject.AddComponent(new MeshRenderer(new Shader("shader.vert", "shader.frag"), new Texture("silk.png")));

            Scene scene = new Scene();
            scene.AddGameObject(cameraGameObject);
            scene.AddGameObject(gameObject);

            SceneManager.LoadScene(scene);
            if (SceneManager.sceneLayer != null) SceneManager.sceneLayer.scene.mainCamera = camera;
        
            Input.SetMouseMode(MouseMode.Raw);
        }

        public override void Update(double deltaTime) {
            if (Input.IsKeyPressed(KeyCode.Escape)) {
                Application.Instance.Quit();
            }

            var moveSpeed = 2.5f * (float) deltaTime;
            Transform cameraTransform = cameraGameObject.GetComponent<Transform>();

            if (Input.IsKeyHeld(KeyCode.W)) cameraTransform.position += moveSpeed * cameraTransform.rotationEulerAngles;
            if (Input.IsKeyHeld(KeyCode.S)) cameraTransform.position -= moveSpeed * cameraTransform.rotationEulerAngles;
            if (Input.IsKeyHeld(KeyCode.A)) cameraTransform.position -= Vector3.Normalize(Vector3.Cross(cameraTransform.rotationEulerAngles, Vector3.UnitY)) * moveSpeed;
            if (Input.IsKeyHeld(KeyCode.D)) cameraTransform.position += Vector3.Normalize(Vector3.Cross(cameraTransform.rotationEulerAngles, Vector3.UnitY)) * moveSpeed;

            // Camera
            yaw += InputLayer.mouseDeltaPosition.X * lookSensitivity;
            pitch -= InputLayer.mouseDeltaPosition.Y * lookSensitivity;

            pitch = Math.Clamp(pitch, -89.0f, 89.0f);

            cameraTransform.rotationEulerX = MathF.Cos(MathUtils.DegreesToRadians(yaw)) * MathF.Cos(MathUtils.DegreesToRadians(pitch));
            cameraTransform.rotationEulerY = MathF.Sin(MathUtils.DegreesToRadians(pitch));
            cameraTransform.rotationEulerZ = MathF.Sin(MathUtils.DegreesToRadians(yaw)) * MathF.Cos(MathUtils.DegreesToRadians(pitch));
        }

        public override void Dispose() {

        }
    }
}
