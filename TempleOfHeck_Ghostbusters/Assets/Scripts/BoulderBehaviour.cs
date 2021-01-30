using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderBehaviour : MonoBehaviour
{
    [SerializeField] float xSpeed = 1;
    [SerializeField] float ySpeed = 1;
    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody2D.velocity = new Vector3(xSpeed, ySpeed, 0);
    }
}
