using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordButtonScript : ButtonScript
{
    private string myWord;
    private GameObject sentenceInputFieldGameObject;
    private TMP_InputField sentenceInputField;
    private GameObject sentenceInputTextMeshPro;

    private void Start()
    {
        myWord = GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
        sentenceInputFieldGameObject = GameObject.FindGameObjectWithTag("SentencesInputField");
        sentenceInputField = sentenceInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
        //sentenceInputTextMeshPro = GameObject.FindGameObjectWithTag("SentenceInputTextMeshPro");
    }

    public override void HandleButtonClick()
    {
        sentenceInputField.text += myWord;
        if (gameObject.transform.parent.name == "WordButtonsHorizontalLayoutGroup")
        {
            sentenceInputField.text += " ";
        }
    }
}