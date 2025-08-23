#include <Nova/VertexBufferObject.h>


namespace Nova {
    VertexBufferObject::VertexBufferObject(GLfloat* vertices, GLsizeiptr size) {
        glGenBuffers(1, &ID);
        Bind();

        // Add the vertices to the VBO - Must change "GL_STATIC_DRAW" based on use case
        glBufferData(GL_ARRAY_BUFFER, size, vertices, GL_STATIC_DRAW);
    }


    void VertexBufferObject::Bind() {
        glBindBuffer(GL_ARRAY_BUFFER, ID);
    }


    void VertexBufferObject::Unbind() {
        glBindBuffer(GL_ARRAY_BUFFER, 0);
    }


    void VertexBufferObject::Delete() {
        glDeleteBuffers(1, &ID);
    }
}
