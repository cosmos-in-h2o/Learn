#include <iostream>
#include <thread>
#include <mutex>
#include <queue>
#include <condition_variable>
using namespace std;
mutex mtx;
condition_variable cv;
queue<int> q;

[[noreturn]] void producer(){
    int i=0;
    while(true){
        unique_lock<mutex> lock(mtx);
        q.push(i);
        cv.notify_one();
        i++;
    }
}

[[noreturn]] void customer(){
    while(true){
        unique_lock<mutex> lock(mtx);
        if(q.empty()){
            cv.wait(lock);
        }
        cout<<q.front()<<'\n';
        q.pop();
    }
}
int main()
{
    thread t1(producer);
    thread t2(customer);
    t1.join();
    t2.join();
    return 0;
}