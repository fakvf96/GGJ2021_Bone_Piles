using System.Collections;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    [SerializeField] private GameObject saw;
    public bool playerInRange = false;
    public int direction = 0;
    private Braco player;
    private bool damagingPlayer = false;
    [Range(0.01f, 0.10f)] public float speed = 0.01f;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Braco>();
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
            if (!damagingPlayer)
            {
                damagingPlayer = true;
                player.TomaDano();
                StartCoroutine(Count(2));
            }
        }
    }

    IEnumerator Count(int time)
    {
        yield return new WaitForSeconds(time);
        damagingPlayer = false;
    }

    IEnumerator MoveLeft()
    {
        bool movingLeft = true;
        var target = saw.transform.localPosition.x - 5.3f;
        while (movingLeft)
        {
            saw.transform.localPosition = Vector2.MoveTowards(saw.transform.localPosition, saw.transform.localPosition - new Vector3(5.3f, 0, 0), speed);
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
            saw.transform.localPosition = Vector2.MoveTowards(saw.transform.localPosition, saw.transform.localPosition + new Vector3(5.3f, 0, 0), speed);
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


}
