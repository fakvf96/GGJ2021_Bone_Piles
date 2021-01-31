using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap
{
    private Animator anim;
    
    [SerializeField] private float DelayToStart = 2f;
    private bool canDealDamage = false;
    private bool playerIsInRange = false;

    void Start()
    {
        StartCoroutine(StartTrap());
        anim = GetComponent<Animator>();
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
}
