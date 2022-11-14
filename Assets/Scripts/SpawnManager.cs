using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEditorInternal;
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

    //[SerializeField]
    private GameObject _enemyPrefab;
    //[SerializeField]
    private GameObject _enemyDodgePrefab;
    [SerializeField]
    private GameObject[] _ememyArray;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] _powerUpPrefab;
    [SerializeField]
    private int _waveIndex = 0;
    [SerializeField]
    private int _enemyCount;
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private Text _testText;
    
    private int numberOfEnemiesActive = 0;

    public int enemyCounter;

    private bool _stopSpawning = false;

    public void StartSpawning()
    {
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
            WaveLevelUpMain();
            _enemyCount = 0;
            _waveIndex += 1;
            StartSpawning();
        }
    }
    IEnumerator SpawnEnemyRoutine(int numberOfEnemies, float rateOfRelease)
    {
        yield return new WaitForSeconds(rateOfRelease);
        numberOfEnemiesActive++;

        while (_stopSpawning == false && numberOfEnemiesActive <= numberOfEnemies)
        {
            Vector3 posToSpawnEnemy = new Vector3(Random.Range(-9f, 9f), 7, 0);
            int ememyPrefabRS = Random.Range(0, _ememyArray.Length); 
            GameObject newEnemy = Instantiate(_ememyArray[ememyPrefabRS], posToSpawnEnemy, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            numberOfEnemiesActive++;
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
}
