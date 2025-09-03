using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //TMP
    [SerializeField]
    private int ePoolSize = 10;
    [SerializeField]
    private int bPoolSize = 10;

    [SerializeField]
    private Enemy ePrefab;
    [SerializeField]
    private Bullet bPrefab;

    [SerializeField]
    private List<Enemy> enemyPool;
    [SerializeField]
    private List<Bullet> bulletPool;

    public void AddEnemyToPool(Enemy enemy) => enemyPool.Add(enemy);

    public void AddBulletToPool(Bullet bullet) => bulletPool.Add(bullet);

    public Enemy GetEnemy()
    {
        if (enemyPool.Count < 0)
            return null;
        Enemy enemy = enemyPool[0];
        enemyPool.Remove(enemy);
        return enemy;
    }

    public Bullet GetBullet()
    {
        if (bulletPool.Count < 0)
            return null;
        Bullet bullet = bulletPool[0];
        bulletPool.Remove(bullet);
        return bullet;
    }

    private void Awake()
    {
        for(int i = 0; i < ePoolSize; i++)
        {
            enemyPool.Add(Instantiate(ePrefab));
            enemyPool[i].gameObject.SetActive(false);
        }
        for(int j = 0; j < bPoolSize; j++)
        {
            bulletPool.Add(Instantiate(bPrefab));
            bulletPool[j].gameObject.SetActive(false);
        }
    }
}
