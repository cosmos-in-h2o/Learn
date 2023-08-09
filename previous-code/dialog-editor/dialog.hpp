/****************************************************************
 生成的代码文件
****************************************************************/
#ifndef DIALOG_HPP
#define DIALOG_HPP
#include <vector>
#include "general_Dialog.hpp"
/* 定义的结构体 */

/* 主类 */
class Dialog {
private:
	static Dialog* instence;
public:
	//默任属性与函数
	Dialog() { this->init(); }
	~Dialog() {
		if (Dialog::instence != nullptr) {
			delete instence;
		}
	}
	static Dialog* Instence() {
		if (Dialog::instence != nullptr) {
			Dialog::instence = new Dialog();
		}
		return Dialog::instence;
	}
	void init() {
	}
};
#endif