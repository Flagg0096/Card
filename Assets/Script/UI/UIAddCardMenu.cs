using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UIAddCardMenu : UIPopUpMenu
{
    DeckManager deckManager;
    public RectTransform contentTF;
    public CardInfoSO cardInfoSO;
    public RectTransform contentPrefab;
    public Vector2 offset;
    List<GameObject> menuItem = new List<GameObject>();
    public List<CardData> allCards;

    // Start is called before the first frame update
    void Start()
    {
        deckManager = FindAnyObjectByType<DeckManager>();
        HideMenu();
    }

    public void CreateMenu(List<CardData> cardDatas)
    {
        // for (int i = 0; i < transform.childCount; i++)
        // {
        //     Destroy(transform.GetChild(i).gameObject);
        // }

        foreach (var item in menuItem)
        {
            Destroy(item);
        }
        menuItem.Clear();

        foreach (var cardInfo in cardDatas)
        {
            AddMenuItem(cardInfo);
        }

        contentTF.sizeDelta = new Vector2(contentPrefab.sizeDelta.x, contentPrefab.sizeDelta.y * cardDatas.Count);
    }

    private void AddMenuItem(CardData cardData)
    {
        Vector2 position = offset + contentPrefab.sizeDelta.y * menuItem.Count * Vector2.down;
        GameObject addCardButton = Instantiate(contentPrefab.gameObject, contentTF.TransformPoint(position), Quaternion.identity, contentTF);
        menuItem.Add(addCardButton);

        Button button = addCardButton.GetComponent<Button>();
        button.onClick.AddListener(() => deckManager.AddCardtoHand(cardData));
        button.onClick.AddListener(HideMenu);

        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
        text.text = cardData.cardName + "：" + cardData.description;
    }

    public void OpenAddCardMenu()
    {
        ShowMenu();
        CreateMenu(allCards);
    }

    public void Random3AmongRankMenu(int rank)
    {
        ShowMenu();
        List<CardInfo> cardInfos = cardInfoSO.cardInfos.FindAll(card => card.rank == rank);
        cardInfos = cardInfos.OrderBy(x => Random.value).ToList();

        CreateMenu(allCards);
    }

    public void AddCardFrom(List<CardData> cardDatas)
    {
        ShowMenu();
        CreateMenu(cardDatas);
    }
}
