/*
*代码作用：不可堆叠，不可重复物品
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemOfDream", menuName = "Dream/Inventory/New ItemOfDream")]
public class ItemOfDream : ScriptableObject
{
	public int ID;//ID，全局唯一
	public BagSystem.ItemType item_type;//类型
	public string item_name;//名字
	public Sprite item_sprite;//物品的照片
	public bool item_is_have;//是否拥有该物品
	[TextArea]//使text可以富文本进行多行书写
	public string item_info;//物品的介绍描述
}
