using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPhoneUserSoft : MonoBehaviour
{
	//单例模式
	private static VRPhoneUserSoft instance;
	public static VRPhoneUserSoft Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType(typeof(VRPhoneUserSoft)) as VRPhoneUserSoft;
			}
			return instance;
		}
	}

	public Transform grid;//生成位置

	public List<GameObject> user_soft;

    private void Start()
    {
		//开始更新一次
		VRPhoneUserSoft.Instance.updataApp();
    }

    //更新当前界面的软件
    void updataApp()
	{
		//先删除grid下全部子物体
		for (int i = 0; i < VRPhoneUserSoft.Instance.grid.transform.childCount; i++)
		{
			if (VRPhoneUserSoft.Instance.grid.transform.childCount == 0)
				break;
			Destroy(VRPhoneUserSoft.Instance.grid.transform.GetChild(i).gameObject);
		}
		//在重新加载所有物体
		for (int i = 0; i < user_soft.Count; i++)
		{
			GameObject new_item = Instantiate(user_soft[i], VRPhoneUserSoft.Instance.grid.transform.position, Quaternion.identity);
			new_item.gameObject.transform.SetParent(VRPhoneUserSoft.Instance.grid.transform);
		}
	}
}
