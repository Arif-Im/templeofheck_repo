using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingSpikeBehavior : MonoBehaviour
{
    [SerializeField] float startingKillTime;
    float killTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("killtime = " + killTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GridMovement2D>())
        {
            killTime = startingKillTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<GridMovement2D>())
        {
            if (killTime > 0)
            {
                killTime -= Time.deltaTime;
            }
            else
            {

                collision.gameObject.GetComponent<Death>().Activate();
            }
        }
    }
}
