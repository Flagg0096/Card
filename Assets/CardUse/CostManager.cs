using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostManager : MonoBehaviour
{
    public TextMeshProUGUI costText;
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
    }

    private void OnDisable()
    {
        TurnManager.turnEndEvent -= OnTurnEndEvent;

    }

    // Start is called before the first frame update
    void Start()
    {
        ResetCost();
    }

    // Update is called once per frame
    void Update()
    {
        costText.text = "费用" + remainCost.ToString();
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
}
