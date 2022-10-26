using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private float _speedMultipler = 2.0f;
    [SerializeField]
    private GameObject _laserShot;
    [SerializeField]
    private GameObject _tripleShot;
    [SerializeField]
    private GameObject _shieldOnline;
    [SerializeField]
    private float _fireRate = 0.3f;

    private float _nextFire = 0.0f;

    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private int _newScore = 0;

    private SpawnManager _spawnManager;

    private bool _isTripleShotActive;
    private bool _isSpeedBoostActive;
    private bool _isShieldOnlineActive;

    private UIManager _uiManager;

    [SerializeField]
    private GameObject _rightEngine, _leftEngine;

    [SerializeField]
    private AudioClip _laserSoundClip;
    private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,-1.31f, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();

        if (_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is NULL or missing!");
        }

        if (_uiManager == null)
        {
            Debug.LogError("UI Manager is NULL or missing!");
        }

        if (_audioSource == null)
        {
            Debug.LogError("Player Audio Source is NULL or missing!");
        } else
        {
            _audioSource.clip = _laserSoundClip;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            laserShot();
        }
        
    }

    void playerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * _speed);
        transform.Translate(Vector3.up * VerticalInput * Time.deltaTime * _speed);
   


        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y <= -3.5f)
        {
            transform.position = new Vector3(transform.position.x, -3.5f, 0);
        }

        if (transform.position.x <= -10.5f)
        {
            transform.position = new Vector3(10.5f, transform.position.y, 0);
        }
        else if (transform.position.x >= 10.5f)
        {
            transform.position = new Vector3(-10.5f, transform.position.y, 0);
        }
    }

    void laserShot()
    {

        _nextFire = Time.time + _fireRate;
        
        if (_isTripleShotActive is false)
        {
            Instantiate(_laserShot, transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
        } else
        {
            Instantiate(_tripleShot, transform.position +new Vector3(0, 0.6f, 0), Quaternion.identity);
        }
        
        _audioSource.Play();
    }

    public void playerDamage()
    {

        if (_isShieldOnlineActive is true)
        {
            ShieldOnline();
            return;
        }

        _lives--;
        _uiManager.UpdateLives(_lives);

        if (_lives == 2 )
        {
            _rightEngine.SetActive(true);
           _speed /= _speedMultipler;

        } 
        else if (_lives == 1){
            _leftEngine.SetActive(true);
            _speed /= _speedMultipler;
        }
        else if (_lives < 1)
        {

            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void tripleShot()
    {
        _isTripleShotActive = true;
        StartCoroutine(tripleShotPowerUpPowerDown());
    }

    IEnumerator tripleShotPowerUpPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }

    public void speedBoost()
    {
        _isSpeedBoostActive = true;
        _speed *= _speedMultipler;
        StartCoroutine(speedBoostPowerUpPowerDown());
    }

    IEnumerator speedBoostPowerUpPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        _speed /= _speedMultipler;
        _isSpeedBoostActive = false;
    }

    public void ShieldOnline()
    {
        _isShieldOnlineActive = true;
        _shieldOnline.SetActive(true);
        StartCoroutine(shieldOnlinePowerUpDowerDown());
    }

    IEnumerator shieldOnlinePowerUpDowerDown()
    {
        yield return new WaitForSeconds(15.0f);
        _shieldOnline.gameObject.SetActive(false);
        _isShieldOnlineActive = false;
    }

    public void scoringSystem(int _score)
    {
        _newScore += _score;
        _uiManager.ScoringSystem(_newScore);
    }
}
