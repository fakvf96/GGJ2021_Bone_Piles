using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDust : MonoBehaviour
{
    public GameObject dust;
    private bool canSpawn = false;

    private void Start()
    {
        StartCoroutine(SpawnDust());
    }
    void Update()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            canSpawn = true;
        }
        else
        {
            canSpawn = false;
        }
    }

    IEnumerator SpawnDust()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (canSpawn)
            {
                var dustGO = Instantiate(dust, transform.position, Quaternion.identity);
                Destroy(dustGO, 1f);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
