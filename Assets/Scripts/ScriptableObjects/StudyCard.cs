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

    private Dictionary<Language, TextMeshProUGUI> dictionaryOfTextMeshProObjects = new Dictionary<Language, TextMeshProUGUI>();
    [SerializeField] TextMeshProUGUI englishWordTextMeshPro;
    [SerializeField] TextMeshProUGUI albanianWordTextMeshPro;
    [SerializeField] TextMeshProUGUI georgianWordTextMeshPro;

    public Dictionary<Language, AudioClip> dictionaryOfAudioClips = new Dictionary<Language, AudioClip>();
    AudioClip englishAudio;
    AudioClip albanianAudio;
    AudioClip georgianAudio;

    [SerializeField]
    Image wordImage;

    private string currentTextString;
    private GameSoundEnum myGameSoundEnum;

    private void OnValidate()
    {
        if (wordObject != null)
        {
            englishWordTextMeshPro.text = wordObject.englishWord;
            dictionaryOfTextMeshProObjects.Add(Language.English, englishWordTextMeshPro);
            albanianWordTextMeshPro.text = wordObject.albanianWord;
            dictionaryOfTextMeshProObjects.Add(Language.Albanian, albanianWordTextMeshPro);
            georgianWordTextMeshPro.text = wordObject.georgianWord;
            dictionaryOfTextMeshProObjects.Add(Language.Georgian, georgianWordTextMeshPro);
            dictionaryOfTextMeshProObjects[GameManagerScript.currentLanguage].gameObject.SetActive(true);

            englishAudio = wordObject.englishAudio;
            dictionaryOfAudioClips.Add(Language.English, englishAudio);
            albanianAudio = wordObject.albanianAudio;
            dictionaryOfAudioClips.Add(Language.Albanian, albanianAudio);
            georgianAudio = wordObject.georgianAudio;
            dictionaryOfAudioClips.Add(Language.Georgian, georgianAudio);
            //dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage].gameObject.SetActive(true);

            wordImage.sprite = wordObject.icon;
        }   
    }

    private void Start()
    {
        InitializeMyGameSoundEnum();
        
        if (GameManagerScript.currentLanguage == Language.English)
        {
            englishWordTextMeshPro.gameObject.SetActive(true);
            albanianWordTextMeshPro.gameObject.SetActive(false);
            georgianWordTextMeshPro.gameObject.SetActive(false);
        }
        else if (GameManagerScript.currentLanguage == Language.Albanian)
        {
            englishWordTextMeshPro.gameObject.SetActive(false);
            albanianWordTextMeshPro.gameObject.SetActive(true);
            georgianWordTextMeshPro.gameObject.SetActive(false);
        }
        else if (GameManagerScript.currentLanguage == Language.Georgian)
        {
            englishWordTextMeshPro.gameObject.SetActive(false);
            albanianWordTextMeshPro.gameObject.SetActive(false);
            georgianWordTextMeshPro.gameObject.SetActive(true);
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
                currentTextString = englishWordTextMeshPro.text;
                break;

            case Language.Albanian:
                currentTextString = albanianWordTextMeshPro.text;
                break;
            case Language.Georgian:
                currentTextString = georgianWordTextMeshPro.text;
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
            case "ჰამბურგერი":
                myGameSoundEnum = GameSoundEnum.Georgian_Hamburger;                
                break;
            case "Chicken Doner":
                myGameSoundEnum = GameSoundEnum.English_Chicken_Doner;
                break;
            case "Doner Pule":
                myGameSoundEnum = GameSoundEnum.Albanian_Chicken_Doner;
                break;
            case "ქათმის შაურმა":
                myGameSoundEnum = GameSoundEnum.Georgian_Chicken_Doner;
                break;
            case "Lettuce":
                myGameSoundEnum = GameSoundEnum.English_Lettuce;
                break;
            case "Marule":
                myGameSoundEnum = GameSoundEnum.Albanian_Lettuce;
                break;
            case "სალათის ფურწლი":
                myGameSoundEnum = GameSoundEnum.Georgian_Lettuce;
                break;
            case "Tomato":
                myGameSoundEnum = GameSoundEnum.English_Tomato;
                break;
            case "Domate":
                myGameSoundEnum = GameSoundEnum.Albanian_Tomato;
                break;
            case "პამიდორი":
                myGameSoundEnum = GameSoundEnum.Georgian_Tomato;
                break;
            case "Onion":
                myGameSoundEnum = GameSoundEnum.English_Onion;
                break;
            case "Qepe":
                myGameSoundEnum = GameSoundEnum.Albanian_Onion;
                break;
            case "ხახვი":
                myGameSoundEnum = GameSoundEnum.Georgian_Onion;
                break;
        }

    }
}
