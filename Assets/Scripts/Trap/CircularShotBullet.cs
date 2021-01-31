using UnityEngine;
using System.Collections;

public class CircularShotBullet : MonoBehaviour
{
    [SerializeField] private Sprite bullet_sprite;
    [SerializeField] private int difficult_level;
    private Braco player;
    private bool damagingPlayer = false;

    private Vector2 directionToGo;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = bullet_sprite;
        player = GameObject.Find("Player").GetComponent<Braco>();
    }

    void Update()
    {
        if (difficult_level == 1)
            difficult_level = 2;
        transform.Translate(directionToGo.normalized * Time.deltaTime * (difficult_level));
    }

    public void ReceiveDirection(Vector2 direction, int difficult)
    {
        directionToGo = direction;
        difficult_level = difficult;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Trap"))
        {
            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!damagingPlayer)
            {
                damagingPlayer = true;
                player.TomaDano();
                StartCoroutine(Count(5));
            }
            
        }
        
        Destroy(this.gameObject);
    }

    IEnumerator Count(int time)
    {
        yield return new WaitForSeconds(time);
        damagingPlayer = false;
    }
}
