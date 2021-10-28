using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class StudyCard : MonoBehaviour
{
    [SerializeField]
    WordObject wordObject;

    private Dictionary<string, Text> dictionaryOfTextBoxObjects = new Dictionary<string, Text>();
    [SerializeField]
    Text englishWord;
    [SerializeField]
    Text albanianWord;

    public Dictionary<string, AudioClip> dictionaryOfAudioClips = new Dictionary<string, AudioClip>();
    AudioClip englishAudio;
    AudioClip albanianAudio;

    [SerializeField]
    Image wordImage;

    private string currentTextString;
    private GameSoundEnum myGameSoundEnum;

    private void OnValidate()
    {
        if (wordObject != null)
        {
            englishWord.text = wordObject.englishWord;
            dictionaryOfTextBoxObjects.Add("English", englishWord);
            albanianWord.text = wordObject.albanianWord;
            dictionaryOfTextBoxObjects.Add("Albanian", albanianWord);

            englishAudio = wordObject.englishAudio;
            dictionaryOfAudioClips.Add("English", englishAudio);
            albanianAudio = wordObject.albanianAudio;
            dictionaryOfAudioClips.Add("Albanian", albanianAudio);
            //dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage].gameObject.SetActive(true);

            wordImage.sprite = wordObject.icon;
        }   
    }

    private void Start()
    {
        InitializeMyGameSoundEnum();
        
        if (GameManagerScript.currentLanguage == "English")
        {
            englishWord.gameObject.SetActive(true);
            albanianWord.gameObject.SetActive(false);
        }
        else if (GameManagerScript.currentLanguage == "Albanian")
        {
            englishWord.gameObject.SetActive(false);
            albanianWord.gameObject.SetActive(true);
        }
    }
    public void PlayAudioClip()
    {
        AudioController.instance.PlayAudio(myGameSoundEnum);
    }

    private void InitializeMyGameSoundEnum()
    {
        
        switch (GameManagerScript.currentLanguage)
        {
            case "English":
                currentTextString = englishWord.text;
                break;

            case "Albanian":
                currentTextString = albanianWord.text;
                break;
        }

        switch (currentTextString)
        {
            case "Hamburger":
                if (GameManagerScript.currentLanguage == "English")
                {
                    myGameSoundEnum = GameSoundEnum.English_Hamburger;
                }
                else if (GameManagerScript.currentLanguage == "Albanian")
                {
                    myGameSoundEnum = GameSoundEnum.Albanian_Hamburger;
                }
                break;
            case "Chicken Doner":
                myGameSoundEnum = GameSoundEnum.English_Chicken_Doner;
                break;
            case "Doner Pule":
                myGameSoundEnum = GameSoundEnum.Albanian_Chicken_Doner;
                break;
            case "Lettuce":
                myGameSoundEnum = GameSoundEnum.English_Lettuce;
                break;
            case "Marule":
                myGameSoundEnum = GameSoundEnum.Albanian_Lettuce;
                break;
            case "Tomato":
                myGameSoundEnum = GameSoundEnum.English_Tomato;
                break;
            case "Domate":
                myGameSoundEnum = GameSoundEnum.Albanian_Tomato;
                break;
            case "Onion":
                myGameSoundEnum = GameSoundEnum.English_Onion;
                break;
            case "Qepe":
                myGameSoundEnum = GameSoundEnum.Albanian_Onion;
                break;
        }

    }
}
