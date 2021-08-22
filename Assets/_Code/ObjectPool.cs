using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 60)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 20f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }


    void Start()
    {
        StartCoroutine(EnemySpawner());
    }
        
    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnabledObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;

            }
            
        }        
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            EnabledObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
