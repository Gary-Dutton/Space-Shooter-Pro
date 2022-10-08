using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.left * Input.GetAxis("Horizontal") * Time.deltaTime * _speed);
    }

    // Update is called once per frame
    void Update()
    {
        float enemyRangeX = Random.Range(-9f, 9f);

        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y <= -5.75f)
        {
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
                Destroy(this.gameObject);
            }
            
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);        
        }
        
    }
}
