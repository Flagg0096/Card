using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardSet
{
    public int id;
    public int amount;
}

[CreateAssetMenu(menuName = "Card Set")]
public class CardSetSO : ScriptableObject
{
    public List<int> cards;
}