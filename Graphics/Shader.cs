using System.Numerics;
using Silk.NET.OpenGL;


namespace Nova.Graphics {
    public class Shader: IDisposable {
        private GL gl;
        private uint handle;


        public Shader(GL gl, string vertexPath, string fragmentPath) {
            this.gl = gl;

            // Load the shaders
            uint vertexShader = LoadShader(ShaderType.VertexShader, vertexPath);
            uint fragmentShader = LoadShader(ShaderType.FragmentShader, fragmentPath);

            // Create the shader program
            handle = gl.CreateProgram();

            // Attach the shaders
            gl.AttachShader(handle, vertexShader);
            gl.AttachShader(handle, fragmentShader);

            // Link the shader program and check for errors
            gl.LinkProgram(handle);

            gl.GetProgram(handle, ProgramPropertyARB.LinkStatus, out int status);
            if (status == 0) {
                throw new Exception($"Program failed to link with error: {gl.GetProgramInfoLog(handle)}");
            }

            // No longer need any of ther shaders and therefore delete them from the gpu memory
            gl.DetachShader(handle, vertexShader);
            gl.DetachShader(handle, fragmentShader);
            gl.DeleteShader(vertexShader);
            gl.DeleteShader(fragmentShader);
        }


        public void Use() {
            gl.UseProgram(handle);
        }


        public void SetUniform(string name, int value) {
            // Set the texture uniform
            int location = gl.GetUniformLocation(handle, name);

            //If GetUniformLocation returns -1 the uniform is not found
            if (location == -1) {
                throw new Exception($"{name} uniform not found on shader.");
            }

            gl.Uniform1(location, value);
        }


        public void SetUniform(string name, float value) {
            int location = gl.GetUniformLocation(handle, name);

            if (location == -1) {
                throw new Exception($"{name} uniform not found on shader.");
            }

            gl.Uniform1(location, value);
        }


        public unsafe void SetUniform(string name, Matrix4x4 value) {
            int location = gl.GetUniformLocation(handle, name);

            if (location == -1) {
                throw new Exception($"{name} uniform not found on shader.");
            }

            gl.UniformMatrix4(location, 1, false, (float*) &value);
        }


        public void Dispose() {
            gl.DeleteProgram(handle);
        }


        private uint LoadShader(ShaderType type, string path) {
            string shaderCode = File.ReadAllText(path);

            // Create the shader
            uint shader = gl.CreateShader(type);
            gl.ShaderSource(shader, shaderCode);

            // Comile the vertex shader
            gl.CompileShader(shader);

            string infoLog = gl.GetShaderInfoLog(handle);
            if (!string.IsNullOrWhiteSpace(infoLog)) {
                throw new Exception($"Error compiling shader of type {type}, failed with error {infoLog}");
            }

            return shader;
        }
    }
}
