using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    DeckManager deckManager;
    [SerializeField] CardInfoSO cardInfoSO;
    public GameObject cardPrefab;
    public float cardGap = 2.5f;
    List<Card> handsCard = new List<Card>();
    List<int> hands;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        UpdateHands();
    }

    private void Initialize()
    {
        deckManager = FindAnyObjectByType<DeckManager>();

        deckManager.onHandsChange += UpdateHands;
        hands = deckManager.hands.cards;
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
        float cardAmount = hands.Count;
        float width = (cardAmount - 1) * cardGap;
        Vector3 startPos = Vector3.left * width * 0.5f;

        for (int i = 0; i < cardAmount; i++)
        {
            Vector3 position = startPos + Vector3.right * cardGap * i;
            Card card = Instantiate(cardPrefab, position, Quaternion.identity).GetComponent<Card>();
            card.cardInfo = cardInfoSO.GetCardInfo(hands[i]);
            handsCard.Add(card);
        }
    }

    public void DiscardHand(Card card)
    {
        deckManager.DiscardHand(handsCard.IndexOf(card));
    }
}
