#include "MyButton.h"

MyButton::MyButton(int X, int Y, int W, int H, const char *l) :
		Fl_Box(X, Y, W, H, l) {
	this->box(FL_RFLAT_BOX);
	this->color(fl_rgb_color(52, 73, 94));
}

MyButton::MyButton(Fl_Boxtype b, int X, int Y, int W, int H, const char *l) :
		Fl_Box(b, X, Y, W, H, l) {
	
}

int MyButton::handle(int e) {
	switch (e) {
		case FL_ENTER:
			this->color(fl_rgb_color(46, 64, 83));
			this->redraw();
			return 1;
		case FL_LEAVE:
			this->color(fl_rgb_color(52, 73, 94));
			this->redraw();
			return 1;
		case FL_PUSH:
			this->color(fl_rgb_color(40, 55, 71));
			if (this->is_click) { this->is_click(); }
			this->redraw();
			return 1;
		case FL_RELEASE:
			this->color(fl_rgb_color(52, 73, 94));
			if (this->is_release) { this->is_release(); }
			this->redraw();
			return 1;
		default:
			return 0;
	}
}

void MyButton::connectClick(std::function<void(void)> func) {
	this->is_click = func;
}

void MyButton::connectRelease(std::function<void(void)> func) {
	this->is_release = func;
}
