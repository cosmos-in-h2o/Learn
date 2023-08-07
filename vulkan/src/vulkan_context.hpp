#ifndef VULKAN_CONTEXT
#define VULKAN_CONTEXT

#include <vulkan/vulkan.hpp>
#define GLFW_INCLUDE_VULKAN
#include <GLFW/glfw3.h>

struct Application{
	Application()=default;
	~Application();
	void run();
	void init();
	void main_loop();
	void destory();

	void creat_window();
	void creat_instance();
	void init_vulkan();
private:
	GLFWwindow* window;
	vk::Instance vk_instance;
};

#endif // !VULKAN_CONTEXT
