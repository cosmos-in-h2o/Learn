/* 
 * 代码作用：
 * 作为一个武器类封装了一些基础属性，可用于创建武器对象和继承
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dream.Scripts.ThingScripts.Weapons
{
    //武器类
    public class Weapons
    {
        string name;//武器名称
        float weapons_ATK;//武器攻击力

        //构造函数
        public Weapons()
        {
            name = "weapon";
            weapons_ATK = 0f;
        }
        //传参的构造函数
        public Weapons(string m_Name,float m_Attack)
        {
            name = m_Name;
            weapons_ATK = m_Attack;
        }
    }
}