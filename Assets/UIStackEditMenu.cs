using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStackEditMenu : UIPopUpMenu
{
    public CardInfoSO cardInfoSO;
    CardStack cardStack;
    public Vector2 offset;
    public RectTransform contentPrefab;
    public RectTransform contentTF;
    List<GameObject> menuItem = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        HideMenu();
    }

    public void OpenMenu(CardStack cardStack)
    {
        if (cardStack != null)
            cardStack.onChange -= UpdateMenu;

        this.cardStack = cardStack;

        ShowMenu();
        UpdateMenu();

        cardStack.onChange += UpdateMenu;
    }

    private void UpdateMenu()
    {
        ClearMenuItem();

        foreach (var card in cardStack.cards)
        {
            CreateMenuItem(card);
        }
    }

    private void CreateMenuItem(int card)
    {
        Vector2 position = offset + contentPrefab.sizeDelta.y * menuItem.Count * Vector2.down;
        GameObject addCardButton = Instantiate(contentPrefab.gameObject, contentTF.TransformPoint(position), Quaternion.identity, contentTF);

        Button button = addCardButton.GetComponent<Button>();
        button.onClick.AddListener(() => RemoveCardAt(menuItem.IndexOf(addCardButton)));

        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
        CardInfo cardInfo = cardInfoSO.GetCardInfo(card);
        text.text = cardInfo.cardName + "：" + cardInfo.description;

        menuItem.Add(addCardButton);
    }

    private void ClearMenuItem()
    {
        foreach (var item in menuItem)
        {
            Destroy(item);
        }
        menuItem.Clear();
    }

    public void RemoveCardAt(int index)
    {
        Debug.Log(index);
        cardStack.RemoveCardAt(index);
    }
}
