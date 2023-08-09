#include "ChessBoard.h"
#include "Analyzer.h";

ChessBoard::ChessBoard()
{
	for (int i = 0; i < 256; i++)
	{
		this->chess_pieces[i] = _NULL;
	}
	this->chess_pieces_ptr = chess_pieces;
	this->is_win = true;
}

ChessBoard::ChessBoard(ChessBoard* ptr)
{
	for (int i = 0; i < 256; i++)
	{
		this->chess_pieces[i] = _NULL;
	}
	this->chess_pieces_ptr = chess_pieces;
	this->is_win = true;
	this->ptr = ptr;
}

void ChessBoard::_malloc(Size size, bool mode, ChessPieces* chess_pieces)
{
	ChessBoard* board;
	//最终的地址
	Pos address;
	//对大小做限定
	if (mode == COMMAND && size >= 4) size = 4;
	else if (size > 2) size = 2;
	else if (size <= 0) size = 1;
	//修改的棋盘位置
	if (mode == COMMAND) board = this;
	else board = this->ptr;
	//创建地址列表
	Pos add_list[256] = {0};
	//先将空余空间地址存入
	Size _i = 0;
	bool is_ = false;
	for (Size i = 0; i < 256; i++)
	{
		if (board->chess_pieces[i] == _NULL)
		{
			//std::cout << "a" << std::endl;
			add_list[_i] = i + 1;
			_i++;
		}
	}
	//调试
	for (Size i = 0; i < 256; i++)
	{
		std::cout << add_list[i] << "  ";
	}
	std::cout << std::endl;
	//再找一片连续的指定大小的空间，并获取首地址
	for (Size add = 0; add_list[add] != 0; add++)
	{
		/*
		* 思路：
		* 每个位置往后判断size次在这之间找到非_NULL就退出本循环
		*/
		bool _is = true;
		for (Size i = 0; i < size - 1; i++)
		{
			if (add_list[add + i] != add_list[add + i + 1] - 1) 
			{
				_is = false;
				break;
			}
		}
		//判断为连续内存就退出循环并记录下内存首地址
		if (_is)
		{
			address = add_list[add];
			//std::cout << address << std::endl;
			address--;
			//写入
			for (Size i = 0; i < size; i++)
			{
				board->chess_pieces[address + i] = chess_pieces[i];
			}
			is_ = true;//已经写入
			break;
		}
	}
	//代表未进入也就是有一方堆区溢出
	if(!is_) board->is_win = false;
}

void ChessBoard::_cover(Pos address, Size size, bool mode, ChessPieces* chess_pieces)
{
	if (address <= 0)
	{
		throw _ERROR_();
		return;
	}
	ChessBoard* board;
	//对大小做限定
	if (mode == COMMAND && size >= 5) size = 5;
	else if (size > 3) size = 3;
	else if (size <= 0) size = 1;
	//修改的棋盘位置
	if (mode == COMMAND) board = this;
	else board = this->ptr;
	//创建地址列表
	Pos add_list[256] = { 0 };
	//先将空余空间地址存入
	Size _i = 0;
	for (Size i = 0; i < 256; i++)
	{
		if (board->chess_pieces[i] != _NULL)
		{
			//std::cout << "a" << std::endl;
			add_list[_i] = i + 1;
			_i++;
		}
	}
	//调试
	for (Size i = 0; i < 256; i++)
	{
		std::cout << add_list[i] << "  ";
	}
	std::cout << std::endl;
	Size i = 0;
	for (; i < 256; i++) 
	{
		if (add_list[i] == address)
		{
			break;
		}
		else if (i >= 255)
		{
			throw _ERROR_();
			return;
		}
	}
	std::cout << _i << std::endl;
	//对size进一步限制
	if (size >= _i + 1) size = _i + 1;
	for (Size _i = 0; _i <= size; _i++)
	{
		board->chess_pieces[add_list[i]-1] = chess_pieces[_i];
		i++;
	}
}

void ChessBoard::_cover(Pos x, Pos y, Size size, bool mode, ChessPieces* chess_pieces)
{
	Pos address;
	Change2to1(address, x, y);
	if (address <= 0)
	{
		throw _ERROR_();
		return;
	}
	ChessBoard* board;
	//对大小做限定
	if (mode == COMMAND && size >= 5) size = 5;
	else if (size > 3) size = 3;
	else if (size <= 0) size = 1;
	//修改的棋盘位置
	if (mode == COMMAND) board = this;
	else board = this->ptr;
	//创建地址列表
	Pos add_list[256] = { 0 };
	//先将空余空间地址存入
	Size _i = 0;
	for (Size i = 0; i < 256; i++)
	{
		if (board->chess_pieces[i] != _NULL)
		{
			//std::cout << "a" << std::endl;
			add_list[_i] = i + 1;
			_i++;
		}
	}
	//调试
	for (Size i = 0; i < 256; i++)
	{
		std::cout << add_list[i] << "  ";
	}
	std::cout << std::endl;
	Size i = 0;
	for (; i < 256; i++)
	{
		if (add_list[i] == address)
		{
			break;
		}
		else if (i >= 255)
		{
			throw _ERROR_();
			return;
		}
	}
	std::cout << _i << std::endl;
	//对size进一步限制
	if (size >= _i + 1) size = _i + 1;
	for (Size _i = 0; _i <= size; _i++)
	{
		board->chess_pieces[add_list[i] - 1] = chess_pieces[_i];
		i++;
	}
}

void ChessBoard::_free(Pos address, Size size, bool mode)
{
	if (address <= 0)
	{
		throw _ERROR_();
		return;
	}
	else if (address+size >= 256)
	{
		size = 256 - address;
	}
	address--;
	ChessBoard* board;
	//对大小做限定
	if (mode == COMMAND && size >= 3) size = 3;
	else if (size > 2) size = 2;
	else if (size <= 0) size = 1;
	//修改的棋盘位置
	if (mode == COMMAND) board = this;
	else board = this->ptr;
	//删除
	for (Size i = 0; i < size; i++)
	{
		board->chess_pieces[address + i] = _NULL;
	}
}

void ChessBoard::_free(Pos x, Pos y, Size size, bool mode)
{
	Pos address;
	Change2to1(address, x, y);
	if (address <= 0)
	{
		throw _ERROR_();
		return;
	}
	else if (address + size >= 256)
	{
		size = 256 - address;
	}
	address--;
	ChessBoard* board;
	//对大小做限定
	if (mode == COMMAND && size >= 3) size = 3;
	else if (size > 2) size = 2;
	else if (size <= 0) size = 1;
	//修改的棋盘位置
	if (mode == COMMAND) board = this;
	else board = this->ptr;
	//删除
	for (Size i = 0; i < size; i++)
	{
		board->chess_pieces[address + i] = _NULL;
	}

}

void ChessBoard::_point()
{
	ChessBoard* board;
	//最终的地址
	Pos address;
	Size size = 2;
	//修改的棋盘位置
	board = this;
	//创建地址列表
	Pos add_list[256] = { 0 };
	//先将空余空间地址存入
	Size _i = 0;
	bool is_ = false;
	for (Size i = 0; i < 256; i++)
	{
		if (board->chess_pieces[i] == _NULL)
		{
			//std::cout << "a" << std::endl;
			add_list[_i] = i + 1;
			_i++;
		}
	}
	//调试
	for (Size i = 0; i < 256; i++)
	{
		std::cout << add_list[i] << "  ";
	}
	std::cout << std::endl;
	//再找一片连续的指定大小的空间，并获取首地址
	for (Size add = 0; add_list[add] != 0; add++)
	{
		/*
		* 思路：
		* 每个位置往后判断size次在这之间找到非_NULL就退出本循环
		*/
		bool _is = true;
		for (Size i = 0; i < size - 1; i++)
		{
			if (add_list[add + i] != add_list[add + i + 1] - 1)
			{
				_is = false;
				break;
			}
		}
		//判断为连续内存就退出循环并记录下内存首地址
		if (_is)
		{
			address = add_list[add];
			//std::cout << address << std::endl;
			address--;
			//写入
			for (Size i = 0; i < size; i++)
			{
				board->chess_pieces[address + i] = _P;
			}
			is_ = true;//已经写入
			break;
		}
	}
	//代表未进入也就是有一方堆区溢出
	if (!is_) board->is_win = false;
}

void ChessBoard::_static(Size size, bool mode, ChessPieces* chess_pieces)
{
	ChessBoard* board;
	if (mode == COMMAND) board = this;
	else board = this->ptr;
	board->static_area._static(size, chess_pieces);
}