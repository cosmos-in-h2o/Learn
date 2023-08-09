/*
 * 代码作用：管理inventory
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	/*
	 * itemID规则：
	 * abcdefg
	 * a==1 普通item
	 * a==2 equipitem
	 * a==3 dreamitem
	 * b==1	属于equip;
	 * b==2 属于food;
	 * b==3 属于dream
	 * b==4 属于books
	 * b==5 属于materia
	 * b==6 属于blue_print_and_collectibles
	 * b==7 属于another
	 * cdefg 组成的数字代表其在列表中的位置
	 */
	//单例
	private static InventoryManager instance;
	public static InventoryManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType(typeof(InventoryManager)) as InventoryManager;
			}
			return instance;
		}
	}

	public EquipBox equip_box;
	[Header("背包")]
	public InventoryOfEquip equip;
	public Inventory food;
	public InventoryOfDream dream;
	public InventoryOfEquip books;
	public Inventory materia;
	public InventoryOfDream blue_print_and_collectibles;
	public Inventory another;
	[Header("grid")]
	public Transform equip_grid;
	public Transform food_grid;
	public Transform dream_grid;
	public Transform books_grid;
	public Transform materia_grid;
	public Transform blue_print_and_collectibles_grid;
	public Transform another_grid;
	[Header("装备栏")]
	public Transform weapon_equip_box;
	public Transform gun_equip_box;
	public Transform armor_equip_box;
	public Transform dream_equip_box;
	
	public Sprite weapon_default;
	public Sprite gun_default;
	public Sprite armor_default;
	public Sprite dream_default;
	[Header("物品列表")]
	public List <Item> common_items;
	public List <ItemOfEquip> equip_items;
	public List <ItemOfDream> dream_items;
	
	//当物品被启用
	void OnEnable()
	{
        //开始的时候刷新一次
        InventoryManager.Instance.loadInventory(InventoryManager.Instance.equip_grid, InventoryManager.Instance.equip);
        InventoryManager.Instance.loadInventory(InventoryManager.Instance.food_grid, InventoryManager.Instance.food);
        InventoryManager.Instance.loadInventory(InventoryManager.Instance.dream_grid, InventoryManager.Instance.dream);
        InventoryManager.Instance.loadInventory(InventoryManager.Instance.books_grid, InventoryManager.Instance.books);
        InventoryManager.Instance.loadInventory(InventoryManager.Instance.materia_grid, InventoryManager.Instance.materia);
        InventoryManager.Instance.loadInventory(InventoryManager.Instance.blue_print_and_collectibles_grid, InventoryManager.Instance.blue_print_and_collectibles);
        InventoryManager.Instance.loadInventory(InventoryManager.Instance.another_grid, InventoryManager.Instance.another);
        InventoryManager.Instance.loadEquipBox();
    }
	
	void Update()
	{
        //每次打开背包刷新一次物品
        if (Input.GetKeyDown(KeyCode.B) && InputManager.is_phone == false)
        {
            //当打开背包时刷新equip界面和books界面
            InventoryManager.Instance.loadInventory(InventoryManager.Instance.equip_grid, InventoryManager.Instance.equip);
            InventoryManager.Instance.loadInventory(InventoryManager.Instance.books_grid, InventoryManager.Instance.books);
        }
    }
	
	//加载背包方法
	public void loadInventory(Transform grid,Inventory inventory)
	{
		//先删除grid下全部子物体
		for(int i=0;i<grid.transform.childCount;i++)
		{
			if(grid.transform.childCount==0)
				break;
			Destroy(grid.transform.GetChild(i).gameObject);
		}
        //在重新加载所有物体
        for (int i = 0; i < inventory.item_list.Count; i++)
        {
            InventoryFunction.Instance.createItem(inventory.item_list[i]);
        }
    }

    //加载背包方法,重写
    public void loadInventory(Transform grid, InventoryOfEquip inventory)
    {
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

    //加载背包方法,重写
    public void loadInventory(Transform grid, InventoryOfDream inventory)
    {
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
            InventoryFunction.Instance.createDreamItem(inventory.item_list[i]);
        }
    }

    //加载装备栏
    public void loadEquipBox()
    {
        if (equip_box.Weapon != null)
            weapon_equip_box.gameObject.GetComponent<Image>().sprite = equip_box.Weapon.item_sprite;

        if (equip_box.Gun != null)
            gun_equip_box.gameObject.GetComponent<Image>().sprite = equip_box.Gun.item_sprite;

        if (equip_box.Armor != null)
            armor_equip_box.gameObject.GetComponent<Image>().sprite = equip_box.Armor.item_sprite;

        if (equip_box.Dream != null)
            dream_equip_box.gameObject.GetComponent<Image>().sprite = equip_box.Dream.item_sprite;
    }

    //脱下武器 
    public void closeWeapon()
	{
		/*
		 * 先修改数据
		 *1.背包中添加物品
		 *2.将装备栏的东西删除
		 * 然后显示为默认图标
		 */
		if (equip_box.Weapon != null)
		{
			InventoryFunction.Instance.addEquipItem(InventoryManager.Instance.equip_box.Weapon);
			equip_box.Weapon = null;
			weapon_equip_box.GetComponent<Image>().sprite = InventoryManager.Instance.weapon_default;
		}
	}
	
	//脱下枪支
	public void closegun()
	{
		/*
		 * 先修改数据
		 *1.背包中添加物品
		 *2.将装备栏的东西删除
		 * 然后显示为默认图标
		 */
		if (equip_box.Gun != null)
		{
			InventoryFunction.Instance.addEquipItem( InventoryManager.Instance.equip_box.Gun);
			equip_box.Gun = null;
			gun_equip_box.GetComponent<Image>().sprite = InventoryManager.Instance.gun_default;
		}
	}
	
	//脱下防具
	public void closeArmor()
	{
		/*
		 * 先修改数据
		 *1.背包中添加物品
		 *2.将装备栏的东西删除
		 * 然后显示为默认图标
		 */
		if (equip_box.Armor != null)
		{
			InventoryFunction.Instance.addEquipItem(InventoryManager.Instance.equip_box.Armor);
			equip_box.Armor = null;
			armor_equip_box.GetComponent<Image>().sprite = InventoryManager.Instance.armor_default;
		}
	}

	//脱下梦想
	public void closeDream()
	{
		/*
		 * 先修改数据
		 *1.背包中添加物品
		 *2.将装备栏的东西删除
		 * 然后显示为默认图标
		 */
		if (equip_box.Dream != null)
		{
			InventoryFunction.Instance.addDreamItem(equip_box.Dream);
			equip_box.Dream = null;
			dream_equip_box.GetComponent<Image>().sprite = InventoryManager.Instance.dream_default;
		}
	}
}