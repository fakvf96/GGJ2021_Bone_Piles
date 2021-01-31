using System.Collections;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    [SerializeField] private GameObject saw;
    private bool playerInRange = false;
    public int direction = 0;
    void Start()
    {
        if(direction == 0)
        {
            StartCoroutine(MoveLeft());
        }
        else
        {
            StartCoroutine(MoveRight());
        }
        
    }

    private void Update()
    {
        if (playerInRange)
        {
            // DAMAGE PLAYER
        }
    }

    IEnumerator MoveLeft()
    {
        bool movingLeft = true;
        var target = saw.transform.localPosition.x - 5.3f;
        while (movingLeft)
        {
            saw.transform.localPosition = Vector2.MoveTowards(saw.transform.localPosition, saw.transform.localPosition - new Vector3(5.3f, 0, 0), 0.01f);
            //Debug.Log("Left" + saw.transform.localPosition.x.ToString() + " / " + (saw.transform.localPosition.x - 5.3f).ToString());
            if (saw.transform.localPosition.x < (target))
            {
                movingLeft = false;
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveRight()
    {
        bool movingRight = true;
        var target = saw.transform.localPosition.x + 5.3f;
        while (movingRight)
        {
            saw.transform.localPosition = Vector2.MoveTowards(saw.transform.localPosition, saw.transform.localPosition + new Vector3(5.3f, 0, 0), 0.01f);
            //Debug.Log("Right" + saw.transform.localPosition.x.ToString() + " / " + (saw.transform.localPosition.x - 5.3f).ToString());
            if (saw.transform.localPosition.x > (target))
            {
                movingRight = false;
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(MoveLeft());
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
