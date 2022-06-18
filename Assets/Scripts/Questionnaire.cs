using UnityEngine;
using UnityEngine.UI;

public class Questionnaire : MonoBehaviour
{
    [SerializeField]
    Button _submitButton = null;

    string _q1 = "", _q2 = "", _q3 = "", _q4 = "", _q5 = "";

    public string Q1 { set { _q1 = value; Validate(); } }
    public string Q2 { set { _q2 = value; Validate(); } }
    public string Q3 { set { _q3 = value; Validate(); } }
    public string Q4 { set { _q4 = value; Validate(); } }
    public string Q5 { set { _q5 = value; Validate(); } }

    void Start()
    {
        _submitButton.interactable = false;
    }

    void Validate()
    {
        _submitButton.interactable = (_q1 != "") && (_q2 != "") && (_q3 != "") && (_q4 != "") && (_q5 != "");
    }
}
