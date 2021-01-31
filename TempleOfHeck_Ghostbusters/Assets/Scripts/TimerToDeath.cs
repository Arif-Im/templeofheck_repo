using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimerToDeath : MonoBehaviour
{
    [SerializeField] float timerToDeath = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerToDeath > 0)
        {
            timerToDeath -= Time.deltaTime;
        }
        else
        {
            FindObjectOfType<Death>().Activate();
        }
    }
}
