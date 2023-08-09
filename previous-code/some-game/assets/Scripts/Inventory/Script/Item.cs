/*
* 代码作用：普通item
 */

using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Dream/Inventory/New Item")]
public class Item:ScriptableObject
{
	public int ID;//ID，全局唯一	
	public BagSystem.ItemType item_type;//类型
	public string item_name;//名字
	public int item_number;//所持有的数量
	public Sprite item_sprite;//物品的照片
	[TextArea]//使text可以富文本进行多行书写
	public string item_info;//物品的介绍描述
	public Action action;
}