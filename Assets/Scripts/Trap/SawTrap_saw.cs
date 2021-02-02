using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SawTrap_saw : MonoBehaviour
{
    public SawTrap sawtrap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sawtrap.playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sawtrap.playerInRange = false;
        }
    }
}
