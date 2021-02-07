using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateKillPlayer : MonoBehaviour
{
    [SerializeField] GameObject shadow;
    Death player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillMoment()
    {
        player = GetComponentInParent<DroppingSpikeBehavior>().player;
        transform.parent.gameObject.layer = 8;
        shadow.SetActive(false);
        if (CinemachineShake.Instance != null)
            CinemachineShake.Instance.ShakeCamera(5.0f, 0.4f);
        if (player == null) { return; }
        player.Activate();
    }
}
