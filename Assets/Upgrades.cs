using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    //IDK, dynamic programming stuff here read file print upgrade
    [SerializeField] private GameObject Player;
    private int attackUpgradeLevel {get; set;}
    private int healthUpgradeLevel {get; set;}
    public void upgradeAttack()
    {
        attackUpgradeLevel = attackUpgradeLevel + 1;
    }
    public void upgradeHealth()
    {   
        healthUpgradeLevel = healthUpgradeLevel + 1;
    }
}
