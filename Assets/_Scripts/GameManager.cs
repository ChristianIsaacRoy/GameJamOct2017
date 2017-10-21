using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    private bool levelActive = false;
    private float nextSpawnTime;
    private float timeSinceSpawn = 0;

    [SerializeField] private int floor = 0;

    [SerializeField] private List <GameObject> enemies;
    [SerializeField] private List <bool> activeEnemies;

    [SerializeField] private Transform[] spawners;
    [SerializeField] private bool[] activeSpawners;

    [SerializeField] private float minSpawnTime = 1.0f;
    [SerializeField] private float maxSpawnTime = 3.0f ;
    [SerializeField] private float spawnMultiplier = 0.9f;
    [SerializeField] private float interludeTime = 3.0f;
    [SerializeField] private float roundTime = 30.0f;
    private bool pause = false;
    private float timer = 0;

    public int GetFloorNumber()
    {
        return floor;
    }

    private void Awake()
    {
        if( gameManager != null)
        {
            Destroy(gameObject);
            return;
        }

        gameManager = this;
        DontDestroyOnLoad(gameObject);

        timer = interludeTime;
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void Start()
    {
        NextFloor();
        pause = false;
    }

    private void Update()
    {
        if (!pause)
        {
            timer -= Time.deltaTime;
            timeSinceSpawn += Time.deltaTime;
        }

        if(timer <= 0)
        {
            if (!levelActive)
            {
                timer = roundTime;
                levelActive = true;
            }
            else
            {
                // Ohphyn Stohrp
                pause = true;
                levelActive = false;
                timer = interludeTime;
                NextFloor();
            }
        }

        if(levelActive && timeSinceSpawn >= nextSpawnTime)
        {
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceSpawn = 0;
            SpawnEnemy();
        }
    }

    public void NextFloor()
    {
        floor++;
        if (floor > 1)
        {
            minSpawnTime *= spawnMultiplier;
            maxSpawnTime *= spawnMultiplier;
        }
    }

    public void PlayerDead()
    {
        pause = true;
        //Game over screen!
    }

    private void SpawnEnemy()
    {
        int spawner, enemy;
        
        while (!activeSpawners[spawner = Random.Range(0, spawners.Length)]);
        while (!activeEnemies[enemy = Random.Range(0, enemies.Count)]);

        Instantiate(enemies[enemy], spawners[spawner]);
    }
  



}
