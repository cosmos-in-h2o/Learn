/*
 * 玩家设置的数据
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValue : MonoBehaviour
{
	//单例模式
	private static SetValue instance;
	public static SetValue Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType(typeof(SetValue)) as SetValue;
			}
			return instance;
		}
	}

	//默认窗口生成位置
	[Header("窗口坐标")]
	public int default_window_x;

	public int default_window_y;
}
