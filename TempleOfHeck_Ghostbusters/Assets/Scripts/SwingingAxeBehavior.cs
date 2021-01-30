﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingAxeBehavior : MonoBehaviour
{
    [SerializeField] float startingKillTime;
    float killTime;

    [SerializeField] float startingNoKillTime;
    float noKillTime;

    [SerializeField] Color32 color;
    Color32 startingColor;

    // Start is called before the first frame update
    void Start()
    {
        startingColor = color;
        noKillTime = startingNoKillTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (noKillTime > 0)
        {

        }
    }
}
