/*
 * �������ã����ݵ�ǰ����������̬�ı�Content��С
 * ���أ�Content
 */

using UnityEngine;

public class BagGridSize : MonoBehaviour
{
    public RectTransform rect;

    private void Update()
    {
        rect.sizeDelta = new Vector2(1000, (transform.childCount-1)/10*100+100);
        //Debug.Log((transform.childCount-1) / 10);
    }
}
