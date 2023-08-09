/*
 * 代码作用：
 * 改变全局光照的时间
 * 挂载：光源
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using FunkyCode;
using UnityEngine;
using DG.Tweening;

public class LightTime : MonoBehaviour
{
    public LightCycle light_cycle;
    private void Update()
    {
        light_cycle.time = (float)GameTime.Instance.time_in_game / (float)GameTime.Instance.period;
    }
}
