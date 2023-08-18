#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>
typedef int E;
typedef struct List {
    E *array;
    int size;
    int capacity;

} List;

bool resizeList(List *list) {
    if (list->size == list->capacity) {
        list->array = realloc(list->array, list->capacity * 2 * sizeof(E));
        if (list->array == NULL) {
            return false;
        }
        list->capacity = list->capacity * 2;
    }
    return true;
}

bool initList(List *list, int capacity) {
    list->array = malloc(sizeof(E) * capacity);
    if (list->array == NULL)
        return false;
    list->capacity = capacity;
    list->size = 0;
    return true;
}

bool insertList(List *list, E element, int index) {
    if (index < 0 || index >= list->size)
        return false;
    if (!resizeList(list))
        return false;

    list->size++;
    for (int i = list->size; i > index; --i) {
        list->array[i] = list->array[i - 1];
    }
    list->array[index] = element;
    return true;
}

void printList(List *list) {
    for (int i = 0; i < list->size; i++) {
        printf("%d\n", list->array[i]);
    }
    printf("\n");
}

bool popList(List *list, int index) {
    if (index < 0 || index >= list->size)
        return false;
    list->size--;
    for (int i = index; i < list->size; ++i) {
        list->array[i] = list->array[i + 1];
    }
    return true;
}

void destoryList(List *list) {
    if (list->array != NULL)
        free(list->array);
    list->array = NULL;
}

int main() {
    List list;
    if (!initList(&list, 16)) {
        printf("error\n");
        return -1;
    }
    insertList(&list, 100, 0);
    printList(&list);

    insertList(&list, 200, 0);
    printList(&list);

    insertList(&list, 300, 1);
    printList(&list);

    insertList(&list, 400, 2);
    printList(&list);

    destoryList(&list);
    return 0;
}
