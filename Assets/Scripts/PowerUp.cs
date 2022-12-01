using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerUpID;
    [SerializeField]
    private AudioClip _clip;
    [SerializeField]
    private Enemy _enemy;

    private Player _player;
    private float _distanceToActivate = 5f;
    private float _pickUpSpeed;

    void Start()
    { 
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            transform.Translate(Vector3.down * Time.deltaTime * _speed);
            float _distanceBetweenPlayerAndPickup = Vector2.Distance(transform.position, _player.transform.position);

            if (_distanceBetweenPlayerAndPickup < _distanceToActivate && Input.GetKey(KeyCode.C))
            {
                _pickUpSpeed = _distanceToActivate - _distanceBetweenPlayerAndPickup;
                transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _pickUpSpeed * Time.deltaTime);
            }

            if (transform.position.y < -5.75f)
            {
                Destroy(this.gameObject);
            }
            if (transform.position.y >= 0.5 && transform.position.y <= 3)
            {
                StartCoroutine(StopPowerUp3s());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, transform.position);

            if (player != null)
            {
                switch (_powerUpID)
                {
                    case 0:
                        player.tripleShot();
                        break;
                    case 1:
                        player.speedBoost();
                        break;
                    case 2:
                        player.ShieldOnline();
                        break;
                    case 3:
                        player.AmmoReload();
                        break;
                    case 4:
                        player.HealthRecovery();
                        break;
                    case 5:
                        player.MultipleLasersCall();
                        break;
                    case 6:
                        player.NoAmmo();
                        break;
                    default:
                        Debug.Log("Default switch enabled...");
                        break;
                }
            }

            Destroy(this.gameObject);
        }
        if (other.tag == "NewEnemyShip")
        {
            Enemy _enemy = other.transform.GetComponent<Enemy>();
            switch (_powerUpID)
            {
                case 2:
                    _enemy.EnemyShieldOnline(true);
                    Destroy(this.gameObject);
                    break;
                default:
                    Debug.Log("Default switch enabled...");
                    break;
            }
        }
        else if (other.tag == "EnemyLaser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    IEnumerator StopPowerUp3s ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * -3);
        yield return new WaitForSeconds(3f);
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }
}
