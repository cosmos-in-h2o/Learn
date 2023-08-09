#ifndef ANALYZER_H
#define ANALYZER_H
#include "def.h"
#include<iostream>
#include<list>
#include<sstream>
#include"Another.h"
#ifdef ISECPORT
DLLEXPORT
#endif
bool isLetter(char& ch);
#ifdef ISECPORT
DLLEXPORT
#endif
bool isDigit(char& ch);
#ifdef ISECPORT
DLLEXPORT
#endif
std::list<int> analyzer(std::string com, std::string& tag, std::string& pointer);
#endif
/// Analyzer.h文档
/// bool isLetter(char& ch);ch是否为字母
/// bool isDigit(char& ch);ch是否为数字
/// std::list<int> analyzer(std::string com, std::string& tag, std::string& pointer);分析命令储存在list中后面遍历list来执行指令，如果命令有误抛出_ERROR_()错误