using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopUpMenu : MonoBehaviour
{
    public Vector2 offset;
    public RectTransform contentPrefab;
    public RectTransform contentRTF;
    internal List<GameObject> menuItem = new List<GameObject>();

    public void ShowMenu()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    public void HideMenu()
    {
        transform.eulerAngles = new Vector3(0f, 90f, 0f);
    }

    void ClearMenuItem()
    {
        foreach (var item in menuItem)
        {
            Destroy(item);
        }
        menuItem.Clear();
    }

    internal void CreateMenu(int menuItemAmount)
    {
        ClearMenuItem();
        ResizeMenu(menuItemAmount);

        for (int i = 0; i < menuItemAmount; i++)
        {
            CreateMenuItem();
        }
    }

    void ResizeMenu(int menuItemAmount)
    {
        contentRTF.sizeDelta = new Vector2(contentPrefab.sizeDelta.x, contentPrefab.sizeDelta.y * menuItemAmount);
    }

    void CreateMenuItem()
    {
        Vector2 position = offset + contentPrefab.sizeDelta.y * menuItem.Count * Vector2.down;
        GameObject addCardButton = Instantiate(contentPrefab.gameObject, contentRTF.TransformPoint(position), Quaternion.identity, contentRTF);

        menuItem.Add(addCardButton);
    }
}
