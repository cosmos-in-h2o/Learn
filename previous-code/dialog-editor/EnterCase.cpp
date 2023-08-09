#include "EnterCase.h"

void EnterCase::keyPressEvent(QKeyEvent *event) {
	qDebug("aaa");
	switch (event->key()) {
		case Qt::Key_Return:
			emit enterPress();
			break;
	}
}
void EnterCase::keyReleaseEvent(QKeyEvent *event) {
	switch (event->key()) {
		case Qt::Key_Return:
			emit enterRelease();
			break;
	}
}

EnterCase::EnterCase(QWidget *parent) :
		QPushButton(parent) {
}
