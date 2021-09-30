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
            Debug.Log("dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage]: " + dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage]);
            dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage].gameObject.SetActive(true);

            wordImage.sprite = wordObject.icon;
        }   
    }

    //private void Start()
    //{
    //    Debug.Log("dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage]: " + dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage]);
    //    dictionaryOfTextBoxObjects[GameManagerScript.currentLanguage].enabled = true;
    //}
    public void PlayAudioClip()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(dictionaryOfAudioClips[GameManagerScript.currentLanguage]);
    }
}
