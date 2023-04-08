# CMake学习笔记
## 构建最简单的一个helloworld程序
### cmake代码
``` cmake
#CMakeLists.txt

#cmake最低版本要求
cmake_minimum_required(VERSION 3.15)
# 项目名
project(cmake)
# 可执行文件，以及源文件列表
add_executable(cmake main.cpp)
```
### 终端输入
```bash
mkdir build
cd build
cmake ..
make
./cmake #项目名称
```