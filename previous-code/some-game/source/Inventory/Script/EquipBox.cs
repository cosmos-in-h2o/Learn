/*
*代码作用储存装备栏的数据
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New EquipBox", menuName= "Dream/Inventory/New EquipBox")]
public class EquipBox : ScriptableObject
{
	public ItemOfEquip Weapon;
	public ItemOfEquip Gun;
	public ItemOfEquip Armor;
	public ItemOfDream Dream;
}