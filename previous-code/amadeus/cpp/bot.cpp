#define __USENAMESPACE__
#include <iostream>
#include <stdio.h>
#include <string>
#ifdef __USENAMESPACE__
using namespace std;
#endif

int main(int argc, char* argv[])
{
	string input = "";
	while (true)
	{
		printf("<U>:");
		getline(cin, input);
		if (input == "q")
			return 0;
		printf("<Kurisu>:");
		string _command_ = "python ./__main__.py -r " + input;
		system(_command_.c_str());
	}
	return 0;
}