using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement2D : MonoBehaviour
{
    [SerializeField] float raycastDistance = 1.5f;
    [SerializeField] LayerMask whatIsPushableBlock;

    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float pushMovementSpeed = 2.5f;
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask whatIsStopMovement;
    [SerializeField] float drawCircleRadius = 0.8f;
    [SerializeField] Animator playerAnim = null;
    [SerializeField] SpriteRenderer sprite = null;
    private int runningID;
    float originalMovementSpeed;

    bool isBoosted = false;
    Vector3 boostTarget;

    bool isOnBooster = false;
    Vector3 direction;

    bool pushBlock = false;
    bool blockTouchWall = false;

    // Start is called before the first frame update
    void Start()
    {
        originalMovementSpeed = movementSpeed;
        movePoint.parent = null;
        runningID = Animator.StringToHash("Running");
    }

    // Update is called once per frame
    void Update()
    {
        PushableBlockMovement();

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
                if (!blockTouchWall)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) / 2, drawCircleRadius, whatIsStopMovement))
                    {
                        movePoint.position += new Vector3(Mathf.RoundToInt(Input.GetAxisRaw("Horizontal")), 0, 0);
                    }
                }
                sprite.flipX = Input.GetAxisRaw("Horizontal") > 0 ? true: false;
                playerAnim.SetBool(runningID, true);
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                playerAnim.SetBool(runningID, true);
                if (!blockTouchWall)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Mathf.RoundToInt(Input.GetAxisRaw("Vertical")), 0f) / 2, drawCircleRadius, whatIsStopMovement))
                    {
                        movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                    }
                }
            }
            else
            {
                playerAnim.SetBool(runningID, false);
            }
        }
    }

    void PushableBlockMovement()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f).normalized;
        RaycastHit2D hitBlock = Physics2D.Raycast(transform.position, direction, raycastDistance, whatIsPushableBlock);
        RaycastHit2D hitWall = Physics2D.Raycast(transform.position, direction, raycastDistance, whatIsStopMovement);

        //Debug.Log("Input of x = " + Input.GetAxisRaw("Horizontal") + ". Input of y = " + Input.GetAxisRaw("Vertical") + ". Direction = " + direction);

        if (pushBlock)
        {
            if (hitBlock)
            {
                movementSpeed = pushMovementSpeed;
            }

            if (hitBlock && hitWall)
            {
                blockTouchWall = true;
            }
            else
            {
                blockTouchWall = false;
            }
        }
        else
        {
            movementSpeed = originalMovementSpeed;
        }
    }

    private void BoosterMovement()
    {
        if(Vector3.Distance(movePoint.position, boostTarget) >= 0.05f)
        {
            movePoint.position = new Vector3(Mathf.RoundToInt(boostTarget.x), Mathf.RoundToInt(boostTarget.y), 0f);

            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) / 2, drawCircleRadius, whatIsStopMovement))
            {
                movePoint.position = Vector3.MoveTowards(movePoint.position, new Vector3(Mathf.RoundToInt(boostTarget.x), Mathf.RoundToInt(boostTarget.y), 0), 0.5f);
            }

            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) / 2, drawCircleRadius, whatIsStopMovement))
            {
                movePoint.position = Vector3.MoveTowards(movePoint.position, new Vector3(Mathf.RoundToInt(boostTarget.x), Mathf.RoundToInt(boostTarget.y), 0), 0.5f);
            }
        }
        else if(Vector3.Distance(movePoint.position, boostTarget) <= 0.05f)
        {
            isBoosted = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BoosterBehavior>())
        {
            isOnBooster = true;
        }
        if(!isOnBooster && collision.gameObject.layer == 8)
        {
            Debug.Log("wall is hit");
            movePoint.position = new Vector3(Mathf.RoundToInt(movePoint.position.x), Mathf.RoundToInt(movePoint.position.y), 0);
            isBoosted = false;
        }

        if (collision.gameObject.layer == 10)
        {
            pushBlock = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BoosterBehavior>())
        {
            isOnBooster = false;
        }

        if (collision.gameObject.layer == 10)
        {
            pushBlock = false;
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
        //Gizmos.DrawSphere(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) / 2 + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) / 2, drawCircleRadius);
        Gizmos.DrawLine(transform.position, transform.position + direction * raycastDistance);
    }
}
