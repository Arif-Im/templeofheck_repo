using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTreasure : MonoBehaviour
{
    Treasure[] treasures;
    int numberOfTreasuresCollected = 0;
    int totalNumberOfTreasures;

    // Start is called before the first frame update
    void Start()
    {
        treasures = FindObjectsOfType<Treasure>();
        totalNumberOfTreasures = treasures.Length;
    }

    // Update is called once per frame
    void Update()
    {

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
            GoToNextLevel();
        }
    }

    void GoToNextLevel()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.StartCoroutine("LoadNextScene");
    }
}
