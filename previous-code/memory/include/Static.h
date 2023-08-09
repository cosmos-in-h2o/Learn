#ifndef STATIC_H
#define STATIC_H
#include "def.h"
#include"Another.h"
class 
#ifdef ISECPORT
	DLLEXPORT
#endif
	Static
{
public:
	ChessPieces chess_pieces[32];
	//构造函数
	Static();
	//在全局区申请并写入一片内存
	void _static(Size size, ChessPieces* chess_pieces);
	//free所有全局区内存
	void _free();
};
#endif // !STATIC_H
/// Static.h文档
/// class Static 全局区
/// void Static::_static(Size size, ChessPieces* chess_pieces);在本片全局内存写入size大小的chess_pieces数据
/// void Static::_free();删除本片全局内存所有数据