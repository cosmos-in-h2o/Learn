#include <iostream>
using namespace std;
class A{
public:
    A(){cout<<"A的构造函数调用"<<endl;}
    ~A(){cout<<"A的析构函数调用"<<endl;}
};

class B:public A{
public:
    B(){cout<<"B的构造函数调用"<<endl;}
    ~B(){cout<<"B的析构函数调用"<<endl;}
};

class C{
public:
    C(){cout<<"C的构造函数调用"<<endl;}
    virtual ~C(){cout<<"C的析构函数调用"<<endl;}
};

class D:public C{
public:
    D(){cout<<"D的构造函数调用"<<endl;}
    ~D(){cout<<"D的析构函数调用"<<endl;}
};
int main(){
    A*a=new A;
    delete a;
    cout<<"---------------------------\n";
    B*b=new B();
    delete b;
    cout<<"---------------------------\n";
    A*c=new B();
    delete c;
    cout<<"---------------------------\n";
    D*d=new D();
    delete d;
    cout<<"---------------------------\n";
    C*e=new D();
    delete e;
}