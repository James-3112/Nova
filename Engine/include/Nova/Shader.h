#pragma once

#include <glad/glad.h>
#include <string>
#include <fstream>
#include <iostream>
#include <cerrno>

#include <filesystem>


namespace Nova {
    std::string GetFileContents(const char* filename);

    class Shader {
        public:
            GLuint ID;

            Shader(const char* vertexShaderFile, const char* fragmentShaderFile);

            void Activate();
            void Delete();
    };
}
