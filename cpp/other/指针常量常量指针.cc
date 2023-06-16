#include <iostream>

struct test{
public:
    int a,b,c,d;
    void fun(){};
};

int main(){
    int var_1=1;
    int var_2=2;
    int var_3=3;
    //常量指针
    const int* ptr = &var_1;
    //可以修改指向
    ptr=&var_2;
    //error 不能修改其指向的内容
    // *ptr=1;
    
    //----------------------------------------

    //指针常量
    int* const ptr_2=&var_1;
    //error 不行修改指向
    // ptr_2=&var_2;
    //可以修改指向内容
    *ptr_2=4;

    test& ttt=test();
    ttt->fun();

    return 0;
}