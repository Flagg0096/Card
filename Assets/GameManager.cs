using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    RaycastHit hit;
    Card selectedCard, targetCard;
    public int drawAmount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedCard == null)
            {
                selectedCard = GetCardByPosition();
            }
            else
            {
                targetCard = GetCardByPosition();
            }
        }
    }

    public Card GetCardByPosition()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
        if (hit.collider != null)
        {
            return hit.collider.GetComponentInParent<Card>();
        }
        else
        {
            return null;
        }
    }

    void MoveCard(Card from, Card to)
    {
        to.cardInfo = from.cardInfo;
        from.cardInfo = null;
        to.UpdateCard();
        from.UpdateCard();
    }
}
