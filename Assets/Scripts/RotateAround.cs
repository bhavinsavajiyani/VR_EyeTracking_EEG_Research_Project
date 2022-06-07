using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject target;

    private float _timeLeft = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 170 * Time.deltaTime);

        _timeLeft -= Time.deltaTime;

        if(_timeLeft < 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
