using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostManager : MonoBehaviour
{
    public UINumberBar numberBar;
    public int initCost = 3;
    private int remainCost;

    internal bool CanUse(int cost)
    {
        return remainCost >= cost;
    }

    internal void Use(int cost)
    {
        remainCost -= cost;
    }

    private void OnEnable()
    {
        TurnManager.turnEndEvent += OnTurnEndEvent;
        numberBar.inputField.onValueChanged.AddListener(delegate { SetCost(numberBar.value); });
    }

    private void OnDisable()
    {
        TurnManager.turnEndEvent -= OnTurnEndEvent;
        numberBar.inputField.onValueChanged.RemoveListener(delegate { SetCost(numberBar.value); });
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetCost();
    }

    // Update is called once per frame
    void Update()
    {
        numberBar.SetValue(remainCost);
    }

    void SetCost(int value)
    {
        remainCost = value;
    }

    [ContextMenu("ResetCost")]
    private void ResetCost()
    {
        remainCost = initCost;
    }


    private void OnTurnEndEvent()
    {
        ResetCost();
    }

    public void AddCost(int value)
    {
        remainCost += value;
    }
}
