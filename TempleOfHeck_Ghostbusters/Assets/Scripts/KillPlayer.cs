using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class KillPlayer : MonoBehaviour
{
    // Variables for delays between kill states
    [SerializeField]
    private float safeDuration = 0.0f; // Delay between kill states
    [SerializeField]
    private float killDuration = 0.0f; // Duration of kill state
    private float lastStateTransitionTime = 0.0f; // Time of state transition
    private bool killState = false; // State of kill
    public Animator anim = null;
    private int safeID;

    float raycastDistance = 1.5f;
    LayerMask pushableBlock;
    GridMovement2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<GridMovement2D>();
        lastStateTransitionTime = Time.time;
        safeID = Animator.StringToHash("Safe");
    }

    private void Update()
    {
        // Transition between safe and kill states with different durations for both
        if(safeDuration > 0 && killState)
        {
            if(Time.time - lastStateTransitionTime >= killDuration)
            {
                killState = !killState;
                lastStateTransitionTime = Time.time;
                if (anim != null)
                    anim.SetBool(safeID, true);
            }
        }
        else
        {
            if (Time.time - lastStateTransitionTime >= safeDuration)
            {
                killState = !killState;
                lastStateTransitionTime = Time.time;
                if (anim != null)
                    anim.SetBool(safeID, false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Death>())
        {
            if(killState)
                player.gameObject.GetComponent<Death>().Activate();
            /*
            player.gameObject.SetActive(false);
            StartCoroutine("Respawn");
            */
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<GameManager>().ReloadScene();
    }
}
