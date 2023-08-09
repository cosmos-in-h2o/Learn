#ifndef VEC_H
#define VEC_H
#include <stdio.h>
//二维向量
class Vector2
{
public:
	int x;
	int y;
	//设置向量为零向量
	void zero() 
	{
		this->x = 0;
		this->y = 0;
	}
	//设置向量
	void set(int n) 
	{
		this->x = n;
		this->y = n;
	}
	//设置向量
	void set(int x, int y) 
	{
		this->x = x;
		this->y = y;
	}
	//向量点乘
	void dot(Vector2& v) 
	{
		this->x *= v.x;
		this->y *= v.y;
	}
	//向量乘法(乘以一个标量)
	void multi(int n) 
	{
		this->x *= n;
		this->y *= n;
	}
	//向量乘法(一个行向量乘以一个列向量)返回一个标量
	int multi(Vector2& v)
	{
		return this->x * v.x + this->y * v.y;
	}
	//向量乘法(一个列向量乘以一个行向量)返回一个2x2矩阵
	Vector2* multi(Vector2& v ,bool)
	{
		Vector2 mat[2];
		mat[0].x = this->x * v.x;
		mat[0].y = this->y * v.x;
		mat[1].x = this->x * v.y;
		mat[1].y = this->y * v.y;
		return mat;
	}
	//向量加法
	void add(Vector2& v) 
	{
		this->x += v.x;
		this->y += v.y;
	}
	//向量减法
	void subtract(Vector2& v) 
	{
		this->x -= v.x;
		this->y -= v.y;
	}
	//加法运算符
	void operator+=(Vector2 &v) 
	{
		this->add(v);
	}
	//减法运算符
	void operator-=(Vector2 &v) {
		this->subtract(v);
	}
	//乘法运算符
	void operator*=(Vector2 &v) {
		//默认点乘
		this->dot(v);
	}
	void operator*=(int n) {
		this->multi(n);
	}

	void print() {
		printf("x:%d\ny:%d\n", this->x, this->y);
	}

	//加法运算符
	Vector2 operator+(Vector2 &v) {
		return Vector2(this->x + v.x, this->y + v.y);
	}
	//减法运算符
	Vector2 operator-(Vector2 &v) {
		return Vector2(this->x - v.x, this->y - v.y);
	}
	//乘法运算符
	Vector2 operator*(Vector2 &v) {
		//默认点乘
		return Vector2(this->x * v.x, this->y * v.y);
	}
	Vector2 operator*(int n) {
		return Vector2(this->x * n, this->y * n);
	}
	Vector2() {
		this->x = 0;
		this->y = 0;
	}
	Vector2(int x, int y) : x(x), y(y) 
	{
	}

};
#define VEC2_ZERO Vector2(0,0)
#define VEC2_UP Vector2(0,-1)
#define VEC2_DOWN Vector2(0,1)
#define VEC2_RIGHT Vector2(1,0)
#define VEC2_LEFT Vector2(-1,0)

#endif
