#include "Command.h"

Command::Command(ChessPieces com[], Size com_len, Size stack_size, Size static_size, p_fun effect) :
	com_len(com_len),stack_size(stack_size),static_size(static_size),effect(effect)
{
	this->com = new ChessPieces[com_len];
	*(this->com) = *com;
}

void Command::invoke(ChessBoard* chess_board)
{
	this->effect(chess_board);
}

void Command::operator()(ChessBoard* chess_board)
{
	this->effect(chess_board);
}
