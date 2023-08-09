#include "MyWindow.h"

int main(int argc, char **argv) {
	MyWindow *window = new MyWindow(560, 240, 800, 600, "DialogOpener");
	window->end();
	window->show(argc, argv);
	return Fl::run();
}