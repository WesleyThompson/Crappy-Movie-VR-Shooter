using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public float maxTime = 10f;
    private float timeRemaining;
    public List<GameObject> spawnPoints = new List<GameObject>();
    public bool waveBegins = false;
    public int numberOfEnemies = 20;
    public GameObject enemySpawn;
    public List<GameObject> activeEnemies = new List<GameObject>();
    public bool firstSpawn = false;

	// Use this for initialization
	void Start () {
        timeRemaining = maxTime;
        //collect location of spawn points
        CollectSpawnPoints();
	}
	
	// Update is called once per frame
	void Update () {
    //Debug.Log("here");
        if (waveBegins)
        {
            timeRemaining -= Time.deltaTime;
            SpawnEnemies();
        }
        
	}

    public void CollectSpawnPoints()
    {
        //adds spawn points to list of gameobject
        GameObject[] collector = GameObject.FindGameObjectsWithTag("spawn");
        foreach(GameObject location in collector)
        {
            spawnPoints.Add(location);
            Debug.Log(location.name.ToString());
        }
    }

    public void SpawnEnemies()
    {
        if (timeRemaining <= 0 && numberOfEnemies > 0)
        {

            if (!firstSpawn)
            {
                firstSpawn = true;
            }
            GameObject enemySpawnLocation = spawnPoints[Random.Range(0,spawnPoints.Count)];
            activeEnemies.Add(Instantiate(enemySpawn, enemySpawnLocation.transform.position, enemySpawnLocation.transform.rotation ));
            numberOfEnemies -= 1;
            timeRemaining = maxTime;
        }
    }

    public void StartWave()
    {
        waveBegins = true;
        firstSpawn = false;
    }

    public void StartWave(int numberOfEnemies, float timeBetweenSpawns)
    {
        this.numberOfEnemies = numberOfEnemies;
        maxTime = timeBetweenSpawns;
        StartWave();
    }
}
