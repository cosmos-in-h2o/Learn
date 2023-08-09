/*
 * ���ݵ�ǰ�����ı�VRPhone��������content��С
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPhoneGridSize : MonoBehaviour
{
    public enum GridType
    {
        User,
        System,
        HaveOpened
    }

    public GridType grid_type;
    
    public RectTransform rect;

    private void Update()
    {
        //����ǰ��grid����Ϊ�û����ʱ
        if (grid_type == GridType.User)
        {
            rect.sizeDelta = new Vector2(1200, (transform.childCount - 1) / 8 * 150 + 150);
        }
        else if (grid_type == GridType.System)
        {
            rect.sizeDelta = new Vector2(150, transform.childCount * 150);
        }
        else if (grid_type == GridType.HaveOpened)
        {
            rect.sizeDelta = new Vector2(transform.childCount * 150, 150);
        }
    }
}
