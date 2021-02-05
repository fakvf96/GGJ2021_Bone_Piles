using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchLight : MonoBehaviour
{
    private Light2D fireLight;
    private bool fireIsOn = true;
    [Header("Inner Radius")]
    [SerializeField] private float InnerLower = 0.1f;
    [SerializeField] private float InnerHigher = 1.8f;

    [Header("Outer Radius")]
    [SerializeField] private float OuterLower = 11f;
    [SerializeField] private float OuterHigher = 11.5f;
    void Start()
    {
        fireLight = GetComponent<Light2D>();
        StartCoroutine(WaitAndChange());
    }



    void RandomInnerBetweenTwoNumbers(float n1, float n2)
    {
        float n3 = Random.Range(n1, n2);
        fireLight.pointLightInnerRadius = n3;
    }

    void RandomOuterBetweenTwoNumbers(float n1, float n2)
    {
        float n3 = Random.Range(n1, n2);
        fireLight.pointLightOuterRadius = n3;
    }

    IEnumerator WaitAndChange()
    {
        while (fireIsOn)
        {
            yield return new WaitForSeconds(0.2f);
            RandomInnerBetweenTwoNumbers(InnerLower, InnerHigher);
            RandomOuterBetweenTwoNumbers(OuterLower, OuterHigher);
        }
    }
}
