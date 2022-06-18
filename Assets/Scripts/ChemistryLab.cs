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
    public GameObject pointer;

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

    [Space]
    [Header("--- Experiment 3 ---")]
    public GameObject exp3;
    private bool _isExp3;
    public GameObject plateExp3;
    public MeshCollider nitroMethaneMeshCollider;
    public MeshCollider nitroMethaneFluidMeshCollider;
    public CapsuleCollider nitroMethaneCapsuleCollider;
    public MeshCollider methanolMeshCollider;
    public MeshCollider methanolFluidMeshCollider;
    public CapsuleCollider methanolCapsuleCollider;
    public MeshCollider lighterMeshCollider;
    public BoxCollider lighterBoxCollider;
    public GameObject flameExp3;


    // Start is called before the first frame update
    void Start()
    {
        _isExp1 = false;
        _isExp2 = false;
        _isExp3 = false;

        exp1.SetActive(false);
        exp2.SetActive(false);
        exp3.SetActive(false);

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

        if(_isExp3)
        {
            StartCoroutine(StartExp3());
        }
    }

    void ButtonOnClick()
    {
        pointer.SetActive(false);
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
            yield return new WaitForSeconds(12.0f);
            StartCoroutine(StartExp3());
        }

        else
        {
            robotInstructions.text = "Now grab the Brown Bottle of Bromine and pour it into the beaker.";
        }
    }

    IEnumerator StartExp3()
    {
        _isExp3 = true;
        yield return new WaitForSeconds(3.0f);
        exp2.SetActive(false);
        robotInstructions.text = "Grab the White bottle of Nitromethane and pour it into the plate.";
        yield return new WaitForSeconds(0.3f);
        exp3.SetActive(true);

        if(plateExp3.GetComponent<LiquidContainer>().fillAmountPercent == 0.24f && !flameExp3.activeSelf)
        {
            nitroMethaneMeshCollider.enabled = false;
            nitroMethaneFluidMeshCollider.enabled = false;
            nitroMethaneCapsuleCollider.enabled = false;

            methanolMeshCollider.enabled = true;
            methanolFluidMeshCollider.enabled = true;
            methanolCapsuleCollider.enabled = true;
            robotInstructions.text = "Grab Methanol Test-Tube from the stand and pour it into the plate which contains Nitromethane.";
        }

        if(plateExp3.GetComponent<LiquidContainer>().fillAmountPercent == 0.9f && !flameExp3.activeSelf)
        {
            nitroMethaneMeshCollider.enabled = false;
            nitroMethaneFluidMeshCollider.enabled = false;
            nitroMethaneCapsuleCollider.enabled = false;

            methanolMeshCollider.enabled = false;
            methanolFluidMeshCollider.enabled = false;
            methanolCapsuleCollider.enabled = false;

            lighterMeshCollider.enabled = true;
            lighterBoxCollider.enabled = true;

            robotInstructions.text = "Grab the Lighter and light the flame in the plate which contains Nitromethane and Methanol.";
        }

        else if(plateExp3.GetComponent<LiquidContainer>().fillAmountPercent == 0.9f && flameExp3.activeSelf)
        {
            _isExp3 = false;
            yield return new WaitForSeconds(0.3f);
            robotInstructions.text = "Well Done!\nYou have completed the Experiment 3.";
            yield return new WaitForSeconds(6.0f);
            SceneData.NextScene();
        }
    }
}
