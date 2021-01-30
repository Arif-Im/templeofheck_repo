using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] List<Transform> waypoint;
    [SerializeField] float movementSpeed = 5;
    int waypointIndex = 0;

    // Start is called before the first frame update

    void Start()
    {
        transform.position = waypoint[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoint.Count - 1)
        {
            var targetPosition = waypoint[waypointIndex].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            waypointIndex = 0;
        }
    }
}
