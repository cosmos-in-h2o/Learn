/*
* 游戏保存系统
*/

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveSystem : MonoBehaviour
{
    private void Awake()
    {
        //若没有存档文件夹就先创建
        if (!Directory.Exists(Application.dataPath + "/DreamInThePast/save"))
        {
            Directory.CreateDirectory(Application.dataPath + "/DreamInThePast/save");
        }
    }
    private void Start()
    {

    }
    private static SaveSystem instance;
    public static SaveSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(SaveSystem)) as SaveSystem;
            }
            return instance;
        }
    }
    
    /// <summary>
    /// 创建一个新游戏
    /// </summary>
    public void creamNewGame()
    {
        int len = Directory.GetDirectories(Application.dataPath + "/DreamInThePast/save/").Length;
        //先创建文件夹
        Directory.CreateDirectory(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString());
        Debug.Log(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString());
        //在把数据储存进去
        updateGame(len);
    }

    /// <summary>
    /// 更新存档
    /// </summary>
    public void updateGame(int len)
    {
        Debug.Log(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString());
        //当找到存档
	    if (Directory.Exists(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString()))
        {
            DateTime NowTime = DateTime.Now.ToLocalTime();
            NowTime.ToString("yyyy-MM-dd HH:mm:ss");
            //二进制对象
            BinaryFormatter bf = new BinaryFormatter();
            //存档基本数据对象
            SaveData save_data = new SaveData(NowTime.ToString("yyyy-MM-dd HH:mm:ss"), GameTime.Instance.all_time_in_game.ToString(), null);
            //保存文件对象
            FileStream file = File.Create(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/save_data_data.DreamSave");
            //将对象转换为json
            var json = JsonUtility.ToJson(save_data);
            //保存操作
            bf.Serialize(file, json);
            //以上存档基本数据保存完毕
            file = File.Create(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/equip_box.DreamSave");
            json = JsonUtility.ToJson(InventoryManager.Instance.equip_box);
            bf.Serialize(file, json);
            file = File.Create(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/equip.DreamSave");
            json = JsonUtility.ToJson(InventoryManager.Instance.equip);
            bf.Serialize(file, json);
            file = File.Create(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/food.DreamSave");
            json = JsonUtility.ToJson(InventoryManager.Instance.food);
            bf.Serialize(file, json);
            file = File.Create(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/dream.DreamSave");
            json = JsonUtility.ToJson(InventoryManager.Instance.dream);
            bf.Serialize(file, json);
            file = File.Create(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/books.DreamSave");
            json = JsonUtility.ToJson(InventoryManager.Instance.books);
            bf.Serialize(file, json);
            file = File.Create(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/material.DreamSave");
            json = JsonUtility.ToJson(InventoryManager.Instance.materia);
            bf.Serialize(file, json);
            file = File.Create(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/blue_print_and_collectibles.DreamSave");
            json = JsonUtility.ToJson(InventoryManager.Instance.materia);
            bf.Serialize(file, json);
            file = File.Create(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/another.DreamSave");
            json = JsonUtility.ToJson(InventoryManager.Instance.another);
            bf.Serialize(file, json);
            //以上将背包储存完毕
            file = File.Create(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/palyer_attribute.DreamSave");
            json = JsonUtility.ToJson(PlayerAttribute.Instance);
            bf.Serialize(file, json);
            //以上玩家基本数据保存完毕

            //以上进度数据保存完毕

            file.Close();
        }
    }

    /// <summary>
    /// 加载存档
    /// </summary>
    public void loadGame(int len)
    {
        BinaryFormatter bf = new BinaryFormatter();
        //当找到存档就开始读取
        if (File.Exists(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/save_data_data.DreamSave"))
        {
            FileStream file = File.Open(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/save_data_data.DreamSave", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), InventoryManager.Instance.equip_box);
            //以上存档基本数据读取完毕
            file = File.Open(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/equip_box.DreamSave", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),InventoryManager.Instance.equip_box);
            file = File.Open(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/equip.DreamSave", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), InventoryManager.Instance.equip);
            file = File.Open(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/food.DreamSave", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), InventoryManager.Instance.food);
            file = File.Open(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/dream.DreamSave", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), InventoryManager.Instance.dream);
            file = File.Open(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/books.DreamSave", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), InventoryManager.Instance.books);
            file = File.Open(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/material.DreamSave", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), InventoryManager.Instance.materia);
            file = File.Open(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/blue_print_and_collectibles.DreamSave", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), InventoryManager.Instance.blue_print_and_collectibles);
            file = File.Open(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/another.DreamSave", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), InventoryManager.Instance.another);
            //以上读完背包
            file = File.Open(Application.dataPath + "/DreamInThePast/save/save_data" + len.ToString() + "/palyer_attribute.DreamSave", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), PlayerAttribute.Instance);
            file.Close();
            //以上读完玩家基本数据

            //以上读完游戏进度数据

            //读完后刷新背包
            InventoryManager.Instance.loadInventory(InventoryManager.Instance.equip_grid, InventoryManager.Instance.equip);
            InventoryManager.Instance.loadInventory(InventoryManager.Instance.food_grid, InventoryManager.Instance.food);
            InventoryManager.Instance.loadInventory(InventoryManager.Instance.dream_grid, InventoryManager.Instance.dream);
            InventoryManager.Instance.loadInventory(InventoryManager.Instance.books_grid, InventoryManager.Instance.books);
            InventoryManager.Instance.loadInventory(InventoryManager.Instance.materia_grid, InventoryManager.Instance.materia);
            InventoryManager.Instance.loadInventory(InventoryManager.Instance.blue_print_and_collectibles_grid, InventoryManager.Instance.blue_print_and_collectibles);
            InventoryManager.Instance.loadInventory(InventoryManager.Instance.another_grid, InventoryManager.Instance.another);
            InventoryManager.Instance.loadEquipBox();
        }
    }
}