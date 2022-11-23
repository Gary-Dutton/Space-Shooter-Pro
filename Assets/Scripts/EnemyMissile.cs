using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMissile : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _rotateSpeed = 100f;
    [SerializeField]
    private AudioClip _enemyExplosionSoundClip;
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private Enemy _enemy;

    private Player _player;
    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (_rb != null)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                target = _player.transform;
            }

            if (target != null)
            {
                _rb = GetComponent<Rigidbody2D>();
            }
        }

        if (_player == null)
        {
            Debug.LogError("Player is NULL!");
        }
    }

    void Update()
    {
        if (this.gameObject.transform.position.x > 12
            || this.gameObject.transform.position.x < -12)
        {
            if (this.transform.gameObject != null)
            {
                Destroy(transform.gameObject);
            }
        }
        else if (this.gameObject.transform.position.y < -8
            || this.gameObject.transform.position.y > 8)
        {
            if (this.transform.gameObject != null)
            {
                Destroy(transform.gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        this.gameObject.SetActive(true);
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - _rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            _rb.angularVelocity = rotateAmount * _rotateSpeed;
            _rb.velocity = -transform.up * _speed;
            StartCoroutine(EnemyLaserCoolDown());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _enemy.EnemyKills(1);
            _player.playerDamage();
            _speed = 1f;
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    IEnumerator EnemyLaserCoolDown()
    {
        yield return new WaitForSeconds(15);
    }
}
