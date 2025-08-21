#pragma once

struct GLFWwindow;

namespace Nova {
    class Engine {
        public:
            bool Init();
            void Run();
            void Shutdown();
        
        private:
            GLFWwindow* m_Window = nullptr;
    };
}
