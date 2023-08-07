#include <stdexcept>
#include <iostream>
#include "vulkan_context.hpp"

int main(int argc,char**argv){
	Application* app=new Application;
	try {
        app->run();
    } catch (const std::exception& e) {
        std::cerr << e.what() << std::endl;
		delete app;
        return EXIT_FAILURE;
    }
	delete app;
    return EXIT_SUCCESS;
}
