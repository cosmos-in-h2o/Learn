/*
 * ������õ�����
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValue : MonoBehaviour
{
	//����ģʽ
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

	//Ĭ�ϴ�������λ��
	[Header("��������")]
	public int default_window_x;

	public int default_window_y;
}
