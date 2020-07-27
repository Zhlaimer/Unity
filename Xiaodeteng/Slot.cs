using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int SlotId;//编号=物品ID，实现真正的交换，否则捡到物体后又会变成正常顺序

    //该类用于显示物品的名称和个数
    public Entity slotItem;//名字
    public Image slotImage;
    public Text slotNum;

    public string SlotInfo;
    public GameObject itemInSlot;//预制体下的item

    public void ItemOnClick()
    {
        InventoryManager.UpdateInfo(SlotInfo);
    }

    public void SetupSlot(Entity item)
    {
        if (item==null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        SlotInfo = item.itemInformation;
    }
}
