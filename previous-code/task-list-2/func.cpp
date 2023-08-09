#include "func.h"
#include <iostream>
#include <fstream>
#include <ios>
#include <string>
#include <vector>
#include <algorithm>

using std::cout;
using std::endl;

void write(const std::string& str,const std::string path,WMode mode){
    //判断模式
    std::ios::openmode _mode;
    if (mode==WMode::APPEND)    _mode=std::ios::app;
    else                        _mode=std::ios::out;
    //写入
    std::ofstream out(path,_mode);
	out << str << std::endl;
	out.close();
}
void write(const std::vector<std::string>& lists,const std::string path,WMode mode){
	//判断模式
    std::ios::openmode _mode;
    if (mode==WMode::APPEND)    _mode=std::ios::app;
    else                        _mode=std::ios::out;
    //写入
    std::ofstream out(path,_mode);
	for(auto str:lists)
	out << str << std::endl;
	out.close();
	std::vector<int> a;
}
void read(std::vector<std::string> lists,const std::string& path,std::function<void(void)> notfound,std::function<void(void)> callback){
	std::ifstream in(path, std::ios::in);
	if (!in.is_open()) {
        //打开失败就执行回调函数
        notfound();
		return;
	}
	while (in) {
		std::string buff;
		getline(in, buff);
		lists.push_back(buff);
	}
	in.close();
    callback();
}
bool read(std::vector<std::string> lists,const std::string& path){
	std::ifstream in(path, std::ios::in);
	if (!in.is_open()) {
		return false;
	}
	while (in) {
		std::string buff;
		getline(in, buff);
		lists.push_back(buff);
	}
	in.close();
    return true;
}
void getSingle(const std::string &path,const int index){
	std::vector<std::string> lists;
	read(lists, path, 
		[](){
			cout<<"File not found.\n\tPlease execute task init or check the file path.";
		},
		[&](){
			if (index < lists.size()) {
				cout<<lists[index];
			}
			else {
				cout<<"Out of range";
			}
		});
}
void getLists(const std::string &path){
	std::vector<std::string> lists;
	read(lists, path, 
		[](){
			cout<<"File not found.\n\tPlease execute task init or check the file path.";
		},
		[=](){
			int num=0;
			for (auto i:lists) {
				cout<<num<<'.'<<i<<'\n';
			}
		});
}
void moveTask(const std::string &path,const std::string &to_path,const int index){
	//读取
	std::vector<std::string> lists;
	std::string will_be_move;//要移动的任务
	//读取文件并判断文件是否为空，为空就打印信息退出
	if(!read(lists, path)){
		cout<<"File not found.\n\tPlease execute task init or check the file path."<<endl;
		return;
	}
	if (index < lists.size()) {
		will_be_move = lists[index];
		lists.erase(lists.begin() + index);
	}
	else {
		cout<<"Out of range";
		return;
	}
	// 写入
	write(lists,path);
	// 写入
	write(will_be_move,to_path,WMode::APPEND);
	cout<<"Finsh task:"<<will_be_move;
}
void findSingleTask(const std::string &str, const std::string &path){
	std::vector<std::string> lists;
	if(!read(lists, path)){
		cout<<"File not found.\n\tPlease execute task init or check the file path."<<endl;
		return;
	}
	auto p = std::find(lists.begin(), lists.end(), str);
	if (p == lists.end())
		cout<<"Task not found:"<<str;
	else 
		cout<<"The index of tasks:"<<str<<" is "<<(int)(p - lists.begin());
}
void removeTask(const std::string &path,const int index){
	//读取
	std::vector<std::string> lists;
	if(!read(lists, path)){
		cout<<"File not found.\n\tPlease execute task init or check the file path."<<endl;
		return;
	}
	if (index < lists.size()) {
		cout<<"Delete task:"<<lists[index];
		lists.erase(lists.begin() + index);
	}
	else{
		cout<<"Out of range";
		return;
	}
	write(lists,path);
}