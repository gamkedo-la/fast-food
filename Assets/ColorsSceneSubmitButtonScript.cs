using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ColorsSceneSubmitButtonScript : ButtonScript
{
    private string studentSubmission;
    private GameObject colorsInputFieldGameObject;
    private TMP_InputField colorsInputField;
    [SerializeField] private GameObject colorsWordManager;

    // Start is called before the first frame update
    void Start()
    {
        colorsInputFieldGameObject = GameObject.FindGameObjectWithTag("ColorsInputField");
        colorsInputField = colorsInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
    }

    public override void HandleButtonClick()
    {
        studentSubmission = colorsInputField.text;

        if (studentSubmission == colorsWordManager.GetComponent<ColorsManagerScript>().currentTargetColorString)
        {
            colorsWordManager.GetComponent<ColorsManagerScript>().ResetDisplay();
            Debug.Log("you rule");
        }
        else
        {
            Debug.Log("nope");
        }
        colorsInputField.text = "";
    }
}
