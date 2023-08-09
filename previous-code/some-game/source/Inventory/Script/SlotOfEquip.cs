/*
*代码作用：储存不可堆叠数量不限物品slot
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotOfEquip : MonoBehaviour
{
	public Image slot_image;
	public ItemOfEquip slot_item;

	public void updateInfo()
	{
		InputManager.Instance.info_text.gameObject.SetActive(true);
		InputManager.Instance.info_image.gameObject.SetActive(true);
		InputManager.Instance.info_name.gameObject.SetActive(true);
		InputManager.Instance.info_text.text = slot_item.item_info;
		InputManager.Instance.info_image.sprite = slot_item.item_sprite;
		InputManager.Instance.info_name.text = slot_item.item_name;
		InputManager.Instance.now_box.gameObject.transform.SetParent(this.gameObject.transform);
		InputManager.Instance.now_box.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
		InputManager.Instance.now_box.gameObject.SetActive(true);

		BagSystem.ItemType item_type = slot_item.item_type;

		if (item_type == BagSystem.ItemType.Gun || item_type == BagSystem.ItemType.Armor || item_type == BagSystem.ItemType.Weapon || item_type == BagSystem.ItemType.Dream)
		{
			InputManager.Instance.button_text.text = "装备";
			InputManager.Instance.info_button.gameObject.SetActive(true);
			InputManager.Instance.button_text.gameObject.SetActive(true);
		}
		else if (item_type == BagSystem.ItemType.Food)
		{
			InputManager.Instance.button_text.text = "食用";
			InputManager.Instance.info_button.gameObject.SetActive(true);
			InputManager.Instance.button_text.gameObject.SetActive(true);
		}
		else if (item_type == BagSystem.ItemType.Books)
		{
			InputManager.Instance.button_text.text = "阅读";
			InputManager.Instance.info_button.gameObject.SetActive(true);
			InputManager.Instance.button_text.gameObject.SetActive(true);
		}
		else
		{
			InputManager.Instance.info_button.gameObject.SetActive(false);
			InputManager.Instance.button_text.gameObject.SetActive(false);
		}
	}
}
