#ifndef BLOCK_H
#define BLOCK_H
#include <qpushbutton.h>
#include <qboxlayout.h>
#include <qevent.h>
#include <qpainter.h>
#include "ui_Dialog.h"

typedef struct Clips{
	QString cilp_call_back; //开始时调用
	QString speaker_name;
	QString speaker_words;
	QString next_block; //走到此片段时就通到下一个块
	void set(Clips &c) {
		this->speaker_name = c.speaker_name;
		this->speaker_words = c.speaker_name;
	}
} Clips;

Clips Slipt(QString str);
QString ClipsToString(Clips &c);
class Dialog;
class Block : public QPushButton {
	Q_OBJECT
private:
	QPoint pressPoint;
signals:
	void PressSignals();

public:
	//名称在外部使用字典表示
	QString block_is;//前置条件
	int block_type;//类型
	Clips block_list[20]; //内容列表
	QString block_call_back;
	Block **now;
	Ui::DialogClass *ui;
	void mousePressEvent(QMouseEvent *e) override;
	void mouseMoveEvent(QMouseEvent *e) override;
	Block(Block &b) {
		this->block_type = b.block_type;
		this->now = b.now;
		this->ui = b.ui;
		for (int i = 0; i < 20; i++) {
			this->block_list[i] = b.block_list[i];
		}

	}
	Block(QString name, Block **now, Ui::DialogClass *ui, QWidget *parent = nullptr) :
			QPushButton(parent) 
	{
		this->now = now;
		this->ui = ui;
		this->resize(100,50);
		/**正常情况下样式**/
		this->setStyleSheet(QString::fromUtf8
			(
				"QPushButton{"
				"font: 18pt \"宋体\";"
				"color:#7FB3D5;"
				"background-color : rgb(58, 72, 87);"
				"border-radius : 10px;"
				"border-style : solid;" 
				"border-color : #7FB3D5;"
				"border-width : 4px;"
				"padding:5px;"
				"}" 
				"QPushButton::hover {"
				"background-color : rgb(49, 64, 77);"
				"}" 
				"QPushButton::pressed,QPushButton::checked {"
				"background-color : rgb(39, 51, 61);"
				"}"
			)
		);
		this->setText(name);
	}
};
#endif