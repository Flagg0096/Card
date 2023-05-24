using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Discard : MonoBehaviour
{
    public UIStackEditMenu stackEditMenu;
    public TextMeshProUGUI text;
    DeckManager deckManager;
    CardStack cardStack;
    // Start is called before the first frame update
    void Start()
    {
        deckManager = FindAnyObjectByType<DeckManager>();
        cardStack = deckManager.deck;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "弃牌堆\n" + deckManager.discard.cards.Count;
    }

    public void RemoveCard()
    {
        stackEditMenu.OpenMenu(cardStack);
    }
}
