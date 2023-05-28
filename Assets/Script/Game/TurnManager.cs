using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public UINumberBar numberBar;
    public static event Action turnEndEvent;
    public int turn = 1;
    public Button endTurnButton;


    private void OnEnable()
    {
        endTurnButton.onClick.AddListener(EndTurn);
        numberBar.inputField.onValueChanged.AddListener(delegate { SetTurn(numberBar.value); });
    }

    private void OnDisable()
    {
        endTurnButton.onClick.RemoveListener(EndTurn);
        numberBar.inputField.onValueChanged.RemoveListener(delegate { SetTurn(numberBar.value); });
    }

    void SetTurn(int value)
    {
        turn = value;
    }

    private void EndTurn()
    {
        turnEndEvent?.Invoke();
        turn++;
    }

    private void Update()
    {
        numberBar.SetValue(turn);
    }
}
