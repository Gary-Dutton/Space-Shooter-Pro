using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
public class MultipleLasers : MonoBehaviour
{
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private int _numberOfLasers = 3;
    [SerializeField]
    private float _angleOfSpread = 90f;
    [SerializeField]
    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        if (_rb != null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MultipleLasersPowerUp()
    {
        float facingRotation = Mathf.Atan2(_laser.transform.position.y, _laser.transform.position.x) * Mathf.Rad2Deg;
        float startRotation = facingRotation - _angleOfSpread / 2f;
        float angleIncrease = _angleOfSpread / ((float)_numberOfLasers - 1f);

        for (int i = 0; i < _numberOfLasers; i++)
        {
            float tempRotation = startRotation - angleIncrease * i;
            GameObject newLaser = Instantiate(_laser, transform.position, Quaternion.Euler(0f, 0f, tempRotation));
            MultipleLasers temp = newLaser.GetComponent<MultipleLasers>();
            if (temp)
            {
                _ = (new Vector2(Mathf.Cos(tempRotation * Mathf.Deg2Rad), Mathf.Sin(tempRotation * Mathf.Deg2Rad)));
            }
        }
    }

    public void MultipleLasersPowerUpCall()
    {
        MultipleLasersPowerUp();
    }


}
