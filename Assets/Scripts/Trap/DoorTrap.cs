using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrap : Trap
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        anim.SetTrigger("OpenDoor");
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void CloseDoor()
    {
        anim.SetTrigger("CloseDoor");
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
