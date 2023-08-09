/*
 * 代码作用：
 * 计算玩家当前的属性
 * 挂载：主控组件上
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttribute : MonoBehaviour
{
    //单例模式
    private static PlayerAttribute instance;
    public static PlayerAttribute Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(PlayerAttribute)) as PlayerAttribute;
            }
            return instance;
        }
    }

    public event Action onEXPChange;//在经验改变时
    public event Action onLevelChange;//在等级改变时
    public event Action onHPChange;//在当前血量改变时
    public event Action onDPChange;//在当前DP改变时

    [SerializeField]
    private int levels=0;//等级
    public int Levels
    {
        get 
        {
            return levels; 
        }
        set
        {
            levels = value;
            onLevelChange?.Invoke();
        }
    }

    [SerializeField]
    private int exp=0;//当前经验值
    public int EXP
    {
        get 
        {
            return exp; 
        }
        set 
        { 
            exp = value;
            onEXPChange?.Invoke();
        }
    }

    public int next_levels_need_EXP=1000;//下一级所需经验值

    public int all_of_EXP =0;//所有经验值

    public float ATK;//攻击力

    [SerializeField]
    private float now_HP=100;//当前生命值
    public float Now_HP
    {
        get 
        {
            return now_HP;
        }
        set
        {
            now_HP = value;
            onHPChange?.Invoke();
        }
    }

    public float max_HP=100;//最大生命值

    [SerializeField]
    private float now_DP=100;//当前梦境力
    public float Now_DP
    {
        get
        {
            return now_DP;
        }
        set
        {
            now_DP = value;
            onDPChange?.Invoke();
        }
    }

    public float max_DP=100;//最大梦境力

    public float move_speed = 5.0f;

    private void Start()
    {
        //注册委托
        Instance.onEXPChange = Instance.countLevels;
        Instance.onEXPChange += () => { Debug.Log("经验值改变了"); };

        Instance.onLevelChange = () =>
        {
            if (Instance.Levels < 0)
                Instance.Levels = 0;
        };

        Instance.onHPChange = () =>
        {
            if (Instance.Now_HP > Instance.max_HP)
                Instance.Now_HP = Instance.max_HP;
            if (Instance.Now_HP < 0)
                Instance.Now_HP = 0;
        };

        Instance.onDPChange = () =>
        {
            if (Instance.Now_DP >= Instance.max_DP)
                Instance.Now_DP = max_DP;
            if (Instance.Now_DP <= 0)
                Instance.Now_DP = 0;
        };

        Instance.EXP += 1000;

        //初始化升级所需经验
        if (levels >= 0 && levels < 80)
        {
            next_levels_need_EXP = 10 * levels * levels + 1000;
        }
        else if(levels>=80&&levels<100)
        {
            next_levels_need_EXP=2*levels * levels + 200000;
        }
    }

    //计算等级
    public void countLevels()
    {
        //当前等级大于等于一小于八十
        if (Instance.Levels >=0&& Instance.Levels < 80)
        {
            //达到升级条件
            if(Instance.EXP >= Instance.next_levels_need_EXP)
            {
                float hp = Instance.Now_HP / Instance.max_HP;//当前HP百分比
                float dp = Instance.Now_DP / Instance.max_DP;//当前DP百分比
                //(使用exp越过委托)
                Instance.exp = Instance.exp - Instance.next_levels_need_EXP;//当前经验值减去所需经验值
                Instance.Levels += 1;//等级加一
                //此处写maxhp和maxdp的变化


                Instance.next_levels_need_EXP = Instance.next_levels_need_EXP = 10 * Instance.Levels * Instance.Levels + 1000;//刷新所需经验值
                Instance.Now_HP = hp * Instance.max_HP;
                Instance.now_DP = dp * Instance.max_DP;
            }
        }
        else if (Instance.Levels >= 80 && Instance.Levels < 100)
        {
            //达到升级条件
            if (Instance.EXP >= Instance.next_levels_need_EXP)
            {
                float hp = Instance.Now_HP / Instance.max_HP;//当前HP百分比
                float dp = Instance.Now_DP / Instance.max_DP;//当前DP百分比
                //(使用exp越过委托)
                Instance.exp = Instance.exp - Instance.next_levels_need_EXP;//当前经验值减去所需经验值
                Instance.Levels += 1;//等级加一
                //此处写maxhp和maxdp的变化


                Instance.next_levels_need_EXP = Instance.next_levels_need_EXP = 2 * Instance.Levels * Instance.Levels + 200000;//刷新所需经验值
                Instance.Now_HP = hp * Instance.max_HP;
                Instance.now_DP = dp * Instance.max_DP;
            }
        }
    }

    /* 
     * 造成伤害计算公式
     * (((武器攻击力*（1+遗失之梦武器攻击力加成)+角色攻击力*(1+遗失之梦角色攻击力加成))
     * *(1+遗失之梦伤害加成或者其他伤害加成))*(1+暴击伤害))*倍率
     */

    /*
     * 变量名解释
     * weapons_ATK 武器攻击力
     * player_ATK 角色攻击力
     * multiplier 伤害倍率
     * crit_damage 暴击伤害倍率
     * is_crit 是否造成暴击
     * lost_dreams_weapons_ATK 遗失之梦加成的武器攻击力
     * lost_dreams_player_ATK 遗失之梦加成的角色攻击力
     * lost_dreams_damage 遗失之梦加成的伤害
     */
    //造成计算函数(不带遗失之梦的加成)
    public float injury(float weapons_ATK, float player_ATK, float multiplier, float crit_damage, bool is_crit)
    {

        crit_damage += 1;

        //如果暴击
        if (is_crit == true)
            return ((weapons_ATK + player_ATK) * crit_damage) * multiplier;
        //没有暴击
        else
            return (weapons_ATK + player_ATK) * multiplier;
    }

    //造成伤害计算函数(带遗失之梦的加成)
    public float injury(float weapons_ATK, float player_ATK, float multiplier, float crit_damage, bool is_crit, float lost_dreams_weapons_ATK, float lost_dreams_player_ATK, float lost_dreams_damage)
    {

        crit_damage += 1;

        lost_dreams_damage += 1;

        lost_dreams_player_ATK += 1;

        lost_dreams_weapons_ATK += 1;

        //如果暴击
        if (is_crit == true)
            return (((weapons_ATK * lost_dreams_weapons_ATK + player_ATK * lost_dreams_player_ATK) * lost_dreams_damage) * crit_damage) * multiplier;
        //没有暴击
        else
            return (weapons_ATK + player_ATK) * multiplier;
    }
}