#include <iostream>
#include <vector>

void func(std::vector<int> &arr) {
    int temp;
    for (int i = 0; i < arr.size(); i++) {
        for (int j = 1; j < arr.size(); j++) {
            if (arr[j - 1] > arr[j]) {
                temp = arr[j - 1];
                arr[j - 1] = arr[j];
                arr[j] = temp;
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
	std::cout<<std::endl;
}
