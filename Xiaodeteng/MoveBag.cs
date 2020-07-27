using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBag : MonoBehaviour,IDragHandler
{
    RectTransform currenRect;
    public void OnDrag(PointerEventData eventData)
    {
        currenRect.anchoredPosition += eventData.delta;
            //移动中心锚点坐标
    }

    private void Awake()
    {
        currenRect = GetComponent<RectTransform>();
    }
}
