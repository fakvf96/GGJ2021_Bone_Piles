using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Smasher : MonoBehaviour
{
    public SmashTrap smash;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            smash.playerInContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            smash.playerInContact = false;
        }
    }
}   
