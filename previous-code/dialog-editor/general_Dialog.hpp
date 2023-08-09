#ifndef GENERAL_DIALOG_HPP
#define GENERAL_DIALOG_HPP
#include <functional>
#include <list>
#include <string>
/* 块类型 */
typedef enum {
	DIALOG,
	MENU,
	MENU_WITH_TIME
} BlockType;
/* 一个对话片段通常指一句话,menu的情况speaker_name无效 */
typedef struct {
	std::function<void(void)> cilp_call_back;//开始时调用
	std::string speaker_name;
	std::string speaker_words;
	Block *next_block;//走到此片段时就通到下一个块
} Clips;
/* 块类 */
class Block {
public:
	/* 走此块前置条件 */
	std::function<bool(void)> block_is;
	std::string block_name;
	BlockType block_type;
	std::list<Clips> block_clips;
	std::function<void(void)> block_call_back;//当此块结束开始走下一个快时调用
	Block() {}
	Block(std::function<bool(void)> block_is, std::string block_name, BlockType block_type, std::function<void(void)> block_call_back) :
			block_is(block_is), block_name(block_name), block_type(block_type), block_call_back(block_call_back) {}
};
#endif