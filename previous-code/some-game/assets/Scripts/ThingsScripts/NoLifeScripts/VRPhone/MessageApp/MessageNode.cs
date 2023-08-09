/*
 * 一个对话节点
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Node", menuName = "Dream/MessageApp/New Node")]
public class MessageNode : ScriptableObject
{
    //说出这句话的角色
    public enum Role
    {
        Bright,
        Other
    }

    [System.Serializable]
    public struct NodeBit
    {
        public Role role;
        public string words;
    }
    public List<NodeBit> nodeBits = new List<NodeBit>();
}