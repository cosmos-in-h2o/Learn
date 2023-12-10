# 文件目录管理
## 文件和目录权限
权限设置针对三种人:文件所有者,文件属组用户,其他人(不包含root用户,root用户拥有一切权力)
### 需要设置哪些权限
读取(r),写入(w),执行(x)
### 查看文件和目录的属性
```bash
$ ls -l /bin/login
-rwxr-xr-x 1 root root 43112 9月12日 03:26 /bin/login 
```
第一个'-'代表文件类型;\
后面的'rwx','r-x','r-x'分别代表属主对文件的权限,属组的,其他人的;\
后面的两个'root'分别代表文件的属主和属组
### 改变文件所有权
#### chown
```bash
chown [option...] ([owner])(:[group]) [file...]
```
将文件的属主改为owner属组改为group,例如:
```bash
sudo chown kurisu:root days
```
将文件的属主改为kurisu,属组改为root
##### -R
修改文件夹下所有文件以及子目录文件的属主与属组
#### chgrp
和chown相似,只能修改属组
#### chmod
构成:
```bash
chmod (u/g/o/a(所有人))(+/-)(r/w/x) file...
```
或者:
```bash
chomd ug=rw,o=r file
```
代表给属主和属组写读的权限给其他人读的权限
```bash
chomd o=u file
```
给其他人属主的权限\
更常用的方式:1代表x,2代表w,4代表r
```bash
chomd 711 file
```
代表rwx--x--x
### 文件类型
|符号|文件类型|
|----- | ----- |
|-|普通文件 |
|d|目录文件|
|l|符号链接|
|c|字符设备|
|b|块设备|
|s|套接字文件|
|p|命名管道文件|
### 建立链接
```bash
ln -s [target] [link_name]
```

