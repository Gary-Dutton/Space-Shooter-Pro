using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{    
    public Text whatsLeft;
    public Image afterBurner;


    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _livesView;
    [SerializeField]
    private Sprite[] _livesLeft;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private Image _ammoView;
    [SerializeField]
    private Sprite[] _ammoLeft;
    [SerializeField]
    private Image _missileReady;
    [SerializeField]
    private GameObject _separator;
    [SerializeField]
    private Text _waveLevelUp;


    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
        _waveLevelUp.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _missileReady.gameObject.SetActive(false);
        afterBurner.gameObject.SetActive(false);
        //_missileReady.gameObject.SetActive(false);
        _scoreText.text = "Score: " + 0;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(_gameManager == null)
        {
            Debug.Log("Game Manager is NULL");
        }
    }


    public void ScoringSystem(int _newScore)
    {
        _scoreText.text = "Score: " + _newScore;
    }

    public void LevelingUp(Text NextWavetext)
    {
        _waveLevelUp.text = NextWavetext.text;
    }

    public void UpdateLives(int currentLives)
    {
        if (currentLives <= 0)
        {
            currentLives = 0;
        }

        _livesView.sprite = _livesLeft[currentLives];
        
        if (currentLives <= 0)
        {
            _gameOverText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
            _gameManager.GameOver();
        }
    }

    public void UpdateAmmo(int currentAmmo)
    {
        _ammoView.sprite = _ammoLeft[currentAmmo];
    }

    public IEnumerator UpdateMissileStatus()
    {
        if (_missileReady.IsActive() == false)
        {
            float waitTime = Random.Range(15f, 45f);
            yield return new WaitForSeconds(waitTime);
            _separator.gameObject.SetActive(false);
            _missileReady.gameObject.SetActive(true);
            yield return new WaitForSeconds(5f);
            _missileReady.gameObject.SetActive(false);
            _separator.gameObject.SetActive(true);
        }
        
    }

}
