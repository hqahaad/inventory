using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour, IUIView
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private TextMeshProUGUI inventoryCountText;

    private List<UISlot> slots = new();
    private Canvas canvas;

    void Start()
    {
        InitInventory();
        GameManager.Instance.Player.Inventory.OnChangedSlot += UpdateUI;
    }

    private void InitInventory()
    {
        for (int i = 0; i < Inventory.maxSlotCount; i++)
        {
            int index = i;

            slots.Add(Instantiate(slotPrefab, slotParent).GetComponent<UISlot>());
            slots[i].Button.onClick.AddListener(() => GameManager.Instance.Player.Inventory.EquipToggle(index));
        }

        inventoryCountText.text = $"{GameManager.Instance.Player.Inventory.inventoryCount} / {Inventory.maxSlotCount}";
    }

    private void UpdateUI(InventorySlot slot, int index)
    {
        if (index >= slots.Count)
            return;

        slots[index].SetItem(slot.ItemInstance);

        var inven = GameManager.Instance.Player.Inventory;

        inventoryCountText.text = $"{inven.inventoryCount} / {Inventory.maxSlotCount}";
    }

    void Awake() => canvas = GetComponent<Canvas>();

    public void Show() => canvas.enabled = true;
    public  void Hide() => canvas.enabled = false;
}
