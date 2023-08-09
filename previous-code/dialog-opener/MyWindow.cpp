#pragma warning(disable : 4996)
#include "MyWindow.h"
#include <stdio.h>
#include <iostream>
#include <io.h> 
#include <direct.h>

//将一个LPCWSTR转换为string
std::string Lpcwstr2String(LPCWSTR lps) {
	int len = WideCharToMultiByte(CP_ACP, 0, lps, -1, NULL, 0, NULL, NULL);
	if (len <= 0) {
		return "";
	} else {
		char *dest = new char[len];
		WideCharToMultiByte(CP_ACP, 0, lps, -1, dest, len, NULL, NULL);
		dest[len - 1] = 0;
		std::string str(dest);
		delete[] dest;
		return str;
	}
}

//新建一个对话窗口，选择文件
std::string get_path() {
	OPENFILENAME ofn;
	char szFile[300];

	ZeroMemory(&ofn, sizeof(ofn));
	ofn.lStructSize = sizeof(ofn);
	ofn.hwndOwner = NULL;
	ofn.lpstrFile = (LPWSTR)szFile;
	ofn.lpstrFile[0] = '\0';
	ofn.nFilterIndex = 1;
	ofn.nMaxFile = sizeof(szFile);
	ofn.lpstrFilter = L"(*.prod)\0*.prod\0";
	ofn.lpstrFileTitle = NULL;
	ofn.nMaxFileTitle = 0;
	ofn.lpstrInitialDir = NULL;

	ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;

	std::string path_image = "";
	if (GetOpenFileName(&ofn)) {
		path_image = Lpcwstr2String(ofn.lpstrFile);
		return path_image;
	} else {
		return "";
	}
}

std::string path_(std::string s) {
	std::string::size_type pos = 0;
	while ((pos = s.find('\\', pos)) != std::string::npos) {
		s.insert(pos, "\\");
		pos = pos + 2;
	}
	return s;
}

MyWindow::MyWindow(int x, int y, int w, int h, const char *title) :
		Fl_Window(x, y, w, h, title) {
	this->color(fl_rgb_color(28, 40, 51));
	this->uiInit();
	this->load();
}

bool const_char_is_empty(const char* p) {
	if (p != nullptr && strlen(p) == 0) {
		return true;
	}
	else {
		return false;
	}
}

void MyWindow::uiInit() {
	std::ifstream in_("path.txt", std::ios::out);
	in_ >> path;
	in_.close();
	//项目列表初始化
	this->proglist = std::list<std::string>();
	//快捷打开项目按钮初始化
	this->prog_btn[0] = new MyButton(10, 150, 500, 50);
	this->prog_btn[0]->label("null");
	this->prog_btn[0]->labelcolor(fl_rgb_color(255, 255, 255));
	this->prog_btn[0]->labelsize(18);
	this->prog_btn[0]->connectRelease([=]() {
		std::string value_ = this->prog_btn[0]->label();
		if (value_ == "null" || value_ == "") {
			return;
		}
		WinExec(("DialogEditor.exe " + value_).c_str(), SW_SHOWNORMAL);
	});

	this->prog_btn[1] = new MyButton(10, 225, 500, 50);
	this->prog_btn[1]->label("null");
	this->prog_btn[1]->labelcolor(fl_rgb_color(255, 255, 255));
	this->prog_btn[1]->labelsize(18);
	this->prog_btn[1]->connectRelease([=]() {
		std::string value_ = this->prog_btn[1]->label();
		if (value_ == "null" || value_ == "") {
			return;
		}
		WinExec(("DialogEditor.exe " + value_).c_str(), SW_SHOWNORMAL);
	});

	this->prog_btn[2] = new MyButton(10, 300, 500, 50);
	this->prog_btn[2]->label("null");
	this->prog_btn[2]->labelcolor(fl_rgb_color(255, 255, 255));
	this->prog_btn[2]->labelsize(18);
	this->prog_btn[2]->connectRelease([=]() {
		std::string value_ = this->prog_btn[2]->label();
		if (value_ == "null" || value_ == "") {
			return;
		}
		WinExec(("DialogEditor.exe " + value_).c_str(), SW_SHOWNORMAL);
	});

	this->prog_btn[3] = new MyButton(10, 375, 500, 50);
	this->prog_btn[3]->label("null");
	this->prog_btn[3]->labelcolor(fl_rgb_color(255, 255, 255));
	this->prog_btn[3]->labelsize(18);
	this->prog_btn[3]->connectRelease([=]() {
		std::string value_ = this->prog_btn[3]->label();
		if (value_ == "null" || value_ == "") {
			return;
		}
		WinExec(("DialogEditor.exe " + value_).c_str(), SW_SHOWNORMAL);
	});

	this->prog_btn[4] = new MyButton(10, 450, 500, 50);
	this->prog_btn[4]->label("null");
	this->prog_btn[4]->labelcolor(fl_rgb_color(255, 255, 255));
	this->prog_btn[4]->labelsize(18);
	this->prog_btn[4]->connectRelease([=]() {
		std::string value_ = this->prog_btn[4]->label();
		if (value_ == "null" || value_ == "") {
			return;
		}
		WinExec(("DialogEditor.exe " + value_).c_str(), SW_SHOWNORMAL);
	});

	this->prog_btn[5] = new MyButton(10, 525, 500, 50);
	this->prog_btn[5]->label("null");
	this->prog_btn[5]->labelcolor(fl_rgb_color(255, 255, 255));
	this->prog_btn[5]->labelsize(18);
	this->prog_btn[5]->connectRelease([=]() {
		std::string value_ = this->prog_btn[5]->label();
		if (value_ == "null" || value_ == "") {
			return;
		}
		WinExec(("DialogEditor.exe " + value_).c_str(), SW_SHOWNORMAL);
	});
	//打开按钮初始化
	this->open_btn = new MyButton(625, 50, 60, 30, "打开");
	this->open_btn->labelsize(18);
	this->open_btn->labelcolor(fl_rgb_color(255, 255, 255));
	this->open_btn->connectRelease([this]() {
		std::string value_ = this->input->value();
		if (value_ == "" || value_.length() < 5 || value_.substr(value_.length() - 5, value_.length()) != ".prod") {
			return;
		}
		WinExec(("DialogEditor.exe " + value_).c_str(), SW_SHOWNORMAL);
		this->add(value_);
		this->save();

	});
	//文件路径输入框初始化
	this->input = new Fl_Input(10, 50, 600, 30);
	this->input->color(fl_rgb_color(40, 55, 71));
	this->input->box(FL_FLAT_BOX);
	this->input->textcolor(fl_rgb_color(255, 255, 255));
	//打开选择器按钮初始化
	this->f_chooser_btn = new MyButton(700, 50, 60, 30, "...");
	this->f_chooser_btn->labelsize(18);
	this->f_chooser_btn->labelcolor(fl_rgb_color(255, 255, 255));
	this->f_chooser_btn->connectRelease([=]() { 
		std::string str = path_(get_path());
		this->input->value(str.c_str()); 
	});
	//项目名字输入框初始化
	this->progname = new Fl_Input(550,150,200,30);
	this->progname->color(fl_rgb_color(40, 55, 71));
	this->progname->box(FL_FLAT_BOX);
	this->progname->textcolor(fl_rgb_color(255, 255, 255));
	this->progname->textsize(18);
	//项目路径输入初始化
	this->prog_path = new Fl_Multiline_Input(550,220,200,200);
	this->prog_path->color(fl_rgb_color(40, 55, 71));
	this->prog_path->box(FL_FLAT_BOX);
	this->prog_path->textcolor(fl_rgb_color(255, 255, 255));
	this->prog_path->textsize(18);
	//创建按钮初始化
	this->creat_btn = new MyButton(550, 460, 200, 50, "创建");
	this->creat_btn->labelcolor(fl_rgb_color(255, 255, 255));
	this->creat_btn->labelsize(18);
	this->creat_btn->connectRelease([=]() {
		std::string value_ = this->progname->value();
		if (value_ == "") {
			return;
		}
		std::string value__ = this->prog_path->value();
		if (value__ == "") {
			return;
		}
		if (value_.back() != '/') {
			value_.push_back('/');
		}
		this->creatProgram();
	});
}

void MyWindow::load() {
	std::ifstream _in;
	_in.open(this->path, std::ios::in);
	if (!_in.is_open()) {
		printf("open wrong");
		return;
	}
	std::string buff;
	while (getline(_in, buff)) {
		this->add(buff);
	}
	_in.close();
	this->updata();
}

void MyWindow::add(std::string el) {
	auto p = std::find(this->proglist.begin(), this->proglist.end(), el);
	if (p != this->proglist.end()) {
		return;
	}
	if (el != "" && el != " " && el[0] != '\0' && el[0] != '\n') {
		if (this->proglist.size() >= 6) {
			this->proglist.pop_back();
		}
		this->proglist.push_front(el);
	}
	this->updata();
}

void MyWindow::save() {

	FILE *f = fopen(this->path.c_str(), "w");
	for (int i = 0; i < 6; i++) {
		fprintf(f, "%s\n", this->prog_btn[i]->label());
	}
	fclose(f);
}

void MyWindow::creatProgram() {
	std::string p_name = this->progname->value();
	std::string p_path = this->prog_path->value();
	std::string folder = p_path + p_name;
	std::string out_folder = folder + "/out";
	std::string program_file = folder + "/" + p_name + ".prod";
	std::string json_file = folder + "/" + p_name + ".json";
	std::string text_file = out_folder + "/" + p_name + ".json";
	std::string code_file = out_folder + "/" + p_name + ".cpp";

	mkdir(folder.c_str()); //创建文件夹
	mkdir(out_folder.c_str()); //创建文件夹
	std::ofstream out(program_file, std::ios::out);//初始化项目文件
	out << text_file << "\n";
	out << code_file << "\n";
	out << "0 0 1920 1080\n";
	out << "struct\nend\nfunction\nend\n";
	out << json_file;
	out.close();
	out.open(json_file, std::ios::out);
	out.close();
	WinExec(("DialogEditor.exe " + program_file).c_str(), SW_SHOWNORMAL);
}

void MyWindow::updata() {
	int index = 0;
	for (auto p = this->proglist.begin(); p != this->proglist.end(); p++) {
		
		if (index < 6) {
			this->prog_btn[index]->label(p->c_str());
		}
		index++;
	}
}