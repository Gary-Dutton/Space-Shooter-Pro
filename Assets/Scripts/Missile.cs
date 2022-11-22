using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]

public class Missile : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed = 50f;
    [SerializeField]
    private float _rotateSpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        if (_rb != null)
        {
            if (GameObject.FindGameObjectWithTag("Enemy"))
            {
                target = GameObject.FindGameObjectWithTag("Enemy").transform;
            }
            else if(GameObject.FindGameObjectWithTag("EnemyDodger"))
            {
                target = GameObject.FindGameObjectWithTag("EnemyDodger").transform;
            }
            
            if (target != null)
            {
                _rb = GetComponent<Rigidbody2D>();
            }
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
            _rb.angularVelocity = -rotateAmount * _rotateSpeed;
            _rb.velocity = transform.up * _speed;
        }
    }
}
