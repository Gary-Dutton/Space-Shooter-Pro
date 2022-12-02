using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public CameraShake _cameraShake;


    [SerializeField]
    public float gravitySpeed = 12f;
    [SerializeField]
    public float gravity = -9.81f;
    [SerializeField]
    private int _numberOfHits = 10;
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private bool _isSheildActive;
    [SerializeField]
    private bool _isMissileReady;
    [SerializeField]
    private GameObject[] _bossProjectilePrefab;
    [SerializeField]
    private AudioClip _enemyLaserSoundClip;
    [SerializeField]
    private AudioClip _enemyExplosionSoundClip;
    [SerializeField]
    private Animator[] _explosions;
    [SerializeField]
    private GameObject[] _explosionsGameObject;
    [SerializeField]
    private UIManager _uiManager;


    private bool _readyToFall;
    private float _tractorBeam;
    private float _fireRate = 3.0f;
    private float _canFire = -1f;
    private float _distanceToActivate = 8f;

    private Player _player;
    private SpriteRenderer _spriteLayer;
    private SpawnManager _spawnManager;
    private Animator _animator;
    private AudioSource _audioSource;



    // Start is called before the first frame update
    void Start()
    {
        _explosions[0].enabled = false;
        _explosions[1].enabled = false;

        _player = GameObject.Find("Player").GetComponent<Player>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _animator= GetComponent<Animator>();

        _spriteLayer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        particleSystem.gameObject.SetActive(true);
        particleSystem.Play();
        StartCoroutine(_cameraShake.Shake(0.09f, 0.09f));

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < 5.1)
        {
            if (_player != null)
            {
                BossLaserShot();        
            }

            if (particleSystem != null)
            {
                StartCoroutine(ParticleCoverage());
                StartCoroutine(_cameraShake.Shake(0.07f, 0.07f));
            }
        }
        else if (this.gameObject.transform.position.y <= 8 && this.gameObject.transform.position.y >= 5.1)
        {
            StartCoroutine(_cameraShake.Shake(0.05f, 0.05f));
        }
        else
        {
            EnemyMovement();
        }

        EnemyMovement();
    }

    private void EnemyMovement()
    {
        if (_player != null)
        {
            transform.Translate(Vector3.down * Time.deltaTime * _speed);

            if (transform.position.y <= 5.0f)
            {
                transform.Translate(Vector3.up * Time.deltaTime * _speed);
            }
            else if (transform.position.y >= 6.8f)
            {
                transform.Translate(Vector3.down * Time.deltaTime * _speed);
            }
        }
    }

    public void BossDamage()
    {
        if (_player != null)
        {
            _numberOfHits--;
            StartCoroutine(_cameraShake.Shake(0.05f, 0.05f));

            if (_numberOfHits <= 7 && _numberOfHits > 5)
            {
                _explosionsGameObject[0].SetActive(true);
                _explosions[0].enabled = true;
            }
            else if (_numberOfHits > 3 && _numberOfHits <= 5)
            {
                _explosionsGameObject[1].SetActive(true);
                _explosions[1].enabled = true;
                _cameraShake.Shake(0.05f, 0.05f);
            }
            else if (_numberOfHits > 1 && _numberOfHits <= 3)
            {
                _readyToFall = true;
            }
            else if (_numberOfHits <= 0 )
            {
                
                _cameraShake.Shake(2.5f, 2.5f);
                _animator.gameObject.SetActive(true);
                _animator.enabled = true;
                _canFire = 99f;
                float _distanceBetweenPlayerAndBoss = Vector2.Distance(transform.position, this.transform.position);
                Debug.Log("Distance between player and Boss: " + _distanceBetweenPlayerAndBoss);
                if (_distanceBetweenPlayerAndBoss <= 16f)
                {
                    _tractorBeam = _distanceToActivate - _distanceBetweenPlayerAndBoss;
                    transform.position = Vector2.MoveTowards(transform.position, this.transform.position, _tractorBeam * Time.deltaTime);
                }
                StartCoroutine(BossDeathScene());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            BossDamage();
            Destroy(other.gameObject);
        }
    }


    IEnumerator ParticleCoverage()
    {
        yield return new WaitForSeconds(1f);
        if (particleSystem != null)
        {
            particleSystem.Stop();
            yield return new WaitForSeconds(7f);
            _spriteLayer.sortingLayerName = "Foreground";
            StopCoroutine(_cameraShake.Shake(0.09f, 0.09f));
        }

    }

    private void BossLaserShot()
    {
        if (particleSystem == null && this.gameObject != null)
        {
            if (Time.time > _canFire)
            {
                _fireRate = Random.Range(3f, 7f);
                _canFire = Time.time + _fireRate;
                int _automaticSelection = Random.Range(0, 2);
                GameObject bossLaser = Instantiate(_bossProjectilePrefab[_automaticSelection], transform.position, Quaternion.identity);
                Laser[] projectile = bossLaser.GetComponentsInChildren<Laser>();
                for (int i = 0; i < projectile.Length; i++)
                {
                    if (this.gameObject != null)
                    {
                        projectile[i].AssignBossLaser();
                    }
                }
                _audioSource.clip = _enemyLaserSoundClip;
                _audioSource.pitch = 0.5f;
                _audioSource.Play();
            }
        }
    }

    IEnumerator  BossDeathScene()
    {
        yield return new WaitForSeconds(7f);
        Destroy(this.gameObject);
        _uiManager.UpdateLives(0);
    }
}
