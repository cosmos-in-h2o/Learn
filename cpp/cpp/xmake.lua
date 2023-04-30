add_rules("mode.debug", "mode.release")

target("vdestructor")
    set_kind("binary")
    add_files("vdestructor/main.cpp")
target_end()

target("virtual_func")
    set_kind("binary")
    add_files("virtual_func/main.cpp")
target_end()