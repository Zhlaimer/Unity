using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/New Item")]//物品的属性
public class Entity : ScriptableObject
{
    public string itemName;//物品名
    public Sprite itemImage;//物品图
    public int itemHeld;//物品持有个数
    [TextArea]
    public string itemInformation;//物品描述

    public bool eqiup;//物品是否为装备
}
