#include <Nova/Engine.h>

int main() {
    Nova::Engine engine;
    if (!engine.Init()) return 1;
    engine.Run();
    engine.Shutdown();
    return 0;
}
