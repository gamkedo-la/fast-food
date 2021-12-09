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

    [SerializeField]
    GameObject myParentPhonicsContainerGameObject;

    public string myCharacter;
    
    private AudioClip audio;

    private GameSoundEnum myGameSoundEnum;

    //private void OnValidate()
    //{
    //    if (phonicObject != null)
    //    {
    //        myCharacter = phonicObject.character;

    //        audio = phonicObject.audio;

    //        InitializeMyGameSoundEnum();
    //    }
    //}

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

        //growingString += GameManagerScript.currentLanguage.ToString();
        if (myParentPhonicsContainerGameObject.name == "EnglishPhonics")
        {
            growingString += "English";
        }
        else if (myParentPhonicsContainerGameObject.name == "AlbanianPhonics")
        {
            growingString += "Albanian";
        }
        else if (myParentPhonicsContainerGameObject.name == "GeorgianPhonics")
        {
            growingString += "Georgian";
        }

        growingString += "_Phonic_";

        if (myParentPhonicsContainerGameObject.name != "GeorgianPhonics")
        {
            growingString += myCharacter.ToUpper();
        }
        
        myGameSoundEnum = (GameSoundEnum)Enum.Parse(typeof(GameSoundEnum), growingString);
    }
}
