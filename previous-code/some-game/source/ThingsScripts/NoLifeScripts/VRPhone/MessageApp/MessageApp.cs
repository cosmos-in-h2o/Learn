/*
 * 管理MessageApp的
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageApp : MonoBehaviour
{
    //单例模式
    private static MessageApp instance;
    public static MessageApp Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(MessageApp)) as MessageApp;
            }
            return instance;
        }
    }

    /*
     * 设计思路
     * 1.对话由不同对话节点片段构成
     * 2.list将所有片段结合起来
     * 3.通过不同名称调用不同对话
     */
    [System.Serializable]
    public struct MessageList
    {
        public string message_name;
        public MessageNode message_node;
    }

    //创建对话列表
    public List<MessageList> message_list = new List<MessageList>();

    /// <summary>
    /// 根据键值获取类型值
    /// </summary>
    public int getValue(string name)
    {
        for(int i=0;;i++)
        {
            if(name==MessageApp.Instance.message_list[i].message_name)
            {
                return i;
            }
        }
    }

    /// <summary>
    /// 开始一段对话
    /// </summary>
    public void StartMessage(string name)
    {
        MessageNode node=MessageApp.Instance.message_list[getValue(name)].message_node;
        int message_index = 0;
        int message_index_max = node.nodeBits.Count;//获取列表大小
        writeMessage(node.nodeBits[message_index].words);
    }

    /// <summary>
    /// 在消息框里写出消息
    /// </summary>
    public void writeMessage(string text)
    {

    }
}