using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepSceneAudioButtonScript : ButtonScript
{
    [SerializeField] string languageDictionaryKeyString;

    public void PlayMyAudio()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage][languageDictionaryKeyString]);
    }

    public override void HandleButtonClick()
    {
        PlayMyAudio();
    }
}
