#include "Block.h"
#include <qline.h>

void Block::mousePressEvent(QMouseEvent *e) {
	if (e->button() == Qt::LeftButton) {
		this->raise(); //将此按钮移动到顶层显示
		this->pressPoint = e->pos();
		*(this->now) = this;
		ui->nameEdit->setText(this->text());
		ui->typeEditor->setCurrentIndex(this->block_type);
		ui->boolEdit->setText(this->block_is);
		ui->callBackEdit->setText(this->block_call_back);
		ui->textEdit_1-> setText(ClipsToString(this->block_list[0] ));
		ui->textEdit_2-> setText(ClipsToString(this->block_list[1] ));
		ui->textEdit_3-> setText(ClipsToString(this->block_list[2] ));
		ui->textEdit_4-> setText(ClipsToString(this->block_list[3] ));
		ui->textEdit_5-> setText(ClipsToString(this->block_list[4] ));
		ui->textEdit_6-> setText(ClipsToString(this->block_list[5] ));
		ui->textEdit_7-> setText(ClipsToString(this->block_list[6] ));
		ui->textEdit_8-> setText(ClipsToString(this->block_list[7] ));
		ui->textEdit_9-> setText(ClipsToString(this->block_list[8] ));
		ui->textEdit_10->setText(ClipsToString(this->block_list[9] ));
		ui->textEdit_11->setText(ClipsToString(this->block_list[10]));
		ui->textEdit_12->setText(ClipsToString(this->block_list[11]));
		ui->textEdit_13->setText(ClipsToString(this->block_list[12]));
		ui->textEdit_14->setText(ClipsToString(this->block_list[13]));
		ui->textEdit_15->setText(ClipsToString(this->block_list[14]));
		ui->textEdit_16->setText(ClipsToString(this->block_list[15]));
		ui->textEdit_17->setText(ClipsToString(this->block_list[16]));
		ui->textEdit_18->setText(ClipsToString(this->block_list[17]));
		ui->textEdit_19->setText(ClipsToString(this->block_list[18]));
		ui->textEdit_20->setText(ClipsToString(this->block_list[19]));
	}
}

void Block::mouseMoveEvent(QMouseEvent *e) {
	if (e->buttons() == Qt::LeftButton) {
		this->move(this->mapToParent(e->pos() - this->pressPoint));
		//防止按钮移出父窗口
		if (this->mapToParent(this->rect().topLeft()).x() <= 0) {
			this->move(0, this->pos().y());
		}
		if (this->mapToParent(this->rect().bottomRight()).x() >= this->parentWidget()->rect().width()) {
			this->move(this->parentWidget()->rect().width() - this->width(), this->pos().y());
		}
		if (this->mapToParent(this->rect().topLeft()).y() <= 0) {
			this->move(this->pos().x(), 0);
		}
		if (this->mapToParent(this->rect().bottomRight()).y() >= this->parentWidget()->rect().height()) {
			this->move(this->pos().x(), this->parentWidget()->rect().height() - this->height());
		}
		emit PressSignals();

	}
}

Clips Slipt(QString str) {
	QStringList list = str.split("\n");
	Clips out = { "", "", "", ""};
	int size = list.size();
	if (size >= 1)
		out.cilp_call_back = list[0];
	if (size >= 2)
		out.speaker_name = list[1];
	if (size >= 3)
		out.speaker_words = list[2];
	if (size >= 4)
		out.next_block = list[3];
	return out;
}

QString ClipsToString(Clips &c) {
	QString out = "";
	if (c.cilp_call_back != "")
		out.append(c.cilp_call_back + "\n");
	if (c.speaker_name != "")
		out.append(c.speaker_name + "\n");
	if (c.speaker_words != "")
		out.append(c.speaker_words + "\n");
	if (c.next_block != "")
		out.append(c.next_block + "\n");
	return out;
}