using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool levelActive = false;
    private float nextSpawnTime;
    private float timeSinceSpawn = 0;

    private int floor = 0;

    [SerializeField] private List <GameObject> enemies;
    [SerializeField] private List <bool> activeEnemies;

    [SerializeField] private Transform[] spawners;
    [SerializeField] private bool[] activeSpawners;

    [SerializeField] private float minSpawnTime = 1.0f;
    [SerializeField] private float maxSpawnTime = 3.0f ;
    [SerializeField] private float spawnMultiplier = 0.9f;
    [SerializeField] private float interludeTime = 8.0f;
    [SerializeField] private float roundTime = 30.0f;

    [SerializeField] private UI_GameOverScreen storeScreen;
    [SerializeField] private UI_Countdown downcount;

    private bool pause = false;
    private float timer = 0;

    public int GetFloorNumber()
    {
        return floor;
    }

    private void Awake()
    {
        if( instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        timer = interludeTime;
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void Start()
    {
        NextFloor();
        pause = false;
    }

    public void StartLevel()
    {
        pause = false;
        NextFloor();
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
                storeScreen.Enable();
                pause = true;
                levelActive = false;
                timer = interludeTime;
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
        downcount.Enable();
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
