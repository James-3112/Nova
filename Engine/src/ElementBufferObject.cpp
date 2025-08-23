#include <Nova/ElementBufferObject.h>


namespace Nova {
    ElementBufferObject::ElementBufferObject(GLuint* indices, GLsizeiptr size) {
        glGenBuffers(1, &ID);
        Bind();

        // Add the vertices to the VBO - Must change "GL_STATIC_DRAW" based on use case
        glBufferData(GL_ELEMENT_ARRAY_BUFFER, size, indices, GL_STATIC_DRAW);
    }


    void ElementBufferObject::Bind() {
        glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, ID);
    }


    void ElementBufferObject::Unbind() {
        glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0);
    }


    void ElementBufferObject::Delete() {
        glDeleteBuffers(1, &ID);
    }
}
