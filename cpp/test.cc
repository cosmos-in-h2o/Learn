#include <iostream>
#include <future>
#include <functional>

int main() {
    // 创建一个 packaged_task，将其与一个简单的 lambda 表达式关联
    std::packaged_task<int()> task([](){
        std::cout << "Task executed!" << std::endl;
        return 42;
    });

    // 获取与 packaged_task 关联的 future
    //std::future<int> future = task.get_future();
    // 执行任务
    //task();
    //std::cout << "Task result: " << future.get() << std::endl;
    std::cout << std::boolalpha << task.valid() << std::endl;
    return 0;
}