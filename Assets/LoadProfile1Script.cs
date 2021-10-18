using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadProfile1Script : ButtonScript
{
    
    public override void HandleButtonClick()
    {
        GameManagerScript.currentLevel = ProfileManagerScript.listOfProfiles[0].currentLevel;
        GameManagerScript.currentLanguage = ProfileManagerScript.listOfProfiles[0].targetLanguage;
        SceneManager.LoadScene("ReturningPlayerPrepScene");
    }
}
