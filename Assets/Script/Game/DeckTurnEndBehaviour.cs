using System;
using System.Collections;
using UnityEngine;

public class DeckTurnEndBehaviour : MonoBehaviour
{
    public DeckManager deckManager;
    private void OnEnable()
    {
        TurnManager.turnEndEvent += OnTurnEndEvent;
    }

    private void OnDisable()
    {
        TurnManager.turnEndEvent -= OnTurnEndEvent;
    }

    private void OnTurnEndEvent()
    {
        deckManager.DiscardHand();
        StartCoroutine(deckManager.DrawHand());
    }
}
