/*
*代码作用：当usebutton被点击
*挂载：usebutton上
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButton : MonoBehaviour,ButtonInterface
{
    public void isClick()
	{
		
		Transform transform;
        BagSystem.ItemType item_type=BagSystem.ItemType.Weapon;

        //对当前类型进行赋值
        if (BagToggle.now_toggle == BagToggle.NowToggle.equip
            || BagToggle.now_toggle == BagToggle.NowToggle.books)
        {
            item_type = InputManager.Instance.now_box.parent.GetComponent<SlotOfEquip>().slot_item.item_type;
        }

        if (BagToggle.now_toggle == BagToggle.NowToggle.food
            || BagToggle.now_toggle == BagToggle.NowToggle.materia
            || BagToggle.now_toggle == BagToggle.NowToggle.another)
        {
            item_type = InputManager.Instance.now_box.parent.GetComponent<Slot>().slot_item.item_type;
        }

        if (BagToggle.now_toggle == BagToggle.NowToggle.dream
            || BagToggle.now_toggle == BagToggle.NowToggle.blue_print_and_collectibles)
        {
            item_type = InputManager.Instance.now_box.parent.GetComponent<SlotOfDream>().slot_item.item_type;
        }

        //当是装备类型
        if (item_type == BagSystem.ItemType.Gun || item_type == BagSystem.ItemType.Armor || item_type == BagSystem.ItemType.Weapon)
		{
			/*
			 * 先储存now box的父物体
			 * 然后穿戴装备，此时now box的父物体变了
			 * 然后再将now box的父物体设置成之前储存的
			 */
			transform = InputManager.Instance.now_box.transform.parent;
			InventoryFunction.Instance.wearEquip(InputManager.Instance.now_box.parent.gameObject.GetComponent<SlotOfEquip>().slot_item);
			InputManager.Instance.now_box.SetParent(transform);
			InventoryFunction.Instance.subtractEquipItem(InputManager.Instance.now_box.parent.gameObject.GetComponent<SlotOfEquip>().slot_item,
                () =>
                {

                });
		}

		//当是dream类型
		if (item_type == BagSystem.ItemType.Dream)
		{
			/*
			 * 先储存now box的父物体
			 * 然后穿戴装备，此时now box的父物体变了
			 * 然后再将now box的父物体设置成之前储存的
			 */
			transform = InputManager.Instance.now_box.transform.parent;
			InventoryFunction.Instance.wearEquip(InputManager.Instance.now_box.parent.gameObject.GetComponent<SlotOfDream>().slot_item);
			InputManager.Instance.now_box.SetParent(transform);
			InventoryFunction.Instance.subtractDreamItem(InputManager.Instance.now_box.parent.gameObject.GetComponent<SlotOfDream>().slot_item,
                () =>
                {

                });
		}

		//当是食物类型
		else if(item_type == BagSystem.ItemType.Food)
		{
            //每次使用减少一个
            InventoryFunction.Instance.subtractItem(InputManager.Instance.now_box.parent.gameObject.GetComponent<Slot>().slot_item, 
				() =>
				{

				});
        }

		//当是书类型
		else if(item_type == BagSystem.ItemType.Books)
		{
            InventoryFunction.Instance.subtractEquipItem(InputManager.Instance.now_box.parent.gameObject.GetComponent<SlotOfEquip>().slot_item, 
				() =>
				{

				});
		}

		//其他
		else
		{
				
		}
	}
}
