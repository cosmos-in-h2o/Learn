/*
 * 代码作用：封装了一些背包里的方法
 */
using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryFunction : MonoBehaviour
{
	//单例模式
	private static InventoryFunction instance;
	public static InventoryFunction Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType(typeof(InventoryFunction)) as InventoryFunction;
			}
			return instance;
		}
    }

	/// <summary>
	/// 创建一个普通item
	/// </summary>
	/// <param name="item">要创建的物品</param>
	public void createItem(Item item)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;
		//思路：创建预制体
		GameObject perfab =Resources.Load<GameObject>("Prefabs/Slot");
        GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
		new_item.gameObject.transform.SetParent(grid.transform);
        new_item.GetComponent<Slot>().slot_item = item;
        new_item.GetComponent<Slot>().slot_image.sprite = item.item_sprite;
        new_item.GetComponent<Slot>().slot_number.text = item.item_number.ToString();
    }

	/// <summary>
	/// 创建一个不可堆叠数量不限的item
	/// </summary>
	/// <param name="item">要创建的物品</param>
	public void createEquipItem(ItemOfEquip item)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		//思路：通过循环创建预制体，因为物品不可堆叠
		for (int i=0;i<item.item_number;i++)
		{
			GameObject perfab=Resources.Load<GameObject>("Prefabs/EquipSlot");
			GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
			new_item.gameObject.transform.SetParent(grid.transform);
			new_item.GetComponent<SlotOfEquip>().slot_item = item;
			new_item.GetComponent<SlotOfEquip>().slot_image.sprite = item.item_sprite;
		}
    }
	
	/// <summary>
	/// 创建一个不可堆叠数量限一的item
	/// </summary>
	/// <param name="item">要创建的物品</param>
	public void createDreamItem(ItemOfDream item)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		//思路：创建预制体
		GameObject perfab =Resources.Load<GameObject>("Prefabs/DreamSlot");
		GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
		new_item.gameObject.transform.SetParent(grid.transform);
		new_item.GetComponent<SlotOfDream>().slot_item = item;
		new_item.GetComponent<SlotOfDream>().slot_image.sprite = item.item_sprite;
    }

	/// <summary>
	/// 增加一个普通item
	/// </summary>
	/// <param name="item">要增加的物品</param>
	/// <param name="number">增加的数量</param>
	public void addItem(Item item, int number=1)
	{
		int item_type = item.ID / 1000000 % 10;
		int item_inventory = item.ID / 100000 % 10;
		int item_index = item.ID - item.ID / 1000000 % 10 * 1000000 - item.ID / 100000 % 10 * 100000;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		Inventory inventory;
		if (item_inventory == 2)
			inventory = InventoryManager.Instance.food;
		else if (item_inventory == 5)
			inventory = InventoryManager.Instance.materia;
		else
			inventory = InventoryManager.Instance.another;

		//思路:如果背包中没有就添加到背包中然后增加数量，在通过在背包中的位置寻找到在父物体下的位置然后将这个物体显示数量同步
		GameObject perfab =Resources.Load<GameObject>("Prefabs/Slot");
        if (!inventory.item_list.Contains(item))
        {
            inventory.item_list.Add(item);
            GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
            new_item.gameObject.transform.SetParent(grid.transform);
            new_item.GetComponent<Slot>().slot_item = item;
            new_item.GetComponent<Slot>().slot_image.sprite = item.item_sprite;
	        new_item.GetComponent<Slot>().slot_number.text = item.item_number.ToString();
	        item.item_number+=number;
	        grid.transform.GetChild(inventory.item_list.IndexOf(item)).GetComponent<Slot>().slot_number.text=item.item_number.ToString();
        }
        else
        {
            item.item_number += number;
			grid.transform.GetChild(inventory.item_list.IndexOf(item)).GetComponent<Slot>().slot_number.text = item.item_number.ToString();
		}
    }

	/// <summary>
	/// 增加一个不可堆叠数量不限的item
	/// </summary>
	/// <param name="item">要增加的物品</param>
	/// <param name="number">增加的数量</param>
	public void addEquipItem(ItemOfEquip item,int number=1)
	{
		int item_type = item.ID / 1000000 % 10;
		int item_inventory = item.ID / 100000 % 10;
		int item_index = item.ID - item.ID / 1000000 % 10 * 1000000 - item.ID / 100000 % 10 * 100000;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		InventoryOfEquip inventory;
		if (item_inventory == 1)
			inventory = InventoryManager.Instance.equip;
		else
			inventory = InventoryManager.Instance.books;

		//思路：数量加一的同时实际也加一，因为这个实现麻烦所以

		InputManager.Instance.now_box.gameObject.SetActive(false);
		InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
		InputManager.Instance.info_image.gameObject.SetActive(false);
		InputManager.Instance.info_text.gameObject.SetActive(false);
		InputManager.Instance.info_name.gameObject.SetActive(false);
		InputManager.Instance.info_button.gameObject.SetActive(false);
		InputManager.Instance.button_text.gameObject.SetActive(false);
		if (!inventory.item_list.Contains(item))
		{
			inventory.item_list.Add(item);
		}
		item.item_number+=number;
		//先删除grid下全部子物体
		for (int i = 0; i < grid.transform.childCount; i++)
		{
			if (grid.transform.childCount == 0)
				break;
			Destroy(grid.transform.GetChild(i).gameObject);
		}
		//在重新加载所有物体
		for (int i = 0; i < inventory.item_list.Count; i++)
		{
			InventoryFunction.Instance.createEquipItem(inventory.item_list[i]);
		}
    }

	/// <summary>
	/// 增加一个不可堆叠数量不限的item
	/// </summary>
	/// <param name="item">要增加的物品</param>
	public void addDreamItem(ItemOfDream item)
	{
		int item_type = item.ID / 1000000 % 10;
		int item_inventory = item.ID / 100000 % 10;
		int item_index = item.ID - item.ID / 1000000 % 10 * 1000000 - item.ID / 100000 % 10 * 100000;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		InventoryOfDream inventory;
		if (item_inventory == 3)
			inventory = InventoryManager.Instance.dream;
		else
			inventory = InventoryManager.Instance.blue_print_and_collectibles;
		/*
		 * 思路：
		 * 创建一个预制体
		 */
		GameObject perfab =Resources.Load<GameObject>("Prefabs/DreamSlot");
		if (!inventory.item_list.Contains(item))
		{
			inventory.item_list.Add(item);
			GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
			new_item.gameObject.transform.SetParent(grid.transform);
			new_item.GetComponent<SlotOfDream>().slot_item = item;
			new_item.GetComponent<SlotOfDream>().slot_image.sprite = item.item_sprite;
			item.item_is_have=true;
		}
    }

	/// <summary>
	/// 减少普通item
	/// </summary>
	/// <param name="item">要减少的物品</param>
	/// <param name="action">如果失败调用函数</param>
	/// <param name="number">要减少的数量默认为一</param>
	public void subtractItem(Item item, Action action,int number=1)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;
		
		Inventory inventory;
		if (item_inventory == 2)
			inventory = InventoryManager.Instance.food;
		else if (item_inventory == 5)
			inventory = InventoryManager.Instance.materia;
		else
			inventory = InventoryManager.Instance.another;

		//当列表中有这个东西	
		if (inventory.item_list.Contains(item))
		{
			//当物品数量大于减少的数量则减少物品数量并刷新数字
			if(item.item_number>number)
			{
				item.item_number-=number;
				grid.transform.GetChild(inventory.item_list.IndexOf(item)).GetComponent<Slot>().slot_number.text = item.item_number.ToString();
			}
			//当物品数量等于减少的数量则将数量设为零删除创建的预制体
			else if(item.item_number==number)
            {
				item.item_number = 0;
				InputManager.Instance.now_box.gameObject.SetActive(false);
				InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
				InputManager.Instance.info_image.gameObject.SetActive(false);
				InputManager.Instance.info_text.gameObject.SetActive(false);
				InputManager.Instance.info_name.gameObject.SetActive(false);
				InputManager.Instance.info_button.gameObject.SetActive(false);
				InputManager.Instance.button_text.gameObject.SetActive(false);
				Destroy(grid.transform.GetChild(inventory.item_list.IndexOf(item)).gameObject);
				inventory.item_list.Remove(item);
            }
			//如果数量小于要减少的数量就不减少并返回false
			else if(item.item_number<number)
			{
				action();
			}
		}
		else
		{
			action();
		}


    }

	/// <summary>
	/// 减少不可堆叠数量不限的item
	/// </summary>
	/// <param name="item">要减少的物品</param>
	/// <param name="action">如果失败调用函数</param>
	/// <param name="number">减少的数量默认为一</param>
	public void subtractEquipItem(ItemOfEquip item,Action action, int number=1)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		InventoryOfEquip inventory;
		if (item_inventory == 1)
			inventory = InventoryManager.Instance.equip;
		else
			inventory = InventoryManager.Instance.books;

		//当列表中有这个物品
		if (inventory.item_list.Contains(item))
		{
			//物品数量大于等于number，减少数量后重新加载所有物品
			if (item.item_number>=number)
			{
				item.item_number -= number;
				InputManager.Instance.now_box.gameObject.SetActive(false);
				InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
				InputManager.Instance.info_image.gameObject.SetActive(false);
				InputManager.Instance.info_text.gameObject.SetActive(false);
				InputManager.Instance.info_name.gameObject.SetActive(false);
				InputManager.Instance.info_button.gameObject.SetActive(false);
				InputManager.Instance.button_text.gameObject.SetActive(false);
				//先删除grid下全部子物体
				for (int i = 0; i < grid.transform.childCount; i++)
				{
					if (grid.transform.childCount == 0)
						break;
					Destroy(grid.transform.GetChild(i).gameObject);
				}
				//在重新加载所有物体
				for (int i = 0; i < inventory.item_list.Count; i++)
				{
					InventoryFunction.Instance.createEquipItem(inventory.item_list[i]);
				}
			}
			else if(item.item_number<number)
			{
				action();
			}
		}
		else
		{
			action();
		}
    }

	/// <summary>
	/// 减少不可堆叠数量限一的item
	/// </summary>
	/// <param name="item">要减少的的物品</param>
	/// <param name="action">如果失败调用函数</param>
	public void subtractDreamItem(ItemOfDream item,Action action)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		InventoryOfDream inventory;
		if (item_inventory == 3)
			inventory = InventoryManager.Instance.dream;
		else
			inventory = InventoryManager.Instance.blue_print_and_collectibles;

		//当背包有这个物品
		if (inventory.item_list.Contains(item))
		{
			item.item_is_have = false;
			InputManager.Instance.now_box.gameObject.SetActive(false);
			InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
			InputManager.Instance.info_image.gameObject.SetActive(false);
			InputManager.Instance.info_text.gameObject.SetActive(false);
			InputManager.Instance.info_name.gameObject.SetActive(false);
			InputManager.Instance.info_button.gameObject.SetActive(false);
			InputManager.Instance.button_text.gameObject.SetActive(false);
			Destroy(grid.transform.GetChild(inventory.item_list.IndexOf(item)).gameObject);
			inventory.item_list.Remove(item);
		}
		else
		{
			action();
		}
	}
	
	/// <summary>
	/// 穿戴装备
	/// </summary>
	/// <param name="item">穿戴的装备</param>
	public void wearEquip(ItemOfEquip item)
	{
		/*
		*思路：
		*先判断装备的类型，然后判断装备框有没有东西，有的话就先将这个东西添加进背包然后移除，然后装备上新装备的,然后更新显示
		*/
		if(item.item_type == BagSystem.ItemType.Weapon)
		{
			//如果有东西
			if(InventoryManager.Instance.equip_box.Weapon!=null)
			{
				InventoryFunction.Instance.addEquipItem(InventoryManager.Instance.equip_box.Weapon);
				InventoryManager.Instance.equip_box.Weapon=item;
			}
			//如果没东西
			else
			{
				InventoryManager.Instance.equip_box.Weapon=item;
			}
			InventoryManager.Instance.weapon_equip_box.gameObject.GetComponent<Image>().sprite= InventoryManager.Instance.equip_box.Weapon.item_sprite;
		}
		else if(item.item_type==BagSystem.ItemType.Gun)
		{
			//如果有东西
			if(InventoryManager.Instance.equip_box.Gun!=null)
			{
				InventoryFunction.Instance.addEquipItem(InventoryManager.Instance.equip_box.Gun );
				InventoryManager.Instance.equip_box.Gun =item;
			}
			//如果没东西
			else
			{
				InventoryManager.Instance.equip_box.Gun =item;
			}
			InventoryManager.Instance.gun_equip_box.gameObject.GetComponent<Image>().sprite= InventoryManager.Instance.equip_box.Gun.item_sprite;
		}
		else if(item.item_type == BagSystem.ItemType.Armor)
		{
			//如果有东西
			if(InventoryManager.Instance.equip_box.Armor!=null)
			{
				InventoryFunction.Instance.addEquipItem( InventoryManager.Instance.equip_box.Armor);
				InventoryManager.Instance.equip_box.Armor=item;
			}
			//如果没东西
			else
			{
				InventoryManager.Instance.equip_box.Armor=item;
			}
			InventoryManager.Instance.weapon_equip_box.gameObject.GetComponent<Image>().sprite= InventoryManager.Instance.equip_box.Armor.item_sprite;
		}
	}

	/// <summary>
	/// 穿戴遗失之梦
	/// </summary>
	/// <param name="item">穿戴的梦想</param>
	public void wearEquip(ItemOfDream item)
	{
		if(item.item_type==BagSystem.ItemType.Dream)
		{
			//如果有东西
			if(InventoryManager.Instance.equip_box.Dream!=null)
			{
				InventoryFunction.Instance.addDreamItem(InventoryManager.Instance.equip_box.Dream);
				InventoryManager.Instance.equip_box.Dream=item;
			}
			//如果没东西
			else
			{
				InventoryManager.Instance.equip_box.Dream=item;
			}
		}
		InventoryManager.Instance.dream_equip_box.gameObject.GetComponent<Image>().sprite= InventoryManager.Instance.equip_box.Dream.item_sprite;
	}

	//-----------------------------------------函数重写分割线-------------------------------------------

	/// <summary>
	/// 创建一个物品
	/// </summary>
	/// <param name="item_ID">创建物品的ID</param>
	public void createItem(int item_ID)
	{
		int item_type = item_ID / 1000000 % 10;
		int item_inventory = item_ID / 100000 % 10;
		int item_index = item_ID - item_ID / 1000000 % 10 * 1000000 - item_ID / 100000 % 10 * 100000;
		
		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if(item_inventory==2)
			grid = InventoryManager.Instance.food_grid;
		else if(item_inventory==3)
			grid = InventoryManager.Instance.dream_grid;
		else if(item_inventory==4)
			grid = InventoryManager.Instance.books_grid;
		else if(item_inventory==5)
			grid = InventoryManager.Instance.materia_grid;
		else if(item_inventory==6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		if (item_type == 1)
		{
			//思路：创建预制体
			GameObject perfab = Resources.Load<GameObject>("Prefabs/Slot");
			GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
			new_item.gameObject.transform.SetParent(grid.transform);
			new_item.GetComponent<Slot>().slot_item = InventoryManager.Instance.common_items[item_index];
			new_item.GetComponent<Slot>().slot_image.sprite = InventoryManager.Instance.common_items[item_index].item_sprite;
			new_item.GetComponent<Slot>().slot_number.text = InventoryManager.Instance.common_items[item_index].item_number.ToString();
		}
		else if (item_type == 2)
		{
			//思路：通过循环创建预制体，因为物品不可堆叠
			for (int i = 0; i < InventoryManager.Instance.equip_items[item_index].item_number; i++)
			{
				GameObject perfab = Resources.Load<GameObject>("Prefabs/EquipSlot");
				GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
				new_item.gameObject.transform.SetParent(grid.transform);
				new_item.GetComponent<SlotOfEquip>().slot_item = InventoryManager.Instance.equip_items[item_index];
				new_item.GetComponent<SlotOfEquip>().slot_image.sprite = InventoryManager.Instance.equip_items[item_index].item_sprite;
			}
		}
		else if (item_type == 3)
		{
			//思路：创建预制体
			GameObject perfab = Resources.Load<GameObject>("Prefabs/DreamSlot");
			GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
			new_item.gameObject.transform.SetParent(grid.transform);
			new_item.GetComponent<SlotOfDream>().slot_item = InventoryManager.Instance.dream_items[item_index];
			new_item.GetComponent<SlotOfDream>().slot_image.sprite = InventoryManager.Instance.dream_items[item_index].item_sprite;
		}
	}

	/// <summary>
	/// 增加一个物品
	/// </summary>
	/// <param name="item_ID">增加物品的ID</param>
	/// <param name="number">增加的数量，默认为一</param>
	public void addItem(int item_ID, int number = 1)
	{
		int item_type = item_ID / 1000000 % 10;
		int item_inventory = item_ID / 100000 % 10;
		int item_index = item_ID - item_ID / 1000000 % 10 * 1000000 - item_ID / 100000 % 10 * 100000;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		if (item_type == 1)
		{
			Inventory inventory;
			if (item_inventory == 2)
				inventory = InventoryManager.Instance.food;
			else if (item_inventory == 5)
				inventory = InventoryManager.Instance.materia;
			else
				inventory = InventoryManager.Instance.another;

			//思路:如果背包中没有就添加到背包中然后增加数量，在通过在背包中的位置寻找到在父物体下的位置然后将这个物体显示数量同步
			GameObject perfab = Resources.Load<GameObject>("Prefabs/Slot");
			if (!inventory.item_list.Contains(InventoryManager.Instance.common_items[item_index]))
			{
				inventory.item_list.Add(InventoryManager.Instance.common_items[item_index]);
				GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
				new_item.gameObject.transform.SetParent(grid.transform);
				new_item.GetComponent<Slot>().slot_item = InventoryManager.Instance.common_items[item_index];
				new_item.GetComponent<Slot>().slot_image.sprite = InventoryManager.Instance.common_items[item_index].item_sprite;
				new_item.GetComponent<Slot>().slot_number.text = InventoryManager.Instance.common_items[item_index].item_number.ToString();
				InventoryManager.Instance.common_items[item_index].item_number += number;
				grid.transform.GetChild(inventory.item_list.IndexOf(InventoryManager.Instance.common_items[item_index])).GetComponent<Slot>().slot_number.text = InventoryManager.Instance.common_items[item_index].item_number.ToString();
			}
			else
			{
				InventoryManager.Instance.common_items[item_index].item_number += number;
				grid.transform.GetChild(inventory.item_list.IndexOf(InventoryManager.Instance.common_items[item_index])).GetComponent<Slot>().slot_number.text = InventoryManager.Instance.common_items[item_index].item_number.ToString();
			}
		}
		else if (item_type == 2)
		{
			InventoryOfEquip inventory;
			if (item_inventory == 1)
				inventory = InventoryManager.Instance.equip;
			else
				inventory = InventoryManager.Instance.books;


			//思路：数量加一的同时实际也加一，因为这个实现麻烦所以
			InputManager.Instance.now_box.gameObject.SetActive(false);
			InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
			InputManager.Instance.info_image.gameObject.SetActive(false);
			InputManager.Instance.info_text.gameObject.SetActive(false);
			InputManager.Instance.info_name.gameObject.SetActive(false);
			InputManager.Instance.info_button.gameObject.SetActive(false);
			InputManager.Instance.button_text.gameObject.SetActive(false);
			if (!inventory.item_list.Contains(InventoryManager.Instance.equip_items[item_index]))
			{
				inventory.item_list.Add(InventoryManager.Instance.equip_items[item_index]);
			}
			InventoryManager.Instance.equip_items[item_index].item_number += number;
			//先删除grid下全部子物体
			for (int i = 0; i < grid.transform.childCount; i++)
			{
				if (grid.transform.childCount == 0)
					break;
				Destroy(grid.transform.GetChild(i).gameObject);
			}
			//在重新加载所有物体
			for (int i = 0; i < inventory.item_list.Count; i++)
			{
				InventoryFunction.Instance.createEquipItem(inventory.item_list[i]);
			}
		}
		else if (item_type == 3)
		{
			InventoryOfDream inventory;
			if (item_inventory == 3)
				inventory = InventoryManager.Instance.dream;
			else
				inventory = InventoryManager.Instance.blue_print_and_collectibles;

			/*
			* 思路：
			* 创建一个预制体
			*/
			GameObject perfab = Resources.Load<GameObject>("Prefabs/DreamSlot");
			if (!inventory.item_list.Contains(InventoryManager.Instance.dream_items[item_index]))
			{
				inventory.item_list.Add(InventoryManager.Instance.dream_items[item_index]);
				GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
				new_item.gameObject.transform.SetParent(grid.transform);
				new_item.GetComponent<SlotOfDream>().slot_item = InventoryManager.Instance.dream_items[item_index];
				new_item.GetComponent<SlotOfDream>().slot_image.sprite = InventoryManager.Instance.dream_items[item_index].item_sprite;
				InventoryManager.Instance.dream_items[item_index].item_is_have = true;
			}
		}
	}

	/// <summary>
	/// 减少物品
	/// </summary>
	/// <param name="item_ID">减少物品的ID</param>
	/// <param name="action">数量不够减少的数量</param>
	/// <param name="number">减少的数量</param>
	/// <returns>是否减少了</returns>
	public void subtractItem(int item_ID,Action action, int number = 1)
	{
		int item_type = item_ID / 1000000 % 10;
		int item_inventory = item_ID / 100000 % 10;
		int item_index = item_ID - item_ID / 1000000 % 10 * 1000000 - item_ID / 100000 % 10 * 100000;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		if (item_type == 1)
		{
			Inventory inventory;
			if (item_inventory == 2)
				inventory = InventoryManager.Instance.food;
			else if (item_inventory == 5)
				inventory = InventoryManager.Instance.materia;
			else
				inventory = InventoryManager.Instance.another;
			//当列表中有这个东西
			if (inventory.item_list.Contains(InventoryManager.Instance.common_items[item_index]))
			{
				//当物品数量大于减少的数量则减少物品数量并刷新数字
				if (InventoryManager.Instance.common_items[item_index].item_number > number)
				{
					InventoryManager.Instance.common_items[item_index].item_number -= number;
					grid.transform.GetChild(inventory.item_list.IndexOf(InventoryManager.Instance.common_items[item_index])).GetComponent<Slot>().slot_number.text = InventoryManager.Instance.common_items[item_index].item_number.ToString();
				}
				//当物品数量等于减少的数量则将数量设为零删除创建的预制体
				else if (InventoryManager.Instance.common_items[item_index].item_number == number)
				{
					InventoryManager.Instance.common_items[item_index].item_number = 0;
					InputManager.Instance.now_box.gameObject.SetActive(false);
					InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
					InputManager.Instance.info_image.gameObject.SetActive(false);
					InputManager.Instance.info_text.gameObject.SetActive(false);
					InputManager.Instance.info_name.gameObject.SetActive(false);
					InputManager.Instance.info_button.gameObject.SetActive(false);
					InputManager.Instance.button_text.gameObject.SetActive(false);
					Destroy(grid.transform.GetChild(inventory.item_list.IndexOf(InventoryManager.Instance.common_items[item_index])).gameObject);
					inventory.item_list.Remove(InventoryManager.Instance.common_items[item_index]);
				}
				//如果数量小于要减少的数量就不减少并返回false
				else if (InventoryManager.Instance.common_items[item_index].item_number < number)
				{
					action();
				}
			}
			else
			{
				action();
			}
		}
		else if (item_type == 2)
		{
			InventoryOfEquip inventory;
			if (item_inventory == 1)
				inventory = InventoryManager.Instance.equip;
			else
				inventory = InventoryManager.Instance.books;
			//当列表中有这个物品
			if (inventory.item_list.Contains(InventoryManager.Instance.equip_items[item_index]))
			{
				//物品数量大于等于number，减少数量后重新加载所有物品
				if (InventoryManager.Instance.equip_items[item_index].item_number >= number)
				{
					InventoryManager.Instance.equip_items[item_index].item_number -= number;
					InputManager.Instance.now_box.gameObject.SetActive(false);
					InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
					InputManager.Instance.info_image.gameObject.SetActive(false);
					InputManager.Instance.info_text.gameObject.SetActive(false);
					InputManager.Instance.info_name.gameObject.SetActive(false);
					InputManager.Instance.info_button.gameObject.SetActive(false);
					InputManager.Instance.button_text.gameObject.SetActive(false);
					//先删除grid下全部子物体
					for (int i = 0; i < grid.transform.childCount; i++)
					{
						if (grid.transform.childCount == 0)
							break;
						Destroy(grid.transform.GetChild(i).gameObject);
					}
					//在重新加载所有物体
					for (int i = 0; i < inventory.item_list.Count; i++)
					{
						InventoryFunction.Instance.createEquipItem(inventory.item_list[i]);
					}
				}
				else if (InventoryManager.Instance.equip_items[item_index].item_number < number)
				{
					action();
				}
			}
			else
			{
				action();
			}
		}
		else if(item_type == 3)
		{
			InventoryOfDream inventory;
			if (item_inventory == 3)
				inventory = InventoryManager.Instance.dream;
			else
				inventory = InventoryManager.Instance.blue_print_and_collectibles;
			//当背包有这个物品
			if (inventory.item_list.Contains(InventoryManager.Instance.dream_items[item_index]))
			{
				InventoryManager.Instance.dream_items[item_index].item_is_have = false;
				InputManager.Instance.now_box.gameObject.SetActive(false);
				InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
				InputManager.Instance.info_image.gameObject.SetActive(false);
				InputManager.Instance.info_text.gameObject.SetActive(false);
				InputManager.Instance.info_name.gameObject.SetActive(false);
				InputManager.Instance.info_button.gameObject.SetActive(false);
				InputManager.Instance.button_text.gameObject.SetActive(false);
				Destroy(grid.transform.GetChild(inventory.item_list.IndexOf(InventoryManager.Instance.dream_items[item_index])).gameObject);
				inventory.item_list.Remove(InventoryManager.Instance.dream_items[item_index]);
			}
			else
			{
				action();
			}
		}
	}

	/// <summary>
	/// 穿戴装备
	/// </summary>
	/// <param name="item_ID">穿戴物品id</param>
	public void wearEquip(int item_ID)
	{
		int item_type = item_ID / 1000000 % 10;
		int item_index = item_ID - item_ID / 1000000 % 10 * 1000000 - item_ID / 100000 % 10 * 100000;
		if (item_type == 2)
		{
			/*
			*思路：
			*先判断装备的类型，然后判断装备框有没有东西，有的话就先将这个东西添加进背包然后移除，然后装备上新装备的,然后更新显示
			*/
			if (InventoryManager.Instance.equip_items[item_index].item_type == BagSystem.ItemType.Weapon)
			{
				//如果有东西
				if (InventoryManager.Instance.equip_box.Weapon != null)
				{
					InventoryFunction.Instance.addItem(item_ID);
					InventoryManager.Instance.equip_box.Weapon = InventoryManager.Instance.equip_items[item_index];
				}
				//如果没东西
				else
				{
					InventoryManager.Instance.equip_box.Weapon = InventoryManager.Instance.equip_items[item_index];
				}
				InventoryManager.Instance.weapon_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Weapon.item_sprite;
			}
			else if (InventoryManager.Instance.equip_items[item_index].item_type == BagSystem.ItemType.Gun)
			{
				//如果有东西
				if (InventoryManager.Instance.equip_box.Gun != null)
				{
					InventoryFunction.Instance.addItem(item_ID);
					InventoryManager.Instance.equip_box.Gun = InventoryManager.Instance.equip_items[item_index];
				}
				//如果没东西
				else
				{
					InventoryManager.Instance.equip_box.Gun = InventoryManager.Instance.equip_items[item_index];
				}
				InventoryManager.Instance.gun_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Gun.item_sprite;
			}
			else if (InventoryManager.Instance.equip_items[item_index].item_type == BagSystem.ItemType.Armor)
			{
				//如果有东西
				if (InventoryManager.Instance.equip_box.Armor != null)
				{
					InventoryFunction.Instance.addEquipItem(InventoryManager.Instance.equip_box.Armor);
					InventoryManager.Instance.equip_box.Armor = InventoryManager.Instance.equip_items[item_index];
				}
				//如果没东西
				else
				{
					InventoryManager.Instance.equip_box.Armor = InventoryManager.Instance.equip_items[item_index];
				}
				InventoryManager.Instance.weapon_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Armor.item_sprite;
			}
		}
		else if (item_ID == 3)
		{
			if (InventoryManager.Instance.dream_items[item_index].item_type == BagSystem.ItemType.Dream)
			{
				//如果有东西
				if (InventoryManager.Instance.equip_box.Dream != null)
				{
					InventoryFunction.Instance.addItem(item_ID);
					InventoryManager.Instance.equip_box.Dream = InventoryManager.Instance.dream_items[item_index];
				}
				//如果没东西
				else
				{
					InventoryManager.Instance.equip_box.Dream = InventoryManager.Instance.dream_items[item_index];
				}
			}
			InventoryManager.Instance.dream_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Dream.item_sprite;
		}
	}

	//--------------------------------大分割线（加上回调函数的重写）-----------------------------------
	//--------------------------------大分割线（加上回调函数的重写）-----------------------------------
	//--------------------------------大分割线（加上回调函数的重写）-----------------------------------

	/// <summary>
	/// 创建一个普通item
	/// </summary>
	/// <param name="item">要创建的物品</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void createItem(Item item, Action<int, int> callBack,int value1=0,int value2=0)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;
		//思路：创建预制体
		GameObject perfab = Resources.Load<GameObject>("Prefabs/Slot");
		GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
		new_item.gameObject.transform.SetParent(grid.transform);
		new_item.GetComponent<Slot>().slot_item = item;
		new_item.GetComponent<Slot>().slot_image.sprite = item.item_sprite;
		new_item.GetComponent<Slot>().slot_number.text = item.item_number.ToString();
		callBack(value1, value2);
	}

	/// <summary>
	/// 创建一个不可堆叠数量不限的item
	/// </summary>
	/// <param name="item">要创建的物品</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>

	public void createEquipItem(ItemOfEquip item, Action<int, int> callBack, int value1 = 0, int value2 = 0)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		//思路：通过循环创建预制体，因为物品不可堆叠
		for (int i = 0; i < item.item_number; i++)
		{
			GameObject perfab = Resources.Load<GameObject>("Prefabs/EquipSlot");
			GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
			new_item.gameObject.transform.SetParent(grid.transform);
			new_item.GetComponent<SlotOfEquip>().slot_item = item;
			new_item.GetComponent<SlotOfEquip>().slot_image.sprite = item.item_sprite;
		}
		callBack(value1, value2);
	}

	/// <summary>
	/// 创建一个不可堆叠数量限一的item
	/// </summary>
	/// <param name="item">要创建的物品</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void createDreamItem(ItemOfDream item, Action<int, int> callBack, int value1 = 0, int value2 = 0)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		//思路：创建预制体
		GameObject perfab = Resources.Load<GameObject>("Prefabs/DreamSlot");
		GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
		new_item.gameObject.transform.SetParent(grid.transform);
		new_item.GetComponent<SlotOfDream>().slot_item = item;
		new_item.GetComponent<SlotOfDream>().slot_image.sprite = item.item_sprite;
		callBack(value1, value2);
	}

	/// <summary>
	/// 增加一个普通item
	/// </summary>
	/// <param name="item">要增加的物品</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="number">增加的数量</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void addItem(Item item, Action<int, int> callBack, int number = 1, int value1 = 0, int value2 = 0)
	{
		int item_type = item.ID / 1000000 % 10;
		int item_inventory = item.ID / 100000 % 10;
		int item_index = item.ID - item.ID / 1000000 % 10 * 1000000 - item.ID / 100000 % 10 * 100000;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		Inventory inventory;
		if (item_inventory == 2)
			inventory = InventoryManager.Instance.food;
		else if (item_inventory == 5)
			inventory = InventoryManager.Instance.materia;
		else
			inventory = InventoryManager.Instance.another;

		//思路:如果背包中没有就添加到背包中然后增加数量，在通过在背包中的位置寻找到在父物体下的位置然后将这个物体显示数量同步
		GameObject perfab = Resources.Load<GameObject>("Prefabs/Slot");
		if (!inventory.item_list.Contains(item))
		{
			inventory.item_list.Add(item);
			GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
			new_item.gameObject.transform.SetParent(grid.transform);
			new_item.GetComponent<Slot>().slot_item = item;
			new_item.GetComponent<Slot>().slot_image.sprite = item.item_sprite;
			new_item.GetComponent<Slot>().slot_number.text = item.item_number.ToString();
			item.item_number += number;
			grid.transform.GetChild(inventory.item_list.IndexOf(item)).GetComponent<Slot>().slot_number.text = item.item_number.ToString();
		}
		else
		{
			item.item_number += number;
			grid.transform.GetChild(inventory.item_list.IndexOf(item)).GetComponent<Slot>().slot_number.text = item.item_number.ToString();
		}
		callBack(value1, value2);
	}

	/// <summary>
	/// 增加一个不可堆叠数量不限的item
	/// </summary>
	/// <param name="item">要增加的物品</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="number">增加的数量</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void addEquipItem(ItemOfEquip item, Action<int, int> callBack, int number = 1, int value1 = 0, int value2 = 0)
	{
		int item_type = item.ID / 1000000 % 10;
		int item_inventory = item.ID / 100000 % 10;
		int item_index = item.ID - item.ID / 1000000 % 10 * 1000000 - item.ID / 100000 % 10 * 100000;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		InventoryOfEquip inventory;
		if (item_inventory == 1)
			inventory = InventoryManager.Instance.equip;
		else
			inventory = InventoryManager.Instance.books;

		//思路：数量加一的同时实际也加一，因为这个实现麻烦所以

		InputManager.Instance.now_box.gameObject.SetActive(false);
		InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
		InputManager.Instance.info_image.gameObject.SetActive(false);
		InputManager.Instance.info_text.gameObject.SetActive(false);
		InputManager.Instance.info_name.gameObject.SetActive(false);
		InputManager.Instance.info_button.gameObject.SetActive(false);
		InputManager.Instance.button_text.gameObject.SetActive(false);
		if (!inventory.item_list.Contains(item))
		{
			inventory.item_list.Add(item);
		}
		item.item_number += number;
		//先删除grid下全部子物体
		for (int i = 0; i < grid.transform.childCount; i++)
		{
			if (grid.transform.childCount == 0)
				break;
			Destroy(grid.transform.GetChild(i).gameObject);
		}
		//在重新加载所有物体
		for (int i = 0; i < inventory.item_list.Count; i++)
		{
			InventoryFunction.Instance.createEquipItem(inventory.item_list[i]);
		}
		callBack(value1, value2);
	}

	/// <summary>
	/// 增加一个不可堆叠数量不限的item
	/// </summary>
	/// <param name="item">要增加的物品</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void addDreamItem(ItemOfDream item,Action<int,int>callBack, int value1 = 0, int value2 = 0)
	{
		int item_type = item.ID / 1000000 % 10;
		int item_inventory = item.ID / 100000 % 10;
		int item_index = item.ID - item.ID / 1000000 % 10 * 1000000 - item.ID / 100000 % 10 * 100000;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		InventoryOfDream inventory;
		if (item_inventory == 3)
			inventory = InventoryManager.Instance.dream;
		else
			inventory = InventoryManager.Instance.blue_print_and_collectibles;
		/*
		 * 思路：
		 * 创建一个预制体
		 */
		GameObject perfab = Resources.Load<GameObject>("Prefabs/DreamSlot");
		if (!inventory.item_list.Contains(item))
		{
			inventory.item_list.Add(item);
			GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
			new_item.gameObject.transform.SetParent(grid.transform);
			new_item.GetComponent<SlotOfDream>().slot_item = item;
			new_item.GetComponent<SlotOfDream>().slot_image.sprite = item.item_sprite;
			item.item_is_have = true;
		}
		callBack(value1, value2);
	}

	/// <summary>
	/// 减少普通item
	/// </summary>
	/// <param name="item">要减少的物品</param>
	/// <param name="action">如果失败调用函数</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="number">要减少的数量默认为一</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void subtractItem(Item item, Action action, Action<int, int> callBack, int number = 1, int value1 = 0, int value2 = 0)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		Inventory inventory;
		if (item_inventory == 2)
			inventory = InventoryManager.Instance.food;
		else if (item_inventory == 5)
			inventory = InventoryManager.Instance.materia;
		else
			inventory = InventoryManager.Instance.another;

		//当列表中有这个东西	
		if (inventory.item_list.Contains(item))
		{
			//当物品数量大于减少的数量则减少物品数量并刷新数字
			if (item.item_number > number)
			{
				item.item_number -= number;
				grid.transform.GetChild(inventory.item_list.IndexOf(item)).GetComponent<Slot>().slot_number.text = item.item_number.ToString();
				callBack(value1, value2);
			}
			//当物品数量等于减少的数量则将数量设为零删除创建的预制体
			else if (item.item_number == number)
			{
				item.item_number = 0;
				InputManager.Instance.now_box.gameObject.SetActive(false);
				InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
				InputManager.Instance.info_image.gameObject.SetActive(false);
				InputManager.Instance.info_text.gameObject.SetActive(false);
				InputManager.Instance.info_name.gameObject.SetActive(false);
				InputManager.Instance.info_button.gameObject.SetActive(false);
				InputManager.Instance.button_text.gameObject.SetActive(false);
				Destroy(grid.transform.GetChild(inventory.item_list.IndexOf(item)).gameObject);
				inventory.item_list.Remove(item);
				callBack(value1, value2);
			}
			//如果数量小于要减少的数量就不减少并返回false
			else if (item.item_number < number)
			{
				action();
			}
		}
		else
		{
			action();
		}
	}

	/// <summary>
	/// 减少不可堆叠数量不限的item
	/// </summary>
	/// <param name="item">要减少的物品</param>
	/// <param name="action">如果失败调用函数</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="number">减少的数量默认为一</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void subtractEquipItem(ItemOfEquip item, Action action, Action<int, int> callBack, int number = 1, int value1 = 0, int value2 = 0)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		InventoryOfEquip inventory;
		if (item_inventory == 1)
			inventory = InventoryManager.Instance.equip;
		else
			inventory = InventoryManager.Instance.books;

		//当列表中有这个物品
		if (inventory.item_list.Contains(item))
		{
			//物品数量大于等于number，减少数量后重新加载所有物品
			if (item.item_number >= number)
			{
				item.item_number -= number;
				InputManager.Instance.now_box.gameObject.SetActive(false);
				InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
				InputManager.Instance.info_image.gameObject.SetActive(false);
				InputManager.Instance.info_text.gameObject.SetActive(false);
				InputManager.Instance.info_name.gameObject.SetActive(false);
				InputManager.Instance.info_button.gameObject.SetActive(false);
				InputManager.Instance.button_text.gameObject.SetActive(false);
				//先删除grid下全部子物体
				for (int i = 0; i < grid.transform.childCount; i++)
				{
					if (grid.transform.childCount == 0)
						break;
					Destroy(grid.transform.GetChild(i).gameObject);
				}
				//在重新加载所有物体
				for (int i = 0; i < inventory.item_list.Count; i++)
				{
					InventoryFunction.Instance.createEquipItem(inventory.item_list[i]);
				}
				callBack(value1, value2);
			}
			else if (item.item_number < number)
			{
				action();
			}
		}
		else
		{
			action();
		}
	}

	/// <summary>
	/// 减少不可堆叠数量限一的item
	/// </summary>
	/// <param name="item">要减少的的物品</param>
	/// <param name="action">如果失败调用函数</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void subtractDreamItem(ItemOfDream item, Action action, Action<int, int> callBack, int value1 = 0, int value2 = 0)
	{
		int item_inventory = item.ID / 100000 % 10;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		InventoryOfDream inventory;
		if (item_inventory == 3)
			inventory = InventoryManager.Instance.dream;
		else
			inventory = InventoryManager.Instance.blue_print_and_collectibles;

		//当背包有这个物品
		if (inventory.item_list.Contains(item))
		{
			item.item_is_have = false;
			InputManager.Instance.now_box.gameObject.SetActive(false);
			InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
			InputManager.Instance.info_image.gameObject.SetActive(false);
			InputManager.Instance.info_text.gameObject.SetActive(false);
			InputManager.Instance.info_name.gameObject.SetActive(false);
			InputManager.Instance.info_button.gameObject.SetActive(false);
			InputManager.Instance.button_text.gameObject.SetActive(false);
			Destroy(grid.transform.GetChild(inventory.item_list.IndexOf(item)).gameObject);
			inventory.item_list.Remove(item);
			callBack(value1, value2);
		}
		else
		{
			action();
		}
	}

	/// <summary>
	/// 穿戴装备
	/// </summary>
	/// <param name="item">穿戴的装备</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void wearEquip(ItemOfEquip item, Action<int, int> callBack, int value1 = 0, int value2 = 0)
	{
		/*
		*思路：
		*先判断装备的类型，然后判断装备框有没有东西，有的话就先将这个东西添加进背包然后移除，然后装备上新装备的,然后更新显示
		*/
		if (item.item_type == BagSystem.ItemType.Weapon)
		{
			//如果有东西
			if (InventoryManager.Instance.equip_box.Weapon != null)
			{
				InventoryFunction.Instance.addEquipItem(InventoryManager.Instance.equip_box.Weapon);
				InventoryManager.Instance.equip_box.Weapon = item;
			}
			//如果没东西
			else
			{
				InventoryManager.Instance.equip_box.Weapon = item;
			}
			InventoryManager.Instance.weapon_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Weapon.item_sprite;
			callBack(value1, value2);
		}
		else if (item.item_type == BagSystem.ItemType.Gun)
		{
			//如果有东西
			if (InventoryManager.Instance.equip_box.Gun != null)
			{
				InventoryFunction.Instance.addEquipItem(InventoryManager.Instance.equip_box.Gun);
				InventoryManager.Instance.equip_box.Gun = item;
			}
			//如果没东西
			else
			{
				InventoryManager.Instance.equip_box.Gun = item;
			}
			InventoryManager.Instance.gun_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Gun.item_sprite;
			callBack(value1, value2);
		}
		else if (item.item_type == BagSystem.ItemType.Armor)
		{
			//如果有东西
			if (InventoryManager.Instance.equip_box.Armor != null)
			{
				InventoryFunction.Instance.addEquipItem(InventoryManager.Instance.equip_box.Armor);
				InventoryManager.Instance.equip_box.Armor = item;
			}
			//如果没东西
			else
			{
				InventoryManager.Instance.equip_box.Armor = item;
			}
			InventoryManager.Instance.weapon_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Armor.item_sprite;
			callBack(value1, value2);
		}
	}

	/// <summary>
	/// 穿戴遗失之梦
	/// </summary>
	/// <param name="item">穿戴的梦想</param>
	/// <param name="callBack">回调函数</param>
	public void wearEquip(ItemOfDream item, Action<int, int> callBack, int value1 = 0, int value2 = 0)
	{
		if (item.item_type == BagSystem.ItemType.Dream)
		{
			//如果有东西
			if (InventoryManager.Instance.equip_box.Dream != null)
			{
				InventoryFunction.Instance.addDreamItem(InventoryManager.Instance.equip_box.Dream);
				InventoryManager.Instance.equip_box.Dream = item;
			}
			//如果没东西
			else
			{
				InventoryManager.Instance.equip_box.Dream = item;
			}
		}
		InventoryManager.Instance.dream_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Dream.item_sprite;
		callBack(value1, value2);
	}

	//-----------------------------------------函数重写分割线-------------------------------------------

	/// <summary>
	/// 创建一个物品
	/// </summary>
	/// <param name="item_ID">创建物品的ID</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void createItem(int item_ID, Action<int, int> callBack, int value1 = 0, int value2 = 0)
	{
		int item_type = item_ID / 1000000 % 10;
		int item_inventory = item_ID / 100000 % 10;
		int item_index = item_ID - item_ID / 1000000 % 10 * 1000000 - item_ID / 100000 % 10 * 100000;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		if (item_type == 1)
		{
			//思路：创建预制体
			GameObject perfab = Resources.Load<GameObject>("Prefabs/Slot");
			GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
			new_item.gameObject.transform.SetParent(grid.transform);
			new_item.GetComponent<Slot>().slot_item = InventoryManager.Instance.common_items[item_index];
			new_item.GetComponent<Slot>().slot_image.sprite = InventoryManager.Instance.common_items[item_index].item_sprite;
			new_item.GetComponent<Slot>().slot_number.text = InventoryManager.Instance.common_items[item_index].item_number.ToString();
			callBack(value1, value2);
		}
		else if (item_type == 2)
		{
			//思路：通过循环创建预制体，因为物品不可堆叠
			for (int i = 0; i < InventoryManager.Instance.equip_items[item_index].item_number; i++)
			{
				GameObject perfab = Resources.Load<GameObject>("Prefabs/EquipSlot");
				GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
				new_item.gameObject.transform.SetParent(grid.transform);
				new_item.GetComponent<SlotOfEquip>().slot_item = InventoryManager.Instance.equip_items[item_index];
				new_item.GetComponent<SlotOfEquip>().slot_image.sprite = InventoryManager.Instance.equip_items[item_index].item_sprite;
			}
			callBack(value1, value2);
		}
		else if (item_type == 3)
		{
			//思路：创建预制体
			GameObject perfab = Resources.Load<GameObject>("Prefabs/DreamSlot");
			GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
			new_item.gameObject.transform.SetParent(grid.transform);
			new_item.GetComponent<SlotOfDream>().slot_item = InventoryManager.Instance.dream_items[item_index];
			new_item.GetComponent<SlotOfDream>().slot_image.sprite = InventoryManager.Instance.dream_items[item_index].item_sprite;
			callBack(value1, value2);
		}
	}

	/// <summary>
	/// 增加一个物品
	/// </summary>
	/// <param name="item_ID">增加物品的ID</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="number">增加的数量，默认为一</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void addItem(int item_ID, Action<int, int> callBack, int number = 1, int value1 = 0, int value2 = 0)
	{
		int item_type = item_ID / 1000000 % 10;
		int item_inventory = item_ID / 100000 % 10;
		int item_index = item_ID - item_ID / 1000000 % 10 * 1000000 - item_ID / 100000 % 10 * 100000;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		if (item_type == 1)
		{
			Inventory inventory;
			if (item_inventory == 2)
				inventory = InventoryManager.Instance.food;
			else if (item_inventory == 5)
				inventory = InventoryManager.Instance.materia;
			else
				inventory = InventoryManager.Instance.another;

			//思路:如果背包中没有就添加到背包中然后增加数量，在通过在背包中的位置寻找到在父物体下的位置然后将这个物体显示数量同步
			GameObject perfab = Resources.Load<GameObject>("Prefabs/Slot");
			if (!inventory.item_list.Contains(InventoryManager.Instance.common_items[item_index]))
			{
				inventory.item_list.Add(InventoryManager.Instance.common_items[item_index]);
				GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
				new_item.gameObject.transform.SetParent(grid.transform);
				new_item.GetComponent<Slot>().slot_item = InventoryManager.Instance.common_items[item_index];
				new_item.GetComponent<Slot>().slot_image.sprite = InventoryManager.Instance.common_items[item_index].item_sprite;
				new_item.GetComponent<Slot>().slot_number.text = InventoryManager.Instance.common_items[item_index].item_number.ToString();
				InventoryManager.Instance.common_items[item_index].item_number += number;
				grid.transform.GetChild(inventory.item_list.IndexOf(InventoryManager.Instance.common_items[item_index])).GetComponent<Slot>().slot_number.text = InventoryManager.Instance.common_items[item_index].item_number.ToString();
			}
			else
			{
				InventoryManager.Instance.common_items[item_index].item_number += number;
				grid.transform.GetChild(inventory.item_list.IndexOf(InventoryManager.Instance.common_items[item_index])).GetComponent<Slot>().slot_number.text = InventoryManager.Instance.common_items[item_index].item_number.ToString();
			}
			callBack(value1, value2);
		}
		else if (item_type == 2)
		{
			InventoryOfEquip inventory;
			if (item_inventory == 1)
				inventory = InventoryManager.Instance.equip;
			else
				inventory = InventoryManager.Instance.books;


			//思路：数量加一的同时实际也加一，因为这个实现麻烦所以
			InputManager.Instance.now_box.gameObject.SetActive(false);
			InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
			InputManager.Instance.info_image.gameObject.SetActive(false);
			InputManager.Instance.info_text.gameObject.SetActive(false);
			InputManager.Instance.info_name.gameObject.SetActive(false);
			InputManager.Instance.info_button.gameObject.SetActive(false);
			InputManager.Instance.button_text.gameObject.SetActive(false);
			if (!inventory.item_list.Contains(InventoryManager.Instance.equip_items[item_index]))
			{
				inventory.item_list.Add(InventoryManager.Instance.equip_items[item_index]);
			}
			InventoryManager.Instance.equip_items[item_index].item_number += number;
			//先删除grid下全部子物体
			for (int i = 0; i < grid.transform.childCount; i++)
			{
				if (grid.transform.childCount == 0)
					break;
				Destroy(grid.transform.GetChild(i).gameObject);
			}
			//在重新加载所有物体
			for (int i = 0; i < inventory.item_list.Count; i++)
			{
				InventoryFunction.Instance.createEquipItem(inventory.item_list[i]);
			}
			callBack(value1, value2);
		}
		else if (item_type == 3)
		{
			InventoryOfDream inventory;
			if (item_inventory == 3)
				inventory = InventoryManager.Instance.dream;
			else
				inventory = InventoryManager.Instance.blue_print_and_collectibles;

			/*
			* 思路：
			* 创建一个预制体
			*/
			GameObject perfab = Resources.Load<GameObject>("Prefabs/DreamSlot");
			if (!inventory.item_list.Contains(InventoryManager.Instance.dream_items[item_index]))
			{
				inventory.item_list.Add(InventoryManager.Instance.dream_items[item_index]);
				GameObject new_item = Instantiate(perfab, grid.transform.position, Quaternion.identity);
				new_item.gameObject.transform.SetParent(grid.transform);
				new_item.GetComponent<SlotOfDream>().slot_item = InventoryManager.Instance.dream_items[item_index];
				new_item.GetComponent<SlotOfDream>().slot_image.sprite = InventoryManager.Instance.dream_items[item_index].item_sprite;
				InventoryManager.Instance.dream_items[item_index].item_is_have = true;
				callBack(value1, value2);
			}
		}
	}

	/// <summary>
	/// 减少物品
	/// </summary>
	/// <param name="item_ID">减少物品的ID</param>
	/// <param name="action">数量不够减少的数量</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="number">减少的数量</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void subtractItem(int item_ID, Action action, Action<int, int> callBack, int number = 1, int value1 = 0, int value2 = 0)
	{
		int item_type = item_ID / 1000000 % 10;
		int item_inventory = item_ID / 100000 % 10;
		int item_index = item_ID - item_ID / 1000000 % 10 * 1000000 - item_ID / 100000 % 10 * 100000;

		Transform grid;
		if (item_inventory == 1)
			grid = InventoryManager.Instance.equip_grid;
		else if (item_inventory == 2)
			grid = InventoryManager.Instance.food_grid;
		else if (item_inventory == 3)
			grid = InventoryManager.Instance.dream_grid;
		else if (item_inventory == 4)
			grid = InventoryManager.Instance.books_grid;
		else if (item_inventory == 5)
			grid = InventoryManager.Instance.materia_grid;
		else if (item_inventory == 6)
			grid = InventoryManager.Instance.blue_print_and_collectibles_grid;
		else
			grid = InventoryManager.Instance.another_grid;

		if (item_type == 1)
		{
			Inventory inventory;
			if (item_inventory == 2)
				inventory = InventoryManager.Instance.food;
			else if (item_inventory == 5)
				inventory = InventoryManager.Instance.materia;
			else
				inventory = InventoryManager.Instance.another;
			//当列表中有这个东西
			if (inventory.item_list.Contains(InventoryManager.Instance.common_items[item_index]))
			{
				//当物品数量大于减少的数量则减少物品数量并刷新数字
				if (InventoryManager.Instance.common_items[item_index].item_number > number)
				{
					InventoryManager.Instance.common_items[item_index].item_number -= number;
					grid.transform.GetChild(inventory.item_list.IndexOf(InventoryManager.Instance.common_items[item_index])).GetComponent<Slot>().slot_number.text = InventoryManager.Instance.common_items[item_index].item_number.ToString();
				}
				//当物品数量等于减少的数量则将数量设为零删除创建的预制体
				else if (InventoryManager.Instance.common_items[item_index].item_number == number)
				{
					InventoryManager.Instance.common_items[item_index].item_number = 0;
					InputManager.Instance.now_box.gameObject.SetActive(false);
					InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
					InputManager.Instance.info_image.gameObject.SetActive(false);
					InputManager.Instance.info_text.gameObject.SetActive(false);
					InputManager.Instance.info_name.gameObject.SetActive(false);
					InputManager.Instance.info_button.gameObject.SetActive(false);
					InputManager.Instance.button_text.gameObject.SetActive(false);
					Destroy(grid.transform.GetChild(inventory.item_list.IndexOf(InventoryManager.Instance.common_items[item_index])).gameObject);
					inventory.item_list.Remove(InventoryManager.Instance.common_items[item_index]);
				}
				//如果数量小于要减少的数量就不减少并返回false
				else if (InventoryManager.Instance.common_items[item_index].item_number < number)
				{
					action();
				}
			}
			else
			{
				action();
			}
		}
		else if (item_type == 2)
		{
			InventoryOfEquip inventory;
			if (item_inventory == 1)
				inventory = InventoryManager.Instance.equip;
			else
				inventory = InventoryManager.Instance.books;
			//当列表中有这个物品
			if (inventory.item_list.Contains(InventoryManager.Instance.equip_items[item_index]))
			{
				//物品数量大于等于number，减少数量后重新加载所有物品
				if (InventoryManager.Instance.equip_items[item_index].item_number >= number)
				{
					InventoryManager.Instance.equip_items[item_index].item_number -= number;
					InputManager.Instance.now_box.gameObject.SetActive(false);
					InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
					InputManager.Instance.info_image.gameObject.SetActive(false);
					InputManager.Instance.info_text.gameObject.SetActive(false);
					InputManager.Instance.info_name.gameObject.SetActive(false);
					InputManager.Instance.info_button.gameObject.SetActive(false);
					InputManager.Instance.button_text.gameObject.SetActive(false);
					//先删除grid下全部子物体
					for (int i = 0; i < grid.transform.childCount; i++)
					{
						if (grid.transform.childCount == 0)
							break;
						Destroy(grid.transform.GetChild(i).gameObject);
					}
					//在重新加载所有物体
					for (int i = 0; i < inventory.item_list.Count; i++)
					{
						InventoryFunction.Instance.createEquipItem(inventory.item_list[i]);
					}
				}
				else if (InventoryManager.Instance.equip_items[item_index].item_number < number)
				{
					action();
				}
			}
			else
			{
				action();
			}
		}
		else if (item_type == 3)
		{
			InventoryOfDream inventory;
			if (item_inventory == 3)
				inventory = InventoryManager.Instance.dream;
			else
				inventory = InventoryManager.Instance.blue_print_and_collectibles;
			//当背包有这个物品
			if (inventory.item_list.Contains(InventoryManager.Instance.dream_items[item_index]))
			{
				InventoryManager.Instance.dream_items[item_index].item_is_have = false;
				InputManager.Instance.now_box.gameObject.SetActive(false);
				InputManager.Instance.now_box.SetParent(GameObject.Find("Info").transform);
				InputManager.Instance.info_image.gameObject.SetActive(false);
				InputManager.Instance.info_text.gameObject.SetActive(false);
				InputManager.Instance.info_name.gameObject.SetActive(false);
				InputManager.Instance.info_button.gameObject.SetActive(false);
				InputManager.Instance.button_text.gameObject.SetActive(false);
				Destroy(grid.transform.GetChild(inventory.item_list.IndexOf(InventoryManager.Instance.dream_items[item_index])).gameObject);
				inventory.item_list.Remove(InventoryManager.Instance.dream_items[item_index]);
			}
			else
			{
				action();
			}
		}
	}

	/// <summary>
	/// 穿戴装备
	/// </summary>
	/// <param name="item_ID">穿戴物品id</param>
	/// <param name="callBack">回调函数</param>
	/// <param name="value1">作为回调函数第一个参数</param>
	/// <param name="value1">作为回调函数第二个参数</param>
	public void wearEquip(int item_ID, Action<int, int> callBack, int value1 = 0, int value2 = 0)
	{
		int item_type = item_ID / 1000000 % 10;
		int item_index = item_ID - item_ID / 1000000 % 10 * 1000000 - item_ID / 100000 % 10 * 100000;
		if (item_type == 2)
		{
			/*
			*思路：
			*先判断装备的类型，然后判断装备框有没有东西，有的话就先将这个东西添加进背包然后移除，然后装备上新装备的,然后更新显示
			*/
			if (InventoryManager.Instance.equip_items[item_index].item_type == BagSystem.ItemType.Weapon)
			{
				//如果有东西
				if (InventoryManager.Instance.equip_box.Weapon != null)
				{
					InventoryFunction.Instance.addItem(item_ID);
					InventoryManager.Instance.equip_box.Weapon = InventoryManager.Instance.equip_items[item_index];
				}
				//如果没东西
				else
				{
					InventoryManager.Instance.equip_box.Weapon = InventoryManager.Instance.equip_items[item_index];
				}
				InventoryManager.Instance.weapon_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Weapon.item_sprite;
				callBack(value1, value2);
			}
			else if (InventoryManager.Instance.equip_items[item_index].item_type == BagSystem.ItemType.Gun)
			{
				//如果有东西
				if (InventoryManager.Instance.equip_box.Gun != null)
				{
					InventoryFunction.Instance.addItem(item_ID);
					InventoryManager.Instance.equip_box.Gun = InventoryManager.Instance.equip_items[item_index];
				}
				//如果没东西
				else
				{
					InventoryManager.Instance.equip_box.Gun = InventoryManager.Instance.equip_items[item_index];
				}
				InventoryManager.Instance.gun_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Gun.item_sprite;
				callBack(value1, value2);
			}
			else if (InventoryManager.Instance.equip_items[item_index].item_type == BagSystem.ItemType.Armor)
			{
				//如果有东西
				if (InventoryManager.Instance.equip_box.Armor != null)
				{
					InventoryFunction.Instance.addEquipItem(InventoryManager.Instance.equip_box.Armor);
					InventoryManager.Instance.equip_box.Armor = InventoryManager.Instance.equip_items[item_index];
				}
				//如果没东西
				else
				{
					InventoryManager.Instance.equip_box.Armor = InventoryManager.Instance.equip_items[item_index];
				}
				InventoryManager.Instance.weapon_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Armor.item_sprite;
				callBack(value1, value2);
			}
		}
		else if (item_ID == 3)
		{
			if (InventoryManager.Instance.dream_items[item_index].item_type == BagSystem.ItemType.Dream)
			{
				//如果有东西
				if (InventoryManager.Instance.equip_box.Dream != null)
				{
					InventoryFunction.Instance.addItem(item_ID);
					InventoryManager.Instance.equip_box.Dream = InventoryManager.Instance.dream_items[item_index];
				}
				//如果没东西
				else
				{
					InventoryManager.Instance.equip_box.Dream = InventoryManager.Instance.dream_items[item_index];
				}
			}
			InventoryManager.Instance.dream_equip_box.gameObject.GetComponent<Image>().sprite = InventoryManager.Instance.equip_box.Dream.item_sprite;
			callBack(value1, value2);
		}
	}
}