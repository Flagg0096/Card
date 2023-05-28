using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DeckManager : MonoBehaviour
{
    public CardSetSO startDeck;
    public CardStack deck, hands, discard;
    public UnityAction onHandsChange;
    private GameManager gameManager;

    private void OnEnable()
    {
        hands.onChange += HandsChanged;
    }

    private void OnDisable()
    {
        hands.onChange -= HandsChanged;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        deck.AddCard(startDeck.GetList());
        ShuffleDeck();
        StartCoroutine(DrawCard(gameManager.drawAmount));
    }

    public void RefillDeck()
    {
        deck.AddCard(discard.cards);
        discard.RemoveAllCard();
    }

    public void DiscardHand()
    {
        discard.AddCard(hands.cards);
        hands.RemoveAllCard();

        HandsChanged();
    }
    public void DiscardHand(CardData cardData)
    {
        // Debug.Log(index);
        discard.AddCard(cardData);
        hands.RemoveCard(cardData);

        HandsChanged();
    }

    private void HandsChanged()
    {
        if (onHandsChange != null)
            onHandsChange.Invoke();
    }

    public IEnumerator DrawCard(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            DrawCard();
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void DrawCard()
    {
        if (deck.cards.Count == 0)
        {
            if (discard.cards.Count > 0)
            {
                ShuffleDeck();
                RefillDeck();
                DrawCard();
            }
        }
        else
        {
            hands.AddCard(deck.cards.Last());
            deck.RemoveCardAt(deck.cards.Count - 1);

            HandsChanged();
        }
    }

    public void ShuffleDeck()
    {
        deck.Shuffle();
    }

    public void AddCardtoHand(CardData cardData)
    {
        hands.AddCard(cardData);
        HandsChanged();
    }
}
