using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform originalParent;

    public Inventory myBag;
    private int currentItemId;
    //此脚本用于实现拖拽
    //使用接口分别是开始拽，拽的过程，结束拽，需要生成方法
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;//transform.parent也就是slot
        currentItemId = originalParent.GetComponent<Slot>().SlotId;//获得slot里的slot组件里的slotID

        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;//物品位置等于鼠标位置
                                                //会出现拖拽时图标被其他图标挡住，原因：渲染层次问题，解决：拖拽开始后将图标设置成父级的父级

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
     
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        //拖动时，图标会挡住鼠标的射线，所以在开始时设置false
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);//打印出鼠标射线检测下的物体名称

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject!=null)//判断是不是空即不    属于UI，比如地图，可用else实现丢弃功能
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "Image")
            {
                //Image显示在最上层，所以如果检测到名称有Image，即检测到格子里有物体
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;//将物体放入方格

                //itemList的物品存储位置改变
                var temp = myBag.itemList[currentItemId];
                myBag.itemList[currentItemId] = myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().SlotId];

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;//射线阻挡开启，否则无法再次选中移动的物品
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.name == "Slot(Clone)")//防止图标移到其他地方回不来
            {
                //否则直接挂在检测到的slot下面
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //itemList的物品存储位置改变
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().SlotId] = myBag.itemList[currentItemId];
                //解决自己放在自己的位置问题，当拖拽自己但放在自己原本的格子里时会消失
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().SlotId != currentItemId)
                {
                    myBag.itemList[currentItemId] = null;
                }
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
        //在其他任何位置都归位
        transform.SetParent(originalParent);
        transform.position = originalParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
