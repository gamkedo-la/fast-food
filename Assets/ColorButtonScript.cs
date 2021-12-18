using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorButtonScript : ButtonScript
{
    private string myColorString;
    private GameObject colorInputFieldGameObject;
    private TMP_InputField colorInputField;
    private GameObject colorInputTextMeshPro;

    private void Start()
    {
        myColorString = GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
        colorInputFieldGameObject = GameObject.FindGameObjectWithTag("ColorsInputField");
        colorInputField = colorInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
        //sentenceInputTextMeshPro = GameObject.FindGameObjectWithTag("SentenceInputTextMeshPro");
    }

    public override void HandleButtonClick()
    {
        colorInputField.text += myColorString;
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}
