using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField]
    private int enemyCount = 0;
    [SerializeField]
    private List<EnemyBase> enemyBases;
    [SerializeField]
    private List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void SpawnEnemy()
    {
        Enemy enemy = ObjectPool.Instance.GetEnemy();
        if(enemy != null)
        {
            Vector3 spawnPos = new Vector3((Random.value - 0.5f)*2, (Random.value - 0.5f)*2);
            spawnPos = MathH.GetSpawnCoordOutRange(spawnPos, 21);
            enemy.transform.position = Player.Instance.transform.position+spawnPos;
            enemies.Add(enemy);
            enemy.Init(enemyBases[Random.RandomRange(0,enemyBases.Count-1)],Player.Instance.transform).Invoke();
            enemy.gameObject.SetActive(true);
        }

    }

    Coroutine spawner;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if (spawner == null)
                spawner = StartCoroutine(EnemySpawner());
        }
    }


    public void RemoveEnemy(Enemy enemy)
    {
        if(enemies.Contains(enemy))
            enemies.Remove(enemy);
    }

    private IEnumerator EnemySpawner()
    {
        while(true)
        {
            yield return new WaitUntil(() => enemies.Count < 10);
            yield return new WaitForSeconds(0.5f);
            SpawnEnemy();
        }
    }
}
