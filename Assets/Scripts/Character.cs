using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }

    private int level;
    public int Level
    {
        get => level;
        set
        {
            level = value;
            OnStatusChanged?.Invoke(this);
        }
    }

    private int gold;
    public int Gold
    {
        get => gold;
        set
        {
            gold = value;
            OnStatusChanged?.Invoke(this);
        }
    }

    private float attackPower;
    public float AttackPower
    {
        get => attackPower;
        set
        {
            attackPower = value;
            OnStatusChanged?.Invoke(this);
        }
    }

    private float defensive;
    public float Defensive
    {
        get => defensive;
        set
        {
            defensive = value;
            OnStatusChanged?.Invoke(this);
        }
    }

    private float hp;
    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
            OnStatusChanged?.Invoke(this);
        }
    }

    private float critical;
    public float Critical
    {
        get => Mathf.Clamp(critical, 0f, 100f);
        set 
        {
            critical = value;
            OnStatusChanged?.Invoke(this);
        }
    }

    public event Action<Character> OnStatusChanged = delegate { };

    private Inventory inventory = new();
    public Inventory Inventory => inventory;

    public Character(int level, string name, float attackPower, float defensive, float hp, float critical)
    {
        inventory = new();

        Level = level;
        Name = name;
        AttackPower = attackPower;
        Defensive = defensive;
        Hp = hp;
        Critical = critical;
    }
}