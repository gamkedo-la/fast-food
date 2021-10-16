using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadProfile2Script : ButtonScript
{

    public override void HandleButtonClick()
    {
        GameManagerScript.currentLevel = ProfileManagerScript.listOfProfiles[1].currentLevel;
        SceneManager.LoadScene("ReturningPlayerPrepScene");
    }
}