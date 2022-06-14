using UnityEngine;
using UnitySimpleLiquid;

public class OnCollisionMethanolExp3 : MonoBehaviour
{
    public GameObject plateExp3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlateExp3")
        {
            plateExp3.GetComponent<LiquidContainer>().fillAmountPercent = 0.9f;
        }
    }
}
