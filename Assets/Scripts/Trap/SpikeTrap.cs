using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap
{
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private float DelayToStart = 2f;
    private bool canDealDamage = false;
    private bool playerIsInRange = false;

    void Start()
    {
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
        while (!TrapIsWorking)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(DelayToStart);
        while (TrapIsWorking)
        {
            yield return new WaitForSeconds(2f);
            GetComponent<SpriteRenderer>().sprite = sprite2;
            canDealDamage = true;
            yield return new WaitForSeconds(2f);
            GetComponent<SpriteRenderer>().sprite = sprite1;
            canDealDamage = false;
            yield return new WaitForSeconds(2f);
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
