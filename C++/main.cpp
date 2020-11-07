#include <iostream>
#include <list>
#include <random>
#include <time.h>

using namespace std;

template<typename T>
int random_point(const list<T>& list_) {
    srand(time(0));
    return rand() % list_.size();
};

template<typename T>
auto list_at(list<T>& list_, const int& position) {
    // throw exception for invalid position
    auto iter = list_.cbegin();
    for(int i = 0; i < position; ++i)
        ++iter;
    return iter;
};

template<typename T>
void list_crossover(list<T>& list1, list<T>& list2) {
    int point1 = random_point(list1);
    int point2 = random_point(list2);
    cout << point1 << ' ' << point2 << endl;

    list<T> new_list1 = list<T>();
    list<T> new_list2 = list<T>();

    new_list1.insert(new_list1.begin(), list_at(list1, point1 + 1), list1.cend());
    new_list1.insert(new_list1.begin(), list2.cbegin(), list_at(list2, point2 + 1));
    new_list2.insert(new_list2.begin(), list_at(list2, point2 + 1), list2.cend());
    new_list2.insert(new_list2.begin(), list1.cbegin(), list_at(list1, point1 + 1));

    swap(list1, new_list1);
    swap(list2, new_list2);
};

template<typename T>
list<T> create_list() {
    srand(time(0));
    int size = rand() % 10 + 5;
    list<T> result = list<T>();
    for(int i = 0; i < size; ++i)
        result.push_back(rand());
    return result;
};

template<typename T>
ostream& operator<<(ostream& out, const list<T>& list_) {
    for(auto item : list_)
        out << item << ' ';
    return out;
};

int main() {
    list<int> list1 = create_list<int>();
    _sleep(1000);
    list<int> list2 = create_list<int>();
    cout << list1 << endl << list2 << endl;
    list_crossover(list1, list2);
    cout << list1 << endl << list2 << endl;

    return 0;
}
