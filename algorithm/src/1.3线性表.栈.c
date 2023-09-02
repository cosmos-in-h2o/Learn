#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>

typedef int E;

typedef struct Stack {
    E *bottom;
    int capacity;
    E *top;
} Stack;

bool initStack(Stack *stack, int capacity) {
    stack->bottom = malloc(sizeof(E) * capacity);
    if (stack == NULL)
        return false;
    stack->capacity = capacity;
    stack->top = stack->bottom;
    return true;
}

bool resizeStack(Stack *stack) {
    if ((long long)(stack->top) ==
        (long long)(stack->bottom) + (stack->capacity - 1) * sizeof(E)) {
        stack->bottom = realloc(stack->bottom, stack->capacity * sizeof(E) * 2);
        if (stack->bottom == NULL) {
            return false;
        }
        stack->capacity *= 2;
    }
    return true;
}

bool pushStack(Stack *stack, E element) {
    if (!resizeStack(stack)) {
        return false;
    }
    *stack->top = element;
    stack->top++;
    return true;
}

bool popStack(Stack *stack) {
    if (stack->top == stack->bottom)
        return false;
    stack->top--;
    return true;
}

void destoryStack(Stack *stack) { free(stack->bottom); }

int main() {
    Stack stack;
    return 0;
}
