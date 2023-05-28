using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStackEditMenu : UIPopUpMenu
{
    CardStack cardStack;
    // Start is called before the first frame update
    void Start()
    {
        HideMenu();
    }

    public void OpenMenu(CardStack cardStack)
    {
        if (cardStack != null)
            cardStack.onChange -= RefreshMenu;

        this.cardStack = cardStack;

        RefreshMenu();
        ShowMenu();

        cardStack.onChange += RefreshMenu;
    }

    private void RefreshMenu()
    {
        int amount = cardStack.cards.Count;

        CreateMenu(amount);
        UpdateMenuItem(amount);
    }

    private void UpdateMenuItem(int menuItemAmount)
    {

        for (int i = 0; i < menuItemAmount; i++)
        {
            CardData cardData = cardStack.cards[i];
            Button button = menuItem[i].GetComponent<Button>();
            button.onClick.AddListener(() => RemoveCard(cardData));

            TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
            text.text = cardData.cardName + "：" + cardData.description;
        }
    }
    void RemoveCard(CardData cardData)
    {
        cardStack.RemoveCard(cardData);
    }
    public void RemoveCardAt(int index)
    {
        Debug.Log(index);
        cardStack.RemoveCardAt(index);
    }
}
