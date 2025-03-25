using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour, IUIView
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    private Canvas canvas;

    void Awake() => canvas = GetComponent<Canvas>();

    void Start()
    {
        statusButton.onClick.AddListener(UIManager.Instance.OpenStatus);
        inventoryButton.onClick.AddListener(UIManager.Instance.OpenInventory);
    }

    public void Show() => canvas.enabled = true;
    public void Hide() => canvas.enabled = false;
}
