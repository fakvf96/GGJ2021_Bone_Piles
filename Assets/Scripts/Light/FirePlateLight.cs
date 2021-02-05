using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FirePlateLight : MonoBehaviour
{
    [SerializeField] private Light2D l1, l2, l3, l4;
    private FireplateTrap fireplate;

    private bool fireStarted = false;


    [Header("Inner Radius")]
    [SerializeField] private float SpeedInnerUp = 0.01f;
    [SerializeField] private float SpeedInnerDown = 0.01f;
    [SerializeField] private float InnerLower = 0.1f;
    [SerializeField] private float InnerHigher = 1.8f;

    [Header("Outer Radius")]
    [SerializeField] private float SpeedOuterUp = 0.004f;
    [SerializeField] private float SpeedOuterDown = 0.01f;
    [SerializeField] private float OuterLower = 11f;
    [SerializeField] private float OuterHigher = 11.5f;

    private void Start()
    {
        fireplate = GetComponent<FireplateTrap>();
    }
    private void Update()
    {
        if (!fireStarted)
        {
            if (fireplate.TrapIsWorking)
            {
                StartCoroutine(StartLight(fireplate.DelayToStart));
                fireStarted = true;
            }
        }
    }

    IEnumerator StartLight(float delay)
    {
        yield return new WaitForSeconds(delay + 2f);
        while (fireplate.TrapIsWorking)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(MoreInner());
            StartCoroutine(MoreOuter());
            yield return new WaitForSeconds(4f); //Espera o fogo começar a apagar.
            StartCoroutine(LessInner());
            StartCoroutine(LessOuter());
            yield return new WaitForSeconds(3.5f); //Espera o fogo começar a acender.
        }
    }

    IEnumerator MoreInner()
    {
        while (l1.pointLightInnerRadius < InnerHigher)
        {

            l1.pointLightInnerRadius += SpeedInnerUp;
            l2.pointLightInnerRadius += SpeedInnerUp;
            l3.pointLightInnerRadius += SpeedInnerUp;
            l4.pointLightInnerRadius += SpeedInnerUp;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator LessInner()
    {
        while (l1.pointLightInnerRadius > InnerLower)
        {

            l1.pointLightInnerRadius -= SpeedInnerDown;
            l2.pointLightInnerRadius -= SpeedInnerDown;
            l3.pointLightInnerRadius -= SpeedInnerDown;
            l4.pointLightInnerRadius -= SpeedInnerDown;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator MoreOuter()
    {
        while (l1.pointLightOuterRadius < OuterHigher)
        {
            l1.pointLightOuterRadius += SpeedOuterUp;
            l2.pointLightOuterRadius += SpeedOuterUp;
            l3.pointLightOuterRadius += SpeedOuterUp;
            l4.pointLightOuterRadius += SpeedOuterUp;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator LessOuter()
    {
        while (l1.pointLightOuterRadius > OuterLower)
        {
            l1.pointLightOuterRadius -= SpeedOuterDown;
            l2.pointLightOuterRadius -= SpeedOuterDown;
            l3.pointLightOuterRadius -= SpeedOuterDown;
            l4.pointLightOuterRadius -= SpeedOuterDown;
            yield return new WaitForEndOfFrame();
        }
    }
}
