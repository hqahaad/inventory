using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Character Player { get; private set; }

    public ItemData[] itemTests;

    protected override void Awake()
    {
        base.Awake();
        SetData();
    }

    public void SetData()
    {
        var character = new Character(10, "Chad", 35, 40, 100, 25);
        Player = character;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Player.Inventory.AddItem(itemTests[Random.Range(0, itemTests.Length)]);
        }
    }
}
