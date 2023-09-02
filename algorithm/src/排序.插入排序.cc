#include <iostream>
#include <vector>

void func(std::vector<int> &arr) {
    int temp;
    for (int i = 1; i < arr.size(); i++) {
        temp = arr[i];
        for (int j = i; j > 0; --j) {
            if (temp < arr[j - 1]) {
                arr[j] = arr[j - 1];
                arr[j - 1] = temp;
            }
        }
    }
}

int main() {
    std::vector<int> arr{2, 3, 1, 6, 9, 7, 5, 4, 8, 0};
    func(arr);
    for (int i : arr) {
        std::cout << i << " ";
    }
    std::cout << std::endl;
}
