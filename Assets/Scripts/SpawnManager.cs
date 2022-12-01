using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
    private Text _waveText;
    [SerializeField]
    private int _numberOfSpawnedPowerUps = 0;
    [SerializeField]
    private int _healthPUCount = 0;
    [SerializeField]
    private int _ammoPUCount = 0;
    [SerializeField]
    private int _numberOfEnemies = 0;
    [SerializeField]
    private Boss _boss;

    //[SerializeField]
    private GameObject _enemyPrefab;
    //[SerializeField]
    private GameObject _enemyDodgePrefab;
    private int _numberOfEnemiesActive = 0;
    
    private bool _stopSpawning = false;
    private bool _stopSpawningEnemy = false;
    private Player _player;
    private Enemy _enemy;
    private int _loopCounter = 0;


    public void StartSpawning(int _waveIndex)
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        _enemy = GameObject.Find("SpawnManager").GetComponent<Enemy>();

        if (_player != null)
        {
            switch (_waveIndex)
            {
                case 0:
                    StartCoroutine(SpawnEnemyRoutine(waveMachine[_waveIndex].numberOfEnemies, waveMachine[_waveIndex].rateOfRelease));
                    break;
                case 1:
                    StartCoroutine(SpawnEnemyRoutine(waveMachine[_waveIndex].numberOfEnemies, waveMachine[_waveIndex].rateOfRelease));
                    break;
                case 2:
                    StartCoroutine(SpawnEnemyRoutine(waveMachine[_waveIndex].numberOfEnemies, waveMachine[_waveIndex].rateOfRelease));
                    break;
                case 3:
                    StartCoroutine(SpawnEnemyRoutine(waveMachine[_waveIndex].numberOfEnemies, waveMachine[_waveIndex].rateOfRelease));
                    break;
                case 4:
                    _boss.gameObject.SetActive(isActiveAndEnabled);
                    break;
                default:
                    Debug.Log("DEAFULT Would use values: " + waveMachine[_waveIndex].rateOfRelease + "/" + waveMachine[_waveIndex].numberOfEnemies);
                    break;
            }
            StartCoroutine(SpawnPowerUpRoutine());
        }
    }

    void Update()
    {
        if (_player != null && waveMachine[_waveIndex].numberOfEnemies == _numberOfEnemies && _loopCounter == 0)
        {
            if (waveMachine[_waveIndex].numberOfEnemies == _enemyCount)
            {
                _stopSpawningEnemy = true;
                _stopSpawning = true;
                _loopCounter++;
                if (_loopCounter == 1)
                {
                    WaveLevelUpMain(_waveIndex);
                    _loopCounter = -1;
                }
            }
        }
    }
    IEnumerator SpawnEnemyRoutine(int numberOfEnemies, float rateOfRelease)
    {
        while (_stopSpawningEnemy == false)    
        {
            if (_numberOfEnemies == waveMachine[_waveIndex].numberOfEnemies)
            {
                _stopSpawningEnemy = true;
            } 
            else
            {
                Vector3 posToSpawnEnemy = new Vector3(Random.Range(-9f, 9f), 7, 0);
                int ememyPrefabRS = Random.Range(0, _ememyArray.Length);
                GameObject newEnemy = Instantiate(_ememyArray[ememyPrefabRS], posToSpawnEnemy, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
                _numberOfEnemies++;
                yield return new WaitForSeconds(rateOfRelease);                

            }

        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        while (_stopSpawning == false)
        {   
            _numberOfSpawnedPowerUps++;

            Vector3 posToSpawnPowerUp = new Vector3(Random.Range(-9f, 9f), 7, 0);
            int powerUpsRS = Random.Range(0, _powerUpPrefab.Length);
            Instantiate(_powerUpPrefab[powerUpsRS], posToSpawnPowerUp, Quaternion.identity);

            if (_powerUpPrefab[powerUpsRS].tag == "HealthPowerUp")
            {
                _healthPUCount++;
            }
            else if (_powerUpPrefab[powerUpsRS].tag == "AmmoPowerUp")
            {
                _ammoPUCount++;
            }
            yield return new WaitForSeconds(Random.Range(3.0f, 15.0f));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
        _stopSpawningEnemy = true;
    }

    public void enemyCount(int enemyCounter)
    {
        _enemyCount ++;
    }


    public void WaveLevelUpMain(int index)
    {   
        _waveIndex = index;
        _waveText.text = "Next Wave In...";
        _waveText.gameObject.SetActive(true);
        StartCoroutine(TextWaveLevelUpMain(_waveText));

    }
    IEnumerator TextWaveLevelUpMain(Text _waveText)
    {
        yield return new WaitForSeconds(1f);
        _waveText.gameObject.SetActive(false);
        WaveLevelUp5();
    }
    private void WaveLevelUp5()
    {
        _waveText.text = "5".ToString();
        _waveText.gameObject.SetActive(true);
        StartCoroutine(TextWaveLevelUp5(_waveText));

    }
    IEnumerator TextWaveLevelUp5(Text _waveText)
    {
        yield return new WaitForSeconds(1f);
        _waveText.gameObject.SetActive(false);
        WaveLevelUp4();
    }
    private void WaveLevelUp4()
    {        
        _waveText.text = "4".ToString();
        _waveText.gameObject.SetActive(true);
        StartCoroutine(TextWaveLevelUp4(_waveText));

    }
    IEnumerator TextWaveLevelUp4(Text _waveText)
    {
        yield return new WaitForSeconds(1f);
        _waveText.gameObject.SetActive(false);
        WaveLevelUp3();
    }
    private void WaveLevelUp3()
    {        
        _waveText.text = "3".ToString();
        _waveText.gameObject.SetActive(true);
        StartCoroutine(TextWaveLevelUp3(_waveText));

    }
    IEnumerator TextWaveLevelUp3(Text _waveText)
    {
        yield return new WaitForSeconds(1f);
        _waveText.gameObject.SetActive(false);
        WaveLevelUp2();
    }
    private void WaveLevelUp2()
    {        
        _waveText.text = "2".ToString();
        _waveText.gameObject.SetActive(true);
        StartCoroutine(TextWaveLevelUp2(_waveText));
    }
    IEnumerator TextWaveLevelUp2(Text _waveText)
    {
        yield return new WaitForSeconds(1f);
        _waveText.gameObject.SetActive(false);
        WaveLevelUp1();
    }
    private void WaveLevelUp1()
    {        
        _waveText.text = "1".ToString();
        _waveText.gameObject.SetActive(true);
        StartCoroutine(TextWaveLevelUp1(_waveText));

    }
    IEnumerator TextWaveLevelUp1(Text _waveText)
    {
        yield return new WaitForSeconds(1f);
        _waveText.gameObject.SetActive(false);
        _waveIndex ++;
        _stopSpawningEnemy = false;
        _stopSpawning = false;
        _loopCounter = 0;
        _enemyCount = 0;
        _numberOfEnemies = 0;
        StartSpawning(_waveIndex);        
    }
}
