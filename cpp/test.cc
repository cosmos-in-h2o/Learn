#include <algorithm>
#include <string>
#include <memory.h>
#include <malloc.h>
#include <iostream>
#include <type_traits>
#include <utility>
void func(int& i){
    std::cout<<i<<"\tlval\n";
}
void func(int&& i){
    std::cout<<i<<"\trval\n";
}
template<typename T> void test(T&& i){
    func(std::forward(i));
}
int main(){
    int a=1;
    test(a);
    test(std::forward(1));
}