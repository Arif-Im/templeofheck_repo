using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    float raycastDistance = 1.5f;
    LayerMask pushableBlock;
    GridMovement2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<GridMovement2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player.gameObject.GetComponent<Death>().Activate();
            /*
            player.gameObject.SetActive(false);
            StartCoroutine("Respawn");
            */
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<GameManager>().ReloadScene();
    }
}
