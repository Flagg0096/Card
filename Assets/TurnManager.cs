using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public static event Action turnEndEvent;
    public TextMeshProUGUI turnText;
    public int turn = 1;
    public Button endTurnButton;


    private void OnEnable()
    {
        endTurnButton.onClick.AddListener(EndTurn);
    }

    private void OnDisable()
    {
        endTurnButton.onClick.RemoveListener(EndTurn);
    }

    private void EndTurn()
    {
        turnEndEvent?.Invoke();
        turn++;
    }

    private void Update()
    {
        turnText.text = "回合" + turn.ToString();
    }
}
