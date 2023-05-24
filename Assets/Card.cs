using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public int index;
    FieldManager fieldManager;
    public CardInfo cardInfo;
    public TextMeshPro title, description;
    public CardBehaviour cardBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        fieldManager = FindAnyObjectByType<FieldManager>();
        UpdateCard();
    }
    private void OnMouseDown()
    {
        Activate();
    }
    public virtual void Activate()
    {
        if (!cardBehaviour.CanUse())
        {
            return;
        }

        cardBehaviour.Use();
        fieldManager.DiscardHand(index);

    }

    public void UpdateCard()
    {
        if (cardInfo != null)
        {
            title.text = $"{cardInfo.cardName} [{cardInfo.cost}]";
            description.text = cardInfo.description;
        }
        else
        {
            title.text = "";
            description.text = "";
        }
    }
}
