using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Deck : MonoBehaviour
{
    public UIStackEditMenu stackEditMenu;
    public TextMeshProUGUI text;
    CardStack cardStack;
    private DeckManager deckManager;

    // Start is called before the first frame update
    void Start()
    {
        deckManager = FindAnyObjectByType<DeckManager>();
        cardStack = deckManager.deck;
    }
    private void Update()
    {
        text.text = "卡组\n" + cardStack.cards.Count.ToString();
    }

    public void DrawCard()
    {
        deckManager.DrawCard();
    }

    public void Shuffle()
    {
        cardStack.Shuffle();
    }

    public void RemoveCard()
    {
        stackEditMenu.OpenMenu(cardStack);
    }
}
