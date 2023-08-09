/*
保存的数据类型，不挂载任何组件
*/
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
    public string save_time;//保存的时间
    public string save_game_time;//游戏时长
    public Texture texture;//保存时的截图
    public SaveData() { }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="save_time">保存时间</param>
    /// <param name="save_game_time">游戏时间</param>
    /// <param name="texture">截图</param>
    public SaveData(string save_time,string save_game_time,Texture texture)
    {
        this.save_time = save_time;
        this.save_game_time = save_game_time;
        this.texture = texture;
    }
}