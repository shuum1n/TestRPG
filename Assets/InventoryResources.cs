using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryResources : MonoBehaviour
{
    [SerializeField] private int m_gold;

    public void addGold(int goldDropped)
    {
        m_gold = m_gold + goldDropped;
    }

    public void spendGold(int gold)
    {
        m_gold = m_gold - gold;
    }
    public int Gold
    {
        get {return m_gold;}
        set {m_gold = value;}
    }
}
