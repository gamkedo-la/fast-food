using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpellingSceneSubmitButtonScript : ButtonScript
{
    private string studentSubmission;
    private GameObject spellingInputFieldGameObject;
    private TMP_InputField spellingInputField;
    [SerializeField] private GameObject spellingWordManager;
    [SerializeField] private Image thumbsUpImage;
    [SerializeField] private Image thumbsDownImage;

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
        spellingInputField.text = "";
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
