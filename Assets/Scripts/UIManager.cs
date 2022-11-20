using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
using UnityEngine.SocialPlatforms.Impl;
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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
    [SerializeField]
    private Image _ammoView;
    [SerializeField]
    private Sprite[] _ammoLeft;
    [SerializeField]
    private Image _missileReady;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
    [SerializeField]
    private GameObject _separator;
    [SerializeField]
    private Text _waveLevelUp;

    public Text whatsLeft;

    public Image _afterBurner;
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)


    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        _restartText.gameObject.SetActive(false);
        _missileReady.gameObject.SetActive(false);
=======
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        _waveLevelUp.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _missileReady.gameObject.SetActive(false);
        _afterBurner.gameObject.SetActive(false);
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
    public void LevelingUp(Text NextWavetext)
    {
        _waveLevelUp.text = NextWavetext.text;
    }

<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
    }

    public IEnumerator UpdateMissileStatus()
    {
        if (_missileReady.IsActive() == false)
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            float waitTime = Random.Range(30f, 60f);
            yield return new WaitForSeconds(waitTime);
            _missileReady.gameObject.SetActive(true);
            yield return new WaitForSeconds(5f);
            _missileReady.gameObject.SetActive(false);
=======
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
            float waitTime = Random.Range(15f, 45f);
            yield return new WaitForSeconds(waitTime);
            _separator.gameObject.SetActive(false);
            _missileReady.gameObject.SetActive(true);
            yield return new WaitForSeconds(5f);
            _missileReady.gameObject.SetActive(false);
            _separator.gameObject.SetActive(true);
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        }
        
    }

}
