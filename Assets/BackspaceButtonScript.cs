using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BackspaceButtonScript : ButtonScript
{
    private GameObject inputFieldGameObject;
    private TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Phonics":
                inputFieldGameObject = GameObject.FindGameObjectWithTag("PhonicsInputField");
                inputField = inputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
                break;

            case "Spelling":
                inputFieldGameObject = GameObject.FindGameObjectWithTag("SpellingInputField");
                inputField = inputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
                break;
        }
        
    }

    public override void HandleButtonClick()
    {
        string currentStudentInputString = inputField.text;
        string editedString = currentStudentInputString.Substring(0, currentStudentInputString.Length - 1);
        inputField.text = editedString;
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}
