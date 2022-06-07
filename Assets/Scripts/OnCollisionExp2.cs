using UnityEngine;
using UnitySimpleLiquid;

public class OnCollisionExp2 : MonoBehaviour
{
    public GameObject beaker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BeakerExp2")
        {
            beaker.GetComponent<LiquidContainer>().fillAmountPercent = 0.9f;
        }
    }
}
