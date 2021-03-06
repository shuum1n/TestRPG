using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GameBattleLogic : MonoBehaviour
{
    public GameObject Player;
    public List<GameObject> PlayerParty;
    public GameObject enemyInstance;
    public List<GameObject> AvailableEnemyList;
    public List<GameObject> SpawnedEnemies;
    [SerializeField] private float enemyHP;
    [SerializeField] private int enemyGoldDropped;
    [SerializeField] private InventoryResources inventory;
    [SerializeField] private int targetIndex;
    private float EnemySpawnPosition = -5;
    [SerializeField] private int currentEnemyCount;
    [SerializeField] private GameObject slider;
    int indexAI;

    void Start()
    {
        PlayerParty.Add(Player);
        AvailableEnemyList = Resources.LoadAll<GameObject>("Enemies").ToList();
        SpawnEnemy();
        targetIndex = 0;
        enemyInstance = SpawnedEnemies[targetIndex];
        enemyHP = enemyInstance.GetComponent<CommonAttributes>().currentHealth;
    }
    void Update() 
    {   
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D m_hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero);

            if (m_hit.collider != null)
            {
               targetIndex = m_hit.transform.GetComponent<CommonAttributes>().targetIndex;
               UpdateMobvalues();
            }
        }
    }

    #region Spawning Logic
    public void SpawnEnemy()
    {
        EnemySpawnPosition = -3;
        int maxEnemyCount = UnityEngine.Random.Range(1,3);
        currentEnemyCount = maxEnemyCount;
        for (int i = 0; i < maxEnemyCount; i++)
        {
            indexAI = UnityEngine.Random.Range(0,AvailableEnemyList.Count);
            enemyInstance = Instantiate(AvailableEnemyList[indexAI], new Vector3(EnemySpawnPosition,0, 0), Quaternion.identity);
            enemyInstance.GetComponent<CommonAttributes>().targetIndex = i;
            Debug.Log(enemyInstance.GetComponent<CommonAttributes>().maxHealth);
            SpawnedEnemies.Add(enemyInstance);
            EnemySpawnPosition = (EnemySpawnPosition - 2.25f);
        }
    }
    #endregion
    
    #region Add Gold Logic
    public void addGoldToInventory()
    {
        inventory.addGold(enemyInstance.GetComponent<CommonAttributes>().goldDropped);
    }
    #endregion

    #region Getting Values on Click & Targeting
    
    public void UpdateMobvalues()
    {
        enemyInstance = SpawnedEnemies[targetIndex];
        Debug.Log(enemyInstance);
        enemyHP = (enemyInstance.GetComponent<CommonAttributes>().currentHealth);
        UpdateHealthBar();
    }


    public void UpdateTargetWhenDead()
    {
        for (int index = 0; index < SpawnedEnemies.Count; index++)
        {
            if (SpawnedEnemies[index] == null)
            {
                ;
            }
            else
            {
                enemyInstance = SpawnedEnemies[index];
                targetIndex = enemyInstance.GetComponent<CommonAttributes>().targetIndex;
                UpdateHealthBar();
                return;
            }
        }
    }
    #endregion

    public void CheckIfEnemiesAreAllDead()
    {
        if (currentEnemyCount <= 0)
        {
            SpawnedEnemies.Clear();
            SpawnEnemy();
            targetIndex = 0;
            UpdateHealthBar();
        }
    }

    public void UpdateHealthBar()
    {
        slider.GetComponent<HealthBar>().SetMaxHealth(enemyInstance.GetComponent<CommonAttributes>().maxHealth);
        slider.GetComponent<HealthBar>().SetHealth(enemyInstance.GetComponent<CommonAttributes>().currentHealth);
    }

    #region Turn System

    public void EnterTurn()
    {
        playerPartyTurn();
        enemyPartyTurn();
    }

    public void playerPartyTurn()
    {
        enemyInstance = SpawnedEnemies[targetIndex];
        for (int i = 0; i < PlayerParty.Count; i++)
        {
            GameObject activePlayer = PlayerParty[i];
            float damageDealt = activePlayer.GetComponent<CommonAttributes>().attack - enemyInstance.GetComponent<CommonAttributes>().defence;
            if (Mathf.Floor(damageDealt)<= 0) damageDealt = 1;
            enemyInstance.GetComponent<CommonAttributes>().currentHealth = enemyInstance.GetComponent<CommonAttributes>().currentHealth - damageDealt;
            enemyHP = enemyInstance.GetComponent<CommonAttributes>().currentHealth;
            Debug.Log(damageDealt + " Damage to enemy");
            UpdateHealthBar();
            if (enemyHP <= 0)
            {
                Debug.Log("Dead");
                addGoldToInventory();
                Object.Destroy(enemyInstance);
                SpawnedEnemies[targetIndex] = null;
                currentEnemyCount = currentEnemyCount - 1;
                CheckIfEnemiesAreAllDead();
                UpdateTargetWhenDead();
                UpdateHealthBar();
            }
        }
    }

    public void enemyPartyTurn()
    {
        int targetedPlayerIndex = UnityEngine.Random.Range(0,PlayerParty.Count);
        for (int i = 0; i < SpawnedEnemies.Count; i++)
        {
            GameObject activeEnemy = SpawnedEnemies[i];
            GameObject targetedPlayer = PlayerParty[targetedPlayerIndex];
            if (activeEnemy == null)
            {
                Debug.Log("Active enemy slot" + i + "is already dead");
            }
            else
            {
                float damageDealt = activeEnemy.GetComponent<CommonAttributes>().attack - targetedPlayer.GetComponent<CommonAttributes>().defence;
                if (Mathf.Floor(damageDealt)<= 0) damageDealt = 1;
                targetedPlayer.GetComponent<CommonAttributes>().currentHealth = targetedPlayer.GetComponent<CommonAttributes>().currentHealth - damageDealt;
                
                Debug.Log(damageDealt + " Damage to player," + targetedPlayer.GetComponent<CommonAttributes>().currentHealth + "HP left");
                if (targetedPlayer.GetComponent<CommonAttributes>().currentHealth <= 0)
                {
                    Debug.Log("Player died");
                }
            }
            
        }
    }



    #endregion
}
