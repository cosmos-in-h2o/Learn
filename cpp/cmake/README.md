# CMake学习笔记
## 0.一些说明
>一些注意事项，可以先跳过
### 0-0.开始
以下操作实现了构建一个最简单的hello world程序
#### cmake代码
``` cmake
#CMakeLists.txt

#cmake最低版本要求
cmake_minimum_required(VERSION 3.15)
# 项目名
project(demo CXX)
# 可执行文件，以及源文件列表
add_executable(demo main.cpp)
```
#### 终端输入
```bash
mkdir build
cd build
cmake ..
make
./demo #项目名称
```

### 0-1.命令说明
cmake的命令不分大小写比如
```cmake
PROJECT(demo)
```
和
```cmake
project(demo)
```
是等价的
### 0-2.变量说明
变量使用
```cmake
${VAR}
```
的方式取出
>变量要分大小写
### 0-3.参数说明
参数名要用空格或者分号分开，如：
```cmake
add_executable(demo main.cpp main.cc main.cxx main.ixx)
#也可以
add_executable(demo;main.cpp;main.cc;main.cxx;main.ixx)
```
参数名中有空格的画用引号括起来，如：
```cmake
add_executable(cmake "my src.cpp")
```
> c语言是C,c++是CXX\
> 参数名要分大小写

## 1.命令

### 1-1.cmake版本命令
```cmake
cmake_minimum_required(VERSION 3.15)
```
0-0中的第一条命令，指定了cmake最低版本
### 1-2.项目
```cmake
project(demo)
```
0-0中的第二个命令，可以在后面指定语言，比如要指定c++可以写成
```cmake
project(demo CXX)
```
还可以设置项目版本，如
```cmake
project(demo VERSION 1.0)
```
既指定语言又设置版本可以写成
```cmake
project(demo VERSION 1.0 LANGUAGE CXX)
```
### 1-3.打印构建信息
```cmake
message()
```
可以通过这条命令打印上面设置的项目名
```cmake
message(${PROJECT_NAME})
```
不同模式
```cmake
message("hello")
# 输出：hello
message(STATUS "hello")
# 输出：-- hello
message(SEND_ERROR "hello")
# 产生错误，跳过构建过程
message(FATAL "hello")
# 产生错误，中止运行
```
### 1-4.目标文件的构建
#### 构建一个可执行文件
```cmake
add_executable(demo src/main.cpp)
```
#### 构建静态或动态库文件
```cmake
add_library(lib SHARED src/lib.cpp) #生成动态库文件
add_library(lib STATIC src/lib.cpp) #生成静态库文件
```
### 1-5.set
#### 介绍
写法
```cmake
set(变量名 值)
```
例如

```cmake
set(num 1)
message(${num})
# 输出：1
```
#### 使用set()设置生成目录
```cmake
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BIANRY_DIR}/bin)
```
### 1-6.设置语言标准
```cmake
set(CMAKE_CXX_STANDARD 23)#设置c++标准为c++23
```
### 1-7.option
定义一个开关
```cmake
option(IS_ "is" ON)#这里设置了默认为ON,不设置默认为OFF
```
### 1-8.configure_file
```cmake
configure_file(src/conf.in conf.h)
```
将conf.in中的配置进行替换
### 1-9.逻辑
```cmake
if()
#语句
elseif()
#语句
else()
#语句
endif()
```
### 1-10.头文件包含目录
#### include_directories
```cmake
添加所有目标的头文件包含目录
include_directories(目录1 目录2 ...)
```
#### target_include_directories
```cmake
添加目标的头文件包含目录
target_include_directories(<target> PUBLIC 目录1)
```
>一般用这个
## 2.变量
| 变量名                        | 解释 |
| :-----:                       | :----: |
| C                             | c语言 |
| CXX                           | c++ |
| PROJECT_NAME                  | 项目名 |
| PROJECT_SOURCE_DIR            | 项目目录 |
| <PROJECT_NAME>_SOURCE_DIR     | 项目目录 |
| PROJECT_BIANRY_DIR            | 二进制文件目录 |
| <PROJECT_NAME>_BIANRY_DIR     | 二进制文件目录 |
| PROJECT_VERSION               | 项目版本号 |
| <PROJECT_NAME>_VERSION        | 项目版本号 |
| PROJECT_VERSION_MAJOR         | 主版本号 |
| <PROJECT_NAME>_VERSION_MAJOR  | 主版本号 |
| PROJECT_VERSION_MINOR         | 次版本号 |
| <PROJECT_NAME>_VERSION_MINOR  | 次版本号 |