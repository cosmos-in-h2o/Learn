#ifndef FUNC_H
#define FUNC_H
#include <string>
#include <vector>
#include <functional>
///定义一些可供复用的函数

//写入模式
enum class WMode {
    APPEND,     //追加
    OVER        //覆盖
};
//写入文件
void write(const std::string& str,const std::string path,WMode mode=WMode::OVER);
void write(const std::vector<std::string>& lists,const std::string path,WMode mode=WMode::OVER);
//读文件
void read(std::vector<std::string> lists,const std::string& path,std::function<void(void)> notfound,std::function<void(void)> callback);
bool read(std::vector<std::string> lists,const std::string& path);
//获取单个
void getSingle(const std::string &path,const int index);
//获取多个
void getLists(const std::string &path);
//移动操作
void moveTask(const std::string &path,const std::string &to_path,const int index);
//查找操作
void findSingleTask(const std::string &str, const std::string &path);
//删除操作
void removeTask(const std::string &path,const int index);

#endif // !FUNC_H