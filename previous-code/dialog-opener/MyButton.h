#ifndef MY_BUTTON_H
#define MY_BUTTON_H
#include <FL/Fl_Box.H>
#include <functional>
class MyButton :public Fl_Box{
public:
	MyButton(int X, int Y, int W, int H, const char *l = 0);
	MyButton(Fl_Boxtype b, int X, int Y, int W, int H, const char *l);
	int handle(int e);
	void connectClick(std::function<void(void)> func);
	void connectRelease(std::function<void(void)> func);
private:
	std::function<void(void)> is_click;
	std::function<void(void)> is_release;
};
#endif