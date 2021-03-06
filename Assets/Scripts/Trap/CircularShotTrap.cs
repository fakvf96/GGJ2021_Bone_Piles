using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularShotTrap : Trap
{
    [SerializeField] private GameObject bullet_prefab;
    [SerializeField] private List<GameObject> fire_destination_list;
    [SerializeField] [Range(1, 7)] private int difficult_level = 1;

    private Animator anim;
    private bool startedShooting = false;

    private bool canShoot = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        TrapIsWorking = false;
    }


    private void FireBullet(Vector3 firePoint)
    {
        var bullet = Instantiate(bullet_prefab, gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
        bullet.GetComponent<CircularShotBullet>().ReceiveDirection(firePoint,difficult_level);
    }

    IEnumerator FiringBullets(GameObject GO_fire)
    {
        yield return new WaitForSeconds(1f);
        while (canShoot)
        {
            if (TrapIsWorking)
            {
                startedShooting = true;
                float waitTime = 1.75f - ((difficult_level * 0.5f) / 2);
                if (waitTime <= 0)
                    waitTime = 0.15f;
                yield return new WaitForSeconds(waitTime);
                FireBullet(GO_fire.transform.localPosition);
            }
            else
            {
                if (startedShooting)
                {
                    anim.SetTrigger("Desactivate");
                    anim.SetTrigger("Iddle");
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }

    public int getDifficult()
    {
        return difficult_level;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!canShoot)
            {
                canShoot = true;
                foreach (GameObject fireDestination in fire_destination_list)
                {
                    anim.SetTrigger("Activate");
                    anim.SetTrigger("Fire");
                    StartCoroutine(FiringBullets(fireDestination));
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canShoot = false;
        }
    }
}