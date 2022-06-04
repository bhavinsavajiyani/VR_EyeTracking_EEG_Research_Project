using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemistryLab : MonoBehaviour
{
    // Variable Declarations
    public Button button;
    public GameObject taskButton;

    public GameObject exp1;
    private bool isExp1;

    public Text robotInstructions;

    public GameObject miniPotassium;
    public GameObject pointLight;

    // Start is called before the first frame update
    void Start()
    {
        exp1.SetActive(false);
        button.onClick.AddListener(ButtonOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(exp1 && miniPotassium.activeSelf)
        {
            StartCoroutine(FinishExp1());
        }
    }

    void ButtonOnClick()
    {
        isExp1 = true;

        if(isExp1)
        {
            exp1.SetActive(true);
            taskButton.SetActive(false);
            robotInstructions.text = "Grab the Potassium Rock and put it inside Water Beaker.";
        }
    }

    IEnumerator FinishExp1()
    {
        yield return new WaitForSeconds(0.3f);
        robotInstructions.text = "Well Done!\nYou have completed the Experiment 1.";
        yield return new WaitForSeconds(10f);
        StartCoroutine(StartExp2());
    }

    IEnumerator StartExp2()
    {
        yield return new WaitForSeconds(3.0f);
        exp1.SetActive(false);
        pointLight.SetActive(true);
        robotInstructions.text = "Experiment 2.";
    }
}
