using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoulder : MonoBehaviour
{
    [SerializeField] GameObject boulder;
    [SerializeField] Treasure boulderTrigger;
    BoulderSpawner[] boulderSpawners;

    bool playOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        boulderSpawners = FindObjectsOfType<BoulderSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boulderTrigger == null)
        {
            if (!playOnce)
            {
                foreach (BoulderSpawner boulderSpawner in boulderSpawners)
                {
                    Instantiate(boulder, boulderSpawner.transform.position, Quaternion.identity);
                }
            }
            playOnce = true;
        }
    }
}
