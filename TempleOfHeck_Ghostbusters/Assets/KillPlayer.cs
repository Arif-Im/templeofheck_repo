using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Respawn");
            Destroy(collider.gameObject);
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<GameManager>().ReloadScene();
    }
}
