using UnityEngine;

public class ScaleDown : MonoBehaviour
{
    void ScaleDownObject()
    {
        iTween.ScaleTo(this.gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "time", 21.0f));
    }

    // Update is called once per frame
    void Update()
    {
        ScaleDownObject();
    }
}
