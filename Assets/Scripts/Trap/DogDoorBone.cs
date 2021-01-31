using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDoorBone : MonoBehaviour
{
    public GameManager GM;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GM.playerHasDogBone = true;
            Destroy(this.gameObject);
        }
    }
}
