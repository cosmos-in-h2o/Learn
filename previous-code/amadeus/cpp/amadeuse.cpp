#define __USENAMESPACE__
#include <stdio.h>
#include <iostream>
#include <filesystem>
#ifdef __USENAMESPACE__
using namespace std;
using namespace std::filesystem;
#endif

int main(int argc, char* argv[])
{
	string _command_ = "python ";
	_command_ += current_path().string() + "\\__main__.py ";
	for (int i = 1; i < argc; i++)
	{
		_command_ += argv[i];
		_command_ += ' ';
	}
	system(_command_.c_str());
}