#pragma once

#include <glad/glad.h>


namespace Nova {
    class ElementBufferObject {
        public:
            GLuint ID;

            ElementBufferObject(GLuint* indices, GLsizeiptr size);

            void Bind();
            void Unbind();
            void Delete();
    };
}
