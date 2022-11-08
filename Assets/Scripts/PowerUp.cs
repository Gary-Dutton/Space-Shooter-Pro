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

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y < -5.75f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
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
<<<<<<< HEAD
                    case 4:
                        player.HealthRecovery();
                        break;
=======
>>>>>>> 7826e9eefe9e31bad8ffff4afd66887b33481ee4
                    default:
                        Debug.Log("Default switch enabled...");
                        break;
                }
            }
            
            Destroy(this.gameObject);
        }
    }
}
