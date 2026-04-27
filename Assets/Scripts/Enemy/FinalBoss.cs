using Assets.Scripts.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class FinalBoss : MonoBehaviour
{
    public List<GameObject> ListOfEnemies;

    [SerializeField] private Transform SpawnForMobs;

    [SerializeField] private Canvas windowWinner;

    [SerializeField] private float spawnInterval = 5f; 
    private bool isSpawning = true;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (isSpawning)
        {
            SpawnRandomMob();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnRandomMob()
    {
        if (ListOfEnemies == null || ListOfEnemies.Count == 0) return;
        GameObject mobPrefab = ListOfEnemies[UnityEngine.Random.Range(0, ListOfEnemies.Count)];
        Vector3 spawnPos = SpawnForMobs.position;
        spawnPos.y -= 1.5f;
        Instantiate(mobPrefab, spawnPos, Quaternion.identity);
    }
}
