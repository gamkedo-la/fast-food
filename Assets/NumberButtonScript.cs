using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberButtonScript : ButtonScript
{
    private string myNumberString;
    private GameObject numberInputFieldGameObject;
    private TMP_InputField numberInputField;
    private GameObject numberInputTextMeshPro;

    private void Start()
    {
        myNumberString = GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
        numberInputFieldGameObject = GameObject.FindGameObjectWithTag("NumbersInputField");
        numberInputField = numberInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
        //sentenceInputTextMeshPro = GameObject.FindGameObjectWithTag("SentenceInputTextMeshPro");
    }

    public override void HandleButtonClick()
    {
        numberInputField.text += myNumberString;
    }
}
