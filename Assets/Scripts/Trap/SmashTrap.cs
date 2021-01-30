using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashTrap : Trap
{
    [SerializeField] private GameObject leftSmash, rightSmash, center;
    private bool closing = false;
    private bool opening = false;
    private Vector3 leftStartPosition;
    private Vector3 rightStartPosition;

    void Start()
    {
        StartCoroutine(Smash());
        leftStartPosition = leftSmash.transform.position;
        rightStartPosition = rightSmash.transform.position;
    }

    IEnumerator Smash()
    {
        
        while (true)
        {
            while (TrapIsWorking)
            {
                StartCoroutine(ClosingSmash());
                while (closing)
                {
                    leftSmash.transform.position = Vector2.MoveTowards(leftSmash.transform.position, center.transform.position, 0.05f);
                    rightSmash.transform.position = Vector2.MoveTowards(rightSmash.transform.position, center.transform.position, 0.05f);
                    yield return new WaitForEndOfFrame();
                }
                StartCoroutine(OpeningSmash());
                while (opening)
                {
                    leftSmash.transform.position = Vector2.MoveTowards(leftSmash.transform.position, leftStartPosition, 0.01f);
                    rightSmash.transform.position = Vector2.MoveTowards(rightSmash.transform.position, rightStartPosition, 0.01f);
                    yield return new WaitForEndOfFrame();
                }
            }
        }
    }
    
    IEnumerator ClosingSmash()
    {
        closing = true;
        yield return new WaitForSeconds(1f);
        closing = false;
    }
    IEnumerator OpeningSmash()
    {
        opening = true;
        yield return new WaitForSeconds(3f);
        opening = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (closing)
            {
                // DAMAGE PLAYER
            }
        }
    }
}
