using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private UIMainMenu mainMenuView;
    [SerializeField] private UIInventory inventoryView;
    [SerializeField] private UIStatus statusView;

    void Start()
    {
        inventoryView?.Hide();
        statusView?.Hide();
    }

    public void OpenMainMenu()
    {
        inventoryView.Hide();
        statusView.Hide();

        mainMenuView.Show();
    }

    public void OpenStatus()
    {
        mainMenuView.Hide();
        inventoryView.Hide();

        statusView.Show();
    }

    public void OpenInventory()
    {
        mainMenuView.Hide();
        statusView.Hide();

        inventoryView.Show();
    }
}
