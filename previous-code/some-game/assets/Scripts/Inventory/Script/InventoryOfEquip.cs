/*
*代码作用：不可堆叠，数量不限inventory
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InventoryOfEquip", menuName = "Dream/Inventory/New InventoryOfEquip")]
public class InventoryOfEquip : ScriptableObject
{
    public List<ItemOfEquip> item_list = new List<ItemOfEquip>();

}
