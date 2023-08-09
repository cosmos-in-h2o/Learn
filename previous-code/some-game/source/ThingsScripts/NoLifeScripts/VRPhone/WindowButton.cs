using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowButton : MonoBehaviour
{
    /// <summary>
    /// 对应图标名字
    /// </summary>
    public string icon;

    /// <summary>
    /// 关闭窗口函数
    /// </summary>
    public void closeWindow()
    {
        GameObject.Find("Canvas/VRPhone/UserSoft/Viewport/Content/"+icon + "(Clone)").GetComponent<AppIcon>().is_creat=false;
        Destroy(gameObject);
        Destroy(GameObject.Find("Canvas/VRPhone/UserSoft/Viewport/Content/" + icon + "(Clone)").GetComponent<AppIcon>().prefab_icon);
    }

    /// <summary>
    /// 最大化函数
    /// </summary>
    public void MaxChange()
    {
        if (!GameObject.Find("Canvas/VRPhone/UserSoft/Viewport/Content/" + icon + "(Clone)").GetComponent<AppIcon>().is_max)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            gameObject.GetComponent<RectTransform>().localScale = new Vector2(1.333333f, 1.333333f);
            GameObject.Find("Canvas/VRPhone/UserSoft/Viewport/Content/" + icon + "(Clone)").GetComponent<AppIcon>().is_max = true;
        }
        else
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(SetValue.Instance.default_window_x, -SetValue.Instance.default_window_y);
            gameObject.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            GameObject.Find("Canvas/VRPhone/UserSoft/Viewport/Content/" + icon+ "(Clone)").GetComponent<AppIcon>().is_max = false;
        }
    }

    /// <summary>
    /// 最小化
    /// </summary>
    public void MinChange()
    {
        gameObject.SetActive(false);
    }
}
