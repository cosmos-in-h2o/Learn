#ifndef TAG_H
#define TAG_H
#include "def.h"
//#define ISECPORT
//是否要导出为dll
#ifdef BUILD_DLL
#define DLLEXPORT __declspec(dllexport)
#else
#define DLLEXPORT __declspec(dllimport)
#endif
#include<iostream>
typedef unsigned short TagType; //tag类型
class ChessBoard;
#define COM 0//指令
#define VAR 1//变量
#define STA 2//常量
#define PTR 3//指针
typedef unsigned short Pos;

class 
#ifdef ISECPORT
	DLLEXPORT
#endif
	Tag
{
public:
	std::string name;
	ChessBoard* chess_board_ptr;
	TagType tag_type;
	unsigned short size;
	Pos address;
	Tag* ptr;//如果是指针指向的tag
	//构造函数
	Tag();
	//构造函数
	Tag(std::string _name,
	ChessBoard* _chess_board_ptr,
	TagType _tag_type,
	unsigned short _size,
	Pos _address,
	Tag* ptr_);
};
#endif // !TAG_H
/// Tag.h文档
/// typedef unsigned short TagType; tag的类型
/// #define COM 0 定义指令
/// #define VAR 1 定义变量
/// #define STA 2 定义常量
/// #define PTR 3 定义指针
/// class Tag tag类型