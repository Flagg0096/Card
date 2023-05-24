using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DeckManager : MonoBehaviour
{
    public CardStack deck, hands, discard;
    public UnityAction onHandsChange;
    // Start is called before the first frame update
    void Start()
    {
        ShuffleDeck();
    }

    public void RemoveCardFrom(List<int> stack, int index)
    {
        stack.RemoveAt(index);
    }

    public void RefillDeck()
    {
        deck.AddCard(discard.cards);
        discard.RemoveAllCard();
    }

    public void DiscardHand()
    {
        for (int i = 0; i < hands.cards.Count; i++)
        {
            DiscardHand(0);
        }
    }
    public void DiscardHand(int index)
    {
        discard.AddCard(hands.cards[index]);
        hands.RemoveCardAt(index);

        HandsChanged();
    }

    private void HandsChanged()
    {
        onHandsChange.Invoke();
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

    public void AddCardtoHand(int id)
    {
        hands.AddCard(id);
        HandsChanged();
    }
}
