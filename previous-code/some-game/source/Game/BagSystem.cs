/*
* 背包系统
* 不挂载任何物体上
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSystem : MonoBehaviour
{
	//item的类型
    public enum ItemType
    {
        Weapon,
        Gun,
        Armor,
        Food,
        Dream,
        Books,
        Material,
        Blue_print,
        Collectibles,
        Another
    }
    public static int m_coin=0;//货币数量
}