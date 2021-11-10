using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackspaceButtonScript : ButtonScript
{
    private GameObject spellingInputFieldGameObject;
    private TMP_InputField spellingInputField;
    private GameObject spellingInputTextMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        spellingInputFieldGameObject = GameObject.FindGameObjectWithTag("SpellingInputField");
        spellingInputField = spellingInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
        spellingInputTextMeshPro = GameObject.FindGameObjectWithTag("SpellingInputTextMeshPro");
    }

    public override void HandleButtonClick()
    {
        string currentStudentInputString = spellingInputField.text;
        string editedString = currentStudentInputString.Substring(0, currentStudentInputString.Length - 1);
        spellingInputField.text = editedString;
    }
}
