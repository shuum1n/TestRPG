using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CommonAttributes
{
    [SerializeField] private InventoryResources inventory;
    // private int maxMana;
    // private int currentMana;
    // private int experience;
    void Start()
    {
        maxHealth = 100;
        currentHealth = 100;
        //maxMana = 100;
        //currentMana = 100;
        attack = 4;
        defence = 1;
        level = 1;
        //experience = 0;
    }
    private int attackUpgradeCost = 5;
    private int attackUpgradeLevel {get; set;}
    private int healthUpgradeLevel {get; set;}
    public void upgradeAttack()
    {
        if (inventory.Gold < attackUpgradeCost)
        {
            Debug.Log("not enough gold");
        }
        else
        {
            attackUpgradeLevel = attackUpgradeLevel + 1;
            inventory.spendGold(attackUpgradeCost);
            addAttack();
            Debug.Log("attack upgraded");
        }
    }
    public void upgradeHealth()
    {   
        healthUpgradeLevel = healthUpgradeLevel + 1;
    }

    public void addAttack()
    {
        attack = attack + (attackUpgradeLevel/5);
    }
}
