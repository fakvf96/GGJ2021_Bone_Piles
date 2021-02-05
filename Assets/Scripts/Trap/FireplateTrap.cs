using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplateTrap : Trap
{
    [SerializeField] private ParticleSystem fire1;
    public float DelayToStart = 2f;
    private bool canDealDamage = false;
    private bool playerIsInRange = false;
    private Animator anim;
    private Braco player;
    private bool damagingPlayer = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(StartTrap());
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
        yield return new WaitForSeconds(2f);
        while (!TrapIsWorking)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(DelayToStart);
        while (TrapIsWorking)
        {
            anim.SetTrigger("FireUp");
            fire1.Play();
            yield return new WaitForSeconds(2f);
            canDealDamage = true;
            yield return new WaitForSeconds(2f);
            anim.SetTrigger("FireDown");
            canDealDamage = false;
            yield return new WaitForSeconds(4f);
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
