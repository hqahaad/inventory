using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour, IUIView
{
    [SerializeField] private TextMeshProUGUI statusText;

    private Canvas canvas;

    void Awake() => canvas = GetComponent<Canvas>();
    void Start()
    {
        var player = GameManager.Instance.Player;
        statusText.text = $"ATT {player.AttackPower}\nDEF {player.Defensive}\nHP {player.Hp}\nCRIT {player.Critical}";

        player.OnStatusChanged += (p) =>
        {
            statusText.text = $"ATT {p.AttackPower}\nDEF {p.Defensive}\nHP {p.Hp}\nCRIT {p.Critical}";
        };
    }

    public void Show() => canvas.enabled = true;
    public void Hide() => canvas.enabled = false;
}
