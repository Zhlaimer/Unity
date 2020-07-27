using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnShow : MonoBehaviour
{
    public Entity thisItem;
    public Inventory playerInventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }
    
    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))//判断是否包含，如果包含则数量+1，反之添加进列表
        {
            //playerInventory.itemList.Add(thisItem);
            //InventoryManager.CreateNewItem(thisItem);
            for (int i=0;i<playerInventory.itemList.Count;i++)
            {
                if (playerInventory.itemList[i]==null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
    }
}
