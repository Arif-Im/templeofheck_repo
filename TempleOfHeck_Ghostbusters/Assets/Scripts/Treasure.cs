using UnityEngine;

public class Treasure : MonoBehaviour
{
    private Collider2D coll = null;
    private Animator anim = null;
    private int pickUpID;
    private AudioSource audio = null;
    private bool pickedUp = false;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        pickUpID = Animator.StringToHash("PickUp");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collide with Player
        if(!pickedUp && collision.GetComponent<GridMovement2D>())
        {
            // PickUp event behaviours
            pickedUp = true;
            coll.enabled = false;
            anim.SetBool(pickUpID, true);
            Destroy(gameObject, 1.0f);
        }
    }
}
