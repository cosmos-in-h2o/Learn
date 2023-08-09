/*
 * 代码作用：根据当前的行数来动态改变Content大小
 * 挂载：Content
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
