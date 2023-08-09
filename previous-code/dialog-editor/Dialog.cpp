#include "Dialog.h"
#include "color.h"
#include <fstream>
#include <QDockWidget.h>
#include "nlohmann/json.hpp"
using json = nlohmann::json;

Dialog::Dialog(const char *path, QWidget *parent)
    : QMainWindow(parent){
	this->path = path;
	//窗口基本设置区域
	this->resize(1200, 800);
	this->SetUiStyle();
	QPalette pal = QPalette(QPalette::Background, QColor(23, 32, 42));
	this->setPalette(pal);
	ui.setupUi(this);
	//项目初始化区域
	this->initProgram();
	//控件初始化区域
	this->initSet();
	//block加载区域
	//this->initBlocks();
	//信号连接区域
	this->initConnect();
}

bool Dialog::eventFilter(QObject *watched, QEvent *event) {
	QTextEdit *edit;
	bool _is = false;
	if		(watched == ui.textEdit_1 ) {_is = true; edit = ui.textEdit_1;}
	else if (watched == ui.textEdit_2 ) {_is = true; edit = ui.textEdit_2;}
	else if (watched == ui.textEdit_3 ) {_is = true; edit = ui.textEdit_3;}
	else if (watched == ui.textEdit_4 ) {_is = true; edit = ui.textEdit_4;}
	else if (watched == ui.textEdit_5 ) {_is = true; edit = ui.textEdit_5;}
	else if (watched == ui.textEdit_6 ) {_is = true; edit = ui.textEdit_6;}
	else if (watched == ui.textEdit_7 ) {_is = true; edit = ui.textEdit_7;}
	else if (watched == ui.textEdit_8 ) {_is = true; edit = ui.textEdit_8;}
	else if (watched == ui.textEdit_9 ) {_is = true; edit = ui.textEdit_9;}
	else if (watched == ui.textEdit_10) {_is = true; edit = ui.textEdit_10;}
	else if (watched == ui.textEdit_11) {_is = true; edit = ui.textEdit_11;}
	else if (watched == ui.textEdit_12) {_is = true; edit = ui.textEdit_12;}
	else if (watched == ui.textEdit_13) {_is = true; edit = ui.textEdit_13;}
	else if (watched == ui.textEdit_14) {_is = true; edit = ui.textEdit_14;}
	else if (watched == ui.textEdit_15) {_is = true; edit = ui.textEdit_15;}
	else if (watched == ui.textEdit_16) {_is = true; edit = ui.textEdit_16;}
	else if (watched == ui.textEdit_17) {_is = true; edit = ui.textEdit_17;}
	else if (watched == ui.textEdit_18) {_is = true; edit = ui.textEdit_18;}
	else if (watched == ui.textEdit_19) {_is = true; edit = ui.textEdit_19;}
	else if (watched == ui.textEdit_20) {_is = true; edit = ui.textEdit_20;}

	if (_is) {
		if (event->type() == QEvent::KeyPress) {
			QKeyEvent *keyEvent = static_cast<QKeyEvent *>(event);
			if (keyEvent->key() == Qt::Key_Return || keyEvent->key() == Qt::Key_Enter) {
				edit->append("\n");
				QTextCursor cursor = edit->textCursor();
				cursor.movePosition(QTextCursor::End);
				cursor.select(QTextCursor::LineUnderCursor);
				cursor.removeSelectedText();
				cursor.deletePreviousChar();
				edit->setTextCursor(cursor); 
				this->saveBlock();
				return true;
			}
		}
	}
	return QWidget::eventFilter(watched, event);
}

void Dialog::closeEvent(QCloseEvent *event) {
	this->save();
}

void Dialog::initProgram() {
	const char *pathtemp = this->path;
	/* 初始化读取项目文件内容 */
	pos = Vector2(0, 0); //偏移位置
	size = Vector2(1920, 1080); //大小
	std::ifstream in;
	in.open(pathtemp, std::ios::in);
	if (!in.is_open()) {
		in.close();
		printf("aaa");
		return;
	}
	getline(in, block_path);
	getline(in, code_path);
	in >> pos.x;
	in >> pos.y;
	in >> size.x;
	in >> size.y;
	getline(in, buff);
	while (getline(in, buff)) {
		if (buff == "end")
			break;
		else if (buff != " " && buff[0] != '\0' && buff[0] != '\n')
			struct_code.append(buff + "\n");
	}
	while (getline(in, buff)) {
		if (buff == "end")
			break;
		else if (buff != " " && buff[0] != '\0' && buff[0] != '\n')
			method_code.append(buff + "\n");
	}
	getline(in, json_path);
	in.close();
}

void Dialog::initConnect() {
	connect(setAction, &QAction::triggered, this, [=]() { ui.dockSet->setVisible(true); });
	connect(codeAction, &QAction::triggered, this, [=]() { ui.dockCode->setVisible(true); });
	connect(editorAction, &QAction::triggered, this, [=]() { ui.dockEditor->setVisible(true); });
	connect(ui.Quit, &QPushButton::clicked, this, &Dialog::quit);
	connect(ui.CreatBlock, &QPushButton::clicked, this, &Dialog::creatBlock);
	connect(ui.SaveMain, &QPushButton::clicked, this, &Dialog::save);
	connect(ui.save,&QPushButton::clicked,this,&Dialog::saveBlock);
}

void Dialog::creatBlock() {
	QString temp_qstring = ui.BlockName->text();
	if (temp_qstring == "") {
		return;
	}
	QString text = temp_qstring;
	ui.BlockName->setText("");
	int temp_num = 1;
	while (true) {
		if (blocks.find(text) != blocks.end()) {
			text = temp_qstring + "_" + QString::number(temp_num);
			temp_num++;
		} 
		else {
			break;
		}
	}
	Block *block = new Block(text, &now, &ui, this->MainBox);
	block->block_is = "[]()->bool{return true;}";
	block->block_call_back = "[]()->void{return;}";
	block->block_type = 0;
	block->block_list[0].cilp_call_back = "[]()->void{}";
	block->block_list[0].speaker_name = "name";
	block->block_list[0].speaker_words = "words";
	block->block_list[0].next_block = "next";
	connect(ui.deleteBtn, &QPushButton::clicked, this, [=]() {
		if (this->now == nullptr) {
			return;
		}
		auto p = blocks.find(block->text());
		switch (QMessageBox::question(this, "是否删除?", "确定要删除block:" + this->now->text() + "?",
				QMessageBox::Yes | QMessageBox::No, QMessageBox::Yes)) {
			case QMessageBox::Yes:
				blocks.erase(p);
				block->deleteLater();
				break;
			case QMessageBox::No:
				break;
			default:
				break;
		}
	});
	connect(block, &Block::PressSignals, this->MainBox,&Plane::_updata);
	block->setGeometry(550 - MainBox->x(), 425 - MainBox->y(), 100, 50);
	this->blocks.insert(text, block);
	block->show();
	emit block->PressSignals();
}

void Dialog::initBlocks() {
	const char *pathtemp = json_path.c_str();
	std::ifstream in(pathtemp, std::ios::in);
	if (in.is_open()) {
		int block_num;
		QString name;
		int type;
		int block_x;
		int block_y;
		Clips block_clips[20] = { 0 };
		json j;
		json _j;
		json __j;
		in >> j;
		if (j = nullptr) {
			return;
		}
		block_num = j.at("block_num");
		for (int i = 0; i < block_num; i++) {
			_j = j.at("block_list").at(i);
			__j = _j.at("block_clips");
			name = QString::fromStdString(_j.at("block_name"));
			Block *block = new Block(name, &now, &ui, this->MainBox);
			connect(ui.deleteBtn, &QPushButton::clicked, this, [=]() {
				if (this->now == nullptr) {
					return;
				}
				auto p = blocks.find(block->text());
				switch (QMessageBox::question(this, "是否删除?", "确定要删除block:" + this->now->text() + "?",
						QMessageBox::Yes | QMessageBox::No, QMessageBox::Yes)) {
					case QMessageBox::Yes:
						blocks.erase(p);
						block->deleteLater();
						break;
					case QMessageBox::No:
						break;
					default:
						break;
				}
			});
			type = _j.at("block_type");
			block->block_type = type;
			block_x = _j.at("x");
			block_y = _j.at("y");
			if (__j != nullptr) {
				for (int _i = 0; _i < 20; _i++) {
					int __i = 0;
					if (__j.at(_i).at("speaker_words") != "") {
						block_clips[__i].speaker_name = QString::fromStdString(__j.at(_i).at("speaker_name"));
						block_clips[__i].speaker_words = QString::fromStdString(__j.at(_i).at("speaker_words"));
						__i++;
					}
				}
				for (int _i = 0; i < 20; _i++) {
					block->block_list[_i].set(block_clips[_i]);
				}
			}

			block->setGeometry(block_x, block_y, 100, 50);
			block->show();
			block->block_is = QString::fromStdString(_j.at("block_is"));
			block->block_call_back = QString::fromStdString(_j.at("block_call_back"));
			this->blocks.insert(name, block);
		}
		emit this->now->PressSignals();
	}
	in.close();
}

void Dialog::save() {
	
	std::ofstream out(path,std::ios::out);
	out << block_path << "\n";
	out << code_path << "\n";
	out << MainBox->x() << " " << MainBox->y() << " " << MainBox->size().width() << " " << MainBox->size().height() << "\n";
	out << ui.structCode->toPlainText().toStdString()<< "\nend\n";
	out << ui.methodCode->toPlainText().toStdString()<< "\nend\n";
	out << json_path << "\n";
	out.close();
	json ablock;
	json aclip;
	json clips;
	json j;
	int block_num = 0;
	for (QMap<QString, Block *>::iterator p = blocks.begin(); p != blocks.end(); p++) {
		for (int i = 0; i < 20; i++) {
			if (p.value()->block_list[i].speaker_words.toStdString() != "") {
				aclip["speaker_name"] = p.value()->block_list[i].speaker_name.toStdString();
				aclip["speaker_words"] = p.value()->block_list[i].speaker_words.toStdString();
				clips["block_clips"].push_back(aclip);
			}
		}
		if (clips.empty()) {
			ablock["block_clips"] = nullptr;
		} else {
			ablock["block_clips"] = clips;
		}
		ablock["x"] = p.value()->x();
		ablock["y"] = p.value()->y();
		ablock["block_is"] = p.value()->block_is.toStdString();
		ablock["block_call_back"] = p.value()->block_call_back.toStdString();
		ablock["block_type"] = p.value()->block_type;
		ablock["block_name"] = p.key().toStdString();
		j["block_list"].push_back(ablock);
		block_num++;
	}
	j["block_num"] = block_num;
	std::ofstream out2(json_path, std::ios::out);
	out2 << j;
	out2.close();
}

void Dialog::saveBlock() {
	if (now == nullptr) {
		return;
	}
	QString old_ = this->now->text();
	QString new_ = ui.nameEdit->text();
	if (new_ == "") {
		return;
	}
	QString text = new_;
	int temp_num = 1;
	while (true) {
		if (blocks.find(text) != blocks.end() && blocks.find(text).value()->text() != old_) {
			text = new_ + "_" + QString::number(temp_num);
			temp_num++;
		} else {
			break;
		}
	}
	this->now->setText(text);
	this->now->block_is = ui.boolEdit->text();
	this->now->block_call_back = ui.callBackEdit->text();
	this->now->block_type = ui.typeEditor->currentIndex();
	if (ui.textEdit_1-> toPlainText() != "") this->now->block_list[0]  = Slipt(ui.textEdit_1-> toPlainText());
	if (ui.textEdit_2-> toPlainText() != "") this->now->block_list[1]  = Slipt(ui.textEdit_2-> toPlainText());
	if (ui.textEdit_3-> toPlainText() != "") this->now->block_list[2]  = Slipt(ui.textEdit_3-> toPlainText());
	if (ui.textEdit_4-> toPlainText() != "") this->now->block_list[3]  = Slipt(ui.textEdit_4-> toPlainText());
	if (ui.textEdit_5-> toPlainText() != "") this->now->block_list[4]  = Slipt(ui.textEdit_5-> toPlainText());
	if (ui.textEdit_6-> toPlainText() != "") this->now->block_list[5]  = Slipt(ui.textEdit_6-> toPlainText());
	if (ui.textEdit_7-> toPlainText() != "") this->now->block_list[6]  = Slipt(ui.textEdit_7-> toPlainText());
	if (ui.textEdit_8-> toPlainText() != "") this->now->block_list[7]  = Slipt(ui.textEdit_8-> toPlainText());
	if (ui.textEdit_9-> toPlainText() != "") this->now->block_list[8]  = Slipt(ui.textEdit_9-> toPlainText());
	if (ui.textEdit_10->toPlainText() != "") this->now->block_list[9]  = Slipt(ui.textEdit_10->toPlainText());
	if (ui.textEdit_11->toPlainText() != "") this->now->block_list[10] = Slipt(ui.textEdit_11->toPlainText());
	if (ui.textEdit_12->toPlainText() != "") this->now->block_list[11] = Slipt(ui.textEdit_12->toPlainText());
	if (ui.textEdit_13->toPlainText() != "") this->now->block_list[12] = Slipt(ui.textEdit_13->toPlainText());
	if (ui.textEdit_14->toPlainText() != "") this->now->block_list[13] = Slipt(ui.textEdit_14->toPlainText());
	if (ui.textEdit_15->toPlainText() != "") this->now->block_list[14] = Slipt(ui.textEdit_15->toPlainText());
	if (ui.textEdit_16->toPlainText() != "") this->now->block_list[15] = Slipt(ui.textEdit_16->toPlainText());
	if (ui.textEdit_17->toPlainText() != "") this->now->block_list[16] = Slipt(ui.textEdit_17->toPlainText());
	if (ui.textEdit_18->toPlainText() != "") this->now->block_list[17] = Slipt(ui.textEdit_18->toPlainText());
	if (ui.textEdit_19->toPlainText() != "") this->now->block_list[18] = Slipt(ui.textEdit_19->toPlainText());
	if (ui.textEdit_20->toPlainText() != "") this->now->block_list[19] = Slipt(ui.textEdit_20->toPlainText());
	auto p = blocks.find(old_);
	blocks.erase(p);
	this->blocks.insert(text, this->now);
	emit this->now->PressSignals();
}

void Dialog::initSet() {
	this->MainBox = new Plane(this);
	QFont font;
	//初始化操作
	MainBox->setGeometry(pos.x, pos.y, size.x, size.y);
	MainBox->blocks = &(this->blocks);
	font.setFamily(QString::fromUtf8("\345\256\213\344\275\223"));
	font.setPointSize(10);
	setAction = new QAction("SetWindow");
	codeAction = new QAction("CodeWindow");
	editorAction = new QAction("EditorWindow ");
	ui.toolBar->addAction(setAction);
	ui.toolBar->addAction(codeAction);
	ui.toolBar->addAction(editorAction);
	this->MainBox->setFont(font);
	this->MainBox->setStyleSheet(QString::fromUtf8("background-color: rgba(255, 255, 255, 0);border : 2px solid#5D6D7E;"));
	ui.structCode->setPlainText(QString::fromStdString(struct_code));
	ui.methodCode->setPlainText(QString::fromStdString(method_code));
	ui.dockCode->setWindowTitle("代码Editor");
	ui.dockSet->setWindowTitle("设置");
	ui.dockCode->setFloating(true);
	ui.dockEditor->setFloating(true);
	ui.dockSet->setFloating(true);
	ui.dockCode->setGeometry(20, 500, 600, 400);
	ui.dockCode->setVisible(false);
	ui.dockEditor->setGeometry(1700, 100, 215, 785);
	ui.dockSet->setGeometry(20, 300, 250, 150);
	ui.SaveMain->setShortcut(QApplication::translate("Widget", "Ctrl+S", nullptr));
	ui.save->setShortcut(QApplication::translate("Widget", "Return", nullptr));
	ui.CreatBlock->setShortcut(QApplication::translate("Widget", "Ctrl+F", nullptr));
	ui.textEdit_1 ->installEventFilter(this);
	ui.textEdit_2 ->installEventFilter(this);
	ui.textEdit_3 ->installEventFilter(this);
	ui.textEdit_4 ->installEventFilter(this);
	ui.textEdit_5 ->installEventFilter(this);
	ui.textEdit_6 ->installEventFilter(this);
	ui.textEdit_7 ->installEventFilter(this);
	ui.textEdit_8 ->installEventFilter(this);
	ui.textEdit_9 ->installEventFilter(this);
	ui.textEdit_10->installEventFilter(this);
	ui.textEdit_11->installEventFilter(this);
	ui.textEdit_12->installEventFilter(this);
	ui.textEdit_13->installEventFilter(this);
	ui.textEdit_14->installEventFilter(this);
	ui.textEdit_15->installEventFilter(this);
	ui.textEdit_16->installEventFilter(this);
	ui.textEdit_17->installEventFilter(this);
	ui.textEdit_18->installEventFilter(this);
	ui.textEdit_19->installEventFilter(this);
	ui.textEdit_20->installEventFilter(this);
}

void Dialog::quit() {
	switch (QMessageBox::question(this, tr("关闭?"), tr("是否关闭程序（会自动保存）？ "),
			QMessageBox::Yes | QMessageBox::No, QMessageBox::Yes)) {
		case QMessageBox::Yes:
			this->save();
			this->close();
			break;
		case QMessageBox::No:
			break;
		default:
			break;
	}
}

Dialog::~Dialog() {}

void Dialog::SetUiStyle(const char *filePath) {
	/* 第一步:读取出qss文件中的所有文本内容 */
	QFile file(filePath);
	QByteArray fileContent;
	bool isOk = file.open(QIODevice::ReadOnly);

	if (false == isOk) {
		qDebug("wrong");
		file.close();
		return;
	}
	fileContent = file.readAll();
	file.close();
	/* 第二步:将所有内容设置到全局的样式表中 */
	this->setStyleSheet(fileContent);
}