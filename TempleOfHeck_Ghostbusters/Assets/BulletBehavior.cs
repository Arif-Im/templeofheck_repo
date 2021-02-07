using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;

    float speedX;
    float speedY;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody2D.velocity = new Vector2(speedX, speedY);
    }

    public void SpeedOfBullet(float bulletSpeedX, float bulletSpeedY)
    {
        speedX = bulletSpeedX;
        speedY = bulletSpeedY;
    }
}
