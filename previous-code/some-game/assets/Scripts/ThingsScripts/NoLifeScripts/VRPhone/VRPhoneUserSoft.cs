using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPhoneUserSoft : MonoBehaviour
{
	//����ģʽ
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

	public Transform grid;//����λ��

	public List<GameObject> user_soft;

    private void Start()
    {
		//��ʼ����һ��
		VRPhoneUserSoft.Instance.updataApp();
    }

    //���µ�ǰ��������
    void updataApp()
	{
		//��ɾ��grid��ȫ��������
		for (int i = 0; i < VRPhoneUserSoft.Instance.grid.transform.childCount; i++)
		{
			if (VRPhoneUserSoft.Instance.grid.transform.childCount == 0)
				break;
			Destroy(VRPhoneUserSoft.Instance.grid.transform.GetChild(i).gameObject);
		}
		//�����¼�����������
		for (int i = 0; i < user_soft.Count; i++)
		{
			GameObject new_item = Instantiate(user_soft[i], VRPhoneUserSoft.Instance.grid.transform.position, Quaternion.identity);
			new_item.gameObject.transform.SetParent(VRPhoneUserSoft.Instance.grid.transform);
		}
	}
}
