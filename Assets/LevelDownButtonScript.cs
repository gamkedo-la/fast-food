using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelDownButtonScript : ButtonScript
{
    [SerializeField] private GameObject miniGameSpecificManager;
    [SerializeField] private TextMeshProUGUI currentLevelTextMeshPro;
    private Scene currentScene;

    public override void HandleButtonClick()
    {
        currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "Colors":
                if (GameManagerScript.currentColorsLevel == 1)
                {
                    return;
                }
                GameManagerScript.currentColorsLevel--;
                currentLevelTextMeshPro.text = "Current Level: " + GameManagerScript.currentColorsLevel;
                miniGameSpecificManager.GetComponent<ColorsManagerScript>().ResetListOfCurrentLevelStudyCards();
                miniGameSpecificManager.GetComponent<ColorsManagerScript>().ResetDisplay();
                break;

            case "Numbers":
                if (GameManagerScript.currentNumbersLevel == 1)
                {
                    return;
                }
                GameManagerScript.currentNumbersLevel--;
                currentLevelTextMeshPro.text = "Current Level: " + GameManagerScript.currentNumbersLevel;
                miniGameSpecificManager.GetComponent<NumbersManagerScript>().ResetListOfCurrentLevelStudyCards();
                miniGameSpecificManager.GetComponent<NumbersManagerScript>().ResetDisplay();
                break;

            case "Sentences":
                if (GameManagerScript.currentSentencesLevel == 1)
                {
                    return;
                }
                GameManagerScript.currentSentencesLevel--;
                currentLevelTextMeshPro.text = "Current Level: " + GameManagerScript.currentSentencesLevel;
                miniGameSpecificManager.GetComponent<SentencesManagerScript>().ResetListOfCurrentLevelStudyCards();
                miniGameSpecificManager.GetComponent<SentencesManagerScript>().ResetDisplay();
                break;

            case "Spelling":
                if (GameManagerScript.currentSpellingLevel == 1)
                {
                    return;
                }
                GameManagerScript.currentSpellingLevel--;
                currentLevelTextMeshPro.text = "Current Level: " + GameManagerScript.currentSpellingLevel;
                miniGameSpecificManager.GetComponent<SpellingWordsManagerScript>().ResetListOfCurrentLevelStudyCards();
                miniGameSpecificManager.GetComponent<SpellingWordsManagerScript>().ResetDisplay();
                break;

            case "Phonics":
                if (GameManagerScript.currentPhonicsLevel == 1)
                {
                    return;
                }
                GameManagerScript.currentPhonicsLevel--;
                currentLevelTextMeshPro.text = "Current Level: " + GameManagerScript.currentPhonicsLevel;
                miniGameSpecificManager.GetComponent<PhonicsManagerScript>().ResetListOfCurrentLevelStudyCards();
                miniGameSpecificManager.GetComponent<PhonicsManagerScript>().ResetDisplay();
                break;
        }
    }
}

