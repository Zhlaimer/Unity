using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager _instance;

    public Inventory myBag;
    public GameObject slotGrid;//创建好的格
    //public Slot slotPrefab;//预制体
    public GameObject emptySlot;

    public Text itemInform;

    public List<GameObject> slots = new List<GameObject>();//保存18个格子

    private void Awake()
    {
        if (_instance!=null)
        {
            Destroy(this);
        }
            _instance = this;
    }
    private void OnEnable()
    {
        RefreshItem();
        _instance.itemInform.text = "";
    }
    public static void UpdateInfo(string itemDescription)
    {
        _instance.itemInform.text = itemDescription;
    }

    /*public static void CreateNewItem(Entity item)//在背包中创建新的
    {
        Slot newItem = Instantiate(_instance.slotPrefab,_instance.slotGrid.transform.position,Quaternion.identity);
        newItem.gameObject.transform.SetParent(_instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }*/
    public static void RefreshItem()
    {
        //循环删除slotGrid下的子集物体
        for (int i=0;i<_instance.slotGrid.transform.childCount;i++)
        {
            if (_instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(_instance.slotGrid.transform.GetChild(i).gameObject);
            _instance.slots.Clear();//
        }
        //重新生成对应myBag里面的物体的slot
        for (int i=0;i<_instance.myBag.itemList.Count;i++)
        {
            // CreateNewItem(_instance.myBag.itemList[i]);
            _instance.slots.Add(Instantiate(_instance.emptySlot));//生成空格子
            _instance.slots[i].transform.SetParent(_instance.slotGrid.transform);//摆放位置
            _instance.slots[i].GetComponent<Slot>().SlotId = i;
            _instance.slots[i].GetComponent<Slot>().SetupSlot(_instance.myBag.itemList[i]);
        }
    }
}
