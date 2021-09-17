using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepSceneAudioButtonScript : MonoBehaviour
{
    [SerializeField] string languageDictionaryKeyString;

    public void PlayMyAudio()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage][languageDictionaryKeyString]);
    }
}
