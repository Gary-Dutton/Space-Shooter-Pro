using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;    
    [SerializeField]
    private float _fireRate = 0.3f;    
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private int _ammo = 15;
    [SerializeField]
    private int _newScore = 0;

    private float _speedMultipler = 2.0f;
    private int _hitCounter = 3;
    private float _nextFire = 0.0f; 
    
    private bool _isTripleShotActive;
    private bool _isSpeedBoostActive;
    private bool _isShieldOnlineActive;
    private bool _isMissileStatusActive;
    private bool _isMultipleLasersActive;

    [SerializeField]
    private GameObject _laserShot;
    [SerializeField]
    private GameObject _tripleShot;
    [SerializeField]
    private GameObject _secretWeapon;
    [SerializeField]
    private GameObject _shieldOnline;
    [SerializeField]
    private GameObject _isMissileActive;
    [SerializeField]
    private GameObject _rightEngine, _leftEngine;

    private SpawnManager _spawnManager;
    private UIManager _uiManager;

    [SerializeField]
    private GameObject _multipleLasers;

    [SerializeField]
    private AudioClip _laserSoundClip;
    [SerializeField]
    private AudioClip _playerDamageSoundClip;

    private AudioSource _audioSource;
    private SpriteRenderer _fadingColor;

    //[SerializeField]
    //private GameObject _laser;
    [SerializeField]
    private int _numberOfLasers = 3;
    [SerializeField]
    private float _angleOfSpread = 90f;
    [SerializeField]
    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -1.31f, 0);
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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            LeftSpeedBoost();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            LeftSpeedNormal();
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            MissileReady();
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
        int _ammoCounter =+ 1;
        _nextFire = Time.time + _fireRate;

        if (_ammo > 0)
        {
            if (_isTripleShotActive is true & _ammo > 2)
            {
                Instantiate(_tripleShot, transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
                ammoLeft(3);
            }
            else if (_isMissileActive.activeSelf is true)
            {
                Instantiate(_secretWeapon, transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
                ammoLeft(1);
            }
            else if (_isMultipleLasersActive is true & _ammo > 2 & _ammoCounter < 3)
            {
                MultipleLasersActive();
                ammoLeft(3);

                _ammoCounter++;
                
            }
            else
            {
                Instantiate(_laserShot, transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
                ammoLeft(1);
            }

            _audioSource.pitch = 1.0f;
            _audioSource.clip = _laserSoundClip;
            _audioSource.Play();
        }
        else
        {
            _audioSource.pitch = 0.1f;
            _audioSource.reverbZoneMix = 0.5f;
            _audioSource.clip = _laserSoundClip;
            _audioSource.Play();
        }
    }

    public void playerDamage()
    {
        if (_isShieldOnlineActive is true)
        {
            _audioSource.clip = _playerDamageSoundClip;
            _audioSource.pitch = 1.5f;
            _audioSource.Play();
            ShieldFading(_hitCounter);
            ShieldOnline();
            _hitCounter--;
            return;
        }

        _lives--;
        _uiManager.UpdateLives(_lives);

        if (_lives == 2)
        {
            _audioSource.clip = _playerDamageSoundClip;
            _audioSource.pitch = 0.3f;
            _audioSource.Play();
            _rightEngine.SetActive(true);
            _speed /= _speedMultipler;

        }
        else if (_lives == 1) {
            _audioSource.clip = _playerDamageSoundClip;
            _audioSource.pitch = 0.3f;
            _audioSource.Play();
            _leftEngine.SetActive(true);
            _speed /= _speedMultipler;
        }
        else if (_lives < 1)
        {
            _audioSource.clip = _playerDamageSoundClip;
            _audioSource.pitch = 0.1f;
            _audioSource.Play();
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject, 0.5f);
        }
    }

    public void ammoLeft(int amtFired)
    {
        _ammo -= amtFired;
        _uiManager.UpdateAmmo(_ammo);
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

    private void LeftSpeedBoost()
    {
        _speed *= _speedMultipler;
    }

    private void LeftSpeedNormal()
    {
        _speed /= _speedMultipler;
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
        StartCoroutine(shieldOnlinePowerUpDowerDown(15.0f));
    }

    private void ShieldFading(int _fading)
    {
        if (_fading == 3)
        {
            _fadingColor = _shieldOnline.GetComponent<SpriteRenderer>();
            _fadingColor.color = Color.blue;
        }
        else if (_fading == 2)
        {
            _fadingColor = _shieldOnline.GetComponent<SpriteRenderer>();
            _fadingColor.color = Color.red;
        }
        else if (_fading <= 1)
        {
            StartCoroutine(shieldOnlinePowerUpDowerDown(0.5f));
        }

    }

    IEnumerator shieldOnlinePowerUpDowerDown(float activeTimer)
    {
        yield return new WaitForSeconds(activeTimer);
        _fadingColor = _shieldOnline.GetComponent<SpriteRenderer>();
        _shieldOnline.gameObject.SetActive(false);
        _isShieldOnlineActive = false;
        _fadingColor.color = Color.cyan;
        _hitCounter = 3;
    }

    public void AmmoReload()
    {
        _ammo = 15;
        _uiManager.UpdateAmmo(_ammo);
    }

    public void HealthRecovery()
    {
        if (_lives == 2)
        {
            _lives++;
            _rightEngine.SetActive(false);
            _speed *= _speedMultipler;
            _uiManager.UpdateLives(_lives);
        }
        else if (_lives == 1)
        {
            _lives++;
            _leftEngine.SetActive(false);
            _speed *= _speedMultipler;
            _uiManager.UpdateLives(_lives);
        }
    }

    public void MultipleLasersCall()
    {
        _isMultipleLasersActive = true;
        StartCoroutine(MultipleLasersCoolDown(5f));
    }

    public void MultipleLasersActive()
    {
        float facingRotation = Mathf.Atan2(_laserShot.transform.position.y, _laserShot.transform.position.x) * Mathf.Rad2Deg;
        float startRotation = facingRotation - _angleOfSpread / 2f;
        float angleIncrease = _angleOfSpread / ((float)_numberOfLasers - 1f);

        for (int i = 0; i < _numberOfLasers; i++)
        {
            float tempRotation = startRotation - angleIncrease * i;
            GameObject newLaser = Instantiate(_laserShot, transform.position, Quaternion.Euler(0f, 0f, tempRotation));
            MultipleLasers temp = newLaser.GetComponent<MultipleLasers>();
            if (temp)
            {
                _ = (new Vector2(Mathf.Cos(tempRotation * Mathf.Deg2Rad), Mathf.Sin(tempRotation * Mathf.Deg2Rad)));
            }
        }
    }

    IEnumerator MultipleLasersCoolDown(float activeTimer)
    {
        yield return new WaitForSeconds(activeTimer);
        _isMultipleLasersActive = false;
    }

    public void MissileReady()
    {
        StartCoroutine(_uiManager.UpdateMissileStatus());
    }

    public void scoringSystem(int _score)
    {
        _newScore += _score;
        _uiManager.ScoringSystem(_newScore);
    }
}
