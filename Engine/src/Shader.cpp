#include <Nova/shader.h>


namespace Nova {
	std::string GetFileContents(const char* filename) {
		char* exePath;
		_get_pgmptr(&exePath);
		std::filesystem::path fullPath = std::filesystem::path(exePath).parent_path() / filename;

		std::ifstream in(fullPath, std::ios::binary);
		if (!in) throw errno;

		std::string contents;

		in.seekg(0, std::ios::end);
		contents.resize(in.tellg());
		in.seekg(0, std::ios::beg);
		in.read(&contents[0], contents.size());
		in.close();

		return(contents);
	}


	Shader::Shader(const char* vertexShaderFile, const char* fragmentShaderFile) {
		// Read vertex shader File and fragment shader File and store the strings
		std::string vertexShaderCode = GetFileContents(vertexShaderFile);
		std::string fragmentShaderCode = GetFileContents(fragmentShaderFile);

		// Convert the shader source strings into character arrays
		const char* vertexShaderSource = vertexShaderCode.c_str();
		const char* fragmentShaderSource = fragmentShaderCode.c_str();

		// Creates the vertex shader and compiles it
		GLuint vertexShader = glCreateShader(GL_VERTEX_SHADER);
		glShaderSource(vertexShader, 1, &vertexShaderSource, NULL);
		glCompileShader(vertexShader);
		
		// Creates the fragment shader and compiles it
		GLuint fragmentShader = glCreateShader(GL_FRAGMENT_SHADER);
		glShaderSource(fragmentShader, 1, &fragmentShaderSource, NULL);
		glCompileShader(fragmentShader);

		// Creates a shader program uses thoses two shaders
		ID = glCreateProgram();
		glAttachShader(ID, vertexShader);
		glAttachShader(ID, fragmentShader);
		glLinkProgram(ID);
		
		// Deletes the old shaders as we only need the shader program to draw
		glDeleteShader(vertexShader);
		glDeleteShader(fragmentShader);
	}


	void Shader::Activate() {
		glUseProgram(ID);
	}


	void Shader::Delete() {
		glDeleteProgram(ID);
	}
}
