#ifndef MEMORYLOGIC_H
#define MEMORYLOGIC_H
#include "def.h"
//逻辑部分
#include "Analyzer.h"
#include "Another.h"
#include "ChessBoard.h"
#include "Command.h"
#include "Stack.h"
#include "Static.h"
#include "Tag.h"

class 
#ifdef ISECPORT
	DLLEXPORT
#endif
	Mainer
{
public:
	//初始化操作
	ChessBoard* chess_board1;
	ChessBoard* chess_board2;
	std::list<Tag> tag_list;
	std::string tag;//如果有tag操作出现的tag
	std::string pointer;//如果有指针操作出现的指针
	std::list<int> com;//命令列表
	std::list<int>::iterator p;

	Mainer();
	~Mainer();
	void iMain(std::string input, short& player);
};
#endif // !MEMORYLOGIC_H
///-------------------------------总文档-----------------------------------
/// 
/// 本项目是Memory的逻辑部分，也就是后端
/// 
///-----------------------------↓重要部分----------------------------------
/// 
/// MemoryLogic.h文档
/// class Mainer 暴露的接口类
/// bool Mainer::iMain(std::string input, short player);接口函数，写在循环内
/// 
///-----------------------------↑重要部分----------------------------------
///
/// Analyzer.h文档
/// bool isLetter(char& ch);ch是否为字母
/// bool isDigit(char& ch);ch是否为数字
/// std::list<int> analyzer(std::string com, std::string& tag, std::string& pointer);分析命令储存在list中后面遍历list来执行指令，如果命令有误抛出_ERROR_()错误
///-------------------------------------------------------------------------
/// another.h文档
/// typedef unsigned short ChessPieces;棋子类型
/// typedef unsigned short Pos;位置类型
/// typedef unsigned short Size;大小类
/// #define _R		0 定义状态1
/// #define _Y		1 定义状态2
/// #define _B		2 定义状态3
/// #define _G		3 定义状态4
/// #define _NULL	4 定义空状态
/// #define _P		5 定义指针状态
/// #define COMMAND true 定义控制台模式
/// #define EXECUTE false 定义执行命令方式
/// #define _ERROR_ bool 定义错误类型
/// typedef void(*p_fun)(ChessBoard*);函数指针
/// void Change1to2(Pos& address, Pos& x, Pos& y);一维坐标转为二维坐标，传引用自动修改
/// void Change2to1(Pos& address, Pos& x, Pos& y);二维坐标转为一维坐标，传引用自动修改
/// void Run(std::list<Tag>* tags, ChessBoard* p1, ChessBoard* p2);开始运行棋盘函数
///-------------------------------------------------------------------------
/// ChessBoard.h文档
/// class ChessBoard; 棋盘类
/// void ChessBoard::_malloc(Size size, bool mode, ChessPieces* chess_pieces);向本片内存申请一片大小为size的空间并以mode模式写入chess_pieces
/// void ChessBoard::_cover(Pos address, Size size, bool mode, ChessPieces* chess_pieces);将adress向后size以mode模式覆盖为chess_pieces
/// void ChessBoard::_cover(Pos x, Pos y, Size size, bool mode, ChessPieces* chess_pieces);将x,y向后size以mode模式覆盖为chess_pieces
/// void ChessBoard::_free(Pos address, Size size, bool mode);将address向后size大小的空间以mode模式清除
/// void ChessBoard::_free(Pos x, Pos y, Size size, bool mode);将x,y向后size大小的空间以mode模式清除
/// void ChessBoard::_point(); 创建一个指针
/// void ChessBoard::_static(Size size, bool mode, ChessPieces* chess_pieces);在全局区申请size大小内存以mode模式写入chess_pieces数据
///-------------------------------------------------------------------------
/// Command.h文档
/// class Command 命令类型
/// void Command::invoke(ChessBoard* chess_board); chess_board开始执行命令
/// void Command::operator()(ChessBoard* chess_board); chess_board开始执行命令
///-------------------------------------------------------------------------
/// Stack.h文档
/// class Stack 栈区类型
///-------------------------------------------------------------------------
/// Static.h文档
/// class Static 全局区
/// void Static::_static(Size size, ChessPieces* chess_pieces);在本片全局内存写入size大小的chess_pieces数据
/// void Static::_free();删除本片全局内存所有数据
///-------------------------------------------------------------------------
/// Tag.h文档
/// typedef unsigned short TagType; tag的类型
/// #define COM 0 定义指令
/// #define VAR 1 定义变量
/// #define STA 2 定义常量
/// #define PTR 3 定义指针
/// class Tag tag类型
/// 
///---------------------------------结束------------------------------------