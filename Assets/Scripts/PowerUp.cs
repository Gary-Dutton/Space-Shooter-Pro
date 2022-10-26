using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerUpID;
    [SerializeField]
    private AudioClip _clip;

    // Start is called before the first frame update
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, transform.position);
            
            if (player != null)
            {
                switch (powerUpID)
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
                    default:
                        Debug.Log("Default switch enabled...");
                        break;
                }
            }
            
            Destroy(this.gameObject);
        }
    }
}
