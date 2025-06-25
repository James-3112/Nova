using NovaEngine;

using ImGuiNET;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using Silk.NET.Windowing;

using System.Numerics;


namespace NovaEditor {
    public class EditorLayer : IOverlayLayer {
        private ImGuiController controller = null!;
        private GL gl = null!;

        private uint fbo;
        private uint texture;
        private uint rbo; // Renderbuffer for depth

        private Vector2 viewportSize = new(800, 600);

        public void Load(GL gl, IWindow window, IInputContext input) {
            this.gl = gl;
            controller = new ImGuiController(gl, window, input);
            ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;

            ImGui.StyleColorsDark();

            CreateFramebuffer((int)viewportSize.X, (int)viewportSize.Y);
        }

        public void Render(GL gl, double deltaTime) {
            controller.Update((float)deltaTime);

            DrawDockspace();
            DrawViewport();

            controller.Render();
        }

        public void Dispose() {
            controller.Dispose();

            if (gl != null) {
                gl.DeleteFramebuffer(fbo);
                gl.DeleteTexture(texture);
                gl.DeleteRenderbuffer(rbo);
            }
        }

        private void DrawDockspace() {
            var viewport = ImGui.GetMainViewport();
            ImGui.SetNextWindowPos(viewport.Pos);
            ImGui.SetNextWindowSize(viewport.Size);
            ImGui.SetNextWindowViewport(viewport.ID);

            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, Vector2.Zero);

            ImGui.Begin("DockSpaceWindow", ImGuiWindowFlags.NoTitleBar
                                            | ImGuiWindowFlags.NoCollapse
                                            | ImGuiWindowFlags.NoResize
                                            | ImGuiWindowFlags.NoMove
                                            | ImGuiWindowFlags.NoDocking
                                            | ImGuiWindowFlags.NoBringToFrontOnFocus
                                            | ImGuiWindowFlags.NoNavFocus);

            ImGui.PopStyleVar(3);

            uint dockspaceId = ImGui.GetID("MainDockspace");
            ImGui.DockSpace(dockspaceId, Vector2.Zero, ImGuiDockNodeFlags.None);

            ImGui.End();
        }

        private void DrawViewport() {
            ImGui.Begin("Viewport");
            ImGui.Text("Scene rendering happens in main framebuffer.");
            ImGui.End();
        }

        private unsafe void CreateFramebuffer(int width, int height) {
            // Create texture
            texture = gl.GenTexture();
            gl.BindTexture(TextureTarget.Texture2D, texture);
            gl.TexImage2D(TextureTarget.Texture2D, 0, (int)InternalFormat.Rgba8, (uint)width, (uint)height, 0,
                GLEnum.Rgba, GLEnum.UnsignedByte, null);
            gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)GLEnum.Linear);
            gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)GLEnum.Linear);

            // Create renderbuffer for depth
            rbo = gl.GenRenderbuffer();
            gl.BindRenderbuffer(RenderbufferTarget.Renderbuffer, rbo);
            gl.RenderbufferStorage(RenderbufferTarget.Renderbuffer, InternalFormat.DepthComponent24, (uint)width, (uint)height);

            // Create framebuffer and attach texture + depth buffer
            fbo = gl.GenFramebuffer();
            gl.BindFramebuffer(FramebufferTarget.Framebuffer, fbo);
            gl.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2D, texture, 0);
            gl.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, RenderbufferTarget.Renderbuffer, rbo);

            if (gl.CheckFramebufferStatus(FramebufferTarget.Framebuffer) != GLEnum.FramebufferComplete) {
                throw new System.Exception("Framebuffer is not complete!");
            }

            gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }

        private unsafe void ResizeFramebuffer(int width, int height) {
            if (width == 0 || height == 0)
                return;

            gl.BindTexture(TextureTarget.Texture2D, texture);
            gl.TexImage2D(TextureTarget.Texture2D, 0, (int)InternalFormat.Rgba8, (uint)width, (uint)height, 0,
                GLEnum.Rgba, GLEnum.UnsignedByte, null);

            gl.BindRenderbuffer(RenderbufferTarget.Renderbuffer, rbo);
            gl.RenderbufferStorage(RenderbufferTarget.Renderbuffer, InternalFormat.DepthComponent24, (uint)width, (uint)height);
        }

        private void RenderToFramebuffer() {
            gl.BindFramebuffer(FramebufferTarget.Framebuffer, fbo);
            gl.Viewport(0, 0, (uint)viewportSize.X, (uint)viewportSize.Y);

            // Clear to some color so you can see it
            gl.ClearColor(0.1f, 0.2f, 0.3f, 1.0f);
            gl.Clear((uint)(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit));

            // TODO: Render your scene or other OpenGL content here

            gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }
    }
}
