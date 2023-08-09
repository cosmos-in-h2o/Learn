/*
 * 代码作用：
 * 计时
 * 挂载：GameTime物体上
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
	//单例模式
	private static GameTime instance;
	public static GameTime Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType(typeof(GameTime)) as GameTime;
			}
			return instance;
		}
	}

	[Tooltip("游戏时间")]
	public int time_in_game;

	[Tooltip("一个周期,单位为秒")]
	public int period = 1440;

	[Tooltip("开始时间，单位是小时")]
	public int start_time = 8;

	[Tooltip("过了几天")]
	public int day = 0;

	[Tooltip("游玩时间")]
	public int all_time_in_game = 0;

	void Start()
	{
		time_in_game = start_time * (period / 24);//当前时间设为开始时间
		StartCoroutine(TimeFlow());
	}

	IEnumerator TimeFlow()//计时器函数
	{
		while (true)
		{
			yield return new WaitForSeconds(1);

			if (time_in_game < period)//还在周期中
			{
				time_in_game += 1;
				all_time_in_game += 1;
			}
			else//如果完成了一个循环
			{
				time_in_game = 0;//归零

				day += 1;//天数加1
			}
		}
	}
}