using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private TrapController controller;
    private bool activated = false;
    public float TimeToPlayTraps = 5;
    public DoorTrap Door1, Door2;
    public LateralDoorTrap Door3, Door4;

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
            else if(Door3 != null)
            {
                Door3.CloseDoor();
                Door4.CloseDoor();
                StartCoroutine(OpenLateralDoors());
            }
        }
    }

    IEnumerator OpenDoors()
    {
        yield return new WaitForSeconds(TimeToPlayTraps);
        Door1.OpenDoor();
        Door2.OpenDoor();
    }
    IEnumerator OpenLateralDoors()
    {
        yield return new WaitForSeconds(TimeToPlayTraps);
        Door3.OpenDoor();
        Door4.OpenDoor();
    }
}
