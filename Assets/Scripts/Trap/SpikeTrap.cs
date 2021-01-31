using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap
{
    private Animator anim;
    
    [SerializeField] private float DelayToStart = 2f;
    private bool canDealDamage = false;
    private bool playerIsInRange = false;
    private Braco player;
    private bool damagingPlayer = false;

    void Start()
    {
        StartCoroutine(StartTrap());
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Braco>();
    }

    void Update()
    {
        if (canDealDamage && playerIsInRange && TrapIsWorking && !damagingPlayer)
        {
            damagingPlayer = true;
            player.TomaDano();
            StartCoroutine(Count(5));
        }
    }

    IEnumerator StartTrap()
    {
        while (!TrapIsWorking)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(DelayToStart);
        while (TrapIsWorking)
        {
            anim.SetTrigger("Open");
            yield return new WaitForSeconds(2f);
            canDealDamage = true;
            yield return new WaitForSeconds(2f);
            anim.SetTrigger("Close");
            canDealDamage = false;
            yield return new WaitForSeconds(3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsInRange = false;
        }
    }

    IEnumerator Count(int time)
    {
        yield return new WaitForSeconds(time);
        damagingPlayer = false;
    }
}
