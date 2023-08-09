import jieba
import logging
import random

def run(path:str,input:str)->None:
    jieba.setLogLevel(logging.CRITICAL)
    jieba.load_userdict("./dict/SG_dict.txt")
    #先进行关键词分词
    tags=jieba.analyse.extract_tags(input, topK=20, withWeight=False, allowPOS=())
    _s_:str
    with open(path+"keydata.json",'r',encoding="utf-8") as f:
        _s_=f.read()
    data:list=eval(_s_)
    _dict:dict={}
    weigh:float=0.0
    for i in range(len(data)):
        if i+1>=len(data):
            break
        weigh=0.0
        for tag in range(len(tags)):
            for index in range(len(data[i]["user"])):
                if tags[tag] == data[i]["user"][index]:
                    weigh+=float(data[i]["user"][index+1])
        weigh=func2(weigh)
        if weigh!=0.0:
            _dict.update({i:weigh})
    list__:list=[]
    for key,value in _dict.items():
        if int(value)==int(max(_dict.values())):
            list__.append(key)
    is_turn=list__.__len__()
    
    '''
    is_turn=0
    #去掉多行注释后开启全模式，可能更精确？我也不知道
    #如果不开启全模式当匹配不到关键词就自动开启    
    '''
    
    if(is_turn>0):
        __str__:str=data[random.choice(list__)]["anwser"]
        print(__str__)
        with open("temp.txt",'a',encoding="utf-8") as f:
            f.write("U\n"+input+'\n')
            f.write("R\n"+__str__+'\n')
    else:
        func(path,input)
    return

#前边写的太乱了把这块独立出来
def func(path:str,input:str)->None:
    temtags=jieba.cut(input,cut_all=True)
    tags:list=[]
    for i in temtags:
        tags.append(i)
    
    _s_:str
    with open(path+"alldata.json",'r',encoding="utf-8") as f:
        _s_=f.read()
    data:list=eval(_s_)
    weigh:int=0
    _dict:dict={}
    for i in range(len(data)):
        weigh=0
        for tagindex in range(len(tags)):
            for index in range(len(data[i]["user"])):
                if tags[tagindex]==data[i]["user"][index]:
                    weigh+=1
        if weigh!=0:
            _dict.update({i:weigh})
        list__:list=[]
    for key,value in _dict.items():
        if value==max(_dict.values()):
            list__.append(key)
    if list__.__len__()>0:
        __str__:str=data[random.choice(list__)]["anwser"]
        print(__str__)
        with open("temp.txt",'a',encoding="utf-8") as f:
            f.write("U\n"+input+'\n')
            f.write("R\n"+__str__+'\n')
    else:
        print("哈？")
    return

#四舍五入算法
def func2(_ifloat:float)->int:
    _int=int(_ifloat)
    _float=_ifloat-_int
    if(_float>=0.5):
        return _int+1
    else:
        return _int