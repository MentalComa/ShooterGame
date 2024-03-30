﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public List<Transform> spawnerPoints;
     private List<EnemyAI> _enemies;
    public List<Transform> patrolPoints;

    public EnemyAI enemyPrefab;
    public PlayerController player;
    
    public int enemiesMaxCount = 5;
    public float delay = 5;
    public float increaseEnemiesCountDelay = 45;

    private float _timeLastSpawned;


    // Start is called before the first frame update
    void Start()
    {
      //  _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<EnemyAI>();

        Invoke("IncreaseEnemiesMaxCount", increaseEnemiesCountDelay);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDeadEnemies();


        CreateEnemy();
    }
    private void CreateEnemy()
    {
        if (_enemies.Count >= enemiesMaxCount) return;
        if (Time.time - _timeLastSpawned < delay) return;


        var enemy =  Instantiate(enemyPrefab);
        enemy.transform.position = spawnerPoints[Random.Range(0, spawnerPoints.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _enemies.Add(enemy);
        _timeLastSpawned = Time.time;
    }
    private void CheckForDeadEnemies()
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].IsAlive()) continue;
            _enemies.RemoveAt(i);
            i--;
        }
    }
    private void IncreaseEnemiesMaxCount()
    {
        enemiesMaxCount++;
        Invoke("IncreaseEnemiesMaxCount", increaseEnemiesCountDelay);
    }
}