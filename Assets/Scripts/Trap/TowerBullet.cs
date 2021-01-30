using System.Collections;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    private bool hitWall = false;
    public void Shoot(Transform playerPosition, int difficult)
    {
        StartCoroutine(GoToDestination(playerPosition, difficult));
    }

    private IEnumerator GoToDestination(Transform playerPosition, int difficult)
    {
        transform.LookAt(playerPosition);
        while (true)
        {
            while (hitWall)
            {
                yield return new WaitForEndOfFrame();
            }
            transform.position += transform.forward * ( 3 * difficult ) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Bullet"))
        {
            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            // DAMAGE PLAYER

            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            hitWall = true;
            Destroy(this.gameObject, 5f);
        }
    }
}
