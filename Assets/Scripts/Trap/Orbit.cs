using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private Transform target;
    private CircularShotTrap targetTrap;
    private void Start()
    {
        targetTrap = target.gameObject.GetComponent<CircularShotTrap>();
    }
    void Update()
    {
        transform.RotateAround(target.position,new Vector3(0,0,1), targetTrap.getDifficult() * 0.1f);
    }
}
