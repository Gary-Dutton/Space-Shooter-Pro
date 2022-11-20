using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
=======
using UnityEngine;
using UnityEngine.UIElements;
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private GameObject _enemyLaserPrefab;

    private Player _player;
<<<<<<< HEAD
    private Animator _anim;
    private AudioSource _audioSource;
=======
    private SpawnManager _spawnManager;
    private Animator _anim;
    private AudioSource _audioSource;
    private bool _dodge = false;
    private int _dodgePath = 0; // 0 = left, 1 = right
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)

    private float _fireRate = 3.0f;
    private float _canFire = -1f;
    [SerializeField]
    private AudioClip _enemyLaserSoundClip;
    [SerializeField]
    private AudioClip _enemyExplosionSoundClip;

<<<<<<< HEAD
=======
    public int hitCounter = 1;

>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
<<<<<<< HEAD
=======
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        _audioSource = GetComponent<AudioSource>();
        
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
<<<<<<< HEAD

        CalculateMovement();
        
        if (_player != null)
        {
=======
        //CalculateMovement();
        MovementArray();

        if (_player != null)
        {
            if ( this.CompareTag("EnemyDodger") && _dodge == true)
            {
                Vector3 path = (_dodgePath == 0) ? Vector3.left : Vector3.right;
                transform.Translate(path * _speed * 1.25f * Time.deltaTime);
            }

>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
            if (Time.time > _canFire)
            {
                _fireRate = Random.Range(3f, 7f);
                _canFire = Time.time + _fireRate;
                GameObject enemyLaser = Instantiate(_enemyLaserPrefab, transform.position, Quaternion.identity);
                Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();

                for (int i = 0; i < lasers.Length; i++)
                {
                    if (this.gameObject != null)
                    {
                        lasers[i].AssignEnemyLaser();
                    }
                }

<<<<<<< HEAD
=======
                if (this.gameObject == null && lasers.Length > 0)
                {
                    Debug.Log("Enemy still fired!");
                }

>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
                _audioSource.clip = _enemyLaserSoundClip;
                _audioSource.pitch = 0.5f;
                _audioSource.Play();
            }
        }
    }

    void CalculateMovement()
    {
<<<<<<< HEAD
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
=======

        //transform.Translate(Vector3.down * Time.deltaTime * _speed);

        //if (transform.position.y <= -5.75f)
        //{
        //    float enemyRangeX = Random.Range(-9f, 9f);
        //    transform.position = new Vector3(enemyRangeX, 8f, 0);
        //}
        //int _leftrightMovement = Random.Range(0, 2);
        //MovementArray(_leftrightMovement);
    }

    void MovementArray()
    {

        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        int _leftrightMovement = Random.Range(0, 2);
        

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
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)

        if (transform.position.y <= -5.75f)
        {
            float enemyRangeX = Random.Range(-9f, 9f);
            transform.position = new Vector3(enemyRangeX, 8f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
<<<<<<< HEAD
        Debug.Log("Who fired? " + other.tag);
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
<<<<<<< HEAD
=======
                EnemyKills(1);
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
                player.playerDamage();
                _anim.SetTrigger("EnemyDestroyed");
                _speed = 1f;
                _audioSource.clip = _enemyExplosionSoundClip;
                _audioSource.Play();
                Destroy(this.gameObject, 2.8f);

            }
            
        }

        if (other.tag == "Laser")
        {
            if(_player != null)
            {
                _player.scoringSystem(10);
            }
<<<<<<< HEAD
=======
            EnemyKills(1);
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
            Destroy(other.gameObject);
            _anim.SetTrigger("EnemyDestroyed");
            _speed = 0.5f;
            _audioSource.clip = _enemyExplosionSoundClip;
            _audioSource.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.8f);
        }

        if (other.tag == "MissilePowerUp")
        {
<<<<<<< HEAD
            Debug.Log("Missile");
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
            if (_player != null)
            {
                _player.scoringSystem(10);
            }
<<<<<<< HEAD
=======
            EnemyKills(1);
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
            Destroy(other.gameObject);
            _anim.SetTrigger("EnemyDestroyed");
            _speed = 0.2f;
            _audioSource.clip = _enemyExplosionSoundClip;
            _audioSource.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.8f);
        }

    }
<<<<<<< HEAD
=======

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
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
}
