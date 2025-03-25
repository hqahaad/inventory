using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public const int maxSlotCount = 50;

    private List<InventorySlot> inventorySlots = new();

    public event Action<InventorySlot, int> OnChangedSlot = delegate { };
    public int inventoryCount { get; private set; }

    public Inventory()
    {
        for (int i = 0; i < maxSlotCount; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddItem(ItemData item)
    {
        if (inventoryCount >= inventorySlots.Count)
            return false;

        var idx = inventorySlots.FindIndex(s => s.IsEmpty);

        if (idx == -1)
            return false;

        inventorySlots[idx].Add(ItemData.Create(item));
        inventoryCount++;

        OnChangedSlot?.Invoke(inventorySlots[idx], idx);

        return true;
    }

    public void EquipToggle(int index)
    {
        if (index < 0 || index >= inventorySlots.Count)
            return;

        if (inventorySlots[index].ItemInstance != null && inventorySlots[index].ItemInstance.IsEquip)
            UnEquip(index);
        else
            Equip(index);
    }

    public void Equip(int index)
    {
        if (inventorySlots[index].IsEmpty)
            return;

        var item = inventorySlots[index].ItemInstance;
        var player = GameManager.Instance.Player;

        item.IsEquip = true;

        player.AttackPower += item.attackPower;
        player.Defensive += item.defensive;
        player.Hp += item.hp;
        player.Critical += item.critical;

        OnChangedSlot?.Invoke(inventorySlots[index], index);
    }

    public void UnEquip(int index)
    {
        if (inventorySlots[index].IsEmpty)
            return;

        var item = inventorySlots[index].ItemInstance;
        var player = GameManager.Instance.Player;

        item.IsEquip = false;

        player.AttackPower -= item.attackPower;
        player.Defensive -= item.defensive;
        player.Hp -= item.hp;
        player.Critical -= item.critical;

        OnChangedSlot?.Invoke(inventorySlots[index], index);
    }
}

public class InventorySlot
{
    public ItemInstance ItemInstance { get; private set; } = null;
    public bool IsEmpty { get; private set; } = true;

    public void Add(ItemInstance itemInstance)
    {
        if (IsEmpty)
        {
            ItemInstance = itemInstance;
            IsEmpty = false;
        }
    }

    public void Remove()
    {
        IsEmpty = true;
    }
}
