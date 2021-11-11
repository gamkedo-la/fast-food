using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NumbersSceneSubmitButtonScript : ButtonScript
{
    private string studentSubmission;
    private GameObject numbersInputFieldGameObject;
    private TMP_InputField numbersInputField;
    [SerializeField] private GameObject numbersWordManager;

    // Start is called before the first frame update
    void Start()
    {
        numbersInputFieldGameObject = GameObject.FindGameObjectWithTag("NumbersInputField");
        numbersInputField = numbersInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
    }

    public override void HandleButtonClick()
    {
        studentSubmission = numbersInputField.text;

        if (studentSubmission == numbersWordManager.GetComponent<NumbersManagerScript>().currentTargetNumberString)
        {
            numbersWordManager.GetComponent<NumbersManagerScript>().ResetDisplay();
            Debug.Log("you rule");
        }
        else
        {
            Debug.Log("nope");
        }
        numbersInputField.text = "";
    }
}
