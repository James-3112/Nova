#pragma once

#include <glad/glad.h>
#include "VertexBufferObject.h"


namespace Nova {
    class VertexArrayObject {
        public:
            GLuint ID;

            VertexArrayObject();

            void LinkVBO(VertexBufferObject& VBO, GLuint layout);
            void Bind();
            void Unbind();
            void Delete();
    };
}
