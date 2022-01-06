using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScenesToLoadEnumerations
{
    MainMenu1,
    NewPlayerPrepScene,
    ReturningPlayerPrepScene,
    Gameplay,
    Spelling,
    Sentences,
    Numbers,
    Colors,
    Phonics,
}
public class LoadSceneButtonScript : ButtonScript
{
    [SerializeField] ScenesToLoadEnumerations mySceneToLoadEnumeration;
    public GameObject fadeTransitioner;

    private void Start()
    {
        fadeTransitioner = GameObject.FindGameObjectWithTag("FadeTransitioner");
    }
    public override void HandleButtonClick()
    {
        //Time.timeScale = 0;
        AudioController.instance.StopAudio(GameSoundEnum.SFX_Customer_Impatience);
        GameManagerScript.impatienceSoundIsPlaying = false;
        if (buttonClickAudioClip.name == "UI_Button_Back")
        {
            Debug.Log("back button audio clip found");
            AudioController.instance.PlayAudio(GameSoundEnum.Back_Button_UI);
        }
        else
        {
            AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
        }

        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            GameObject[] arrayOfCustomers = GameObject.FindGameObjectsWithTag("Customer");
            for (int i = arrayOfCustomers.Length - 1; i > -1; i--)
            {
                Destroy(arrayOfCustomers[i]);
            }
        }

        fadeTransitioner.GetComponent<FadeTransitionerScript>().isFadingOut = true;
        fadeTransitioner.GetComponent<FadeTransitionerScript>().isTransitioningAScene = true;
        fadeTransitioner.GetComponent<FadeTransitionerScript>().firstFrameAfterSceneLoadHasPassed = false;
        fadeTransitioner.GetComponent<FadeTransitionerScript>().currentLoadSceneButtonScript = this;

        if (SceneManager.GetActiveScene().name == "Colors" ||
            SceneManager.GetActiveScene().name == "Numbers" ||
            SceneManager.GetActiveScene().name == "Phonics" ||
            SceneManager.GetActiveScene().name == "Sentences" ||
            SceneManager.GetActiveScene().name == "Spelling" && GameManagerScript.NewPlayerHasntPlayedMainGameYet)
        {
            mySceneToLoadEnumeration = ScenesToLoadEnumerations.NewPlayerPrepScene;
            return;
        }
        else if (SceneManager.GetActiveScene().name == "Colors" ||
            SceneManager.GetActiveScene().name == "Numbers" ||
            SceneManager.GetActiveScene().name == "Phonics" ||
            SceneManager.GetActiveScene().name == "Sentences" ||
            SceneManager.GetActiveScene().name == "Spelling" && !GameManagerScript.NewPlayerHasntPlayedMainGameYet)
        {
            mySceneToLoadEnumeration = ScenesToLoadEnumerations.Gameplay;
            return;
        }
    }

    public void LoadScene()
    {
        //Debug.Log("mySceneToLoadEnumeration: " + mySceneToLoadEnumeration.ToString());
        
            //block movement and sound calls for a 'pause' while leaving Time.deltaTime running for fadeOut transitions
            //GameManagerScript.extraPauseForTransitions = true;
            fadeTransitioner.GetComponent<FadeTransitionerScript>().firstFrameAfterSceneLoadHasPassed = false;

        //AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
        SceneManager.LoadScene(mySceneToLoadEnumeration.ToString());

        //Play UI button sound
        

        if (gameObject.name == "MainMenuSceneLoadButton")
        {
            SaveSystem.SaveListOfProfilesData();
        }
        //Play the correct music based on scene
        switch (mySceneToLoadEnumeration)
        {
            case ScenesToLoadEnumerations.MainMenu1:
                AudioController.instance.PlayAudio(GameSoundEnum.Music_Main_Menu);
                break;
            case ScenesToLoadEnumerations.Gameplay:
                switch (GameManagerScript.currentLanguage)
                {
                    case Language.Georgian:
                        AudioController.instance.PlayAudio(GameSoundEnum.Music_Level_Georgian);
                        break;
                    default:
                        AudioController.instance.PlayAudio(GameSoundEnum.Music_Level);
                        break;
                }
                break;
            default:
                break;
        }
    }
}
