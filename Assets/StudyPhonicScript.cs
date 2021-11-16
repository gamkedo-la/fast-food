using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class StudyPhonicScript : MonoBehaviour
{
    [SerializeField]
    PhonicObject phonicObject;

    public string myCharacter;
    
    private AudioClip audio;

    private GameSoundEnum myGameSoundEnum;

    private void OnValidate()
    {
        if (phonicObject != null)
        {
            myCharacter = phonicObject.character;

            audio = phonicObject.audio;

            InitializeMyGameSoundEnum();
        }
    }

    private void Start()
    {
        if (phonicObject != null)
        {
            myCharacter = phonicObject.character;

            audio = phonicObject.audio;

            InitializeMyGameSoundEnum();
        }
    }
    public void PlayAudioClip()
    {
        Debug.Log("myGameSoundEnum: " + myGameSoundEnum.ToString());
        AudioController.instance.PlayAudio(myGameSoundEnum);
    }

    private void InitializeMyGameSoundEnum()
    {
        string growingString = "";
        growingString += GameManagerScript.currentLanguage.ToString();
        growingString += "_Phonic_";
        growingString += myCharacter.ToUpper();
        myGameSoundEnum = (GameSoundEnum)Enum.Parse(typeof(GameSoundEnum), growingString);
    }
}
