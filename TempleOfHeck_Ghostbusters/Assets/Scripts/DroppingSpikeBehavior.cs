using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingSpikeBehavior : MonoBehaviour
{
    [SerializeField] float startingKillTime;
    Animator anim;
    float killTime;
    bool isFalling = false;
    GameObject shadow;

    float shadowScaleX;
    float shadowScaleY;

    [SerializeField] Vector3 targetSize;
    Vector3 startingSize;

    public Death player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        shadow = transform.GetChild(1).gameObject;
        startingSize = shadow.transform.localScale;
        shadowScaleX = shadow.transform.localScale.x;
        shadowScaleY = shadow.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            if (killTime > 0)
            {
                killTime -= Time.deltaTime;
                if(shadowScaleX < targetSize.x && shadowScaleY < targetSize.y)
                {
                    shadowScaleX += Time.deltaTime;
                    shadowScaleY += Time.deltaTime;
                    shadow.transform.localScale = new Vector3(shadowScaleX, shadowScaleY, shadow.transform.localScale.z);
                }
            }
            else
            {
                anim.SetTrigger("dropSpike");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Death>())
        {
            isFalling = true;
            killTime = startingKillTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Death>())
        {
            player = collision.GetComponent<Death>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Death>())
        {
            player = null;
        }
    }
}
