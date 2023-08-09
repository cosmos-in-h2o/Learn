/*
 * 消息窗口接口
 */
public interface MessageWindowInterFace 
{
    /// <summary>
    /// 窗口类型
    /// </summary>
    public enum WindowsType
    {

    };

    /// <summary>
    /// 出现方式
    /// </summary>
    public enum AppearFunc
    {

    }

    /// <summary>
    /// 创建一个消息窗口
    /// </summary>
    public bool creatMessageWindow(WindowsType windows_type,AppearFunc appear_func, string text);
}
