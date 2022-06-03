using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySimpleLiquid;

public class OnCollisionPT : MonoBehaviour
{
    public GameObject beaker;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PracticeBeaker")
        {
            beaker.GetComponent<LiquidContainer>().fillAmountPercent = 0.9f;
        }
    }
}
