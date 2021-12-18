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
        
        if (studentSubmission == editedTargetSentenceString)
        {
            sentencesManager.GetComponent<SentencesManagerScript>().ResetDisplay();
            AudioController.instance.PlayAudio(GameSoundEnum.SFX_Correct_Order);
        }
        else
        {
            AudioController.instance.PlayAudio(GameSoundEnum.SFX_Incorrect_Order);
        }
        sentenceInputField.text = "";
    }
}
