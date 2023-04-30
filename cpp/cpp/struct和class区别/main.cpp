class test{
    int a;
};
struct test1{
    int a;
};
int main(){
    test t;
    //t.a;//error
    test1 t1;
    t1.a=3;//正确
}

//区别只有默认的可见权限