using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Sprite bullet_sprite;
    [SerializeField] private int difficult_level;

    private Vector2 directionToGo;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = bullet_sprite;
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
        if (collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("Trap"))
        {
            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            // DAMAGE PLAYER
        }
        
        Destroy(this.gameObject);
    }
}
