using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private RectTransform equipImage;
    [SerializeField] private Button button;

    public Button Button => button;

    public void SetItem(ItemInstance item)
    {
        itemIcon.sprite = item.itemIcon;
        equipImage.gameObject.SetActive(item.IsEquip ? true : false);
    }

    public void RefreshUI()
    {

    }
}
