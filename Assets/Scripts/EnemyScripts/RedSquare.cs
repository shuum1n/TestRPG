using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSquare : CommonAttributes
{   
    void Awake()
    {
        maxHealth = 5;
        currentHealth = maxHealth;       
        attack = 2;
        defence = 1;
        goldDropped = 1;
    }
}
