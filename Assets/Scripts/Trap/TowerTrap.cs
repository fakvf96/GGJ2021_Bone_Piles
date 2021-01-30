using System.Collections;
using UnityEngine;

public class TowerTrap : Trap
{
    [SerializeField] private ParticleSystem charge;
    [SerializeField] private GameObject bullet_prefab;
    [SerializeField] private Transform shoot_from;
    [SerializeField] [Range(1, 6)] private int difficult_level = 1;
    private GameObject player;
    private bool canShoot = false;

    void Start()
    {
        player = GameObject.Find("Player");
        TrapIsWorking = false;
    }

    private void Shoot()
    {
        var bullet = Instantiate(bullet_prefab, shoot_from.position , Quaternion.identity, this.gameObject.transform);
        bullet.GetComponent<TowerBullet>().Shoot(player.transform, difficult_level);
    }

    private IEnumerator StartShooting()
    {
        while (canShoot)
        {
            if (TrapIsWorking)
            {
                charge.Play();
                yield return new WaitForSeconds(1.2f);
                Shoot();
                yield return new WaitForSeconds(2f);
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!canShoot)
            {
                canShoot = true; 
                StartCoroutine(StartShooting());
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
