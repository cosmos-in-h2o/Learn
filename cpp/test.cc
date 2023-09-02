#include <iostream>

template<class T>
struct unique_ptr {
	T *_ptr;
	unique_ptr(unique_ptr &&)  noexcept {}
	void reset(T* ptr){
		if(ptr!=this->_ptr) {
			delete this->_ptr;
			this->_ptr = ptr;
		}
	}
};

int main() {
}