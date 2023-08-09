#ifndef ACTION_H
#define ACTION_H
#include <iostream>
#include <fstream>
#include <vector>
#include <string>
const std::string tpath="~/.config/task/task.task";//未完成的任务路径
const std::string fpath="~/.config/task/finished.task";//完成的任务路径
//初始化
void init();
//添加任务
void addTask(const std::string task);
//获取任务列表
void getTaskList();
//获取完成的任务列表
void getFinishList();
//获取任务
void getTask(const int index);
//获取完成的任务
void getFinishTask(const int index);
//完成任务
void finishTask(const int index);
//把任务返回
void returnTask(const int index);
//查找任务
void findTask(const std::string task);
//查找完成的任务
void findFinishTask(const std::string task);
//删除任务
void deleteTask(const int index);
//删除完成的任务
void deleteFinishedTask(const int index);
#endif //!ACTION_H