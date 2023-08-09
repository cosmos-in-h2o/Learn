#ifndef ANOTHER_H
#define ANOTHER_H
#include "def.h"

//是否要导出为dll
#ifdef BUILD_DLL
#define DLLEXPORT __declspec(dllexport)
#else
#define DLLEXPORT __declspec(dllimport)
#endif

#include<list>
#include"Tag.h"
class ChessBoard;
typedef unsigned short ChessPieces;
typedef unsigned short Pos;
typedef unsigned short Size;
#define _R		0//状态1
#define _Y		1//状态2
#define _B		2//状态3
#define _G		3//状态4
#define _NULL	4//空状态
#define _P		5//指针状态

#define COMMAND true//控制台模式
#define EXECUTE false//执行命令方式

#define _ERROR_ bool//错误类型

typedef void(*p_fun)(ChessBoard*);

//二维坐标与一维坐标的转换
#ifdef ISECPORT
DLLEXPORT
#endif
void Change1to2(Pos& address, Pos& x, Pos& y);
#ifdef ISECPORT
DLLEXPORT
#endif
void Change2to1(Pos& address, Pos& x, Pos& y);
//运行函数
#ifdef ISECPORT
DLLEXPORT
#endif
void Run(std::list<Tag>* tags,ChessBoard* p1,ChessBoard* p2);
#endif // !ANOTHER_H
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