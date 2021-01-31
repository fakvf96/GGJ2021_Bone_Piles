using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralDoorTrap : MonoBehaviour
{

    IEnumerator GoAway()
    {
        yield return new WaitForSeconds(3f);
        bool goingDown = true;
        Vector3 target = transform.position - new Vector3(0, 8, 0);
        while (goingDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0.03f);
            if (transform.position.y <= target.y)
            {
                goingDown = false;
            }
            yield return new WaitForEndOfFrame();
        }
        GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator ComeBack()
    {
        yield return new WaitForSeconds(3f);
        bool goingUp = true;
        Vector3 target = transform.position + new Vector3(0, 8, 0);
        while (goingUp)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0.03f);
            if (transform.position.y >= target.y)
            {
                goingUp = false;
            }
            yield return new WaitForEndOfFrame();
        }
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void OpenDoor()
    {
        StartCoroutine(GoAway());
    }

    public void CloseDoor()
    {
        StartCoroutine(ComeBack());
    }
}
