using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingAxeBehavior : MonoBehaviour
{
    [SerializeField] float startingKillTime;
    [SerializeField] Color32 color;
    Color32 startingColor;

    // Start is called before the first frame update
    void Start()
    {
        startingColor = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
