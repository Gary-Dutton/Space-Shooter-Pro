using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] _powerUpPrefab;



    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while(_stopSpawning == false)
        {
            Vector3 posToSpawnEnemy = new Vector3(Random.Range(-9f, 9f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawnEnemy, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }


    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while(_stopSpawning == false)
        {
            Vector3 posToSpawnPowerUp = new Vector3(Random.Range(-9f, 9f), 7, 0);
            int powerUpsRS = Random.Range(0, 2);
            Instantiate(_powerUpPrefab[powerUpsRS], posToSpawnPowerUp, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3.0f, 15.0f));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

}
