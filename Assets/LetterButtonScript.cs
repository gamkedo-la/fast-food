using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterButtonScript : ButtonScript
{
    private string myCharacter;
    private GameObject spellingInputFieldGameObject;
    private TMP_InputField spellingInputField;
    private GameObject spellingInputTextMeshPro;

    private void Start()
    {
        myCharacter = GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
        spellingInputFieldGameObject = GameObject.FindGameObjectWithTag("SpellingInputField");
        spellingInputField = spellingInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
        spellingInputTextMeshPro = GameObject.FindGameObjectWithTag("SpellingInputTextMeshPro");
    }

    public override void HandleButtonClick()
    {
        spellingInputField.text += myCharacter;
    }
}
