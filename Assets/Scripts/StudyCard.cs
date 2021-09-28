using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class StudyCard : MonoBehaviour
{
    [SerializeField]
    WordObject wordObject;

    [SerializeField]
    Text englishWord;

    [SerializeField]
    Text albanianWord;

   
    AudioClip englishAudio;

   
    AudioClip albanianAudio;

    [SerializeField]
    Image wordImage;

    private void OnValidate()
    {
        if (wordObject != null)
        {
            englishWord.text = wordObject.englishWord;
            albanianWord.text = wordObject.albanianWord;
            englishAudio = wordObject.englishAudio;
            wordImage.sprite = wordObject.icon;
        }   
    }

    public void PlayEnglishClip()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(englishAudio);
    }

    public void PlayAlbanianClip()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(albanianAudio);
    }
}
