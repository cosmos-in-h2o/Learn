/*
 * 已经打开的窗体所创建的快捷方式
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveOpenedItem : MonoBehaviour
{
    public AppIcon icon;

    /// <summary>
    /// 当被点击
    /// </summary>
    public void isClick()
    {
        icon.isClick();
    }
}
