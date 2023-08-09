/*
 * 代码作用：
 * 根据玩家键盘输入对操纵的对象移动
 * 挂载：玩家操纵对象
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    //单例模式
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(PlayerController)) as PlayerController;
            }
            return instance;
        }
    }

    public Transform player;//角色

    public string now_control_role = Constants.Bright;//当前控制角色,默认为明

    /// <summary>
    /// 改变角色
    /// </summary>
    /// <param name="player">角色名</param>
    public void changePlayer(string player)
    {
        Instance.now_control_role = player;
        Instance.player = GameObject.Find(now_control_role).GetComponent<Transform>();
    }

    /// <summary>
    /// 改变角色
    /// </summary>
    /// <param name="action">改变之前调用的函数</param>
    /// <param name="player">角色名</param>
    public void changePlayer(Action action, string player)
    {
        action();
        Instance.now_control_role = player;
        Instance.player = GameObject.Find(now_control_role).GetComponent<Transform>();
    }

    /// <summary>
    /// 改变角色
    /// </summary>
    /// <param name="player">角色名</param>
    /// <param name="action">改变之后调用的函数</param>
    public void changePlayer(string player,Action action)
    {
        Instance.now_control_role = player;
        Instance.player = GameObject.Find(now_control_role).GetComponent<Transform>();
        action();
    }

    /// <summary>
    /// 改变角色
    /// </summary>
    /// <param name="action1">改变之前调用的函数</param>
    /// <param name="player">角色名</param>
    /// <param name="action2">改变之后调用的函数</param>
    public void changePlayer(Action action1,string player, Action action2)
    {
        action1();
        Instance.now_control_role = player;
        Instance.player = GameObject.Find(now_control_role).GetComponent<Transform>();
        action2();
    }


    void Awake()
    {
        player = GameObject.Find(now_control_role).GetComponent<Transform>();//获取角色
    }

    void Update()
    {
        if (Input.GetKey(InputManager.Instance.Front_key))
        {
            player.transform.Translate(new Vector3(0, 1, 0) * PlayerAttribute.Instance.move_speed * Time.deltaTime);
        }
        if (Input.GetKey(InputManager.Instance.Down_key))
        {
            player.transform.Translate(new Vector3(0, -1, 0) * PlayerAttribute.Instance.move_speed * Time.deltaTime);
        }
        if (Input.GetKey(InputManager.Instance.Right_key))
        {
            player.transform.Translate(new Vector3(1, 0, 0) * PlayerAttribute.Instance.move_speed * Time.deltaTime);
        }
        if (Input.GetKey(InputManager.Instance.Left_key))
        {
            player.transform.Translate(new Vector3(-1, 0, 0) * PlayerAttribute.Instance.move_speed * Time.deltaTime);
        }
    }
}
