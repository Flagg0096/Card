using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICard : MonoBehaviour
{
    public Button button;
    public int index;
    HandManager handManager;
    public CardInfo cardInfo;
    public TextMeshProUGUI title, description;
    public CardBehaviour cardBehaviour;
    private void OnEnable()
    {
        button.onClick.AddListener(Activate);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(Activate);
    }
    void Start()
    {
        handManager = FindAnyObjectByType<HandManager>();
        UpdateCard();
    }

    public virtual void Activate()
    {
        if (!cardBehaviour.CanUse())
        {
            return;
        }

        cardBehaviour.Use();
        handManager.DiscardHand(index);
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
