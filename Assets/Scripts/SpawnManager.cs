using System.Collections;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
=======
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class WaveMachine
    {
        public string name;
        public int numberOfEnemies;
        public float rateOfRelease;
    }

    public WaveMachine[] waveMachine;
    public int enemyCounter;

    //[SerializeField]
    private GameObject _enemyPrefab;
    //[SerializeField]
    private GameObject _enemyDodgePrefab;
    [SerializeField]
    private GameObject[] _ememyArray;
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] _powerUpPrefab;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD



=======
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
    [SerializeField]
    private int _waveIndex = 0;
    [SerializeField]
    private int _enemyCount;
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private Text _testText;

    private int _numberOfEnemiesActive = 0;
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
    private bool _stopSpawning = false;

    public void StartSpawning()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while(_stopSpawning == false)
        {
            Vector3 posToSpawnEnemy = new Vector3(Random.Range(-9f, 9f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawnEnemy, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
=======
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        switch (waveMachine[_waveIndex].name)
        {
            case "EASY":
                Debug.Log("Would use values: " + waveMachine[_waveIndex].rateOfRelease + "/" + waveMachine[_waveIndex].numberOfEnemies);
                StartCoroutine(SpawnEnemyRoutine(waveMachine[_waveIndex].numberOfEnemies, waveMachine[_waveIndex].rateOfRelease));
                break;
            case "MILD":
                Debug.Log("Would use values: " + waveMachine[_waveIndex].rateOfRelease + "/" + waveMachine[_waveIndex].numberOfEnemies);
                StartCoroutine(SpawnEnemyRoutine(waveMachine[_waveIndex].numberOfEnemies, waveMachine[_waveIndex].rateOfRelease));
                break;
            case "HARD":
                Debug.Log("Would use values: " + waveMachine[_waveIndex].rateOfRelease + "/" + waveMachine[_waveIndex].numberOfEnemies);
                StartCoroutine(SpawnEnemyRoutine(waveMachine[_waveIndex].numberOfEnemies, waveMachine[_waveIndex].rateOfRelease));
                break;
            case "EXTREME":
                Debug.Log("Would use values: " + waveMachine[_waveIndex].rateOfRelease + "/" + waveMachine[_waveIndex].numberOfEnemies);
                StartCoroutine(SpawnEnemyRoutine(waveMachine[_waveIndex].numberOfEnemies, waveMachine[_waveIndex].rateOfRelease));
                break;
            case "RANDOM":
                Debug.Log("Would use values: " + waveMachine[_waveIndex].rateOfRelease + "/" + waveMachine[_waveIndex].numberOfEnemies);
                StartCoroutine(SpawnEnemyRoutine(waveMachine[_waveIndex].numberOfEnemies, waveMachine[_waveIndex].rateOfRelease));
                break;
            default:
                Debug.Log("DEAFULT Would use values: " + waveMachine[_waveIndex].rateOfRelease + "/" + waveMachine[_waveIndex].numberOfEnemies);
                break;
        }
        //StartCoroutine(SpawnEnemyRoutine(numberOfEnemies, numberOfEnemiesActive));
        StartCoroutine(SpawnPowerUpRoutine());
    }

    void Update()
    {
        if (waveMachine[_waveIndex].numberOfEnemies == _enemyCount)
        {

            Debug.Log("Calling next wave!");
            _testText.gameObject.SetActive(true);
            _stopSpawning = true;
            WaveLevelUpMain();
            _enemyCount = 0;
            _waveIndex += 1;
            _stopSpawning = false;
            StartSpawning();
        }
    }
    IEnumerator SpawnEnemyRoutine(int numberOfEnemies, float rateOfRelease)
    {
        yield return new WaitForSeconds(7);
        _numberOfEnemiesActive++;

        while (_stopSpawning == false && _numberOfEnemiesActive <= numberOfEnemies)
        {
            Vector3 posToSpawnEnemy = new Vector3(Random.Range(-9f, 9f), 7, 0);
            int ememyPrefabRS = Random.Range(0, _ememyArray.Length); 
            GameObject newEnemy = Instantiate(_ememyArray[ememyPrefabRS], posToSpawnEnemy, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            _numberOfEnemiesActive++;
            yield return new WaitForSeconds(rateOfRelease);
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        }


    }

    IEnumerator SpawnPowerUpRoutine()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        yield return new WaitForSeconds(3.0f);
=======
        yield return new WaitForSeconds(5.0f);
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
        yield return new WaitForSeconds(5.0f);
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
        yield return new WaitForSeconds(5.0f);
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
    public void enemyCount(int enemyCounter)
    {
        _enemyCount ++;
        Debug.Log("Number of Enemies destroyed: " + _enemyCount);
        return;
    }

    private void WaveLevelUpMain()
    {
        StartCoroutine(TextWaveLevelUpMain(_testText));
    }
    IEnumerator TextWaveLevelUpMain(Text _testText)
    {
        yield return new WaitForSeconds(2f);
        _testText.gameObject.SetActive(false);
        WaveLevelUp5();
    }
    private void WaveLevelUp5()
    {
        _testText.gameObject.SetActive(true);
        _testText.text = "5".ToString();
        StartCoroutine(TextWaveLevelUp5(_testText));

    }
    IEnumerator TextWaveLevelUp5(Text _testText)
    {
        yield return new WaitForSeconds(1f);
        _testText.gameObject.SetActive(false);
        WaveLevelUp4();
    }
    private void WaveLevelUp4()
    {
        _testText.gameObject.SetActive(true);
        _testText.text = "4".ToString();
        StartCoroutine(TextWaveLevelUp4(_testText));

    }
    IEnumerator TextWaveLevelUp4(Text _testText)
    {
        yield return new WaitForSeconds(1f);
        _testText.gameObject.SetActive(false);
        WaveLevelUp3();
    }
    private void WaveLevelUp3()
    {
        _testText.gameObject.SetActive(true);
        _testText.text = "3".ToString();
        StartCoroutine(TextWaveLevelUp3(_testText));

    }
    IEnumerator TextWaveLevelUp3(Text _testText)
    {
        yield return new WaitForSeconds(1f);
        _testText.gameObject.SetActive(false);
        WaveLevelUp2();
    }
    private void WaveLevelUp2()
    {
        _testText.gameObject.SetActive(true);
        _testText.text = "2".ToString();
        StartCoroutine(TextWaveLevelUp2(_testText));
    }
    IEnumerator TextWaveLevelUp2(Text _testText)
    {
        yield return new WaitForSeconds(1f);
        _testText.gameObject.SetActive(false);
        WaveLevelUp1();
    }
    private void WaveLevelUp1()
    {
        _testText.gameObject.SetActive(true);
        _testText.text = "1".ToString();
        StartCoroutine(TextWaveLevelUp1(_testText));

    }
    IEnumerator TextWaveLevelUp1(Text _testText)
    {
        yield return new WaitForSeconds(1f);
        _testText.gameObject.SetActive(false);
    }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
}
