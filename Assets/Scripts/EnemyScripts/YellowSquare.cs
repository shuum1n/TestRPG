using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowSquare : CommonAttributes
{
    void Awake()
    {
        maxHealth = 4;
        currentHealth = maxHealth;
        attack = 3;
        defence = 1;
        goldDropped = 1;
    }
}