using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _scoreText.text = "Score: " + 0;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(_gameManager == null)
        {
            Debug.Log("Game Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScoringSystem(int _newScore)
    {
        _scoreText.text = "Score: " + _newScore;
    }

    public void UpdateLives(int currentLives)
    {
        _livesView.sprite = _livesLeft[currentLives];
        
        if (currentLives <= 0)
        {
            _gameOverText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
            _gameManager.GameOver();
        }
    }

}
