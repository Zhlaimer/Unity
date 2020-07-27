using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory",menuName ="Inventory/New Inventory")]//背包类型,可用于创建新的背包,也可用于检测背包下的物品
public class Inventory : ScriptableObject
{
    public List<Entity> itemList = new List<Entity>();
    //用于存储列表
}
