using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int enemyCount = 1;
    [SerializeField]
    private List<Action> enemyActivators = new List<Action>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy = ObjectPool.Instance.GetEnemy();
        if(enemy != null)
        {
            Vector3 spawnPos = new Vector3(UnityEngine.Random.value - 0.5f, UnityEngine.Random.value - 0.5f);
            spawnPos.x = MathH.GetSpawnCoordOutRange(spawnPos.x, 15);
            spawnPos.y = MathH.GetSpawnCoordOutRange(spawnPos.y, 15);
            enemy.transform.position = Player.Instance.transform.position+spawnPos;
            enemyActivators.Add(enemy.Init(Player.Instance.transform));
            enemy.gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            foreach(var item in enemyActivators)
            {
                item.Invoke();
            }
        }
    }
}
