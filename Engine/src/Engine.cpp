#include <iostream>
#include <glad/glad.h>
#include <GLFW/glfw3.h>

#include "Nova/Engine.h"

namespace Nova {
    bool Engine::Init() {
        if (!glfwInit()) {
            std::fprintf(stderr, "GLFW init failed\n");
            return false;
        }
        m_Window = glfwCreateWindow(800, 600, "Sandbox", nullptr, nullptr);
        if (!m_Window) {
            std::fprintf(stderr, "Window creation failed\n");
            glfwTerminate();
            return false;
        }
        glfwMakeContextCurrent(m_Window);
        return true;
    }

    void Engine::Run() {
        while (!glfwWindowShouldClose(m_Window)) {
            glfwPollEvents();
            // draw nothing, just swap
            glfwSwapBuffers(m_Window);
        }
    }

    void Engine::Shutdown() {
        if (m_Window) glfwDestroyWindow(m_Window);
        glfwTerminate();
    }
}
