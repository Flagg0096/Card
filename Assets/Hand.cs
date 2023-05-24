using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public UIStackEditMenu stackEditMenu;
    private DeckManager deckManager;
    CardStack cardStack;
    // Start is called before the first frame update
    void Start()
    {
        deckManager = FindAnyObjectByType<DeckManager>();
        cardStack = deckManager.hands;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCard()
    {
        stackEditMenu.OpenMenu(cardStack);
    }
}
