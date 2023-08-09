#include "Another.h"

void Change1to2(Pos& address, Pos& x, Pos& y)
{
	if (address % 16 == 0)
	{
		x = 16;
		y = address / 16;
	}
	else
	{
		x = address % 16;
		y = address / 16 + 1;
	}
}

void Change2to1(Pos& address, Pos& x, Pos& y)
{
	address = (y - 1) * 16 + x;
}

void Run(std::list<Tag>* tags, ChessBoard* p1, ChessBoard* p2)
{
}
