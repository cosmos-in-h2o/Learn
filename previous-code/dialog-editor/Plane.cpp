#include "Plane.h"

void Plane::paintEvent(QPaintEvent *event) {
	QPainter painter(this);
	QPen pen;
	pen.setColor(QColor(52, 73, 94));
	pen.setWidth(2);
	painter.setPen(pen);
	painter.drawRect(this->rect());
	painter.drawLines(this->lines);
	painter.end();
	this->update();
}

void Plane::mousePressEvent(QMouseEvent *e) {
	if (e->button() == Qt::RightButton) {
		this->pressPoint = e->pos();
		this->raise();
	}
}
void Plane::mouseMoveEvent(QMouseEvent *e) {
	if (e->buttons() == Qt::RightButton) {
		this->move(this->mapToParent(e->pos() - this->pressPoint));
	}
}

void Plane::_updata(void) {
	this->lines.clear();
	this->count = 0;
	//遍历字典全部数据来添加线进vector
	for (auto p = blocks->begin(); p != blocks->end(); p++) {
		
		for (int i = 0; i < 20; i++) {
			if (this->count >= this->lines.size() - 10) {
				this->lines.resize(this->lines.size()+1000);
			}
			//过滤掉空的和为null的以及指向自己的
			if (p.value()->block_list[i].next_block != "" &&
					p.value()->block_list[i].next_block != "null" &&
					p.value()->block_list[i].next_block != p.key()) {
				auto p2 = blocks->find(p.value()->block_list[i].next_block);
				//如果找到此键
				if (p2 != blocks->end()) {
					QLineF *line = new QLineF(p.value()->pos().x() + 50, p.value()->pos().y() + 25, p2.value()->pos().x() + 50, p2.value()->pos().y() + 25);
					this->lines[this->count] = *line;
					this->count++;
				}
			}
		}
	}
	for (auto p = this->lines.begin(); p != this->lines.end(); p++) {
		if (p->x1() != 0) {
			qDebug("%d %d %d %d ", p->x1(), p->y1(), p->x2(), p->y2());
		}
	}
}
