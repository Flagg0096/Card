using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public CardInfoSO cardInfoSO;
    public UIStackEditMenu stackEditMenu;
    private DeckManager deckManager;
    public GameObject cardPrefab;
    CardStack hands;
    Transform thisTF;
    List<UICard> handsCard = new List<UICard>();

    // Start is called before the first frame update
    void Start()
    {
        deckManager = FindAnyObjectByType<DeckManager>();
        thisTF = transform;
        hands = deckManager.hands;

        hands.onChange += UpdateHands;
    }

    private void UpdateHands()
    {
        foreach (var card in handsCard)
        {
            Destroy(card.gameObject);
        }

        handsCard.Clear();

        InstantiateHand();
    }

    private void InstantiateHand()
    {
        float cardAmount = hands.cards.Count;

        for (int i = 0; i < cardAmount; i++)
        {
            UICard card = Instantiate(cardPrefab, thisTF).GetComponent<UICard>();
            card.index = i;
            card.cardData = hands.cards[i];
            AddCardBehaviour(card);
            handsCard.Add(card);
        }
    }

    private void AddCardBehaviour(UICard card)
    {
        CardBehaviour cardBehaviour = card.gameObject.AddComponent<CardBehaviour>();
        cardBehaviour.cardData = card.cardData;
        card.cardBehaviour = cardBehaviour;

        cardBehaviour.costManager = FindAnyObjectByType<CostManager>();
    }

    public void DiscardHand(CardData cardData)
    {
        deckManager.DiscardHand(cardData);
    }

    public void RemoveCard()
    {
        stackEditMenu.OpenMenu(hands);
    }
}
