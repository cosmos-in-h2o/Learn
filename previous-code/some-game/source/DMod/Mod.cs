using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DMod
{
    public class Mod
    {
        /// <summary>
        /// 当前HP
        /// </summary>
        public static float HP
        {
            get{ return PlayerAttribute.Instance.Now_HP;}
            set{ PlayerAttribute.Instance.Now_HP = value; }
        }
        /// <summary>
        /// 当前DP
        /// </summary>
        public static float DP
        {
            get { return PlayerAttribute.Instance.Now_DP; }
            set { PlayerAttribute.Instance.Now_DP = value; }
        }
        /// <summary>
        /// 将创建的item添加
        /// </summary>
        /// <param name="item">创建的item</param>
        public static void addItem_1(Item_1 item)
        {
            
        }
        /// <summary>
        /// 将创建的item添加
        /// </summary>
        /// <param name="item">创建的item</param>
        public static void addItem_2(Item_2 item)
        {

        }
        /// <summary>
        /// 将创建的item添加
        /// </summary>
        /// <param name="item">创建的item</param>
        public static void addItem_3(Item_3 item)
        {

        }
    }
    public class Item_1:Item
    {
    }
    public class Item_2:ItemOfEquip
    {
    }
    public class Item_3:ItemOfDream
    {
    }
}