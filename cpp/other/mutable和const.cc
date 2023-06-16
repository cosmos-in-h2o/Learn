class Entity{
    int a;
    mutable int b;
public:
    int get() const{
        //return this->a=1;//error
        return this->b=1;//ok
    }
};