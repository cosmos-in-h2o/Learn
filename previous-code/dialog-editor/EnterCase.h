#ifndef ENTERCASE_H
#define ENTERCASE_H
#include <qpushbutton.h>
#include <qstyleoption.h>
#include <qevent.h>
//捕获enter信号
class EnterCase : public QPushButton {
	Q_OBJECT
protected:
	void keyPressEvent(QKeyEvent *event); //键盘按下事件
	void keyReleaseEvent(QKeyEvent *event); //键盘松开事件
public:
	explicit EnterCase(QWidget *parent = nullptr);
signals:
	//当enter被点击时发送
	void enterPress();
	void enterRelease();
};

#endif // !ENTERCASE_H