using System;
using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private float _speedMultipler = 2.0f;
=======
using UnityEditor;
using UnityEditor.UIElements;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float drainSpeed = 0.1f;
    public float recoverSpeed = 0.1f;
    public Image frontThrusterBar;
    public Image backThrusterBar;

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
    [SerializeField]
    private Text _whatsLeft;
    [SerializeField]
    private GameObject _separator;

    private float _speedMultipler = 2.0f;
    private int _hitCounter = 3;
    private float _nextFire = 0.0f;
    private float _thrusters;
    private float _lerpTimer;
    private bool _timerOn;
    private float _maxThrusters = 100;
    private float _currentTime = 10f;
    private float _fillFG;
    private float _fillBG;
    private float _hFraction;
    private int _missileCounter = 1;

    private bool _isTripleShotActive;
    private bool _isSpeedBoostActive;
    private bool _isShieldOnlineActive;
    private bool _isMissileStatusActive;
    private bool _isMultipleLasersActive;

>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
    [SerializeField]
    private GameObject _laserShot;
    [SerializeField]
    private GameObject _tripleShot;
    [SerializeField]
    private GameObject _secretWeapon;
    [SerializeField]
    private GameObject _shieldOnline;
    [SerializeField]
<<<<<<< HEAD
    private float _fireRate = 0.3f;

    private float _nextFire = 0.0f;

    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private int _ammo = 15;
    private int _hitCounter = 3;
    [SerializeField]
    private int _newScore = 0;
    [SerializeField]
    private GameObject _isMissileActive;

    private SpawnManager _spawnManager;

    private bool _isTripleShotActive;
    private bool _isSpeedBoostActive;
    private bool _isShieldOnlineActive;
    private bool _isMissileStatusActive;

    private UIManager _uiManager;

    [SerializeField]
    private GameObject _rightEngine, _leftEngine;
=======
    private GameObject _isMissileActive;
    [SerializeField]
    private GameObject _rightEngine, _leftEngine;
    [SerializeField]
    private GameObject _asteriod;

    private SpawnManager _spawnManager;
    private UIManager _uiManager;
    
    //[SerializeField]
    private GameObject _multipleLasers;
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)

    [SerializeField]
    private AudioClip _laserSoundClip;
    [SerializeField]
    private AudioClip _playerDamageSoundClip;
<<<<<<< HEAD
    private AudioSource _audioSource;
    private SpriteRenderer _fadingColor;

=======

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

    public CameraShake cameraShake;
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        transform.position = new Vector3(0,-1.31f, 0);
=======
        _thrusters = _maxThrusters;
        transform.position = new Vector3(0, -1.31f, 0);
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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
<<<<<<< HEAD
=======
        _thrusters = Mathf.Clamp(_thrusters, 0, _maxThrusters);
        UpdateThrusterUI();
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        playerMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
<<<<<<< HEAD
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
=======
            if(_isMissileActive.activeSelf is true & _missileCounter <= 3)
            {
                _missileCounter++;
                if(_missileCounter >3)
                {
                    _isMissileActive.gameObject.SetActive(false);
                }
            }
            laserShot();
        }

        if (Input.GetKey(KeyCode.LeftShift) & _isSpeedBoostActive == false)
        {
            _timerOn = true;
            if (_currentTime >= 0 & _timerOn == true)
            {
                if (_rightEngine.activeSelf == (true))
                {
                    _speed = 5f;
                }
                else if (_leftEngine.activeSelf == (true) & _rightEngine.activeSelf == (true))
                {
                    _speed = 2.5f;
                }
                else
                {
                    _speed = 10f;
                }

                _currentTime = _currentTime - Time.deltaTime;
                ThrusterDrain(drainSpeed);
                if (backThrusterBar.fillAmount <= 0.1)
                {
                    {
                        _uiManager._afterBurner.gameObject.SetActive(false);
                        _timerOn = false;
                        _speed = 5f;
                    }
                    
                }
            }
        }
        else if (_timerOn == true & _isSpeedBoostActive == true)
        {
            _currentTime = _currentTime - Time.deltaTime;
            ThrusterDrain(drainSpeed + 0.5f);
            if (backThrusterBar.fillAmount <= 0.1)
            {
                _timerOn = false;
            }
        }
        else if (_timerOn == false || (_timerOn == true & frontThrusterBar.fillAmount <= 0.99))
        {
            _currentTime = _currentTime + Time.time;
            ThrusterRecovery(recoverSpeed);
            if (_rightEngine.activeSelf == (true))
            {
                _speed = 2.5f;
            }
            else if (_leftEngine.activeSelf == (true))
            {
                _speed = 1.25f;
            } 
            else
            {
                _speed = 5f;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (_rightEngine.activeSelf == (true))
            {
                _speed = 2.5f;
            }
            else if (_leftEngine.activeSelf == (true))
            {
                _speed = 1.25f;
            }
            else
            {
                _speed = 5f;
            }

            if (backThrusterBar.fillAmount >= 0.99 & frontThrusterBar.fillAmount >= 0.99)
            {
                _currentTime = 10;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightShift) & _asteriod.gameObject == false)
        {
            if (_asteriod.gameObject == false) 
            { 
                MissileReady();
            }
            else
            {
                Debug.Log("Unable to activate Missile");
            }
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        }
    }

    void playerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

<<<<<<< HEAD
        
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * _speed);
        transform.Translate(Vector3.up * VerticalInput * Time.deltaTime * _speed);
   
=======

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * _speed);
        transform.Translate(Vector3.up * VerticalInput * Time.deltaTime * _speed);

>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)


        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
<<<<<<< HEAD
        else if (transform.position.y <= -3.5f)
        {
            transform.position = new Vector3(transform.position.x, -3.5f, 0);
=======
        else if (transform.position.y <= -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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
<<<<<<< HEAD

        _nextFire = Time.time + _fireRate;
        
        if(_ammo > 0)
        {
            Debug.Log("is missile active? " + _isMissileStatusActive);
            if (_isTripleShotActive is true & _ammo > 2)
            {
                Instantiate(_tripleShot, transform.position +new Vector3(0, 0.6f, 0), Quaternion.identity);
=======
        int _ammoCounter =+ 1;
        _nextFire = Time.time + _fireRate;

        if (_ammo > 0)
        {
            if (_isTripleShotActive is true & _ammo > 2)
            {
                Instantiate(_tripleShot, transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
                ammoLeft(3);
            }
            else if (_isMissileActive.activeSelf is true)
            {
                Instantiate(_secretWeapon, transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
                ammoLeft(1);
            }
<<<<<<< HEAD
=======
            else if (_isMultipleLasersActive is true & _ammo > 2 & _ammoCounter < 3)
            {
                MultipleLasersActive();
                ammoLeft(3);

                _ammoCounter++;
                
            }
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
            else
            {
                Instantiate(_laserShot, transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
                ammoLeft(1);
            }

            _audioSource.pitch = 1.0f;
            _audioSource.clip = _laserSoundClip;
            _audioSource.Play();
<<<<<<< HEAD
        } 
=======
        }
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        else
        {
            _audioSource.pitch = 0.1f;
            _audioSource.reverbZoneMix = 0.5f;
            _audioSource.clip = _laserSoundClip;
            _audioSource.Play();
        }
    }

<<<<<<< HEAD
=======
    public void UpdateThrusterUI()
    {
        _fillFG = frontThrusterBar.fillAmount;
        _fillBG = backThrusterBar.fillAmount;
        _hFraction = _thrusters / _maxThrusters;

        if (_fillBG > _hFraction)
        {
            frontThrusterBar.fillAmount = _hFraction;
            backThrusterBar.color = Color.red;
            _lerpTimer += Time.deltaTime;
            float _percentComplete = _lerpTimer / drainSpeed;
            _percentComplete = _percentComplete * _percentComplete;
            backThrusterBar.fillAmount = Mathf.Lerp(_fillBG, _hFraction, _percentComplete);
        }

        if (_fillFG < _hFraction)
        {
            backThrusterBar.fillAmount = _hFraction;
            backThrusterBar.color = Color.green;
            _lerpTimer += Time.deltaTime;
            float _percentComplete = _lerpTimer / drainSpeed;
            _percentComplete = _percentComplete * _percentComplete;
            frontThrusterBar.fillAmount = Mathf.Lerp(_fillFG, backThrusterBar.fillAmount, _percentComplete);
        }
    }

>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
    public void playerDamage()
    {
        if (_isShieldOnlineActive is true)
        {
            _audioSource.clip = _playerDamageSoundClip;
            _audioSource.pitch = 1.5f;
            _audioSource.Play();
            ShieldFading(_hitCounter);
            ShieldOnline();
<<<<<<< HEAD
            _hitCounter --;
=======
            _hitCounter--;
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
            return;
        }

        _lives--;
        _uiManager.UpdateLives(_lives);

<<<<<<< HEAD
        if (_lives == 2 )
=======
        if (_lives == 2)
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        {
            _audioSource.clip = _playerDamageSoundClip;
            _audioSource.pitch = 0.3f;
            _audioSource.Play();
<<<<<<< HEAD
            _rightEngine.SetActive(true);
            _speed /= _speedMultipler;

        } 
        else if (_lives == 1){
            _audioSource.clip = _playerDamageSoundClip;
            _audioSource.pitch = 0.3f;
            _audioSource.Play();
            _leftEngine.SetActive(true);
            _speed /= _speedMultipler;
=======
            StartCoroutine(cameraShake.Shake(.15f,0.4f));
            _rightEngine.SetActive(true);
            _speed = 2.5f;

        }
        else if (_lives == 1) {
            _audioSource.clip = _playerDamageSoundClip;
            _audioSource.pitch = 0.3f;
            _audioSource.Play();
            StartCoroutine(cameraShake.Shake(.15f, 0.4f));
            _leftEngine.SetActive(true);
            _speed = 1.25f;
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        }
        else if (_lives < 1)
        {
            _audioSource.clip = _playerDamageSoundClip;
            _audioSource.pitch = 0.1f;
            _audioSource.Play();
            _spawnManager.OnPlayerDeath();
<<<<<<< HEAD
=======
            StartCoroutine(cameraShake.Shake(.15f, 0.4f));
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
            Destroy(this.gameObject, 0.5f);
        }
    }

    public void ammoLeft(int amtFired)
    {
        _ammo -= amtFired;
<<<<<<< HEAD
        _uiManager.UpdateAmmo(_ammo);
=======
        _whatsLeft.text = _ammo.ToString();
        _uiManager.UpdateAmmo(_ammo);
        
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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
<<<<<<< HEAD
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
=======
        _speed = 10;
        _timerOn = true;
    }

    public void LeftSpeedNormal()
    {
        _speed = 5;
        _timerOn = false;
    }

    public void ThrusterDrain(float drain)
    {
        _uiManager._afterBurner.gameObject.SetActive(true);
        _thrusters -= drain;
        _lerpTimer = 0f;
    }

    public void ThrusterRecovery(float charge)
    {
        _uiManager._afterBurner.gameObject.SetActive(false);
        _thrusters += charge;
        _lerpTimer = 0f;
    }

    public void speedBoost()
    {
        _isSpeedBoostActive = true;
        _timerOn = true;
        _speed *= _speedMultipler;
        _uiManager._afterBurner.gameObject.SetActive(true);
        ThrusterDrain(drainSpeed);
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        StartCoroutine(speedBoostPowerUpPowerDown());
    }

    IEnumerator speedBoostPowerUpPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        _speed /= _speedMultipler;
        _isSpeedBoostActive = false;
<<<<<<< HEAD
=======
        _timerOn = false;
        _uiManager._afterBurner.gameObject.SetActive(false);
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
    }

    public void ShieldOnline()
    {
        _isShieldOnlineActive = true;
        _shieldOnline.SetActive(true);
        StartCoroutine(shieldOnlinePowerUpDowerDown(15.0f));
    }

    private void ShieldFading(int _fading)
    {
<<<<<<< HEAD
        if(_fading == 3)
        {
            _fadingColor = _shieldOnline.GetComponent<SpriteRenderer>();
            _fadingColor.color = Color.blue;
        }
        else if(_fading == 2)
        {
            _fadingColor = _shieldOnline.GetComponent<SpriteRenderer>();
=======
        if (_fading == 3)
        {
            _fadingColor = _shieldOnline.GetComponent<SpriteRenderer>();
            StartCoroutine(cameraShake.Shake(.1f, 0.3f));
            _fadingColor.color = Color.blue;
        }
        else if (_fading == 2)
        {
            _fadingColor = _shieldOnline.GetComponent<SpriteRenderer>();
            StartCoroutine(cameraShake.Shake(.1f, 0.3f));
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
            _fadingColor.color = Color.red;
        }
        else if (_fading <= 1)
        {
<<<<<<< HEAD
=======
            StartCoroutine(cameraShake.Shake(.15f, 0.4f));
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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
<<<<<<< HEAD
=======
        _whatsLeft.text = _ammo.ToString();
        _uiManager.UpdateAmmo(_ammo);
    }

    public void NoAmmo()
    {
        _ammo = 0;
        _whatsLeft.text = _ammo.ToString();
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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
<<<<<<< HEAD
        
=======
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
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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
