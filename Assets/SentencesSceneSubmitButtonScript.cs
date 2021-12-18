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
    [SerializeField] private Image thumbsUpImage;
    [SerializeField] private Image thumbsDownImage;

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
            thumbsUpImage.gameObject.SetActive(true);
            StartCoroutine(TurnOffThumbsUp());
        }
        else
        {
            AudioController.instance.PlayAudio(GameSoundEnum.SFX_Incorrect_Order);
            thumbsDownImage.gameObject.SetActive(true);
            StartCoroutine(TurnOffThumbsDown());
        }
        sentenceInputField.text = "";
    }

    IEnumerator TurnOffThumbsUp()
    {
        yield return new WaitForSeconds(1);
        thumbsUpImage.gameObject.SetActive(false);
    }

    IEnumerator TurnOffThumbsDown()
    {
        yield return new WaitForSeconds(1);
        thumbsDownImage.gameObject.SetActive(false);
    }
}
