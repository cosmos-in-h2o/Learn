# 基础命令
## 文件和目录
### pwd
显示当前目录
### ls
```bash
$ ls [options] 
```
列出目录内容
#### -F
在目录后加上'/',在可执行文件后面加上'*',在链接文件后面加上@(默认是目录蓝色,普通文件黑色,可执行文件草绿色,链接文件淡蓝色)
#### -a
显示隐藏文件
#### -l
查看文件各种属性
### cat 
```bash
$ cat [file]
```
显示file文件内容
#### -n
显示行号
### grep
```bash
$ grep [word] [file...]
```
在file文件中查找包含word的行(带空格需要使用单引号)
### find 
```bash
$ find [options] [path...] [expression]
```
查找文件
```bash
$ find /usr/bin/ -name zip -print
```
以上命令能够在/usr/bin目录下查找名字为zip的文件并打印出来
```bash
$ find /usr/bin/ -name zip -type d -print
```
-type d的作用是指定查找文件的类型为目录
|参数|含义|
|:----:|:----:|
|b|块设备文件|
|c|字符串设备文件|
|d|目录文件|
|f|普通文件|
|p|命名管道|
|l|符号链接|
### locate
```bash
$ locate \[expression]
```
用来大批量搜索
```bash
$ locate *.doc
```
可以搜索所有后缀为doc的文件
### whereis
```bash 
$ whereis [file]
```
用来查找程序所在文件的命令
```bash
$ whereis find
```
可以查找find命令所在位置
### touch
创建文件,更新文件创建时间
### mv
移动或重命名文件
> 当移动到的文件夹内有重名的文件则会直接覆盖而不提示
#### -i  
增加是否要覆盖的提示
#### -b 
如果有重名就把目标文件夹里的文件后加一个'~'
### cp
复制一个文件或目录到一个目录下
> 与mv一样不会提示会直接覆盖
#### -i&&-b
同mv
#### -r
复制目录到一个文件夹下
### rm
删除文件或目录
#### -i 
增加提示
#### -f
对于只读文件不加-i也会提示,加上此选项会自动回答y
#### -r
删除目录
## 其他
### who
查看有哪些人在登陆
### whoami
自己是以什么身份登陆的
### uname
```bash
$ uname [options]
```
显示当前系统版本信息
#### -a
显示当前版本所有有效信息
#### -r
只显示内核版本信息
### man
```bash
$ man [commands]
```
寻求帮助
```bash
$ man find
```
find命令的文档
### whatis
和man类似,但显示的信息会更加精简
