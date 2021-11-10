using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SentencesSceneSubmitButtonScript : ButtonScript
{
    private string studentSubmission;
    private GameObject sentenceInputFieldGameObject;
    private TMP_InputField sentenceInputField;
    [SerializeField] private GameObject sentencesManager;

    // Start is called before the first frame update
    void Start()
    {
        sentenceInputFieldGameObject = GameObject.FindGameObjectWithTag("SentencesInputField");
        sentenceInputField = sentenceInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
    }

    public override void HandleButtonClick()
    {
        studentSubmission = sentenceInputField.text;
        
        string editedTargetSentenceString = sentencesManager.GetComponent<SentencesManagerScript>().currentSentenceToFormString;
        editedTargetSentenceString += " ";
        Debug.Log("studentSubmission: " + studentSubmission);
        Debug.Log("editedTargetSentenceString: " + editedTargetSentenceString);
        if (studentSubmission == editedTargetSentenceString)
        {
            sentencesManager.GetComponent<SentencesManagerScript>().ResetDisplay();
            Debug.Log("you rule");
        }
        else
        {
            Debug.Log("nope");
        }
        sentenceInputField.text = "";
    }
}
