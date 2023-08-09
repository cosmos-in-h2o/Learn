#ifndef COMMAND_H
#define COMMAND_H
#include "def.h"
#include<iostream>
#include"Another.h"
#include"ChessBoard.h"
class 
#ifdef ISECPORT
	DLLEXPORT
#endif
	Command
{
public:
	//指令内容
	ChessPieces* com;
	//指令长度
	Size com_len;
	//所需栈区内存
	Size stack_size;
	//所需全局区内存
	Size static_size;
private:
	//指令效果
	p_fun effect;
public:
	//构造函数
	Command(
		ChessPieces com[],
		Size com_len = 8,
		Size stack_size = 16,
		Size static_size = 4,
		p_fun effect = [](ChessBoard* chess_board)->void {
			return;
		}
	);
	//执行命令
	void invoke(ChessBoard* chess_board);
	void operator()(ChessBoard* chess_board);
};
#endif // !COMMAND_H
/// Command.h文档
/// class Command 命令类型
/// void Command::invoke(ChessBoard* chess_board); chess_board开始执行命令
/// void Command::operator()(ChessBoard* chess_board); chess_board开始执行命令
