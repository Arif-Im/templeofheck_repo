using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingAxeBehavior : MonoBehaviour
{
    [SerializeField] float startingKillTime;
    float killTime;
    bool killPlayer = false;

    //[SerializeField] float startingNoKillTime;
    //float noKillTime;

    //[SerializeField] Color32 color;
    //Color32 startingColor;

    // Start is called before the first frame update
    void Start()
    {
        //startingColor = color;
        //noKillTime = startingNoKillTime;
    }

    // Update is called once per frame
    void Update()
    {
        SwingingAxeMechanic();
    }

    private void SwingingAxeMechanic()
    {
        //Debug.Log("kill time = " + killTime + " kill player = " + killPlayer);

        if (killTime > 0)
        {
            killPlayer = false;
            killTime -= Time.deltaTime;
        }
        else
        {
            killPlayer = true;
            killTime = startingKillTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Death>())
        {
            if (killPlayer)
            {
                collision.GetComponent<Death>().Activate();
            }
        }
    }
}
