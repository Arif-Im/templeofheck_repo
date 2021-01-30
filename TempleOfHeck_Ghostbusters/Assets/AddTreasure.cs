using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTreasure : MonoBehaviour
{
    Treasure[] treasures;
    int numberOfTreasuresCollected = 0;
    int totalNumberOfTreasures;
    bool playOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        treasures = FindObjectsOfType<Treasure>();
        totalNumberOfTreasures = treasures.Length;
        Debug.Log(treasures.Length);
    }

    // Update is called once per frame
    void Update()
    {
        CollectTreasure();
    }

    void CollectTreasure()
    {
        //foreach (Treasure treasure in treasures)
        //{
        //    if(Vector3.Distance(transform.position, treasure.transform.position) <= .05f)
        //    {
        //        treasure.gameObject.SetActive(false);
        //        numberOfTreasuresCollected += 1;
        //        Debug.Log(treasures.Length);
        //    }
        //    if (numberOfTreasuresCollected >= treasures.Length)
        //    {
        //        if (playOnce == false)
        //        {
        //            Debug.Log("you win!");
        //            playOnce = true;
        //        }
        //    }
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Treasure treasure = collision.GetComponent<Treasure>();

        if (treasure != null)
        {
            Destroy(treasure.gameObject);
            numberOfTreasuresCollected += 1;
        }

        if(numberOfTreasuresCollected >= totalNumberOfTreasures)
        {
            Debug.Log("you win!");
        }
    }
}
