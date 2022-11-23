using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{    
    public int hitCounter = 1;
    
    private CameraShake _cameraShake;

    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private GameObject _enemyLaserPrefab;
    [SerializeField]
    private AudioClip _enemyLaserSoundClip;
    [SerializeField]
    private AudioClip _enemyExplosionSoundClip;
    [SerializeField]
    private GameObject _enemyShieldOnline;

    private Player _player;
    private SpawnManager _spawnManager;
    private Animator _anim;
    private AudioSource _audioSource;
    private bool _dodge = false;
    private int _dodgePath = 0; // 0 = left, 1 = right
    private float _fireRate = 3.0f;
    private float _canFire = -1f;
    private bool _isEnemyShieldOnlineActive;
    private float _distanceToActivate = 3f;
    private float _pickUpSpeed;
    private bool _powerUpShot;
    private Vector3 _powerUpShotOffset;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        _audioSource = GetComponent<AudioSource>();
        _powerUpShotOffset = new Vector3(0, -0.4f, 0);
        
        if(_player == null)
        {
            Debug.LogError("Player is NULL!");
        }
        
        _anim = GetComponent<Animator>();

        if (_anim == null)
        {
            Debug.LogError("Anim is NULL!");
        }

        if (_audioSource == null)
        {
            Debug.LogError("Audio Source is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //CalculateMovement();
        MovementArray();

        if (_player != null)
        {
            PowerUpShot();
        }
    }

    private void LaserShot ()
    {

        if (this.CompareTag("EnemyDodger") && _dodge == true)
        {
            Vector3 path = (_dodgePath == 0) ? Vector3.left : Vector3.right;
            transform.Translate(path * _speed * 1.25f * Time.deltaTime);
        }

        if (Time.time > _canFire)
        {
            _fireRate = Random.Range(3f, 7f);
            _canFire = Time.time + _fireRate;
            GameObject enemyLaser = Instantiate(_enemyLaserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();

            if ((this.gameObject.transform.position.y - _player.transform.position.y) <= 0)
            {
                for (int i = 0; i < lasers.Length; i++)
                {
                    if (this.gameObject != null)
                    {
                        lasers[i].AssignEnemyLaser(2);
                    }
                }
            }
            else
            {
                for (int i = 0; i < lasers.Length; i++)
                {
                    if (this.gameObject != null)
                    {
                        lasers[i].AssignEnemyLaser(1);
                    }
                }
            }

            if (this.gameObject == null && lasers.Length > 0)
            {
                Debug.Log("Enemy still fired!");
            }

            _audioSource.clip = _enemyLaserSoundClip;
            _audioSource.pitch = 0.5f;
            _audioSource.Play();
        }
    }

    private void PowerUpShot()
    {
        Debug.DrawRay(transform.position + _powerUpShotOffset, (-transform.up * _distanceToActivate), Color.red);
        RaycastHit2D _hit  = Physics2D.Raycast(transform.position + _powerUpShotOffset, -transform.up, _distanceToActivate);
        Debug.Log("HIT? " + _hit);
        if (_hit)
        {
            if (_hit.collider.tag.Contains("PowerUp"))
            {
                Debug.Log("Power Up Name: " + _hit.collider.name);
                if (_powerUpShot == false)
                {
                    LaserShot();
                    StartCoroutine(PowerUpShotCoolDown());
                }
            }
            else
            {
                LaserShot();
            }
        }
    }

    void MovementArray()
    {
        if (_player != null)
        {
            transform.Translate(Vector3.down * Time.deltaTime * _speed);
            int _leftrightMovement = Random.Range(0, 2);

            float _distanceBetweenPlayerAndPickup = Vector2.Distance(transform.position, _player.transform.position);
            if (_distanceBetweenPlayerAndPickup < _distanceToActivate)
            {
                _pickUpSpeed = _distanceToActivate - _distanceBetweenPlayerAndPickup;
                transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _pickUpSpeed * Time.deltaTime);
            }

            if (_leftrightMovement == 1)
            {
                if (transform.position.x >= Random.Range(-9, 3))
                {
                    transform.Translate((Vector3.down + Vector3.right) * Time.deltaTime * _speed);
                    if (transform.position.x <= -10.5f)
                    {
                        transform.position = new Vector3(10.5f, transform.position.y, 0);
                    }
                    else if (transform.position.x >= 10.5f)
                    {
                        transform.position = new Vector3(-10.5f, transform.position.y, 0);
                    }
                }
                else if (transform.position.x <= Random.Range(9, -3))
                {
                    transform.Translate((Vector3.down + Vector3.left) * Time.deltaTime * _speed);
                    if (transform.position.x <= -10.5f)
                    {
                        transform.position = new Vector3(10.5f, transform.position.y, 0);
                    }
                    else if (transform.position.x >= 10.5f)
                    {
                        transform.position = new Vector3(-10.5f, transform.position.y, 0);
                    }
                }
            }
            else if (_leftrightMovement == 0)
            {
                transform.Translate(Vector3.down * Time.deltaTime * _speed);
            }

            if (transform.position.y <= -5.75f)
            {
                float enemyRangeX = Random.Range(-9f, 9f);
                transform.position = new Vector3(enemyRangeX, 8f, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                EnemyKills(1);
                player.playerDamage();
                _anim.SetTrigger("EnemyDestroyed");
                _speed = 0.2f;
                _audioSource.clip = _enemyExplosionSoundClip;
                _audioSource.Play();
                Destroy(this.gameObject, 1.8f);

            }
        }

        if (other.tag == "Laser")
        {
            if (_player != null && _isEnemyShieldOnlineActive == true)
            {
                Debug.Log("Entered Shield On Code");
                EnemyDamage();
            }
            else if (_player != null && _isEnemyShieldOnlineActive == false)
            {
                _player.scoringSystem(10);
                EnemyKills(1);
                Destroy(other.gameObject);
                _anim.SetTrigger("EnemyDestroyed");
                _speed = 0.2f;
                _audioSource.clip = _enemyExplosionSoundClip;
                _audioSource.Play();
                Destroy(GetComponent<Collider2D>());
                Destroy(this.gameObject, 1.8f);
            }
        }

        if (other.tag == "MissilePowerUp")
        {
            if (_player != null && _isEnemyShieldOnlineActive == true)
            {
                EnemyDamage();
            }
            if (_player != null)
            {
                _player.scoringSystem(10);
                EnemyKills(1);
                Destroy(other.gameObject);
                _anim.SetTrigger("EnemyDestroyed");
                _speed = 0.2f;
                _audioSource.clip = _enemyExplosionSoundClip;
                _audioSource.Play();
                Destroy(GetComponent<Collider2D>());
                Destroy(this.gameObject, 1.8f);
            }
        }

    }

    IEnumerator PowerUpShotCoolDown()
    {
        _powerUpShot = true;
        yield return new WaitForSeconds(5.0f);
        _powerUpShot= false;
    }


    IEnumerator DodgeRoutine()
    {
        _dodgePath = Random.Range(0, 1);
        _dodge = true;
        yield return new WaitForSeconds(1.5f);
        _dodge = false;
    }

    public void Dodge()
    {
        StartCoroutine(DodgeRoutine());
    }

    public void EnemyKills(int hitCounter)
    {
        hitCounter = +1;
        if (_spawnManager!= null)
        {
            _spawnManager.enemyCount(1);
            
        }
        Debug.Log("Value :" + hitCounter);
        
    }

    public void EnemyDamage ()
    {
        Debug.Log("Enemy Damge has been called");
        Debug.Log("True/False" + _isEnemyShieldOnlineActive);
        if (_isEnemyShieldOnlineActive is true)
        {
            StartCoroutine(_cameraShake.Shake(.15f, 0.4f));
            Debug.Log("Enemy Shield is online");
            _audioSource.pitch = 1.5f;
            _audioSource.Play();
            _isEnemyShieldOnlineActive = false;
            _enemyShieldOnline.SetActive(false);
            return;
        }
    }

    public void EnemyShieldOnline(bool PowerUp)
    {
        Debug.Log("Called by PowerUp Script...");
        _isEnemyShieldOnlineActive = PowerUp;
        _enemyShieldOnline.SetActive(PowerUp);
        StartCoroutine(shieldOnlinePowerUpDowerDown(15.0f));
    }

    private void ShieldFading(int _fading)
    {
        if (_fading <= 1)
        {
            StartCoroutine(shieldOnlinePowerUpDowerDown(0.5f));
        }

    }

    IEnumerator shieldOnlinePowerUpDowerDown(float activeTimer)
    {
        yield return new WaitForSeconds(activeTimer);
        _enemyShieldOnline.SetActive(false);
        _isEnemyShieldOnlineActive = false;
    }
}
