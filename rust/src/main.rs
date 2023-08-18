#[derive(Debug)]
struct Rectangle {
    width: u32,
    height: u32,
}
fn main() {
    let rec=Rectangle{width:600,height:800};
    let str=String::from("abcde");
    let re=&str[0..3];
    println!("The result is {:?},{:?}",rec,re);
}

extern "C" fn fun(p:i32){}
extern "C" fn fun(p:String){}
