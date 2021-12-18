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
                if (GameManagerScript.currentLanguage == Language.English)
                {
                    if (GameManagerScript.currentEnglishPhonicsLevel == 1)
                    {
                        return;
                    }
                    GameManagerScript.currentEnglishPhonicsLevel--;
                    currentLevelTextMeshPro.text = "Current Level: " + GameManagerScript.currentEnglishPhonicsLevel;
                }
                else if (GameManagerScript.currentLanguage == Language.Albanian)
                {
                    if (GameManagerScript.currentAlbanianPhonicsLevel == GameManagerScript.maxAlbanianPhonicsLevel)
                    {
                        return;
                    }
                    GameManagerScript.currentAlbanianPhonicsLevel--;
                    currentLevelTextMeshPro.text = "Current Level: " + GameManagerScript.currentAlbanianPhonicsLevel;
                }
                else if (GameManagerScript.currentLanguage == Language.Georgian)
                {
                    if (GameManagerScript.currentGeorgianPhonicsLevel == GameManagerScript.maxGeorgianPhonicsLevel)
                    {
                        return;
                    }
                    GameManagerScript.currentGeorgianPhonicsLevel--;
                    currentLevelTextMeshPro.text = "Current Level: " + GameManagerScript.currentGeorgianPhonicsLevel;
                }

                miniGameSpecificManager.GetComponent<PhonicsManagerScript>().ResetListOfCurrentLevelStudyCards();
                miniGameSpecificManager.GetComponent<PhonicsManagerScript>().ResetDisplay();
                break;
        }
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}

