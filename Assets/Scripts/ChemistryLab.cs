using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnitySimpleLiquid;

public class ChemistryLab : MonoBehaviour
{
    // Variable Declarations
    [Header("--- General Elements ---")]
    public Button button;
    public GameObject taskButton;
    public Text robotInstructions;
    public GameObject pointLight;

    [Space]
    [Header("--- Experiment 1 ---")]
    public GameObject exp1;
    private bool _isExp1;
    public GameObject miniPotassium;

    [Space]
    [Header("--- Experiment 2 ---")]
    public GameObject exp2;
    private bool _isExp2;
    public GameObject beakerExp2;
    public GameObject miniAluminum;
    public MeshCollider brownBottleMeshCollider;
    public MeshCollider brownBottleFluidMeshCollider;
    public CapsuleCollider brownBottleCapsuleCollider;
    public MeshCollider aluminumMeshCollider;
    public CapsuleCollider aluminumCapsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        _isExp1 = false;
        _isExp2 = false;

        exp1.SetActive(false);
        exp2.SetActive(false);

        aluminumMeshCollider.enabled = false;
        aluminumCapsuleCollider.enabled = false;

        button.onClick.AddListener(ButtonOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(_isExp1)
        {
            StartCoroutine(StartExp1());
        }

        if(_isExp2)
        {
            StartCoroutine(StartExp2());
        }
    }

    void ButtonOnClick()
    {
        _isExp1 = true;
    }

    IEnumerator StartExp1()
    {
        exp1.SetActive(true);
        taskButton.SetActive(false);
        robotInstructions.text = "Grab the Potassium Rock and put it inside Water Beaker.";

        if(miniPotassium.activeSelf)
        {
            _isExp1 = false;
            yield return new WaitForSeconds(0.3f);
            robotInstructions.text = "Well Done!\nYou have completed the Experiment 1.";
            yield return new WaitForSeconds(10f);
            StartCoroutine(StartExp2());
        }
    }

    IEnumerator StartExp2()
    {
        _isExp2 = true;
        yield return new WaitForSeconds(3.0f);
        exp1.SetActive(false);
        pointLight.SetActive(true);
        exp2.SetActive(true);

        if(beakerExp2.GetComponent<LiquidContainer>().fillAmountPercent > 0.48f && !miniAluminum.activeSelf)
        {
            brownBottleMeshCollider.enabled = false;
            brownBottleFluidMeshCollider.enabled = false;
            brownBottleCapsuleCollider.enabled = false;

            aluminumMeshCollider.enabled = true;
            aluminumCapsuleCollider.enabled = true;
            robotInstructions.text = "Grab the Aluminum Foil and put it inside beaker filled with Bromine.";
        }

        else if(beakerExp2.GetComponent<LiquidContainer>().fillAmountPercent > 0.48f && !miniAluminum.activeSelf)
        {
            _isExp2 = false;
            yield return new WaitForSeconds(0.3f);
            robotInstructions.text = "Well Done!\nYou have completed the Experiment 2.";
        }

        else
        {
            robotInstructions.text = "Now grab the Brown Bottle of Bromine and pour it into the beaker.";
        }
    }
}
