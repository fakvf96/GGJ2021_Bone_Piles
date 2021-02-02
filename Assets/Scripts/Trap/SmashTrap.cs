using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashTrap : Trap
{
    [SerializeField] private Animator anim1, anim2;
    [SerializeField] private GameObject leftSmash, rightSmash, center;
    private bool closing = false;
    private bool opening = false;
    private Vector3 leftStartPosition;
    private Vector3 rightStartPosition;
    private Braco player;
    private bool damagingPlayer = false;
    public bool playerInContact = false;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Braco>();
        StartCoroutine(Smash());
        leftStartPosition = leftSmash.transform.position;
        rightStartPosition = rightSmash.transform.position;
    }

    private void Update()
    {
        if (closing && !damagingPlayer && playerInContact)
        {
            damagingPlayer = true;
            player.TomaDano();
            StartCoroutine(Count(2));
        }
    }

    IEnumerator Smash()
    {
        
        while (true)
        {
            while (TrapIsWorking)
            {
                StartCoroutine(ClosingSmash());
                while (closing)
                {
                    leftSmash.transform.position = Vector2.MoveTowards(leftSmash.transform.position, center.transform.position, 0.10f);
                    rightSmash.transform.position = Vector2.MoveTowards(rightSmash.transform.position, center.transform.position, 0.10f);
                    yield return new WaitForEndOfFrame();
                }
                StartCoroutine(OpeningSmash());
                while (opening)
                {
                    leftSmash.transform.position = Vector2.MoveTowards(leftSmash.transform.position, leftStartPosition, 0.05f);
                    rightSmash.transform.position = Vector2.MoveTowards(rightSmash.transform.position, rightStartPosition, 0.05f);
                    yield return new WaitForEndOfFrame();
                }
                anim1.SetTrigger("Smash");
                anim2.SetTrigger("Smash");
            }
            
            yield return new WaitForEndOfFrame();
        }
    }
    
    IEnumerator ClosingSmash()
    {
        closing = true;
        yield return new WaitForSeconds(1f);
        closing = false;
    }
    IEnumerator OpeningSmash()
    {
        opening = true;
        yield return new WaitForSeconds(3f);
        opening = false;
    }

    IEnumerator Count(int time)
    {
        yield return new WaitForSeconds(time);
        damagingPlayer = false;
    }
}
