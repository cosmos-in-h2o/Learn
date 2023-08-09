#include "entt.hpp"
#include <iostream>
struct com{
    int a,b;
};

int main(){
    entt::registry registry;
    entt::entity entity=registry.create(); 
    entt::entity entity2=registry.create();
    registry.emplace<com>(entity);
    registry.emplace<com>(entity2);
	// 如果实体仍然有效，则返回 true，否则返回 false
	bool b = registry.valid(entity);
// 获取给定实体的实际版本
	auto curr = registry.current(entity);
	auto a=2;
}
