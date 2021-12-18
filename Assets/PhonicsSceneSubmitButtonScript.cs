using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PhonicsSceneSubmitButtonScript : ButtonScript
{
    private string studentSubmission;
    private GameObject phonicsInputFieldGameObject;
    private TMP_InputField phonicsInputField;
    [SerializeField] private GameObject phonicsWordManager;

    // Start is called before the first frame update
    void Start()
    {
        phonicsInputFieldGameObject = GameObject.FindGameObjectWithTag("PhonicsInputField");
        phonicsInputField = phonicsInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
    }

    public override void HandleButtonClick()
    {
        studentSubmission = phonicsInputField.text;

        if (studentSubmission == phonicsWordManager.GetComponent<PhonicsManagerScript>().currentPhonicString)
        {
            phonicsWordManager.GetComponent<PhonicsManagerScript>().ResetListOfCurrentLevelStudyCards();

            phonicsWordManager.GetComponent<PhonicsManagerScript>().ResetDisplay();
            AudioController.instance.PlayAudio(GameSoundEnum.SFX_Correct_Order);
        }
        else
        {
            AudioController.instance.PlayAudio(GameSoundEnum.SFX_Incorrect_Order);
        }
        phonicsInputField.text = "";
    }
}
