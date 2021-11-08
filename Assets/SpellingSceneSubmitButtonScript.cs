using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellingSceneSubmitButtonScript : ButtonScript
{
    private string studentSubmission;
    private GameObject spellingInputFieldGameObject;
    private TMP_InputField spellingInputField;
    [SerializeField] private GameObject spellingWordManager;

    // Start is called before the first frame update
    void Start()
    {
        spellingInputFieldGameObject = GameObject.FindGameObjectWithTag("SpellingInputField");
        spellingInputField = spellingInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
    }

    public override void HandleButtonClick()
    {
        studentSubmission = spellingInputField.text;
        if (studentSubmission == spellingWordManager.GetComponent<SpellingWordsManagerScript>().currentWordToSpellString)
        {
            spellingWordManager.GetComponent<SpellingWordsManagerScript>().ResetDisplay();
            Debug.Log("you rule");
        }
        else
        {
            Debug.Log("nope");
        }
        spellingInputField.text = "";
    }
}
