using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private TrapController controller;
    private bool activated = false;
    public float TimeToPlayTraps = 5;
    public DoorTrap Door1, Door2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !activated)
        {
            activated = true;
            controller.TurnOnTrap(TimeToPlayTraps);
            if (Door1 != null) 
            {
                Door1.CloseDoor();
                Door2.CloseDoor();
                StartCoroutine(OpenDoors());
            }
        }
    }

    IEnumerator OpenDoors()
    {
        yield return new WaitForSeconds(TimeToPlayTraps);
        Door1.OpenDoor();
        Door2.OpenDoor();
    }

}
