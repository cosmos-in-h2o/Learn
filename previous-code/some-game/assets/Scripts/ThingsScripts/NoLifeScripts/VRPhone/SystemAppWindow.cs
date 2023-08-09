/*
 * 系统应用的窗口管理
 * 挂载在系统应用的窗口上
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemAppWindow : MonoBehaviour,ButtonInterface
{
    public void closeWindow()
    {
        gameObject.SetActive(false);
    }
    public void isClick()
    {
        gameObject.transform.SetAsLastSibling();
    }
}
