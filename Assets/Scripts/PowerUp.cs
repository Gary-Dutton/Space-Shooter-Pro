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
                    case 4:
                        player.HealthRecovery();
                        break;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
                    case 5:
                        player.MultipleLasersCall();
                        break;
                    case 6:
                        player.NoAmmo();
                        break;
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
                    default:
                        Debug.Log("Default switch enabled...");
                        break;
                }
            }
            
            Destroy(this.gameObject);
        }
    }
}
