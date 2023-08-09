/*
* 主控脚本
* 挂载MyGameManager上
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    //单例模式
    private static MyGameManager instance;
    public static MyGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(MyGameManager)) as MyGameManager;
            }
            return instance;
        }
    }
    
    //游戏总进程
    [System.Serializable]
    public struct GameIndex
    {
        /// <summary>
        /// 当前是否为往事
        /// </summary>
        public bool is_past;
        /// <summary>
        /// 主线
        /// </summary>
        public int index_main;
    }

    public GameIndex game_index;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        if(Instance.game_index.is_past)
        {
            UIManager.Instance.past_volume.gameObject.SetActive(true);
        }
        else
        {
            UIManager.Instance.past_volume.gameObject.SetActive(false);
        }
    }

    public void chanageMode()
    {
        Instance.game_index.is_past = true;
        UIManager.Instance.past_volume.gameObject.SetActive(true);
    }
}