/*
 * 退出游戏
 */

using UnityEngine;

public class BackButton : MonoBehaviour, ButtonInterface
{
    public void isClick()
    {
        //退出
        Application.Quit();
    }
}
