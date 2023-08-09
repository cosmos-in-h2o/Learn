#ifndef OPENDER_WINDOW_H
#define OPENDER_WINDOW_H
#include <FL/Fl_Window.H>
#include <FL/Fl.H>
#include <FL/Fl_Group.H>
#include <FL/Fl_File_Chooser.H>
#include <Fl/Fl_Input.H>
#include <FL/Fl_Multiline_Input.H>
#include "MyButton.h"
#include <list>
#include <string>
#include <fstream>

class MyWindow : public Fl_Window {
private:
	MyButton *f_chooser_btn;
	MyButton *open_btn;
	MyButton *prog_btn[6];
	Fl_Input *input;
	Fl_Multiline_Input *prog_path;
	Fl_Input *progname;
	std::list<std::string> proglist;
	std::string path;
	MyButton* creat_btn;
public:
	MyWindow(int x, int y, int w, int h, const char *title = 0);
	void uiInit();
	void load();
	void add(std::string el);
	void save();
	void creatProgram();
	void updata();
};
#endif // !OPENDER_WINDOW_H