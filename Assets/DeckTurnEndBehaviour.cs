using System;
using System.Collections;
using UnityEngine;

public class DeckTurnEndBehaviour : MonoBehaviour
{
    public DeckManager deckManager;
    public GameManager gameManager;

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
        StartCoroutine(Draw());
    }

    private void OnTurnEndEvent()
    {
        deckManager.DiscardHand();
        StartCoroutine(Draw());
    }
    IEnumerator Draw()
    {
        for (int i = 0; i < gameManager.drawAmount; i++)
        {
            deckManager.DrawCard();
            yield return new WaitForSeconds(0.1f);
        }
    }

}
