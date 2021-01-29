using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplateTrap : MonoBehaviour
{
    [SerializeField] private ParticleSystem fire1;
    [SerializeField] private ParticleSystem fire2;
    private bool canDealDamage = false;
    private bool playerIsInRange = false;
    void Start()
    {
        StartCoroutine(StartTrap());
    }

    void Update()
    {
        if (canDealDamage && playerIsInRange)
        {
            // DAMAGE PLAYER
        }   
    }

    IEnumerator StartTrap()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            fire1.Play();
            fire2.Play();
            yield return new WaitForSeconds(2f);
            canDealDamage = true;
            yield return new WaitForSeconds(2f);
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
