using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSquare : CommonAttributes
{
    void Awake()
    {
        maxHealth = 8;
        currentHealth = maxHealth;
        attack = 1;
        defence = 2;
        goldDropped = 1;
    }
}
