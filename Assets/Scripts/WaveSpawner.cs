using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;


public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {

        public string name;
        public Transform enemy;
        public int enemyCount;
        public float spawnRate;
    }

    
    public Wave[] waves;

    private int _nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    private SpawnState _state = SpawnState.COUNTING;
    void start()
    {
        waveCountDown = timeBetweenWaves;

    }

    void Update()
    {
        if (waveCountDown <= 0)
        {
            if (_state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[_nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        _state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.enemyCount; i++)
        {
            SpawnEnemy(_wave.enemy);
        }

        _state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {

        Debug.Log("Spawning Enemy: " + _enemy.name);
    }
}