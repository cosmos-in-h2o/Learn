import train
import run
import os
def main(argc:int,argv:list)->int:
    if argc<2:
        print("指令错误")
        return -1
    if argv[1]=="-t":
        if argc==3:
            train.train(argv[2])
        elif argc==4:
            train.train(argv[2],int(argv[3]))
        else:
            print("指令错误")
            return -1
    elif argv[1]=="-i":
        if argc==3:
            print("正在初始化")
            with open("path.txt",'w',encoding="utf-8") as f:
                f.write(argv[2])
            fp=open("temp.txt",'w',encoding="utf-8")
            fp.close()
            print("完成初始化，正在打开程序")
            os.startfile("bot.exe")
            print("已打开",end='')
        else:
            print("指令有误")
            return -1
    elif argv[1]=="-r":
        if argc==3:
            with open("path.txt",'r',encoding="utf-8") as path:
                run.run(path.read(),argv[2])
        else:
            print("哈？")
    elif argv[1]=="-o":
        if argc==2:
            print("正在打开程序")
            os.startfile("bot.exe")
            print("已打开",end='')
        else:
            print("指令错误")
            return -1
    elif argv[1]=="--help":
        print("amadeus -t <训练数据目录> #开始格式化数据，目录下的数据文件名为data.txt")
        print("amadeus -i <数据目录> #初始化bot程序，然后打开bot程序")
        print("amadeus -r <数据目录> 语句 #将数据目录里的数据作为语料查找语句对应的回答，事c++和python的交互层")
        print("amadeus -o #打开bot.exe")
    else:
        print("指令错误")
        return -1
    return 0