#include <stdio.h>
int searchOld(int *nums, int numSize, int target) {
    for (int i = 0; i < numSize; ++i) {
        if (nums[i] == target)
            return i;
    }
    return -1;
}
int searchNew(int *nums, int numSize, int target) {
    for (int i = 0; i < numSize; ++i) {
        if (nums[i] == target)
            return i;
        if (nums[i] > target)
            break;
    }
    return -1;
}
int searchBinary(int *nums, int target, int left, int right) {
    if (left > right) {
        return -1;
    }
    int mid = (left + right) / 2;
    if (nums[mid] == target) {
        return mid;
    } else if (nums[mid] > target) {
        return searchBinary(nums, target, left, mid - 1);
    } else {
        return searchBinary(nums, target, mid + 1, right);
    }
}

int main() {
    int arr[] = {1, 4, 5, 6, 7, 9, 10, 13, 15};
    printf("%d", arr[searchOld(arr, 9, 15)]);
    printf("%d", arr[searchNew(arr, 9, 15)]);
    printf("%d", arr[searchBinary(arr, 9, 0, 8)]);
}
