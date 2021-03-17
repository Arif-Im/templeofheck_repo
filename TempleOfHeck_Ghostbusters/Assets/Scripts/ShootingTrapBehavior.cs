using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrapBehavior : MonoBehaviour
{
    [SerializeField] BulletBehavior bulletPrefab;
    [SerializeField] bool repeating = false;
    [SerializeField] float repeatTimer = 0.5f;
    [SerializeField] float bulletSpeedX = -3f;
    [SerializeField] float bulletSpeedY = 0f;
    [SerializeField] bool isShootingHorizontally = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine("RepeatShooting");
        }
        while (repeating);
    }

    IEnumerator RepeatShooting()
    {
        BulletBehavior bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        if (isShootingHorizontally)
        {
            bullet.GetComponent<BulletBehavior>().SpeedOfBullet(bulletSpeedX, 0);
        }
        else
        {
            bullet.GetComponent<BulletBehavior>().SpeedOfBullet(0, bulletSpeedY);
        }

        yield return new WaitForSeconds(repeatTimer);
    }
}
