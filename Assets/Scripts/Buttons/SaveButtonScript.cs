using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButtonScript : ButtonScript
{
    [SerializeField] InputField newPlayerNameInputField;
    [SerializeField] Text savedNameTextField;

    public override void HandleButtonClick()
    {
        if (newPlayerNameInputField.text == "")
        {
            newPlayerNameInputField.text = "You didn't enter a name";
            return;
        }
        
        savedNameTextField.text = "New profile create for: " + newPlayerNameInputField.text;
        GameManagerScript.currentProfile = new ProfileDataScript(newPlayerNameInputField.text);
        
        ProfileManagerScript.listOfProfiles.Add(GameManagerScript.currentProfile);
        
        SaveSystem.SaveListOfProfilesData();
     
        GameManagerScript.currentLevel = 1;
    }
}
