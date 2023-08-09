/*
 * 系统应用脚本
 * 挂载在系统icon上
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemAppIcon : MonoBehaviour,ButtonInterface
{
    public Transform window;//窗口的位置

    /// <summary>
    /// 当被点击打开对应窗口
    /// </summary>
    public void isClick()
    {
        //window.SetAsLastSibling();
        window.gameObject.SetActive(true);
    }
}
