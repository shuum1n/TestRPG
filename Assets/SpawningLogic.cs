using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningLogic : MonoBehaviour
{
    public List<GameObject> ai;

    int indexAI;
    private void Start()
    {
        var res = Resources.LoadAll<GameObject>("Enemies/");

        foreach (GameObject obj in res)
        {
            ai.Add(obj);
        }
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        indexAI = UnityEngine.Random.Range(0,ai.Count);

        Instantiate(ai[indexAI], new Vector2(4,-3), Quaternion.identity);
    }
}
