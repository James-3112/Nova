#pragma once

#include <glad/glad.h>


namespace Nova {
    class VertexBufferObject {
        public:
            GLuint ID;

            VertexBufferObject(GLfloat* vertices, GLsizeiptr size);

            void Bind();
            void Unbind();
            void Delete();
    };
}
