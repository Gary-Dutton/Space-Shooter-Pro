using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public CameraShake _cameraShake;

    [SerializeField]
    private int _numberOfHits = 10;
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private bool _isSheildActive;
    [SerializeField]
    private bool _isMissileReady;
    [SerializeField]
    private GameObject _bossLaserPrefab;
    [SerializeField]
    private AudioClip _enemyLaserSoundClip;
    [SerializeField]
    private AudioClip _enemyExplosionSoundClip;
    [SerializeField]
    private Animator[] _explosions;
    [SerializeField]
    private GameObject[] _explosionsGameObject;

    private float _fireRate = 3.0f;
    private float _canFire = -1f;

    private Player _player;
    private SpriteRenderer _spriteLayer;
    private SpawnManager _spawnManager;
    private AudioSource _audioSource;
    private bool _readyToFall;

    public float gravitySpeed = 12f;
    public float gravity = -9.81f;


    // Start is called before the first frame update
    void Start()
    {
        _explosions[0].enabled = false;
        _explosions[1].enabled = false;

        _player = GameObject.Find("Player").GetComponent<Player>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        _spriteLayer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();

        particleSystem.Play();
        StartCoroutine(_cameraShake.Shake(0.09f, 0.09f));

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < 5.45)
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
        else if (this.gameObject.transform.position.y <= 8 && this.gameObject.transform.position.y >= 5.5)
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

            if (transform.position.y <= 5.4f)
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
                Debug.Log("Explosion should appear");
            }
            else if (_numberOfHits > 3 && _numberOfHits <= 5)
            {
                _explosionsGameObject[1].SetActive(true);
                _explosions[1].enabled = true;
                _cameraShake.Shake(0.05f, 0.05f);
                Debug.Log("Second explosion, shaking should start");
            }
            else if (_numberOfHits > 1 && _numberOfHits <= 3)
            {
                _readyToFall = true;
                Debug.Log("Third explosion, shaking and add small gravity and sideways tilt");
            }
            else if (_numberOfHits == 0 )
            {
                Debug.Log("Full explosion and drop from the sky (z) change layer to background too");
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
        if (Time.time > _canFire)
        {
            _fireRate = Random.Range(3f, 7f);
            _canFire = Time.time + _fireRate;
            GameObject bossLaser = Instantiate(_bossLaserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = bossLaser.GetComponentsInChildren<Laser>();

            if ((this.gameObject.transform.position.y - _player.transform.position.y) <= 8)
            {
                for (int i = 0; i < lasers.Length; i++)
                {
                    if (this.gameObject != null)
                    {
                        lasers[i].AssignBossLaser();
                    }
                }
            }
            _audioSource.clip = _enemyLaserSoundClip;
            _audioSource.pitch = 0.5f;
            _audioSource.Play();
        }
    }

}
