using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSpawner : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    public float _fSpawnDelay = 0.3f;
    float _fNextTimeToSpawn = 0f;

    public GameObject _worm;

    public Transform[] _SpawnPoints;
    // Update is called once per frame
    void Update()
    {
        if(_fNextTimeToSpawn <= Time.time)
        {
            SpawnWorm();
            _fNextTimeToSpawn = Time.time + _fSpawnDelay;
        }
    }

    void SpawnWorm()
    {
        Transform spawnPoint = _SpawnPoints[Random.Range(0, _SpawnPoints.Length)];
        Instantiate(_worm, spawnPoint.position, spawnPoint.rotation);
    }
}
