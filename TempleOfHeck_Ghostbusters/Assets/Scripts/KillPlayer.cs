using System.Collections;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Kill Player Script that kills the player if they collide with the GameObject
/// </summary>
public class KillPlayer : MonoBehaviour
{
    // Variables for delays between kill states
    [SerializeField]
    private float safeDuration = 0.0f; // Delay between kill states
    [SerializeField]
    private float killDuration = 0.0f; // Duration of kill state
    private float lastStateTransitionTime = 0.0f; // Time of state transition
    private bool killState = true; // State of kill
    [SerializeField]
    private Animator anim = null;
    private int safeID;
    [SerializeField]
    private float startUpDelay = 0.0f; // Delay in counter for safe and kill durations for variable trap times

    float raycastDistance = 1.5f;
    LayerMask pushableBlock;
    GridMovement2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<GridMovement2D>();
        lastStateTransitionTime = startUpDelay == 0.0f ? 0.0f : Time.time;
        safeID = Animator.StringToHash("Safe");
        Invoke("StartKillStates", startUpDelay);    // Delay kill states switching for variable trap times
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Death>())
        {
            if (killState)
                player.gameObject.GetComponent<Death>().Activate();
            /*
            player.gameObject.SetActive(false);
            StartCoroutine("Respawn");
            */
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Death>())
        {
            if (killState)
            {
                player.gameObject.GetComponent<Death>().Activate();
            }
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<GameManager>().ReloadScene();
    }

    private void StartKillStates()
    {
        lastStateTransitionTime = Time.time;
        StartCoroutine("KillStates");
    }

    // Coroutine that cycles through Kill and Safe states with a duration that can be set for either, default to only kill state other wise
    IEnumerator KillStates()
    {
        while (true && safeDuration > 0)
        {
            // Transition between safe and kill states with different durations for both
            if (killDuration > 0 && !killState)
            {
                if (Time.time - lastStateTransitionTime >= safeDuration)
                {
                    killState = !killState;
                    lastStateTransitionTime = Time.time;
                    if (anim != null)
                        anim.SetBool(safeID, false);
                }
            }
            else
            {
                if (Time.time - lastStateTransitionTime >= killDuration)
                {
                    killState = !killState;
                    lastStateTransitionTime = Time.time;
                    if (anim != null)
                        anim.SetBool(safeID, true);
                }
            }
            //Debug.Log(killState);
            yield return null;
        }
    }
}
