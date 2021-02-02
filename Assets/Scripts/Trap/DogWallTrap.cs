using System.Collections;
using UnityEngine;

public class DogWallTrap : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    private bool DoorActivated = false;
    public bool playerHasDogBone = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !DoorActivated && playerHasDogBone)
        {
            DoorActivated = true;
            StartCoroutine(GoAway());
        }
    }

    IEnumerator GoAway()
    {
        anim.SetTrigger("ReceiveBone");
        yield return new WaitForSeconds(3f);
        bool goingDown = true;
        Vector3 target = transform.position - new Vector3(0, 8, 0);
        while (goingDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0.03f);
            if(transform.position.y <= target.y)
            {
                goingDown = false;
            }
            yield return new WaitForEndOfFrame();
        }
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
