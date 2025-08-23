#include <Nova/VertexArrayObject.h>


namespace Nova {
	// Constructor that generates a VAO ID
	VertexArrayObject::VertexArrayObject() {
		glGenVertexArrays(1, &ID);
	}


	// Links a VBO to the VAO using a certain layout
	void VertexArrayObject::LinkVBO(VertexBufferObject& VBO, GLuint layout) {
		VBO.Bind();

		// Create attribute pointers for how the data is being passed to be used within the shaders
		glVertexAttribPointer(layout, 3, GL_FLOAT, GL_FALSE, 0, (void*)0);
		glEnableVertexAttribArray(layout);

		VBO.Unbind();
	}


	void VertexArrayObject::Bind() {
		glBindVertexArray(ID);
	}


	void VertexArrayObject::Unbind() {
		glBindVertexArray(0);
	}


	void VertexArrayObject::Delete() {
		glDeleteVertexArrays(1, &ID);
	}
}
