using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    FieldManager fieldManager;
    public CardInfo cardInfo;
    public TextMeshProUGUI title, description;
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
        fieldManager.DiscardHand(this);
    }

    public void UpdateCard()
    {
        if (cardInfo != null)
        {
            title.text = cardInfo.cardName;
            description.text = cardInfo.description;
        }
        else
        {
            title.text = "";
            description.text = "";
        }
    }
}
