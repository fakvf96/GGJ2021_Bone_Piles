using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public List<Trap> TrapList;

    public bool Testing = false;
    public float TimeToKeepTrapsWorking = 5;

    private void Update()
    {
        if (Testing)
        {
            Testing = false;
            TurnOnTrap(TimeToKeepTrapsWorking);
        }
    }
    public void TurnOnTrap(float TimeToStopWorking)
    {
        foreach (var trap in TrapList)
        {
            trap.TrapIsWorking = true;
        }
        if (TimeToStopWorking > 0)
        {
            StartCoroutine(CountAndStopTrap(TimeToStopWorking));
        }
    }

    public void TurnOffTrap()
    {
        foreach (var trap in TrapList)
        {
            trap.TrapIsWorking = false;
        }
    }

    private IEnumerator CountAndStopTrap(float time)
    {
        yield return new WaitForSeconds(time);
        TurnOffTrap();
    }
}
