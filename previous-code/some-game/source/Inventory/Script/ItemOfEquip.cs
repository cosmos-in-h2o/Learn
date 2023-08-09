/*
*代码作用：不可堆叠，数量不限的物品
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemOfEquip", menuName = "Dream/Inventory/New ItemOfEquip")]
public class ItemOfEquip : ScriptableObject
{
	public int ID;//ID，全局唯一
	public BagSystem.ItemType item_type;//类型
	public string item_name;//名字
	public Sprite item_sprite;//物品的照片
	public int item_number;//该物品的数量
	[TextArea]//使text可以富文本进行多行书写
	public string item_info;//物品的介绍描述
}
