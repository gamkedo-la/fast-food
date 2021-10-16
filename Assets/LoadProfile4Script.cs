using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadProfile4Script : ButtonScript
{

    public override void HandleButtonClick()
    {
        GameManagerScript.currentLevel = ProfileManagerScript.listOfProfiles[3].currentLevel;
        SceneManager.LoadScene("ReturningPlayerPrepScene");
    }
}