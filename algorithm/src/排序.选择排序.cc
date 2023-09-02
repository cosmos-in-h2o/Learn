#include <iostream>
#include <vector>

void func(std::vector<int> &arr) {
    int temp = 0, add = 0, temp2;
    for (int i = 0; i < arr.size(); i++) {
        temp = arr[i];
        add = i;
        for (int j = i; j < arr.size(); j++) {
			if(arr[j]<temp){
				temp=arr[j];
				add=j;
			}
        }
        temp = arr[i];
        arr[i] = arr[add];
        arr[add] = temp;
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
