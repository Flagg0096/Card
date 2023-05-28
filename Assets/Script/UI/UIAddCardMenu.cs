using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UIAddCardMenu : UIPopUpMenu
{
    DeckManager deckManager;
    public CardInfoSO cardInfoSO;
    List<CardData> cardDatas;

    // Start is called before the first frame update
    void Start()
    {
        deckManager = FindAnyObjectByType<DeckManager>();
        HideMenu();
    }

    public void CreateMenu(List<CardData> cards)
    {
        cardDatas = cards;

        int amount = cardDatas.Count;

        CreateMenu(amount);
        UpdateMenuItem(amount);
    }

    private void UpdateMenuItem(int menuItemAmount)
    {
        for (int i = 0; i < menuItemAmount; i++)
        {
            CardData cardData = cardDatas[i];
            Button button = menuItem[i].GetComponent<Button>();
            button.onClick.AddListener(() => deckManager.AddCardtoHand(cardData));
            button.onClick.AddListener(HideMenu);

            TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
            text.text = cardData.cardName + "：" + cardData.description;
        }
    }

    public void OpenAddCardMenu()
    {
        ShowMenu();
        CreateMenu(cardDatas);
    }

    public void Random3AmongRankMenu(int rank)
    {
        ShowMenu();
        List<CardInfo> cardInfos = cardInfoSO.cardInfos.FindAll(card => card.rank == rank);
        cardInfos = cardInfos.OrderBy(x => Random.value).ToList();

        CreateMenu(cardDatas);
    }

    public void AddCardFrom(List<CardData> cardDatas)
    {
        ShowMenu();
        CreateMenu(cardDatas);
    }
}
