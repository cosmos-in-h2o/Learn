import jieba
import json as json
import jieba.analyse as analyse

def train(path:str,precision:int=7)->None:
    punctuation:list=['。','，','、','＇','：','∶','；','?','‘','’','“','”','〝','〞','ˆ','ˇ','﹕','︰','﹔','﹖','﹑','·','¨','…','.','¸',';','！','´','？','！','～','—','ˉ','｜','‖','＂','〃','｀','@','﹫','¡','¿','﹏','﹋','﹌','︴','々','﹟','#','﹩','$','﹠','&','﹪','%','*','﹡','﹢','﹦','﹤','‐','￣','¯','―','﹨','ˆ','˜','﹍','﹎','+','=','<','­­＿','_','-','\\','ˇ','~','﹉','﹊','（','）','〈','〉','‹','›','﹛','﹜','『','』','〖','〗','［','］','《','》','〔','〕','{','}','「','」','【','】','︵','︷','︿','︹','︽','_','﹁','﹃','︻','︶','︸','﹀','︺','︾','ˉ','﹂','﹄','︼','\'','"',',']
    jieba.load_userdict("./dict/SG_dict.txt")
    list_:list=[]
    data={"user":[],"anwser":""}
    with open(path+"data.txt",'r',encoding="utf-8") as f:
        list_=f.readlines()
    #去除末尾换行
    for i in range(len(list_)):
        list_[i]=list_[i][:-1]
    #关键字提取
    for i in range(len(list_)):
        ___PROCESS___:int=(float(i+1)/float(len(list_)))*100
        ___INDEX___:int=int(___PROCESS___/5)
        ___BAR___:str=___INDEX___*'#'
        print("\r进度:%d%%%s"%(___PROCESS___,___BAR___),end='')
        if i+3>=len(list_) :
            break
        if list_[i]=='R':
            i+=1
            data["anwser"]=list_[i]
            i+=2
            tags=analyse.extract_tags(list_[i], topK=precision, withWeight=True, allowPOS=())
            word_list:list=[]
            for tag in tags:
                if tag[0] not in punctuation:
                    word_list.append(tag[0])
                    word_list.append(tag[1])
            data["user"]=word_list
            #print(data)
            with open(path+"keydata.json",'a',encoding="utf-8") as f:
                json.dump(data,f,ensure_ascii=False)
                f.write(',\n')
    _s_:str
    with open(path+"keydata.json",'r',encoding="utf-8") as f:
        _s_=f.read()
    _s_=_s_[:-2]
    with open(path+"keydata.json",'w',encoding="utf-8") as f:
        f.write('['+_s_+']')
    print("\r进度:100%####################")
    list_:list=[]
    data={"user":[],"anwser":""}
    with open(path+"data.txt",'r',encoding="utf-8") as f:
        list_=f.readlines()
    #去除末尾换行
    for i in range(len(list_)):
        list_[i]=list_[i][:-1]
    #所有数据进行分词处理
    for i in range(len(list_)):
        ___PROCESS___:int=(float(i+1)/float(len(list_)))*100
        ___INDEX___:int=int(___PROCESS___/5)
        ___BAR___:str=___INDEX___*'#'
        print("\r进度:%d%%%s"%(___PROCESS___,___BAR___),end='')
        if i+3>=len(list_) :
            break
        if list_[i]=='R':
            i+=1
            data["anwser"]=list_[i]
            i+=2
            word_list:list = [str(w) for w in jieba.cut(list_[i], cut_all = True)]
            for i in range(len(word_list)):
                if word_list[i] in punctuation:
                    word_list[i]=''
            word_list = [i for i in word_list if i != '']
            data["user"]=word_list
            #print(data)
            with open(path+"alldata.json",'a',encoding="utf-8") as f:
                json.dump(data,f,ensure_ascii=False)
                f.write(',\n')
    _s_:str
    with open(path+"alldata.json",'r',encoding="utf-8") as f:
        _s_=f.read()
    _s_=_s_[:-2]
    with open(path+"alldata.json",'w',encoding="utf-8") as f:
        f.write('['+_s_+']')
    print("\r进度:100%####################")
    return