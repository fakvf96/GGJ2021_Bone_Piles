using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplateTrap : Trap
{
    [SerializeField] private ParticleSystem fire1;
    [SerializeField] private ParticleSystem fire2;
    [SerializeField] private float DelayToStart = 2f;
    private bool canDealDamage = false;
    private bool playerIsInRange = false;
    private Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(StartTrap());
    }

    void Update()
    {
        if (canDealDamage && playerIsInRange && TrapIsWorking)
        {
            // DAMAGE PLAYER
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
            fire2.Play();
            yield return new WaitForSeconds(2f);
            canDealDamage = true;
            yield return new WaitForSeconds(2f);
            anim.SetTrigger("FireDown");
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
}
