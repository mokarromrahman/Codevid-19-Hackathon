using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Http.Headers;


public class Spawner : MonoBehaviour
{
    //// Start is called before the first frame update


    public float _fSpawnDelay = 0.3f;
    float _fNextTimeToSpawn = 0f;

    //public GameObject worm;
    public GameObject lysol;
    public GameObject doorKnob;
    public GameObject remote;
    public GameObject phone;
    public GameObject glove;
    public GameObject lightswitch;
    public GameObject toiletPaper;

    public Transform[] _SpawnPoints;
    // Update is called once per frame
    List<GameObject> _lgobj;
    System.Random rng = new System.Random();

    void Start()
    {
        _lgobj = new List<GameObject>();
        _lgobj.Add(lysol);
        _lgobj.Add(doorKnob);
        _lgobj.Add(remote);
        _lgobj.Add(phone);
        _lgobj.Add(glove);
        _lgobj.Add(lightswitch);
        _lgobj.Add(toiletPaper);

        //I was trying to dynamically add the prefab object. it was not working 
        //string dir = Directory.GetCurrentDirectory() + "/Assets/Prefab";
        //List<string> prefabs = new List<string>(Directory.GetFiles(dir));
        //prefabs.ForEach(p =>
        //{
        //    if(p.EndsWith(".prefab"))
        //    {
        //        //Debug.Log(p);
        //        FileInfo fi = new FileInfo(p);
        //        GameObject g = Resources.Load(Path.GetFileNameWithoutExtension(fi.Name)) as GameObject;
        //        if (g != null)
        //        {

        //            _lgobj.Add(Instantiate(g));
        //        }
        //    }
        //});
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
