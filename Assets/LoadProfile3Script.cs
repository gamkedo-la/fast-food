using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadProfile3Script : ButtonScript
{

    public override void HandleButtonClick()
    {
        GameManagerScript.currentLevel = ProfileManagerScript.listOfProfiles[2].currentLevel;
        GameManagerScript.currentLanguage = ProfileManagerScript.listOfProfiles[2].targetLanguage;
        SceneManager.LoadScene("ReturningPlayerPrepScene");
    }
}