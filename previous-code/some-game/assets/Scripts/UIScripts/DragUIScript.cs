/*
 * 拖拽窗体
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUIScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,ButtonInterface
{
    RectTransform rt;

    // 最小、最大X、Y坐标
    float minX, maxX, minY, maxY;

    // 位置偏移量
    Vector3 offset = Vector3.zero;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    /// <summary>
    /// 当窗体被点击
    /// </summary>
    public void isClick()
    {
        //把窗体层级设为最上层
        gameObject.transform.SetAsLastSibling();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.enterEventCamera, out Vector3 globalMousePos))
        {
            // 计算偏移量
            offset = rt.position - globalMousePos;
        }

        GameObject.Find("Canvas/VRPhone/UserSoft/Viewport/Content/" + gameObject.GetComponent<WindowButton>().icon + "(Clone)").GetComponent<AppIcon>().is_max = false;
        gameObject.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 将屏幕空间上的点转换为位于给定RectTransform平面上的世界空间中的位置
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out Vector3 globalMousePos))
        {
            // 设置拖拽范围
            rt.position = globalMousePos + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
    // 设置最大、最小坐标
    void SetDragRange()
    {
        minX = rt.rect.width * rt.pivot.x;
        maxX = Screen.width - rt.rect.width * (1 - rt.pivot.x);
        minY = rt.rect.height * rt.pivot.y;
        maxY = Screen.height - rt.rect.height * (1 - rt.pivot.y);
    }

    // 限制坐标范围
    Vector3 DragRangeLimit(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        return pos;
    }

}