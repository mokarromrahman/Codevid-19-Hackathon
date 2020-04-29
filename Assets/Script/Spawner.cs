using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //// Start is called before the first frame update


    public float _fSpawnDelay = 0.3f;
    float _fNextTimeToSpawn = 0f;

    //public GameObject worm;
    public GameObject lysol;
    public GameObject dirtyHand;
    public GameObject remote;
    public GameObject phone;

    public Transform[] _SpawnPoints;
    // Update is called once per frame
    List<GameObject> _lgobj;
    System.Random rng = new System.Random();

    void Start()
    {
        _lgobj = new List<GameObject>();
        _lgobj.Add(lysol);
        _lgobj.Add(dirtyHand);
        _lgobj.Add(remote);
        _lgobj.Add(phone);
    }

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
                
        Instantiate(_lgobj[rng.Next(0, _lgobj.Count)], spawnPoint.position, spawnPoint.rotation);
    }
}
