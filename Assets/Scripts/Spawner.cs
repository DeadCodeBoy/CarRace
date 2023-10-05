using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _driverTemplates;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;
    

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_driverTemplates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn )
        {
            if (TryGetObject(out GameObject driver))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetDriver(driver, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetDriver(GameObject driver, Vector3 spawnPoint)
    {
        driver.SetActive(true);
        driver.transform.position = spawnPoint;  
    }
   
   
}
