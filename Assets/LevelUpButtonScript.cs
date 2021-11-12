using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpButtonScript : ButtonScript
{
    [SerializeField] private GameObject colorManager;

    public override void HandleButtonClick()
    {
        GameManagerScript.currentColorsLevel++;
        colorManager.GetComponent<ColorsManagerScript>().ResetListOfCurrentLevelStudyCards();
        colorManager.GetComponent<ColorsManagerScript>().ResetDisplay();
    }
}
