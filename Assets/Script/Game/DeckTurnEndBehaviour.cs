using System;
using System.Collections;
using UnityEngine;

public class DeckTurnEndBehaviour : MonoBehaviour
{
    GameManager gameManager;
    DeckManager deckManager;
    private void OnEnable()
    {
        TurnManager.turnEndEvent += OnTurnEndEvent;
    }

    private void OnDisable()
    {
        TurnManager.turnEndEvent -= OnTurnEndEvent;
    }

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        deckManager = FindAnyObjectByType<DeckManager>();
    }

    private void OnTurnEndEvent()
    {
        deckManager.DiscardHand();
        StartCoroutine(deckManager.DrawCard(gameManager.drawAmount));
    }
}
