#include <iostream>
#include <string>
using namespace std;
class A{
public:
    string get_name(){return "A";}
};

class B:public A{
    string name;
public:
    B(string name):name(name){}
    string get_name() {return this->name;}
};

//--------------------

class C{
public:
    virtual string get_name(){return "C";}
};

class D:public C{
    string name;
public:
    D(string name):name(name){}
    string get_name() override{return this->name;}
};

auto main()->int{
    A *a=new B("B");
    C *c=new D("D");

    cout<<a->get_name()
        <<'\n'
        <<c->get_name()
        <<endl;
    delete a;
    a=nullptr;
    delete c;
    c=nullptr;
}