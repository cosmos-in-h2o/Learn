#pragma once

#include <QtWidgets/QMainWindow>
#include <qevent.h>
#include <qmap.h>
#include "ui_Dialog.h"
#include "Block.h"
#include "Plane.h"
#include "Vec.h"
#include <qmessagebox.h>
#include "EnterCase.h"
#include <qtimer.h>

class Dialog : public QMainWindow
{
    Q_OBJECT

public:
	Block *now = nullptr;
	Plane *MainBox;
	const char *path;
	std::string block_path = "";
	std::string code_path = "";
	std::string buff;
	std::string method_code = "";
	std::string struct_code = "";
	std::string json_path = "";
	Vector2 pos; //偏移位置
	Vector2 size; //大小
	//事件过滤器
	bool eventFilter(QObject *watched, QEvent *event);
	void closeEvent(QCloseEvent *event);
	//项目初始化
	void initProgram();
	//信号连接初始化
	void initConnect();
	//初始化blocks
	void initBlocks();
	//初始化设置
	void initSet();
	//创建新的block
	void creatBlock();
	//保存单个block
	void saveBlock();
	//保存操作
	void save();
    //退出操作
	void quit();
	//path是文件路径
    Dialog(const char* path, QWidget *parent = nullptr);
    ~Dialog();
	void SetUiStyle(const char *filePath = ":/Dialog/Resources/myqss.qss");

private:
	Ui::DialogClass ui;
	QMap<QString, Block *> blocks;
	QAction *setAction;
	QAction *codeAction;
	QAction *editorAction;
};
