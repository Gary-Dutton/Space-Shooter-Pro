using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]

public class Missile : MonoBehaviour
{
    public Transform _target;
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
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            _rb.angularVelocity = -rotateAmount * _rotateSpeed;
            _rb.velocity = transform.up * _speed;
        }
        
    }

}
