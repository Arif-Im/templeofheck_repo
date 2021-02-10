using UnityEngine;

public class Treasure : MonoBehaviour
{
    private Collider2D coll = null;
    private Animator anim = null;
    private int pickUpID;
    private AudioSource audio = null;
    private ParticleSystem particles = null;
    public bool pickedUp { get; private set; }
    public bool treasureAdded { get; set; }

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        particles = GetComponentInChildren<ParticleSystem>();
        pickUpID = Animator.StringToHash("PickUp");
        pickedUp = false;
        treasureAdded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collide with Player
        if(!pickedUp && collision.GetComponent<GridMovement2D>())
        {
            // PickUp event behaviours
            pickedUp = false;
            coll.enabled = false;
            anim.SetBool(pickUpID, true);
            audio.Play();
            particles.Stop();
            Destroy(gameObject, 2.0f);
        }
    }
}
