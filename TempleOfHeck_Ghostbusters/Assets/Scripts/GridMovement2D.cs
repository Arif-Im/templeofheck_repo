using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement2D : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask whatIsStopMovement;
    [SerializeField] float drawCircleRadius = 0.8f;

    bool isBoosted = false;
    Vector3 boostTarget;

    BoosterBehavior boosterBehavior;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        boosterBehavior = FindObjectOfType<BoosterBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBoosted)
        {
            BoosterMovement();
        }
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) / 2, drawCircleRadius, whatIsStopMovement))
                {
                    movePoint.position += new Vector3(Mathf.RoundToInt(Input.GetAxisRaw("Horizontal")), 0, 0);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Mathf.RoundToInt(Input.GetAxisRaw("Vertical")), 0f) / 2, drawCircleRadius, whatIsStopMovement))
                {
                    movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                }
            }
        }
    }

    private void BoosterMovement()
    {
        if(Vector3.Distance(movePoint.position, boostTarget) >= 0.05)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) / 2, drawCircleRadius, whatIsStopMovement))
            {
                movePoint.position = Vector3.MoveTowards(movePoint.position, new Vector3(Mathf.RoundToInt(boostTarget.x), Mathf.RoundToInt(boostTarget.y), 0), 0.5f);
            }
            //else
            //{
            //    Vector3 direction = (boostTarget - movePoint.position).normalized;
            //    // Does the ray intersect any objects excluding the player layer
            //    if (Physics2D.Raycast(movePoint.position, direction, 1, whatIsStopMovement))
            //    {
            //        Debug.Log("hit");
            //        isBoosted = false;
            //    }
            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Debug.Log("wall is hit");
            movePoint.position = new Vector3(Mathf.RoundToInt(movePoint.position.x), Mathf.RoundToInt(movePoint.position.y), 0);
            isBoosted = false;
        }
    }

    public void SetBoosted(Vector3 targetPosition)
    {
        Debug.Log(movePoint.position + " " + targetPosition);
        boostTarget = targetPosition;
        isBoosted = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) / 2 + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) / 2, drawCircleRadius);
    }
}
