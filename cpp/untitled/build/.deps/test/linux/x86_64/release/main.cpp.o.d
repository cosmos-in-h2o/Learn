{
    files = {
        "main.cpp"
    },
    modules_cachedir = "build/.gens/test/linux/x86_64/release/rules/modules/cache",
    values = {
        "/usr/bin/gcc",
        {
            "-m64",
            "-fvisibility=hidden",
            "-fvisibility-inlines-hidden",
            "-O3",
            "-fmodules-ts",
            "-fmodule-mapper=build/test/mapper.txt",
            "-D_GLIBCXX_USE_CXX11_ABI=0",
            "-DNDEBUG"
        }
    },
    depfiles_gcc = "build/.objs/test/linux/x86_64/release/main.cpp.o: main.cpp\
build/.objs/test/linux/x86_64/release/main.cpp.o: test.c++m\
CXX_IMPORTS += test.c++m\
"
}