using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemistryLabPT : MonoBehaviour
{
    public Button button;
    public GameObject PTButton;

    public GameObject beaker;
    public GameObject brownBottle;

    public Text robotInstructions;
    public Text PTInstructions;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(PTButtonOnClick);
        beaker.SetActive(false);
        brownBottle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PTButtonOnClick()
    {
        PTButton.SetActive(false);
        beaker.SetActive(true);
        brownBottle.SetActive(true);
        robotInstructions.text = "Grab the Brown Bottle of Bromine (using the controller), and pour it into the beaker.";
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(10.0f);
        beaker.SetActive(false);
        brownBottle.SetActive(false);
        PTInstructions.text = "You will now complete a calibration process before conducting the study!";
        robotInstructions.text = "Well Done!\nYou just completed the practice trial.";
    }
}
