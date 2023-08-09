using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	//单例模式
	private static UIManager instance;
	public static UIManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType(typeof(UIManager)) as UIManager;
			}
			return instance;
		}
	}

	/// <summary>
	/// 过去的滤镜
	/// </summary>
	public Transform past_volume;


	public List<Transform> tap_list = new List<Transform>();
	public void addTapInList(Transform transform)
	{
		transform.gameObject.SetActive(true);
		Instance.tap_list.Add(transform);
	}

	/// <summary>
	/// 移除选项卡里的元素
	/// </summary>
	/// <param name="action">如果选项卡没有元素调用</param>
	public void removeTapInList(Action action)
	{
		if (Instance.tap_list.Count > 0)
		{
			tap_list[tap_list.Count - 1].gameObject.SetActive(false);
			tap_list.RemoveAt(tap_list.Count - 1);
		}
		else
		{
			action();
		}
	}

	/// <summary>
	/// 移除选项卡里的元素
	/// </summary>
	/// <param name="action1">如果选项卡没有元素调用</param>
	/// <param name="action2">完成操作后回调函数</param>
	public void removeTapInList(Action action1,Action action2)
	{
		if (Instance.tap_list.Count > 0)
		{
			tap_list[tap_list.Count - 1].gameObject.SetActive(false);
			tap_list.RemoveAt(tap_list.Count - 1);
		}
		else
		{
			action1();
		}
		action2();
	}

	/// <summary>
	/// 移除选项卡里的元素
	/// </summary>
	/// <param name="action">如果选项卡没有元素调用</param>
	/// <param name="transform">移除指定元素</param>
	public void removeTapInList(Action action,Transform transform)
    {
		if(Instance.tap_list.Count>0)
        {
			transform.gameObject.SetActive(false);
			for (int i = Instance.tap_list.IndexOf(transform); i < Instance.tap_list.Count; i++)
			{
				Instance.tap_list.RemoveAt(i);
			}
		}
        else 
		{
			action();
		}
	}

	/// <summary>
	/// 移除选项卡里的元素
	/// </summary>
	/// <param name="action1">如果选项卡没有元素调用</param>
	/// <param name="transform">移除指定元素</param>
	/// <param name="action2">完成操作后回调函数</param>
	public void removeTapInList(Action action1, Transform transform,Action action2)
	{
		if (Instance.tap_list.Count > 0)
		{
			transform.gameObject.SetActive(false);
			for (int i = Instance.tap_list.IndexOf(transform); i < Instance.tap_list.Count; i++)
			{
				Instance.tap_list.RemoveAt(i);
			}
		}
		else
		{
			action1();
		}
		action2();
	}
}