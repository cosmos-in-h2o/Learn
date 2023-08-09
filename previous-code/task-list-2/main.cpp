#include "Action.h"
#include "coc.hpp"
#include <string>
#include <vector>
using namespace coc;
///task init				------init task.\n
///task add <task>			------add a <task>.\n
///task get -t				------get all task.\n
///task get -f				------get all task in finished.\n
///task get -t <index>		------get the <index>th in all task.\n
///task get -f <index>		------get the <index>th in all finished task.\n
///task delete -t <task>	------delete <task>.\n
///task delete -f <task>	------delete finished <task>.\n
///task find -t <task>		------find index of <task>.\n
///task find -f <task>		------find index of <task> in finished.\n
///task finish <index>		------finished the <index>th.\n
///task help				------get help.\n

void action_get(Options*o,Arguments*a,Values*v,std::vector<std::string>&argv){
	if(o->getOption('i')){
		//option为-t
		if(o->getOption('t')){getTask(std::stoi(argv[0]));}
		//option为-f
		else if(o->getOption('f')){getFinishTask(std::stoi(argv[0]));}
		if(argv.empty()) {return;}
	}
	else{
		//option为-t
		if(o->getOption('t')){getTaskList();}
		//option为-f
		else if(o->getOption('f')){getFinishList();}
	}
}

void action_delete(Options*o,Arguments*a,Values*v,std::vector<std::string>&argv){
	if(argv.empty()) {return;}
	//option为-t
	if(o->getOption('t')){deleteTask(std::stoi(argv[0]));}
	//option为-f
	else if(o->getOption('f')){deleteFinishedTask(std::stoi(argv[0]));}
}
void action_find(Options*o,Arguments*a,Values*v,std::vector<std::string>&argv){
	if(argv.empty()) {return;}
	//option为-t
	if(o->getOption('t')){findTask(argv[0]);}
	//option为-f
	else if(o->getOption('f')){ findFinishTask(argv[0]);}
}
int main(int argc, char *argv[]) {
	ParserConfig* config = new ParserConfig;
	Log* log=new Log;
	Parser parser=Parser(config,log);
	parser.addAction("init", "init task", [](Options*o,Arguments*a,Values*v,std::vector<std::string>&argv){init();});
	
	parser.addAction("add", "add a <task>", [](Options*o,Arguments*a,Values*v,std::vector<std::string>&argv){addTask(v->getString("task"));})
			->addValue("task", "please input task", "string", "input task");
	
	parser.addAction("get", "get task", action_get)
			->addOption("index", "get the index task", 3,'i')
			->addOption("task", "get task from task_list", 1,'t')
			->addOption("finish", "get task from finish_list", 2,'f');
	
	parser.addAction("delete", "delete task", action_delete)
			->addOption("task", "delete task in task_list", 1,'t')
			->addOption("finish", "delete task in finish_list", 2,'f');
	
	parser.addAction("find", "find task", action_find)
			->addOption("task", "find task from task_list", 1,'t')
			->addOption("finish", "find task from finish_list", 2,'f');

	parser.addAction("finish", "finish task", [](Options*o,Arguments*a,Values*v,std::vector<std::string>&argv){if(!argv.empty()) finishTask(std::stoi(argv[0]));});
	return parser.run(argc, argv);
}