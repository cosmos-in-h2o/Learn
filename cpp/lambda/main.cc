#include<iostream>

int main(){
    auto f=[](int a,int b){return a+b;};
    auto f2=f;
    auto f3=std::move(f);
    std::cout<<f(1,2)<<" "<<f2(1,2)<<" "<<f3(1,2)<<" ";
    return 0;
}
