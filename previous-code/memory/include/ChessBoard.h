#ifndef CHESSBOARD_H
#define CHESSBOARD_H
#include "def.h"
#include <iostream>
#include "Another.h"
#include "Stack.h"
#include "Static.h"
#include "Tag.h"
//棋盘类
class
#ifdef ISECPORT
	DLLEXPORT
#endif
	ChessBoard
{
public:
	//整个堆区棋盘
	ChessPieces chess_pieces[256];
	//是否胜利
	bool is_win;
	//指向首地址的指针
	ChessPieces* chess_pieces_ptr;
	//对方棋盘
	ChessBoard* ptr;
	//栈区
	Stack stack;
	//全局区
	Static static_area;
	//构造函数
	ChessBoard();
	ChessBoard(ChessBoard *ptr);
	//向本片内存申请一片空间
	void _malloc(Size size, bool mode, ChessPieces* chess_pieces);
	//覆盖写入
	void _cover(Pos address, Size size, bool mode, ChessPieces* chess_pieces);
	//覆盖写入
	void _cover(Pos x, Pos y, Size size, bool mode, ChessPieces* chess_pieces);
	//删除一片连续空间
	void _free(Pos address, Size size, bool mode);
	//删除一片连续空间
	void _free(Pos x, Pos y, Size size, bool mode);
	//创建指针
	void _point();
	//在全局区申请并写入一片内存
	void _static(Size size, bool mode, ChessPieces* chess_pieces);
};
#endif // !CHESSBOARD_H
/// ChessBoard.h文档
/// class ChessBoard; 棋盘类
/// void ChessBoard::_malloc(Size size, bool mode, ChessPieces* chess_pieces);向本片内存申请一片大小为size的空间并以mode模式写入chess_pieces
/// void ChessBoard::_cover(Pos address, Size size, bool mode, ChessPieces* chess_pieces);将adress向后size以mode模式覆盖为chess_pieces
/// void ChessBoard::_cover(Pos x, Pos y, Size size, bool mode, ChessPieces* chess_pieces);将x,y向后size以mode模式覆盖为chess_pieces
/// void ChessBoard::_free(Pos address, Size size, bool mode);将address向后size大小的空间以mode模式清除
/// void ChessBoard::_free(Pos x, Pos y, Size size, bool mode);将x,y向后size大小的空间以mode模式清除
/// void ChessBoard::_point(); 创建一个指针
/// void ChessBoard::_static(Size size, bool mode, ChessPieces* chess_pieces);在全局区申请size大小内存以mode模式写入chess_pieces数据