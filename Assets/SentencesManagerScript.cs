using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using TMPro;

public class SentencesManagerScript : MonoBehaviour
{
    [SerializeField] private StudyCard[] arrayOfAllStudyCards;
    private List<StudyCard> listOfCurrentLevelStudyCards = new List<StudyCard>();
    private StudyCard targetStudyCard;
    public string currentSentenceToFormString;
    [SerializeField] GameObject wordButtonPrefab;
    [SerializeField] GameObject wordButtonsHorizontalLayoutGroup;

    // Start is called before the first frame update
    void Start()
    {
        ResetListOfCurrentLevelStudyCards();
        ResetDisplay();
    }

    public void ResetDisplay()
    {
        foreach (Transform child in wordButtonsHorizontalLayoutGroup.transform)
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

        //Debug.Log("targetStudyCard.dictionaryOfTextMeshProObjects[Language.English]: " + targetStudyCard.dictionaryOfTextMeshProObjects[Language.English]);
        //Debug.Log("targetStudyCard.dictionaryOfTextMeshProObjects[Language.Albanian]: " + targetStudyCard.dictionaryOfTextMeshProObjects[Language.Albanian]);
        //Debug.Log("targetStudyCard.dictionaryOfTextMeshProObjects[Language.Georgian]: " + targetStudyCard.dictionaryOfTextMeshProObjects[Language.Georgian]);

        currentSentenceToFormString = targetStudyCard.dictionaryOfTextMeshProObjects[GameManagerScript.currentLanguage].text;
        if (GameManagerScript.currentLanguage != Language.Georgian)
        {
            currentSentenceToFormString = currentSentenceToFormString.ToLower();
        }

        //Debug.Log("currentSentenceToFormString: " + currentSentenceToFormString);
        string[] arrayOfIndividualWords = currentSentenceToFormString.Split();

        //shuffle the array
        for (int i = 0; i < arrayOfIndividualWords.Length - 1; i++)
        {
            int rnd = UnityEngine.Random.Range(i, arrayOfIndividualWords.Length);
            var tempWord = arrayOfIndividualWords[rnd];
            arrayOfIndividualWords[rnd] = arrayOfIndividualWords[i];
            arrayOfIndividualWords[i] = tempWord;
        }

        for (int i = 0; i < arrayOfIndividualWords.Length; i++)
        {
            var wordButton = Instantiate(wordButtonPrefab);
            wordButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = arrayOfIndividualWords[i].ToString();
            wordButton.transform.SetParent(wordButtonsHorizontalLayoutGroup.transform, false);
        }
    }

    public List<StudyCard> ResetListOfCurrentLevelStudyCards()
    {
        listOfCurrentLevelStudyCards.Clear();
        //Debug.Log("listOfCurrentLevelStudyCards: " + listOfCurrentLevelStudyCards);
        //Debug.Log("arrayOfAllStudyCards: " + arrayOfAllStudyCards[0]);
        for (int i = 0; i < GameManagerScript.currentSentencesLevel; i++)
        {
            listOfCurrentLevelStudyCards.Add(arrayOfAllStudyCards[i]);
        }
        //Debug.Log("listOfCurrentLevelStudyCards.Count: " + listOfCurrentLevelStudyCards.Count);
        return listOfCurrentLevelStudyCards;
    }

    private StudyCard SelectAStudyCard()
    {
        StudyCard targetSentenceStudyCard;
        int randomStudyCardDictionaryIndex = UnityEngine.Random.Range(0, listOfCurrentLevelStudyCards.Count);
        targetSentenceStudyCard = listOfCurrentLevelStudyCards[randomStudyCardDictionaryIndex];
        //Debug.Log("targetSentenceStudyCard: " + targetSentenceStudyCard);
        return targetSentenceStudyCard;
    }
}

