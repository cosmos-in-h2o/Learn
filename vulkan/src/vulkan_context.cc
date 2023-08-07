#include "vulkan_context.hpp"
#include "GLFW/glfw3.h"
#include "vulkan/vulkan_core.h"

Application::~Application() { destory(); }

void Application::run() {
    creat_window();
    init();
    main_loop();
}

void Application::init() {}

void Application::main_loop() {
    while (!glfwWindowShouldClose(window)) {
        glfwPollEvents();
    }
}

void Application::destory() {
	vk_instance.destroy();
    glfwDestroyWindow(window);
    glfwTerminate();
}

void Application::creat_window() {
    glfwInit();
    glfwWindowHint(GLFW_CLIENT_API, GLFW_NO_API);
    glfwWindowHint(GLFW_RESIZABLE, GLFW_FALSE);
    window = glfwCreateWindow(800, 600, "vulkan_learn", nullptr, nullptr);
}

void Application::creat_instance() {
    vk::ApplicationInfo appInfo{};
    appInfo.sType = vk::StructureType::eApplicationInfo;
    appInfo.pApplicationName = "Hello Triangle";
    appInfo.applicationVersion = VK_MAKE_VERSION(1, 0, 0);
    appInfo.pEngineName = "No Engine";
    appInfo.engineVersion = VK_MAKE_VERSION(1, 0, 0);
    appInfo.apiVersion = VK_API_VERSION_1_3;

    vk::InstanceCreateInfo createInfo{};
    createInfo.sType = vk::StructureType::eInstanceCreateInfo;
    createInfo.pApplicationInfo = &appInfo;
    uint32_t glfwExtensionCount = 0;
    const char** glfwExtensions;
    glfwExtensions = glfwGetRequiredInstanceExtensions(&glfwExtensionCount);
    createInfo.enabledExtensionCount = glfwExtensionCount;
    createInfo.ppEnabledExtensionNames = glfwExtensions;
    createInfo.enabledLayerCount = 0;
    if (vk::createInstance(&createInfo, nullptr, &vk_instance) !=
        vk::Result::eSuccess) {
        throw std::runtime_error("can not create instanse");
    }
}

void Application::init_vulkan() { creat_instance(); }
