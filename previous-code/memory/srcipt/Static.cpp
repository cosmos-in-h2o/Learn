#include "Static.h"

Static::Static()
{
	for (int i = 0; i < 32; i++)
	{
		this->chess_pieces[i] = _NULL;
	}
}

void Static::_static(Size size, ChessPieces* chess_pieces)
{
	Static* board;
	//对大小做限定
	if (size >= 8) size = 8;
	else if (size <= 0) size = 1;
	//修改的棋盘位置
	board = this;
	Size i = 0;
	for (i = 0; board->chess_pieces[i] != _NULL; i++){}
	//写入
	for (Size _i = 0; _i < size; _i++)
	{
		if ((_i + i) <= 31) board->chess_pieces[i + _i] = chess_pieces[i];
		else
		{
			for (Size i_ = 0; i < 32 - i; i_++)
			{
				board->chess_pieces[i + i_] = _NULL;
			}
			//全局区内存溢出
			throw _ERROR_();
			return;
		}
	}
}

void Static::_free()
{
}
