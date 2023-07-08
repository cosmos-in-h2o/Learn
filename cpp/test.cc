#include <atomic>
#include <iostream>
#include <thread>
struct Test{
    int a;
    Test& operator+=(const Test&t){}
};

int main() {
    return 0;
}