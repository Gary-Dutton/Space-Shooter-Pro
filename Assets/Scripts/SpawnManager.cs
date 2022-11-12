using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyDodgePrefab;
    [SerializeField]
    private GameObject[] _ememyArray;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] _powerUpPrefab;



    private bool _stopSpawning = false;

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while(_stopSpawning == false)
        {
            Vector3 posToSpawnEnemy = new Vector3(Random.Range(-9f, 9f), 7, 0);
            int ememyPrefabRS = Random.Range(0, _ememyArray.Length); 
            GameObject newEnemy = Instantiate(_ememyArray[ememyPrefabRS], posToSpawnEnemy, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }


    }

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning == false)
        {
            Vector3 posToSpawnPowerUp = new Vector3(Random.Range(-9f, 9f), 7, 0);
            int powerUpsRS = Random.Range(0, _powerUpPrefab.Length);
            Instantiate(_powerUpPrefab[powerUpsRS], posToSpawnPowerUp, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3.0f, 15.0f));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

}
