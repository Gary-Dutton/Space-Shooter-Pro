using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private GameObject _enemyLaserPrefab;

    private Player _player;
    private Animator _anim;
    private AudioSource _audioSource;

    private float _fireRate = 3.0f;
    private float _canFire = -1f;
    [SerializeField]
    private AudioClip _enemyLaserSoundClip;
    [SerializeField]
    private AudioClip _enemyExplosionSoundClip;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
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

        CalculateMovement();
        
        if (_player != null)
        {
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

                if (this.gameObject == null && lasers.Length > 0)
                {
                    Debug.Log("Enemy still fired!");
                }

                _audioSource.clip = _enemyLaserSoundClip;
                _audioSource.pitch = 0.5f;
                _audioSource.Play();
            }
        }
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y <= -5.75f)
        {
            float enemyRangeX = Random.Range(-9f, 9f);
            transform.position = new Vector3(enemyRangeX, 8f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
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
            if (_player != null)
            {
                _player.scoringSystem(10);
            }
            Destroy(other.gameObject);
            _anim.SetTrigger("EnemyDestroyed");
            _speed = 0.2f;
            _audioSource.clip = _enemyExplosionSoundClip;
            _audioSource.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.8f);
        }

    }
}
