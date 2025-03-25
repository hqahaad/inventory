using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI nameText;

    void Start()
    {
        var player = GameManager.Instance.Player;

        nameText.text = player.Name;
        goldText.text = player.Gold.ToString();
        levelText.text = player.Level.ToString();

        player.OnStatusChanged += Bind;
    }

    private void Bind(Character character)
    {
        levelText.text = character.Level.ToString();
        goldText.text = character.Gold.ToString();
    }
}
