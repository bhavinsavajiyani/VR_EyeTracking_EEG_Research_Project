using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniAluminumFX : MonoBehaviour
{
    public GameObject miniAluminum;
    public GameObject beakerExp2;
    public GameObject fireFX;
    public Renderer miniAluminumRenderer;
    public Material newGlassMaterial;

    // Start is called before the first frame update
    void Start()
    {
        miniAluminumRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf)
        {
            StartCoroutine(StartTimer());
        }
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(12.0f);
        fireFX.SetActive(false);
        miniAluminumRenderer.material.color = Color.Lerp(miniAluminumRenderer.material.color, Color.black, 0.9f);
        yield return new WaitForSeconds(0.6f);
        beakerExp2.GetComponent<MeshRenderer>().material = newGlassMaterial;
    }
}
