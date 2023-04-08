{
    files = {
        "test.ixx"
    },
    modules_cachedir = "build/.gens/test/linux/x86_64/release/rules/modules/cache",
    values = {
        "/usr/bin/gcc",
        {
            "-x",
            "c++",
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
    depfiles_gcc = "build/.objs/test/linux/x86_64/release/test.ixx.o  /home/dream/Learn/cpp/untitled/build/.gens/test/linux/x86_64/release/rules/modules/cache/574a3743/test.gcm:  test.ixx\
test.c++m:  /home/dream/Learn/cpp/untitled/build/.gens/test/linux/x86_64/release/rules/modules/cache/574a3743/test.gcm\
.PHONY: test.c++m\
/home/dream/Learn/cpp/untitled/build/.gens/test/linux/x86_64/release/rules/modules/cache/574a3743/test.gcm:|  build/.objs/test/linux/x86_64/release/test.ixx.o\
"
}