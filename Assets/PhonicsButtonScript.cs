using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhonicsButtonScript : ButtonScript
{
    private string myCharacter;
    private GameObject phonicsInputFieldGameObject;
    private TMP_InputField phonicsInputField;

    private void Start()
    {
        myCharacter = GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
        phonicsInputFieldGameObject = GameObject.FindGameObjectWithTag("PhonicsInputField");
        phonicsInputField = phonicsInputFieldGameObject.GetComponent<TMPro.TMP_InputField>();
    }

    public override void HandleButtonClick()
    {
        phonicsInputField.text += myCharacter;
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}