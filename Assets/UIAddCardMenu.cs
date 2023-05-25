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
    // Start is called before the first frame update
    void Start()
    {
        deckManager = FindAnyObjectByType<DeckManager>();
        HideMenu();
    }

    public void CreateMenu(List<CardInfo> cardInfos)
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

        foreach (var cardInfo in cardInfos)
        {
            AddMenuItem(cardInfo);
        }

        contentTF.sizeDelta = new Vector2(contentPrefab.sizeDelta.x, contentPrefab.sizeDelta.y * cardInfos.Count);
    }

    private void AddMenuItem(CardInfo cardInfo)
    {
        Vector2 position = offset + contentPrefab.sizeDelta.y * menuItem.Count * Vector2.down;
        GameObject addCardButton = Instantiate(contentPrefab.gameObject, contentTF.TransformPoint(position), Quaternion.identity, contentTF);
        menuItem.Add(addCardButton);

        Button button = addCardButton.GetComponent<Button>();
        button.onClick.AddListener(() => deckManager.AddCardtoHand(cardInfo.id));
        button.onClick.AddListener(HideMenu);

        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
        text.text = cardInfo.cardName + "：" + cardInfo.description;
    }

    public void OpenAddCardMenu()
    {
        ShowMenu();
        CreateMenu(cardInfoSO.cardInfos.OrderBy(card => card.rank).ToList());
    }

    public void Random3AmongRankMenu(int rank)
    {
        ShowMenu();
        List<CardInfo> cardInfos = cardInfoSO.cardInfos.FindAll(card => card.rank == rank);
        cardInfos = cardInfos.OrderBy(x => Random.value).ToList();

        CreateMenu(cardInfos.GetRange(0, Mathf.Min(3, cardInfos.Count)));
    }
}
