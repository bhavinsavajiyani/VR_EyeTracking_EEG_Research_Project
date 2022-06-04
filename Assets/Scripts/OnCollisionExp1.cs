using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionExp1 : MonoBehaviour
{
    public GameObject miniPotassium;

    public AudioSource miniPotassiumExp1Audio;
    public GameObject pointLight;

    void Start()
    {
        miniPotassium.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Exp1BeakerLiquid")
        {
            miniPotassium.SetActive(true);
            miniPotassiumExp1Audio.enabled = true;
            pointLight.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
