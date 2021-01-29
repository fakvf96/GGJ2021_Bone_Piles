using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularShotTrap : MonoBehaviour
{
    [SerializeField] private GameObject bullet_prefab;
    [SerializeField] private List<GameObject> fire_destination_list;
    [SerializeField] [Range(1, 7)] private int difficult_level = 1;



    void Start()
    {
        foreach (GameObject fireDestination in fire_destination_list)
        {
            StartCoroutine(FiringBullets(fireDestination));
        }
        
    }

    void Update()
    {
        
    }

    private void FireBullet(Vector3 firePoint)
    {
        var bullet = Instantiate(bullet_prefab, gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
        bullet.GetComponent<Bullet>().ReceiveDirection(firePoint,difficult_level);
    }

    IEnumerator FiringBullets(GameObject GO_fire)
    {
        while (true)
        {
            float waitTime = 1.75f - ((difficult_level * 0.5f) / 2);
            if (waitTime <= 0)
                waitTime = 0.15f;
            yield return new WaitForSeconds(waitTime);
            FireBullet(GO_fire.transform.localPosition);   
        }
    }

    public int getDifficult()
    {
        return difficult_level;
    }
}