using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleOnButtonScript : ButtonScript
{
    [SerializeField] GameObject objectToToggleOn;
    [SerializeField] GameObject objectToToggleOff;

    public GameObject fadeTransitioner;

    private void Start()
    {
        fadeTransitioner = GameObject.FindGameObjectWithTag("FadeTransitioner");
    }
    public void ToggleOn()
    {
        if (objectToToggleOn != null)
        {
            objectToToggleOn.SetActive(true);
        }
    }

    public void ToggleOff()
    {
        if (objectToToggleOff != null)
        {
            objectToToggleOff.SetActive(false);
        }
    }

    public override void HandleButtonClick()
    {
        if (gameObject.name == "SelectLanguageButton" && GameManagerScript.currentProfile == null)
        {
            AudioController.instance.PlayAudio(GameSoundEnum.SFX_Incorrect_Order);
            return;
        } 
        else if (gameObject.name == "OKToggleButton")
        {
            Time.timeScale = 1;
            GameObject tomatoIntroduction = GameObject.FindGameObjectWithTag("TomatoIntroduction");
            GameObject chickenDonerIntroduction = GameObject.FindGameObjectWithTag("ChickenDonerIntroduction");
            GameObject onionIntroduction = GameObject.FindGameObjectWithTag("OnionIntroduction");
            if (tomatoIntroduction != null)
            {
                tomatoIntroduction.SetActive(false);
            }
            if (chickenDonerIntroduction != null)
            {
                chickenDonerIntroduction.SetActive(false);
            }
            if (onionIntroduction != null)
            {
                onionIntroduction.SetActive(false);
            }
        }
        else if (gameObject.name == "NextToggleButton")
        {
            GameManagerScript.NewPlayerHasSeenIntroductorySentence = true;
        }

        
        fadeTransitioner.GetComponent<FadeTransitionerScript>().isFadingOut = true;
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            Debug.Log("fadeTransitioner.GetComponent<FadeTransitionerScript>().isFadingOut: " + fadeTransitioner.GetComponent<FadeTransitionerScript>().isFadingOut);
            Debug.Log("fadeTransitioner.GetComponent<FadeTransitionerScript>().isFadingIn: " + fadeTransitioner.GetComponent<FadeTransitionerScript>().isFadingIn);
        }
        fadeTransitioner.GetComponent<FadeTransitionerScript>().isTransitioningACanvas = true;
        fadeTransitioner.GetComponent<FadeTransitionerScript>().currentToggleOnButtonScript = this;
        if (gameObject.name == "OKToggleButton")
        {
            GameManagerScript.extraPauseForTransitions = false;
        }
        //ToggleOn();
        //ToggleOff();
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}
