/*
 * 当被点击时，挂载在icon上
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppIcon : MonoBehaviour,ButtonInterface
{
    public GameObject window;

    /// <summary>
    /// 窗体是否创建
    /// </summary>
    public bool is_creat;

    /// <summary>
    /// 是否最大化
    /// </summary>
    public bool is_max;

    string string_pos;//创建的位置

    public GameObject prefab_icon;

    /// <summary>
    /// 当图标被点击
    /// </summary>
    public void isClick()
    {
        //如果当前没有创建
        if (!is_creat)
        {
            GameObject window_perfab = Instantiate(window);
            window_perfab.gameObject.transform.SetParent(GameObject.Find("Canvas/VRPhone").transform);
            window_perfab.GetComponent<RectTransform>().anchoredPosition = new Vector2(SetValue.Instance.default_window_x, -SetValue.Instance.default_window_y);
            window_perfab.GetComponent<WindowButton>().icon = window.GetComponent<WindowButton>().icon;
            string_pos = "Canvas/VRPhone/" + window_perfab.name;

            GameObject have_opened_icon = Resources.Load<GameObject>("Prefabs/App/HavaOpenItem");
            GameObject have_opened_icon_perfab = Instantiate(have_opened_icon);
            have_opened_icon_perfab.gameObject.transform.SetParent(GameObject.Find("Canvas/VRPhone/HaveOpenedSoft/Viewport/Content").transform);
            have_opened_icon_perfab.GetComponent<HaveOpenedItem>().icon = this;
            have_opened_icon_perfab.GetComponent<Image>().sprite=gameObject.GetComponent<Image>().sprite;
            
            prefab_icon = have_opened_icon_perfab;

            is_creat = true;
        }
        else
        {
            GameObject.Find(string_pos).SetActive(true);
        }
    }
}