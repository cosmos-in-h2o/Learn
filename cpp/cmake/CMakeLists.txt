# cmake最低版本要求
cmake_minimum_required(VERSION 3.15)

# 项目名
project(demo)
message(${PROJECT_NAME})

#设置标准
set(CMAKE_CXX_STANDARD 11)
set(CMAKE_CXX_STANDARD_REQUIRED True)

#替换变量
configure_file(src/conf.in conf.h)

# 可执行文件，以及源文件列表
add_executable(${PROJECT_NAME} src/main.cpp)

#库生成
add_library(addshare SHARED src/lib.c)#动态库
add_library(addstatic STATIC src/lib.c)#静态库

#头文件包含目录
include_directories(${PROJECT_BINARY_DIR})