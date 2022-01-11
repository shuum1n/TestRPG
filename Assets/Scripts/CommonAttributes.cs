using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CommonAttributes : MonoBehaviour {

    private float m_maxHealth;
   private float m_currentHealth;
    private float m_attack;
    private float m_defence;   
    private string m_element;
    private int m_goldDropped;
    private int m_level;
    private int m_targetIndex;
    private int m_regenAmount;
    public int targetIndex
    {
        get {return m_targetIndex;}
        set {m_targetIndex = value;}
    }
    public float maxHealth
    {
        get {return m_maxHealth;}
        set {m_maxHealth = value;}
    }
    public float currentHealth
    {
        get {return m_currentHealth;}
        set {m_currentHealth = value;}
    }
    public float attack
    {
        get {return m_attack;}
        set {m_attack = value;}
    }
    public float defence
    {
        get {return m_defence;}
        set {m_defence = value;}
    }
    public string element
    {
        get {return m_element;}
        set {m_element = value;}
    }
    public int goldDropped
    {
        get {return m_goldDropped;}
        set {m_goldDropped = value;}
    }
    public int level
    {
        get {return m_level;}
        set {m_level = value;}
    }

    public void RegenHealth()
    {
        m_currentHealth = m_currentHealth + m_regenAmount;
        if (m_currentHealth > m_maxHealth) m_currentHealth = m_maxHealth;
    }
}
