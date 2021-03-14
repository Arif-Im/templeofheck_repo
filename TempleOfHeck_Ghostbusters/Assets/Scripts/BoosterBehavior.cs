using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterBehavior : MonoBehaviour
{
    [SerializeField] int numberOfTilesToStep = 3;
    [SerializeField] LayerMask whatIsStopMovement;
    bool isBoostMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!isBoostMoving && Vector3.Distance(collision.transform.position, transform.position) <= .1)
        {
            //Debug.Log("start moving");
            isBoostMoving = true;
            if (collision.gameObject.GetComponentInParent<GridMovement2D>() == null) { return; }
            collision.gameObject.GetComponentInParent<GridMovement2D>().SetBoosted(transform.position + transform.up * numberOfTilesToStep);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isBoostMoving = false;
    }

    public bool ChangeToBoostMovement()
    {
        return isBoostMoving;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * numberOfTilesToStep);
    }
}
