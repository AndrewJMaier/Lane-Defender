using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private bool _canSpawn;
    //Lists
    [SerializeField] private Transform[] _enemySpawnPoints;
    [SerializeField] private GameObject[] _enemyTypes;
    //int variables
    private int randomTarget;
    private int enemySpawn;
    private float enemySpawnCooldown;
    private Transform targetSpawnPoint;
    [SerializeField] private Transform _self;
    private GameObject targetEnemy;
    // Update is called once per frame
    void Update()
    {
        if (_canSpawn)
        {
            _canSpawn = false;
            randomTarget = Random.Range(0, 5);
            targetSpawnPoint = _enemySpawnPoints[randomTarget];
            enemySpawn = Random.Range(0, 3);
            targetEnemy = _enemyTypes[enemySpawn];
            GameObject enemySpawning = Instantiate(targetEnemy, targetSpawnPoint.position, _self.rotation);
        }
    }

    private IEnumerator SpawnCooldown()
    {
        enemySpawnCooldown = Random.Range(1f, 3f);
        yield return new WaitForSeconds(enemySpawnCooldown);
        _canSpawn = true;
    }
}
