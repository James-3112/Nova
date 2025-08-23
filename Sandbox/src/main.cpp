#include <iostream>
#include <glad/glad.h>
#include <GLFW/glfw3.h>

#include <Nova/Shader.h>
#include <Nova/VertexArrayObject.h>
#include <Nova/VertexBufferObject.h>
#include <Nova/ElementBufferObject.h>


GLfloat vertices[] = {
	-0.5f, -0.5f * float(sqrt(3)) / 3, 0.0f, // Lower left corner
	0.5f, -0.5f * float(sqrt(3)) / 3, 0.0f, // Lower right corner
	0.0f, 0.5f * float(sqrt(3)) * 2 / 3, 0.0f, // Upper corner
	-0.5f / 2, 0.5f * float(sqrt(3)) / 6, 0.0f, // Inner left
	0.5f / 2, 0.5f * float(sqrt(3)) / 6, 0.0f, // Inner right
	0.0f, -0.5f * float(sqrt(3)) / 3, 0.0f // Inner down
};

GLuint indices[] = {
	0, 3, 5, // Lower left triangle
	3, 2, 4, // Upper triangle
	5, 4, 1 // Lower right triangle
};


int main() {
	glfwInit();

	// Tells GLFW that version 3.3 is being used
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);

	// Tells GLFW that we are only using the modern function of OpenGL
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

	// Creates the window, 800 by 800 pixels, naming it "Hello Window"
	GLFWwindow* window = glfwCreateWindow(800, 800, "Hello Window", NULL, NULL);
	if (window == NULL) {
		std::cout << "Failed to create GLFW window" << std::endl;
		glfwTerminate();
		return -1;
	}


	// Adds the indows to the current context
	glfwMakeContextCurrent(window);

	// Load OpenGL and configure it size to take up the hole screen
	gladLoadGL();
	glViewport(0, 0, 800, 800);


	Nova::Shader shader("Resources/Shaders/default.vert", "Resources/Shaders/default.frag");

	Nova::VertexArrayObject vao;
	vao.Bind();

	Nova::VertexBufferObject vbo(vertices, sizeof(vertices));
	Nova::ElementBufferObject ebo(indices, sizeof(indices));

	vao.LinkVBO(vbo, 0);

	vao.Unbind();
	vbo.Unbind();
	ebo.Unbind();


	// Main loop
	while (!glfwWindowShouldClose(window)) {
		// Sets the background color
		glClearColor(0.07f, 0.13f, 0.17f, 1.0f);

		// Clears the back buffer and assigns the new color to it
		glClear(GL_COLOR_BUFFER_BIT);

		// Tell which shader program, vertex array object, and how we want to draw the object. Then draws the object
		shader.Activate();
		vao.Bind();
		glDrawElements(GL_TRIANGLES, 9, GL_UNSIGNED_INT, 0);

		// Swaps the buffers and checks for events like closed window
		glfwSwapBuffers(window);
		glfwPollEvents();
	}


	// Delete all objects
	vao.Delete();
	vbo.Delete();
	ebo.Delete();
	shader.Delete();

	// Destroys the window
	glfwDestroyWindow(window);
	glfwTerminate();

	return 0;
}
