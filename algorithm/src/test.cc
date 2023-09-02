#include <stack>
#include <string>
using namespace std;
struct ListNode {
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
};
class Solution {
  public:
    bool isValid(string s) {
        stack<char> str_stack;
        for (char ch : s) {
            if (str_stack.top() == '(' && ch == ')' ||
                str_stack.top() == '[' && ch == ']' ||
                str_stack.top() == '{' && ch == '}') {
                str_stack.pop();
            } else {
                str_stack.push(ch);
            }
        }
		str_stack.size();
        return str_stack.empty();
    }
};
