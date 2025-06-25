using System.Numerics;
using ImGuiNET;
using NovaEngine;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using Silk.NET.Windowing;

// namespace NovaEditor {
//     class Program {
//         static void Main(string[] args) {
//             Scene editorScene = new Scene();
//             EditorLayer editor = new EditorLayer();

//             Application.Start(editorScene, 1280, 720, "Nova Editor", false, editor);
//         }
//     }
// }


namespace NovaEditor {
    class Program {
        private static IWindow _window = null!;
        private static GL _gl = null!;
        private static ImGuiController _imGuiController = null!;

        static void Main()
        {
            var options = WindowOptions.Default;
            options.Size = new Vector2D<int>(1280, 720);
            options.Title = "Silk.NET ImGui Editor Test";
            options.VSync = true;

            _window = Window.Create(options);
            _window.Load += OnLoad;
            _window.Render += OnRender;
            _window.Closing += OnClose;

            _window.Run();
        }

        private static unsafe void OnLoad()
        {
            _gl = _window.CreateOpenGL();

            // Setup ImGui controller with docking enabled
            _imGuiController = new ImGuiController(_gl, _window, _window.CreateInput());
            ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;

            // Setup ImGui style for docking
            ImGui.StyleColorsDark();

            // Enable Docking (optional: can be done in ImGuiConfigFlags)
            var io = ImGui.GetIO();
            io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        }

        private static unsafe void OnRender(double delta)
        {
            _gl.ClearColor(0.1f, 0.1f, 0.1f, 1f);
            _gl.Clear((uint)ClearBufferMask.ColorBufferBit | (uint)ClearBufferMask.DepthBufferBit);

            _imGuiController.Update((float)delta);

            DrawDockspace();

            _imGuiController.Render();
        }

        private static void OnClose()
        {
            _imGuiController.Dispose();
        }

        private static void DrawDockspace()
        {
            // Fullscreen Dockspace window flags
            ImGuiDockNodeFlags dockspace_flags = ImGuiDockNodeFlags.PassthruCentralNode;

            ImGuiViewportPtr viewport = ImGui.GetMainViewport();
            ImGui.SetNextWindowPos(viewport.Pos);
            ImGui.SetNextWindowSize(viewport.Size);
            ImGui.SetNextWindowViewport(viewport.ID);

            ImGuiWindowFlags window_flags = ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoDocking;
            window_flags |= ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
            window_flags |= ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;

            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);

            ImGui.Begin("DockSpace Demo", window_flags);

            ImGui.PopStyleVar(2);

            // Dockspace
            uint dockspace_id = ImGui.GetID("MyDockSpace");
            ImGui.DockSpace(dockspace_id, new System.Numerics.Vector2(0, 0), dockspace_flags);

            DrawMenuBar();

            // Draw test panels as individual windows

            DrawHierarchyPanel();
            DrawInspectorPanel();
            DrawConsolePanel();

            ImGui.End();
        }

        private static void DrawMenuBar()
        {
            if (ImGui.BeginMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("Exit"))
                    {
                        _window.Close();
                    }
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Help"))
                {
                    if (ImGui.MenuItem("About"))
                    {
                        // Show about dialog or info
                    }
                    ImGui.EndMenu();
                }
                ImGui.EndMenuBar();
            }
        }

        private static void DrawHierarchyPanel()
        {
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(300, 400), ImGuiCond.FirstUseEver);
            ImGui.Begin("Hierarchy");

            // Simple demo tree
            if (ImGui.TreeNode("Root"))
            {
                ImGui.Text("GameObject1");
                ImGui.Text("GameObject2");
                if (ImGui.TreeNode("GameObject3"))
                {
                    ImGui.Text("Child1");
                    ImGui.Text("Child2");
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }

            ImGui.End();
        }

        private static void DrawInspectorPanel()
        {
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(300, 400), ImGuiCond.FirstUseEver);
            ImGui.Begin("Inspector");

            // Demo properties
            ImGui.Text("Selected Object: GameObject1");
            ImGui.Separator();
            ImGui.Text("Transform");

            NovaEditor.Vector3 position = new NovaEditor.Vector3(0, 1, 0);
            NovaEditor.Vector3 rotation = new NovaEditor.Vector3(0, 0, 0);
            NovaEditor.Vector3 scale = new NovaEditor.Vector3(1, 1, 1);

            // Convert to System.Numerics.Vector3
            System.Numerics.Vector3 pos = new System.Numerics.Vector3(position.X, position.Y, position.Z);
            System.Numerics.Vector3 rot = new System.Numerics.Vector3(rotation.X, rotation.Y, rotation.Z);
            System.Numerics.Vector3 scl = new System.Numerics.Vector3(scale.X, scale.Y, scale.Z);

            // Pass to ImGui
            if (ImGui.InputFloat3("Position", ref pos))
            {
                // Convert back to your Vector3
                position = new NovaEditor.Vector3(pos.X, pos.Y, pos.Z);
            }

            if (ImGui.InputFloat3("Rotation", ref rot))
            {
                rotation = new NovaEditor.Vector3(rot.X, rot.Y, rot.Z);
            }

            if (ImGui.InputFloat3("Scale", ref scl))
            {
                scale = new NovaEditor.Vector3(scl.X, scl.Y, scl.Z);
            }


            ImGui.End();
        }

        private static void DrawConsolePanel()
        {
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(0, 150), ImGuiCond.FirstUseEver);
            ImGui.Begin("Console");

            // Demo console logs
            ImGui.TextColored(new System.Numerics.Vector4(1, 1, 0, 1), "[Warning] Something might be wrong");
            ImGui.TextColored(new System.Numerics.Vector4(1, 0, 0, 1), "[Error] Something broke!");
            ImGui.Text("[Info] All systems operational.");

            ImGui.End();
        }
    }

    struct Vector3
    {
        public float X, Y, Z;
        public Vector3(float x, float y, float z) { X = x; Y = y; Z = z; }
    }
}
