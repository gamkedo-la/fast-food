using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class StudyCard : MonoBehaviour
{
    [SerializeField]
    WordObject wordObject;

    public Dictionary<Language, TextMeshProUGUI> dictionaryOfTextMeshProObjects = new Dictionary<Language, TextMeshProUGUI>();
    public TextMeshProUGUI englishWordTextMeshPro;
    public TextMeshProUGUI albanianWordTextMeshPro;
    public TextMeshProUGUI georgianWordTextMeshPro;
    public TextMeshProUGUI turkishWordTextMeshPro;

    public Dictionary<Language, AudioClip> dictionaryOfAudioClips = new Dictionary<Language, AudioClip>();
    AudioClip englishAudio;
    AudioClip albanianAudio;
    AudioClip georgianAudio;
    AudioClip turkishAudio;

    [SerializeField]
    private Image wordImage;

    private string currentTextString;
    private GameSoundEnum myGameSoundEnum;

    public TextMeshProUGUI[] arrayOfTextMeshProUGUI;
    //public Dictionary<Language, TextMeshProUGUI> testDictionaryOfTextMeshProObjects = new Dictionary<Language, TextMeshProUGUI>();

    //private void OnValidate()
    //{
    //    if (wordObject != null)
    //    {
    //        englishWordTextMeshPro.text = wordObject.englishWord;
    //        dictionaryOfTextMeshProObjects.Add(Language.English, englishWordTextMeshPro);
    //        albanianWordTextMeshPro.text = wordObject.albanianWord;
    //        dictionaryOfTextMeshProObjects.Add(Language.Albanian, albanianWordTextMeshPro);
    //        georgianWordTextMeshPro.text = wordObject.georgianWord;
    //        dictionaryOfTextMeshProObjects.Add(Language.Georgian, georgianWordTextMeshPro);

    //        foreach (Language key in dictionaryOfTextMeshProObjects.Keys)
    //        {
    //            if (key != GameManagerScript.currentLanguage)
    //            {
    //                dictionaryOfTextMeshProObjects[key].gameObject.SetActive(false);
    //            }
    //            else
    //            {
    //                dictionaryOfTextMeshProObjects[key].gameObject.SetActive(true);
    //            }
    //        }
    //        //dictionaryOfTextMeshProObjects[GameManagerScript.currentLanguage].gameObject.SetActive(true);

    //        englishAudio = wordObject.englishAudio;
    //        dictionaryOfAudioClips.Add(Language.English, englishAudio);
    //        albanianAudio = wordObject.albanianAudio;
    //        dictionaryOfAudioClips.Add(Language.Albanian, albanianAudio);
    //        georgianAudio = wordObject.georgianAudio;
    //        dictionaryOfAudioClips.Add(Language.Georgian, georgianAudio);
    //        //dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage].gameObject.SetActive(true);

    //        InitializeMyGameSoundEnum();

    //        wordImage.sprite = wordObject.sprite;
    //    }
    //}

    private void Awake()
    {
        if (wordObject != null)
        {
            englishWordTextMeshPro.text = wordObject.englishWord;
            dictionaryOfTextMeshProObjects.Add(Language.English, englishWordTextMeshPro);
            albanianWordTextMeshPro.text = wordObject.albanianWord;
            dictionaryOfTextMeshProObjects.Add(Language.Albanian, albanianWordTextMeshPro);
            georgianWordTextMeshPro.text = wordObject.georgianWord;
            dictionaryOfTextMeshProObjects.Add(Language.Georgian, georgianWordTextMeshPro);
            turkishWordTextMeshPro.text = wordObject.turkishWord;
            dictionaryOfTextMeshProObjects.Add(Language.Turkish, turkishWordTextMeshPro);
            //dictionaryOfTextMeshProObjects[GameManagerScript.currentLanguage].gameObject.SetActive(true);

            englishAudio = wordObject.englishAudio;
            dictionaryOfAudioClips.Add(Language.English, englishAudio);
            albanianAudio = wordObject.albanianAudio;
            dictionaryOfAudioClips.Add(Language.Albanian, albanianAudio);
            georgianAudio = wordObject.georgianAudio;
            dictionaryOfAudioClips.Add(Language.Georgian, georgianAudio);
            turkishAudio = wordObject.turkishAudio;
            dictionaryOfAudioClips.Add(Language.Turkish, turkishAudio);
            //dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage].gameObject.SetActive(true);

            wordImage.sprite = wordObject.sprite;
        }

        InitializeMyGameSoundEnum();

        foreach (Language key in dictionaryOfTextMeshProObjects.Keys)
        {
            if (key != GameManagerScript.currentLanguage)
            {
                dictionaryOfTextMeshProObjects[key].gameObject.SetActive(false);
            }
            else
            {
                dictionaryOfTextMeshProObjects[key].gameObject.SetActive(true);
            }
        }
    }
    private void Start()
    {
        if (wordObject != null)
        {
            if (englishWordTextMeshPro.text == null)
            {
                englishWordTextMeshPro.text = wordObject.englishWord;
                dictionaryOfTextMeshProObjects.Add(Language.English, englishWordTextMeshPro);
            }
            if (albanianWordTextMeshPro.text == null)
            {
                albanianWordTextMeshPro.text = wordObject.albanianWord;
                dictionaryOfTextMeshProObjects.Add(Language.Albanian, albanianWordTextMeshPro);
            }
            if (georgianWordTextMeshPro.text == null)
            {
                georgianWordTextMeshPro.text = wordObject.georgianWord;
                dictionaryOfTextMeshProObjects.Add(Language.Georgian, georgianWordTextMeshPro);
            }
            if (turkishWordTextMeshPro.text == null)
            {
                turkishWordTextMeshPro.text = wordObject.turkishWord;
                dictionaryOfTextMeshProObjects.Add(Language.Turkish, turkishWordTextMeshPro);
            }

            dictionaryOfTextMeshProObjects[GameManagerScript.currentLanguage].gameObject.SetActive(true);

            if (englishAudio == null)
            {
                englishAudio = wordObject.englishAudio;
                if (dictionaryOfAudioClips[Language.English] == null)
                {
                    dictionaryOfAudioClips.Add(Language.English, englishAudio);
                }       
            }
            
            if (albanianAudio == null)
            {
                albanianAudio = wordObject.albanianAudio;
                if (dictionaryOfAudioClips[Language.Albanian] == null)
                {
                    dictionaryOfAudioClips.Add(Language.Albanian, albanianAudio);
                }  
            }
            
            if (georgianAudio == null)
            {
                georgianAudio = wordObject.georgianAudio;
                if (dictionaryOfAudioClips[Language.Georgian] == null)
                {
                    dictionaryOfAudioClips.Add(Language.Georgian, georgianAudio);
                }
            }

            if (turkishAudio == null)
            {
                turkishAudio = wordObject.turkishAudio;
                if (dictionaryOfAudioClips[Language.Turkish] == null)
                {
                    dictionaryOfAudioClips.Add(Language.Turkish, turkishAudio);
                }
            }

            //dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage].gameObject.SetActive(true);

            wordImage.sprite = wordObject.sprite;
        }

        InitializeMyGameSoundEnum();

        foreach (Language key in dictionaryOfTextMeshProObjects.Keys)
        {
            if (key != GameManagerScript.currentLanguage)
            {
                dictionaryOfTextMeshProObjects[key].gameObject.SetActive(false);
            }
            else
            {
                dictionaryOfTextMeshProObjects[key].gameObject.SetActive(true);
            }
        }
    }
    public void PlayAudioClip()
    {
        Debug.Log("myGameSoundEnum: " + myGameSoundEnum.ToString());
        
        AudioController.instance.PlayAudio(myGameSoundEnum);
    }

    private void InitializeMyGameSoundEnum()
    {
        if (SceneManager.GetActiveScene().name == "Numbers" || SceneManager.GetActiveScene().name == "Colors")
        {
            return;
        }

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
            case Language.Turkish:
                currentTextString = turkishWordTextMeshPro.text;
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
                else if (GameManagerScript.currentLanguage == Language.Turkish)
                {
                    myGameSoundEnum = GameSoundEnum.Turkish_Hamburger;
                }
                break;
            case "ჰამბურგერი":
                myGameSoundEnum = GameSoundEnum.Georgian_Hamburger;                
                break;
            case "Chicken doner":
                myGameSoundEnum = GameSoundEnum.English_Chicken_Doner;
                break;
            case "Doner pulë":
                myGameSoundEnum = GameSoundEnum.Albanian_Chicken_Doner;
                break;
            case "ქათმის შაურმა":
                myGameSoundEnum = GameSoundEnum.Georgian_Chicken_Doner;
                break;
            case "Tavuk Döner":
                myGameSoundEnum = GameSoundEnum.Turkish_Chicken_Doner;
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
            case "Marul":
                myGameSoundEnum = GameSoundEnum.Turkish_Lettuce;
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
            case "Domates":
                myGameSoundEnum = GameSoundEnum.Turkish_Tomatoe;
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
            case "Soğan":
                myGameSoundEnum = GameSoundEnum.Turkish_Onion;
                break;
            case "beer":
                myGameSoundEnum = GameSoundEnum.English_Beer;
                break;
            case "birrë":
                myGameSoundEnum = GameSoundEnum.Albanian_Beer;
                break;
            case "ლუდი":
                myGameSoundEnum = GameSoundEnum.Georgian_Beer;
                break;
            case "bira":
                myGameSoundEnum = GameSoundEnum.Turkish_Beer;
                break;
            case "Water":
                myGameSoundEnum = GameSoundEnum.English_Water;
                break;
            case "ujë":
                myGameSoundEnum = GameSoundEnum.Albanian_Water;
                break;
            case "წყალი":
                myGameSoundEnum = GameSoundEnum.Georgian_Water;
                break;
            case "Su":
                myGameSoundEnum = GameSoundEnum.Turkish_Water;
                break;
            case "red wine":
                myGameSoundEnum = GameSoundEnum.English_Red_Wine;
                break;
            case "verë e kuqe":
                myGameSoundEnum = GameSoundEnum.Albanian_Red_Wine;
                break;
            case "წითელი ღვინო":
                myGameSoundEnum = GameSoundEnum.Georgian_Red_Wine;
                break;
            case "Kırmızı Şarap":
                myGameSoundEnum = GameSoundEnum.Turkish_Red_Wine;
                break;
            case "white wine":
                myGameSoundEnum = GameSoundEnum.English_White_Wine;
                break;
            case "verë e bardhë":
                myGameSoundEnum = GameSoundEnum.Albanian_White_Wine;
                break;
            case "თეთრი ღვინო":
                myGameSoundEnum = GameSoundEnum.Georgian_White_Wine;
                break;
            case "Beyaz şarap":
                myGameSoundEnum = GameSoundEnum.Turkish_White_Wine;
                break;

            case "I would like a chicken doner with lettuce":
                myGameSoundEnum = GameSoundEnum.English_Order_Chicken_Doner_Lettuce;
                break;
            case "Unë dua një doner pule me marule":
                myGameSoundEnum = GameSoundEnum.Albanian_Order_Chicken_Doner_Lettuce;
                break;
            case "ერთი ქათმის შაურმა სალათის ფურწლით თუ შეიძლება":
                myGameSoundEnum = GameSoundEnum.Georgian_Order_Chicken_Doner_Lettuce;
                break;
            case "Bir adet marullu tavuk döner istiyorum":
                myGameSoundEnum = GameSoundEnum.Turkish_Order_Chicken_Doner_Lettuce;
                break;

            case "I would like a chicken doner with onion":
                myGameSoundEnum = GameSoundEnum.English_Order_Chicken_Doner_Onion;
                break;
            case "Unë dua një doner pule me qepë":
                myGameSoundEnum = GameSoundEnum.Albanian_Order_Chicken_Doner_Onion;
                break;
            case "ერთი ქათმის შაურმა ხახვით თუ შეიძლება":
                myGameSoundEnum = GameSoundEnum.Georgian_Order_Chicken_Doner_Onion;
                break;
            case "Bir adet soğanlı tavuk döner istiyorum":
                myGameSoundEnum = GameSoundEnum.Turkish_Order_Chicken_Doner_Onion;
                break;

            case "I would like a chicken doner with tomato":
                myGameSoundEnum = GameSoundEnum.English_Order_Chicken_Doner_Tomato;
                break;
            case "Unë dua një doner pule me domate":
                myGameSoundEnum = GameSoundEnum.Albanian_Order_Chicken_Doner_Tomato;
                break;
            case "ერთი ქათმის შაურმა პამიდორით თუ შეიძლება":
                myGameSoundEnum = GameSoundEnum.Georgian_Order_Chicken_Doner_Tomato;
                break;
            case "Bir adet domatesli tavuk döner istiyorum":
                myGameSoundEnum = GameSoundEnum.Turkish_Order_Chicken_Doner_Tomato;
                break;

            case "I would like a hamburger":
                myGameSoundEnum = GameSoundEnum.English_Order_Hamburger;
                break;
            case "Unë dua një hamburger":
                myGameSoundEnum = GameSoundEnum.Albanian_Order_Hamburger;
                break;
            case "ერთი ჰამბურგერი თუ შეიძლება":
                myGameSoundEnum = GameSoundEnum.Georgian_Order_Hamburger;
                break;
            case "Bir adet hamburger istiyorum":
                myGameSoundEnum = GameSoundEnum.Turkish_Order_Hamburger;
                break;

            case "I would like a hamburger with lettuce":
                myGameSoundEnum = GameSoundEnum.English_Order_Hamburger_Lettuce;
                break;
            case "Unë dua një hamburger me marule":
                myGameSoundEnum = GameSoundEnum.Albanian_Order_Hamburger_Lettuce;
                break;
            case "ერთი ჰამბურგერი სალათის ფურწლით თუ შეიძლება":
                myGameSoundEnum = GameSoundEnum.Georgian_Order_Hamburger_Lettuce;
                break;
            case "Bir adet marullu hamburger istiyorum":
                myGameSoundEnum = GameSoundEnum.Turkish_Order_Hamburger_Lettuce;
                break;

            case "I would like a hamburger with onion":
                myGameSoundEnum = GameSoundEnum.English_Order_Hamburger_Onion;
                break;
            case "Unë dua një hamburger me qepë":
                myGameSoundEnum = GameSoundEnum.Albanian_Order_Hamburger_Onion;
                break;
            case "ერთი ჰამბურგერი ხახვით თუ შეიძლება":
                myGameSoundEnum = GameSoundEnum.Georgian_Order_Hamburger_Onion;
                break;
            case "Bir adet soğanlı hamburger istiyorum":
                myGameSoundEnum = GameSoundEnum.Turkish_Order_Hamburger_Onion;
                break;

            case "I would like a hamburger with tomato":
                myGameSoundEnum = GameSoundEnum.English_Order_Hamburger_Tomato;
                break;
            case "Unë dua një hamburger me domate":
                myGameSoundEnum = GameSoundEnum.Albanian_Order_Hamburger_Tomato;
                break;
            case "ერთი ჰამბურგერი  პამიდორით თუ შეიძლება":
                myGameSoundEnum = GameSoundEnum.Georgian_Order_Hamburger_Tomato;
                break;
            case "Bir adet domatesli hamburger istiyorum":
                myGameSoundEnum = GameSoundEnum.Turkish_Order_Hamburger_Tomato;
                break;
        }

    }
}
