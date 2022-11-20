using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]

public class Missile : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    public Transform _target;
=======
    public Transform target;
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
    public Transform target;
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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
<<<<<<< HEAD
<<<<<<< HEAD
        { 
            _target = GameObject.FindGameObjectWithTag("Enemy").transform;
            _rb = GetComponent<Rigidbody2D>();
        }
    }


     void FixedUpdate()
    {
        this.gameObject.SetActive(true);
        if (_target != null)
        {
            Vector2 direction = (Vector2)_target.position - _rb.position;
=======
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
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
<<<<<<< HEAD
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            _rb.angularVelocity = -rotateAmount * _rotateSpeed;
            _rb.velocity = transform.up * _speed;
        }
<<<<<<< HEAD
<<<<<<< HEAD
        
    }

=======
    }
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
=======
    }
>>>>>>> parent of 809a702 (Deploying to main from @ Gary-Dutton/Space-Shooter-Pro@aac516a53bc75fcb6a382446cf770b671244d2c4 🚀)
}
