using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class ItemData : ScriptableObject
{
    public Sprite itemIcon;

    public float attackPower;
    public float defensive;
    public float hp;
    public float critical;

    public static ItemInstance Create(ItemData itemData)
    {
        return new ItemInstance(itemData);
    }
}

public class ItemInstance
{
    public bool IsEquip { get; set; } = false;

    public Sprite itemIcon;
    public float attackPower;
    public float defensive;
    public float hp;
    public float critical;

    public ItemInstance(ItemData data)
    {
        itemIcon = data.itemIcon;

        attackPower = data.attackPower;
        defensive = data.defensive;
        hp = data.hp;
        critical = data.critical;
    }
}