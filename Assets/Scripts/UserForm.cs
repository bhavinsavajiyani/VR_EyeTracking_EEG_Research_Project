using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class UserForm : MonoBehaviour
{
    [SerializeField]
    private InputField _username = null, _age = null;

    [SerializeField]
    private Dropdown _gender = null, _highestEducation = null, _group = null, _vision = null, _hearing = null;

    [SerializeField]
    private Button _submitButton;

    // Start is called before the first frame update
    void Start()
    {
        _submitButton.interactable = false;
        _username.onValueChanged.AddListener(delegate { Validate(); });
        _age.onValueChanged.AddListener(delegate { Validate(); });
        _submitButton.onClick.AddListener(delegate { SaveUserDemographics(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Validate()
    {
        _submitButton.interactable = _username.text != "" && _age.text != "";
    }

    public void SaveUserDemographics()
    {
        string path = $"{Application.dataPath}/Static/Data/" + "UserDemographics.csv";

        if(!File.Exists(path))
        {
            string header = "Username,Age,Gender,HighestEducation,Group,Vision,Hearing" + Environment.NewLine;
            File.AppendAllText(path, header);
        }

        string values = $"{_username.text}, {_age.text}, {_gender.options[_gender.value].text}, {_highestEducation.options[_highestEducation.value].text}, {_group.options[_group.value].text}, {_vision.options[_vision.value].text}, {_hearing.options[_hearing.value].text}" + Environment.NewLine;
        File.AppendAllText(path, values);
        SceneData.NextScene();
    }
}
