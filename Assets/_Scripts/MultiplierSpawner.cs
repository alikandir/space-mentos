using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierSpawner : MonoBehaviour
{
    public GameObject multiplierPrefab;
    private GameObject[] _spawnedMultipliers;
    public int spawnAmount = 20;
    private void Start() {
        SpawnMultipliers();
    }
    public Vector3 GetSpawnPosition()
    {
        return new Vector3(Random.Range(-7, 7), Random.Range(5, 100), 0);
    }

    public void SpawnMultipliers()
    {
        _spawnedMultipliers = new GameObject[spawnAmount];
        for (int i = 0; i < spawnAmount; i++)
        {
            _spawnedMultipliers[i] = Instantiate(multiplierPrefab, GetSpawnPosition(), Quaternion.identity);
        }
    }


}
