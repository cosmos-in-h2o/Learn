#include "Action.h"
#include "func.h"
#include <cstdlib>

using std::cout;
using std::endl;
void init() {
	system("mkdir ~/.config/task");
	system("touch ~/.config/task/task.conf");
	system("touch ~/.config/task/task.task");
	system("touch ~/.config/task/finished.task");
}
void addTask(std::string task) {
	write(task, tpath, WMode::APPEND);
	cout<<"add task:"<<task<<endl;
}
void getTaskList() 					{ getLists(tpath); }
void getFinishList() 					{ getLists(fpath); }
void getTask(const int index) 		{ getSingle(tpath, index); }
void getFinishTask(const int index) 	{ getSingle(tpath, index); }
void finishTask(const int index) 		{ moveTask(tpath, fpath, index); }
void returnTask(const int index)		{ moveTask(fpath, tpath, index); }
void findTask(std::string task) 		{ findSingleTask(task, tpath); }
void findFinishTask(const std::string task) { findSingleTask(task, fpath); }
void deleteTask(int index) 			{ removeTask(tpath, index); }
void deleteFinishedTask(int index)	{ removeTask(fpath, index); }