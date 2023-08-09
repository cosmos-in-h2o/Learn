/*
*代码作用：不可堆叠，不可重复inventory
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InventoryOfDream", menuName = "Dream/Inventory/New InventoryOfDream")]
public class InventoryOfDream : ScriptableObject
{

	public List<ItemOfDream> item_list = new List<ItemOfDream>();

}