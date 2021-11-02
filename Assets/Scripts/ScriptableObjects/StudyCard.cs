using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
public class StudyCard : MonoBehaviour
{
    [SerializeField]
    WordObject wordObject;

    private Dictionary<Language, Text> dictionaryOfTextBoxObjects = new Dictionary<Language, Text>();
    [SerializeField]
    Text englishWord;
    [SerializeField]
    Text albanianWord;

    private Dictionary<Language, TextMeshProUGUI> dictionaryOfTextMeshProObjects = new Dictionary<Language, TextMeshProUGUI>();
    [SerializeField] TextMeshProUGUI englishWordTextMeshPro;
    [SerializeField] TextMeshProUGUI albanianWordTextMeshPro;

    public Dictionary<Language, AudioClip> dictionaryOfAudioClips = new Dictionary<Language, AudioClip>();
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
            dictionaryOfTextBoxObjects.Add(Language.English, englishWord);
            albanianWord.text = wordObject.albanianWord;
            dictionaryOfTextBoxObjects.Add(Language.Albanian, albanianWord);

            englishAudio = wordObject.englishAudio;
            dictionaryOfAudioClips.Add(Language.English, englishAudio);
            albanianAudio = wordObject.albanianAudio;
            dictionaryOfAudioClips.Add(Language.Albanian, albanianAudio);
            //dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage].gameObject.SetActive(true);

            wordImage.sprite = wordObject.icon;
        }   
    }

    private void Start()
    {
        InitializeMyGameSoundEnum();
        
        if (GameManagerScript.currentLanguage == Language.English)
        {
            englishWord.gameObject.SetActive(true);
            albanianWord.gameObject.SetActive(false);
        }
        else if (GameManagerScript.currentLanguage == Language.Albanian)
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
            case Language.English:
                currentTextString = englishWord.text;
                break;

            case Language.Albanian:
                currentTextString = albanianWord.text;
                break;
        }

        switch (currentTextString)
        {
            case "Hamburger":
                if (GameManagerScript.currentLanguage == Language.English)
                {
                    myGameSoundEnum = GameSoundEnum.English_Hamburger;
                }
                else if (GameManagerScript.currentLanguage == Language.Albanian)
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
