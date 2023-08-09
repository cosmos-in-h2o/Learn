#include "Dialog.h"
#include <QtWidgets/QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
	qDebug("%s", argv[1]);
	Dialog w(argv[1]); //传入文件路径
	w.show();
    return a.exec();
}
