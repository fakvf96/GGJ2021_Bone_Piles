using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWallTrap : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    private bool DoorActivated = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !DoorActivated)
        {

            //if player have bone
            // else
            // damage
            DoorActivated = true;
            StartCoroutine(GoAway());
            
        }
    }

    IEnumerator GoAway()
    {
        anim.SetTrigger("ReceiveBone");
        yield return new WaitForSeconds(3f);
        bool goingDown = true;
        Vector3 target = transform.position - new Vector3(0, 5, 0);
        while (goingDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0.01f);
            if(transform.position.y <= target.y)
            {
                goingDown = false;
            }
            yield return new WaitForEndOfFrame();
        }
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
