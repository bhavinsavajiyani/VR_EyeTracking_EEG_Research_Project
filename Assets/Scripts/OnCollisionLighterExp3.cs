using UnityEngine;

public class OnCollisionLighterExp3 : MonoBehaviour
{
    public GameObject flameExp3;

    void Start()
    {
        flameExp3.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlateExp3")
        {
            flameExp3.SetActive(true);
        }
    }
}
