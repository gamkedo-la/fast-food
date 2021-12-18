using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SentenceSceneBackspaceScript : ButtonScript
{
    private GameObject sentenceInputFieldGameObject;
    private TMP_InputField sentenceInputField;
    private GameObject sentenceInputTextMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        sentenceInputFieldGameObject = GameObject.FindGameObjectWithTag("SentencesInputField");
        sentenceInputField = sentenceInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
        sentenceInputTextMeshPro = GameObject.FindGameObjectWithTag("SentenceInputTextMeshPro");
    }

    public override void HandleButtonClick()
    {
        string currentStudentInputString = sentenceInputField.text;
        string editedString = currentStudentInputString.Substring(0, currentStudentInputString.Length - 1);
        sentenceInputField.text = editedString;
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}
