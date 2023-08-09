/*
* 代码作用：普通inventory
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Dream/Inventory/New Inventory")]
public class Inventory:ScriptableObject
{
	public List<Item> item_list =new List<Item>();
}
