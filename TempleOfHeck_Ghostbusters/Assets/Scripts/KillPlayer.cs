using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    GridMovement2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<GridMovement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) <= 0.05)
        {
            player.gameObject.GetComponent<Death>().Activate();
            /*
            player.gameObject.SetActive(false);
            StartCoroutine("Respawn");
            */
        }
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.gameObject.CompareTag("Player"))
    //    {
    //        StartCoroutine("Respawn");
    //        Destroy(collider.gameObject);
    //    }
    //}

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<GameManager>().ReloadScene();
    }
}
