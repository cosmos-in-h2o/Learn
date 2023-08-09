/*
 * 代码作用：
 * 使相机跟随当前操纵角色
 * 挂载：相机
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("相机跟随速度")]
    public float follow_speed=1.0f;//相机跟随速度

    private Vector3 distance;//相机与控制角色的距离

    void Start()
    {
        distance = new Vector3(0,0,-10);//角色与相机的距离
        transform.position = PlayerController.Instance.player.position+distance;//初始先将摄像机位置与角色位置相等
    }

    void Update()
    {
        Vector3 targetCamPos = PlayerController.Instance.player.position+distance;
        // 给摄像机移动到应该在的位置的过程中加上延迟效果
        transform.position = Vector3.Lerp(transform.position, targetCamPos, follow_speed* Time.deltaTime);
    }
}
