#include "Analyzer.h"

bool isLetter(char& ch)
{
    if ('a' <= ch <= 'z' || 'A' <= ch <= 'Z')
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool isDigit(char& ch)
{
    if ('0' <= ch <= '9')
    {
        return 0;
    }
    else
    {
        return false;
    }
}

std::list<int> analyzer(std::string com, std::string& tag, std::string& pointer)
{
    std::istringstream str(com);
    //根据空格分词
    std::list<std::string> token;
    std::string _token;
    std::list<int> out;
    while (str >> _token) 
    {
        token.push_back(_token);
    }
    std::list<std::string>::iterator p = token.begin();
    //指令形式 malloc size 内容
    if (*p == "malloc")
    {
        if (token.size() != 3)
        {
            throw _ERROR_();
            return std::list<int>();
        }
        out.push_back(1);
        p++;
        if (isDigit((*p)[0]))
        {
            if ((*p).size() > 1)
            {
                out.push_back(4);
            }
            else
            {
                out.push_back((*p)[0] - '0');
            }
        }
        else
        {
            throw _ERROR_();
            return std::list<int>();
        }
        p++;
        for (int i = 0; i < (*p).size(); i++)
        {
            if ((*p)[i] == 'R')
                out.push_back(_R);
            else if ((*p)[i] == 'Y')
                out.push_back(_Y);
            else if ((*p)[i] == 'B')
                out.push_back(_B);
            else if ((*p)[i] == 'G')
                out.push_back(_G);
            else
                throw _ERROR_();
                return std::list<int>();
        }
    }
    //指令形式 cover 地址 内容
    else if (*p == "cover")
    {
        if(token.size() != 3)
        {
            throw _ERROR_();
            return std::list<int>();
        }
        out.push_back(2);
        p++;
        Pos x = strtol((char*)(*p)[0], 0, 16);
        Pos y = strtol((char*)(*p)[1], 0, 16);
        Pos address = 0;
        Change2to1(address, x, y);
        out.push_back(address);
        p++;
        for (int i = 0; i < (*p).size(); i++)
        {
            if ((*p)[i] == 'R')
                out.push_back(_R);
            else if ((*p)[i] == 'Y')
                out.push_back(_Y);
            else if ((*p)[i] == 'B')
                out.push_back(_B);
            else if ((*p)[i] == 'G')
                out.push_back(_G);
            else
                throw _ERROR_();
                return std::list<int>();
        }
    }
    //指令形式 free 地址 大小
    else if (*p == "free")
    {
        if (token.size() != 3)
        {
            throw _ERROR_();
            return std::list<int>();
        }
        out.push_back(3);
        p++;
        Pos x = strtol((char*)(*p)[0], 0, 16);
        Pos y = strtol((char*)(*p)[1], 0, 16);
        Pos address = 0;
        Change2to1(address, x, y);
        out.push_back(address);
        p++;
        if (isDigit((*p)[0]))
        {
            out.push_back((*p)[0] - '0');
        }
        else
        {
            throw _ERROR_();
            return std::list<int>();
        }
    }
    //指令形式 point tag:tag
    else if (*p == "point")
    {
        if (token.size() != 2)
        {
            throw _ERROR_();
            return std::list<int>();
        }
        out.push_back(4);
        p++;
        std::string str1;
        std::string str2;
        for (int i = 0; (*p)[i] != ':'; i++)
        {
            if (i >= (*p).size())
            {
                throw _ERROR_();
                return std::list<int>();
            }
            else
            {
                str1.push_back((*p)[i]);
            }
        }
        for (int i = 3;; i++)
        {
            if (i >= (*p).size())
            {
                throw _ERROR_();
                return std::list<int>();
            }
            else
            {
                str2.push_back((*p)[i]);
            }
        }
        if (str1=="tag")
        {
            tag = str2;
        }
        else
        {
            throw _ERROR_();
            return std::list<int>();
        }
    }
    //指令形式 static size 内容
    else if (*p == "static")
    {
        if (token.size() != 3)
        {
            throw _ERROR_();
            return std::list<int>();
        }
        out.push_back(5);
        p++;
        if (isDigit((*p)[0]))
        {
            if ((*p).size() > 1)
            {
                out.push_back(4);
            }
            else
            {
                out.push_back((*p)[0] - '0');
            }
        }
        else
        {
            throw _ERROR_();
            return std::list<int>();
        }
        p++;
        for (int i = 0; i < (*p).size(); i++)
        {
            if ((*p)[i] == 'R')
                out.push_back(_R);
            else if ((*p)[i] == 'Y')
                out.push_back(_Y);
            else if ((*p)[i] == 'B')
                out.push_back(_B);
            else if ((*p)[i] == 'G')
                out.push_back(_G);
            else
                throw _ERROR_();
            return std::list<int>();
        }
    }
    //指令形式 tag 地址 名字 大小
    else if (*p == "tag")
    {
        if (token.size() != 4)
        {
            throw _ERROR_();
            return std::list<int>();
        }
        out.push_back(6);
        p++;
        tag = (*p);
        p++;
        Pos x = strtol((char*)(*p)[0], 0, 16);
        Pos y = strtol((char*)(*p)[1], 0, 16);
        Pos address = 0;
        Change2to1(address, x, y);
        out.push_back(address);
        p++;
        if (isDigit((*p)[0]))
        {
            out.push_back((*p)[0] - '0');
        }
        else
        {
            throw _ERROR_();
            return std::list<int>();
        }
    }
    //指令形式 ptag pointer tag:tag
    else if (*p == "ptag")
    {
        if (token.size() != 3)
        {
            throw _ERROR_();
            return std::list<int>();
        }
        out.push_back(7);
        p++;
        pointer = (*p);
        p++;
        std::string str1;
        std::string str2;
        for (int i = 0; (*p)[i] != ':'; i++)
        {
            if (i >= (*p).size())
            {
                throw _ERROR_();
                return std::list<int>();
            }
            else
            {
                str1.push_back((*p)[i]);
            }
        }
        for (int i = 3;; i++)
        {
            if (i >= (*p).size())
            {
                throw _ERROR_();
                return std::list<int>();
            }
            else
            {
                str2.push_back((*p)[i]);
            }
        }
        if (str1 == "tag")
        {
            tag = str2;
        }
        else
        {
            throw _ERROR_();
            return std::list<int>();
        }
    }
    else
    {
        throw _ERROR_();
        return std::list<int>();
    }
    return out;
}