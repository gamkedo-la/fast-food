using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using TMPro;

public class SpellingWordsManagerScript : MonoBehaviour
{
    [SerializeField] private StudyCard[] arrayOfAllStudyCards;
    private List<StudyCard> listOfCurrentLevelStudyCards = new List<StudyCard>();
    private StudyCard targetStudyCard;
    public string currentWordToSpellString;
    [SerializeField] GameObject letterButtonPrefab;
    [SerializeField] GameObject letterButtonsHorizontalLayoutGroup;

    // Start is called before the first frame update
    void Start()
    {
        ResetListOfCurrentLevelStudyCards();
        ResetDisplay();
    }

    public void ResetDisplay()
    {
        
        foreach (Transform child in letterButtonsHorizontalLayoutGroup.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (targetStudyCard != null)
        {
            targetStudyCard.gameObject.SetActive(false);
        }
        targetStudyCard = SelectAStudyCard();
        targetStudyCard.gameObject.SetActive(true);


        //GameManagerScript.currentLanguage = Language.English;
        Debug.Log("targetStudyCard.dictionaryOfTextMeshProObjects: " + targetStudyCard.dictionaryOfTextMeshProObjects);
        Debug.Log("targetStudyCard.dictionaryOfTextMeshProObjects[GameManagerScript.currentLanguage]: " + targetStudyCard.dictionaryOfTextMeshProObjects[GameManagerScript.currentLanguage]);

        currentWordToSpellString = targetStudyCard.dictionaryOfTextMeshProObjects[GameManagerScript.currentLanguage].text;
        if (GameManagerScript.currentLanguage != Language.Georgian)
        {
            currentWordToSpellString = currentWordToSpellString.ToLower();
        }

        var shuffledCurrentWordToSpellString = new string(currentWordToSpellString.OrderBy(x => Guid.NewGuid()).ToArray());
        char[] arrayOfShuffledCharacters = shuffledCurrentWordToSpellString.ToCharArray();
        for (int i = 0; i < arrayOfShuffledCharacters.Length; i++)
        {
            var letterButton = Instantiate(letterButtonPrefab);
            letterButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = arrayOfShuffledCharacters[i].ToString();
            letterButton.transform.SetParent(letterButtonsHorizontalLayoutGroup.transform, false);
        }
    }

    public List<StudyCard> ResetListOfCurrentLevelStudyCards()
    {
        listOfCurrentLevelStudyCards.Clear();
        
        for (int i = 0; i < GameManagerScript.currentSpellingLevel; i++)
        {
            listOfCurrentLevelStudyCards.Add(arrayOfAllStudyCards[i]);
        }
        return listOfCurrentLevelStudyCards;
    }

    private StudyCard SelectAStudyCard()
    {
        StudyCard targetSpellingWord;
        int randomStudyCardDictionaryIndex = UnityEngine.Random.Range(0, listOfCurrentLevelStudyCards.Count);
        targetSpellingWord = listOfCurrentLevelStudyCards[randomStudyCardDictionaryIndex];
        return targetSpellingWord;
    }
}
