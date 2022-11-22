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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y < -5.75f)
        {
            Destroy(this.gameObject);
        }
        if(transform.position.y >= 0.5 && transform.position.y <= 3)
        {
            StartCoroutine(StopPowerUp3s());
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
                Debug.Log("Who? " + this.tag);
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
            Debug.Log("Who? " + this.tag);
            switch (_powerUpID)
            {
                case 2:
                    _enemy.EnemyShieldOnline(true);
                    Destroy(this.gameObject);
                    Debug.Log("Enemy should have a sheild!");
                    break;
                default:
                    Debug.Log("Default switch enabled...");
                    break;
            }
        }
    }

    IEnumerator StopPowerUp3s ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * -3);
        yield return new WaitForSeconds(3f);
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }
}
