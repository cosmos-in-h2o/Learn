#ifndef PLANE_H
#define PLANE_H
#include <qgroupbox.h>
#include <qevent.h>
#include <qpainter.h>
#include "Block.h"
class Plane :public QGroupBox{
	Q_OBJECT
private:
	QPoint pressPoint;
	QVector<QLineF> lines;
	int count;

public:
	QMap<QString, Block *>* blocks;
	void paintEvent(QPaintEvent *event) override;
	void mousePressEvent(QMouseEvent *e) override;
	void mouseMoveEvent(QMouseEvent *e) override;
	void _updata(void);
	Plane(QWidget *parent = nullptr) :
			QGroupBox(parent) {
		this->lines = QVector<QLineF>(5000);
		this->count = 0;
		
	}
};

#endif // !PLANE_H