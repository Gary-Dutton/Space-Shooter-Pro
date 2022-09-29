using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public or private reference
    // data type (int, float, bool, string)
    // every variable has a name
    // optional value assigned
    [SerializeField]
    private float _speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        // take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis ("Horizontal");
        float VerticalInput = Input.GetAxis ("Vertical");

        // new Vector3(5,0,0) * real time * 5
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * _speed);
        transform.Translate(Vector3.up * VerticalInput * Time.deltaTime * _speed);

        // if player position on the y is greater than 0, y position = 0 or y position = 3.5
        // if player position on the x is greater than 10.20 or less than -10.20, then switch to opposite value

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        } else if (transform.position.y <=-3.5f)
        {
            transform.position = new Vector3(transform.position.x, -3.5f, 0);
        }

        if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        } else if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
    }
}
