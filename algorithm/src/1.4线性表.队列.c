#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>
typedef int E;
typedef struct Queue {
    E *array;
    int capacity;
    int front, rear;
} Queue;

bool initQueue(Queue *queue, int capacity) {
    queue->array = malloc(sizeof(E) * capacity);
    if (queue->array == NULL)
        return false;
    queue->capacity = capacity;
    queue->front = 0;
    queue->rear = 0;
    return true;
}

bool offerQueue(Queue *queue, E element) {
    // 计算位置
    int pos = (queue->rear + 1) % queue->capacity;
    if (pos == queue->front) {
        return false;
    }
    queue->array[pos] = element;
    queue->rear = pos;
    return true;
}

bool isEmpty(Queue *queue) { return queue->rear == queue->front; }

E pollQueue(Queue *queue) {
    if (isEmpty(queue))
        return NULL;
    queue->front = (queue->front + 1) % queue->capacity;
    return queue->array[queue->front];
}

void destoryQueue(Queue *queue) { free(queue->array); }

void printQueue(Queue *queue) {
    for (int i = queue->front + 1; i != queue->rear;
         i = (i + 1) % queue->capacity) {
        printf("%d ", queue->array[i]);
    }
    printf("\n");
}

int main() {
    Queue queue;
    initQueue(&queue, 16);
    offerQueue(&queue, 100);
    offerQueue(&queue, 200);
    offerQueue(&queue, 300);
    offerQueue(&queue, 400);
    offerQueue(&queue, 500);
    offerQueue(&queue, 600);
    offerQueue(&queue, 700);
    printQueue(&queue);
    destoryQueue(&queue);
    return 0;
}
