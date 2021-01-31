using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    [SerializeField] private GameObject saw;
    private bool playerInRange = false;
    private bool showing = false;
    private bool waiting = false;
    void Start()
    {
        StartCoroutine(HideSaw());
    }

    IEnumerator HideSaw()
    {
        bool hiding = true;
        while (hiding)
        {
            saw.transform.position = Vector2.MoveTowards(saw.transform.position, saw.transform.position - new Vector3(0, -1.25f, 0), -0.01f);
            if (saw.transform.position.y < -1.24)
            {
                hiding = false;
                yield return new WaitForSeconds(3f);
            }
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(ShowSaw());
    }

    IEnumerator ShowSaw()
    {
        waiting = false;
        showing = true;
        while (showing)
        {
            if (playerInRange)
            {
                // DAMAGE PLAYER
            }
            if(!waiting)
                saw.transform.position = Vector2.MoveTowards(saw.transform.position, saw.transform.position + new Vector3(0, 1.25f, 0), 0.01f);
            if(saw.transform.position.y > 0 && !waiting)
            {
                waiting = true;
                StartCoroutine(WaitAndHide());
            }
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(HideSaw());
    }

    IEnumerator WaitAndHide()
    {
        yield return new WaitForSeconds(3f);
        showing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
