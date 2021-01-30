using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
    #region References
    [SerializeField] private GameManager game = null;
    [SerializeField] private ParticleSystem blood = null;
    [SerializeField] private AudioSource bloodSplatter = null;
    [SerializeField] private AudioSource bloodSpill = null;
    [SerializeField] private Animator playerAnim = null;
    private int deadID;
    private GridMovement2D playerMovement = null;

    #endregion

    public bool isDead = false;
    public float deathTime = 2.0f;

    void Awake()
    {
        playerMovement = GetComponent<GridMovement2D>();
        if(playerMovement == null)
        {
            Debug.Log("GridMovement2D component not attached onto " + gameObject.name + " for Death component to reference.");
        }
        deadID = Animator.StringToHash("Dead");
    }

    public void Activate()
    {
        if(!isDead)
        {
            isDead = true;
            CinemachineShake.Instance.ShakeCamera(8, 0.5f);
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        playerMovement.enabled = false;
        playerAnim.SetBool(deadID, true);
        blood.Play();
        bloodSplatter.Play();
        bloodSpill.PlayScheduled(0.2f);

        yield return new WaitForSeconds(deathTime);

        game.ReloadScene();
    }
}
