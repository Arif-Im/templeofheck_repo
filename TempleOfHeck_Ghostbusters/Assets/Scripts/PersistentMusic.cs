using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
    public static PersistentMusic Instance; // Instance of Theme Music

    void Awake()
    {
        // Destroy if an Instance exists or assign this as Instance if not
        DontDestroyOnLoad(this);
        if (PersistentMusic.Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
