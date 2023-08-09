#include "Tag.h"

Tag::Tag()
{
}

//md这坨答辩一样的东西是什么玩意
Tag::Tag(std::string _name,
	ChessBoard* _chess_board_ptr, 
	TagType _tag_type, 
	unsigned short _size, 
	Pos _address,Tag* _ptr):
	name(_name),
	chess_board_ptr(_chess_board_ptr),
	tag_type(_tag_type),
	size(_size),
	address(_address),
	ptr(_ptr)
{
}
