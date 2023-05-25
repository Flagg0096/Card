using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CardStack
{
    [field: SerializeField] public List<int> cards { get; private set; }
    public UnityAction onChange;

    public void Shuffle()
    {
        cards = cards.OrderBy(x => Random.value).ToList();
    }
    public void RemoveAllCard()
    {
        cards.Clear();
        RaiseOnChange();
    }

    public void RemoveCardAt(int index)
    {
        cards.RemoveAt(index);
        RaiseOnChange();
    }

    public void AddCard(int id)
    {
        cards.Add(id);
        RaiseOnChange();
    }
    public void AddCard(List<int> ids)
    {
        cards.AddRange(ids);
        RaiseOnChange();
    }

    private void RaiseOnChange()
    {
        if (onChange != null)
            onChange.Invoke();
    }

    internal void RemoveCard(int id)
    {
        cards.Remove(id);
    }
}
