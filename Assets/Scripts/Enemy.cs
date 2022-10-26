using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    
    private Player _player;
    private Animator _anim;

    private AudioSource _audioSource;

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
        
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y <= -5.75f)
        {
            float enemyRangeX = Random.Range(-9f, 9f);
            transform.position = new Vector3(enemyRangeX, 8f,0);
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
            _speed = 1f;
            _audioSource.Play();
            Destroy(this.gameObject, 2.8f);
        }
        
    }
}
