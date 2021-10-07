using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudyCanvasScript : MonoBehaviour
{
    [SerializeField] Text hamburgerImageTextBox;
    [SerializeField] Text lettuceImageTextBox;
    [SerializeField] Text tomatoeImageTextBox;
    [SerializeField] Text onionImageTextBox;

    void Start()
    {
        hamburgerImageTextBox.text = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["hamburger"];
        lettuceImageTextBox.text = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce"];
        tomatoeImageTextBox.text = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["tomato"];
        onionImageTextBox.text = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["onion"];
    }
}
