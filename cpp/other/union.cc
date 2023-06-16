struct vector2 {
  int x, y;
};

struct vector4 {
  union {
    struct {
      int x, y, z, w;
    };
    struct {
      vector2 a, b;
    };
  };
};
int main(int argc, char *argv[]) { return 0; }
