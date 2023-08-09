#include "MemoryLogic.h"

Mainer::Mainer()
{
	this->chess_board1 = new ChessBoard(this->chess_board2);
	this->chess_board2 = new ChessBoard(this->chess_board1);
	this->tag = "";//如果有tag操作出现的tag
	this->pointer = "";//如果有指针操作出现的指针
}

Mainer::~Mainer()
{
	if (this->chess_board1 != nullptr)
		delete this->chess_board1;
		this->chess_board1 = nullptr;
	if (this->chess_board2 != nullptr)
		delete this->chess_board2;
		this->chess_board2 = nullptr;
}

void Mainer::iMain(std::string input, short& player)
{
	ChessPieces* chess_pieces = new ChessPieces[8]{0};//储存内容的数组
	this->tag = "";//如果有tag操作出现的tag
	this->pointer = "";//如果有指针操作出现的指针
	//第一步，分析命令
	FLAG:
	try
	{
		this->com = analyzer(input, tag, pointer);
	}
	catch(_ERROR_ e)
	{
		goto FLAG;//如果捕获错误就重新来
	}
	//第二步，执行命令，使用迭代器一步一步迭代
	this->p = com.begin();
	switch (*p)
	{
	case 1:
		break;
	case 2:
		break;
	case 3:
		break;
	case 4:
		break;
	case 5:
		break;
	case 6:
		break;
	case 7:
		break;
	default:
		break;
	}

	if (player == 1) player = 2;
	else if (player == 2) player = 1;
	delete[] chess_pieces;//内存回收
}