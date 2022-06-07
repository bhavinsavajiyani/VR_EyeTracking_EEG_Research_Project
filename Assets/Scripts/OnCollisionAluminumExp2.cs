using UnityEngine;

public class OnCollisionAluminumExp2 : MonoBehaviour
{
    public GameObject miniAluminum;

    public AudioSource miniAluminumExp2Audio;
    public GameObject pointLight;

    void Start()
    {
        miniAluminum.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BeakerExp2")
        {
            miniAluminum.SetActive(true);
            miniAluminumExp2Audio.enabled = true;
            pointLight.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
