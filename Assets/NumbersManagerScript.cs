using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using TMPro;

public class NumbersManagerScript : MonoBehaviour
{
    [SerializeField] private StudyCard[] arrayOfAllStudyCards;
    private List<StudyCard> listOfCurrentLevelStudyCards = new List<StudyCard>();
    private StudyCard targetStudyCard;
    public string currentTargetNumberString;
    [SerializeField] GameObject numberButtonPrefab;
    [SerializeField] GameObject numberButtonsHorizontalLayoutGroup;
    private string concatenatedNumbersString;

    // Start is called before the first frame update
    void Start()
    {
        ResetListOfCurrentLevelStudyCards();
        ResetDisplay();
    }

    public void ResetDisplay()
    {
        foreach (Transform child in numberButtonsHorizontalLayoutGroup.transform)
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

        currentTargetNumberString = targetStudyCard.dictionaryOfTextMeshProObjects[GameManagerScript.currentLanguage].text;
        if (GameManagerScript.currentLanguage != Language.Georgian)
        {
            currentTargetNumberString = currentTargetNumberString.ToLower();
        }

        //Debug.Log("currentTargetNumberString: " + currentTargetNumberString);

        
        foreach (StudyCard studyCard in listOfCurrentLevelStudyCards)
        {
            concatenatedNumbersString += studyCard.arrayOfTextMeshProUGUI[(int)GameManagerScript.currentLanguage].text.ToString();
            concatenatedNumbersString += " ";
        }
        
        //Debug.Log("concatenatedNumbersString: " + concatenatedNumbersString);
        string[] arrayOfIndividualNumbers = concatenatedNumbersString.Split();
        
        for (int i = 0; i < arrayOfIndividualNumbers.Length - 1; i++)
        {
            //Debug.Log("arrayOfIndividualNumbers[i]: " + arrayOfIndividualNumbers[i]);
        }

        //shuffle the array
        for (int i = 0; i < arrayOfIndividualNumbers.Length - 1; i++)
        {
            int rnd = UnityEngine.Random.Range(i, arrayOfIndividualNumbers.Length);
            var tempNumber = arrayOfIndividualNumbers[rnd];
            arrayOfIndividualNumbers[rnd] = arrayOfIndividualNumbers[i];
            arrayOfIndividualNumbers[i] = tempNumber;
        }

        for (int i = 0; i < arrayOfIndividualNumbers.Length ; i++)
        {
            var numberButton = Instantiate(numberButtonPrefab);
            numberButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = arrayOfIndividualNumbers[i].ToString();
            //Debug.Log("numberButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text: " + numberButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
            if (numberButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text != "")
            {
                numberButton.transform.SetParent(numberButtonsHorizontalLayoutGroup.transform, false);
            }
            else
            {
                Destroy(numberButton);
            }
        }

        concatenatedNumbersString = "";
    }

    public List<StudyCard> ResetListOfCurrentLevelStudyCards()
    {
        listOfCurrentLevelStudyCards.Clear();
        //Debug.Log("listOfCurrentLevelStudyCards: " + listOfCurrentLevelStudyCards);
        //Debug.Log("arrayOfAllStudyCards: " + arrayOfAllStudyCards[0]);
        for (int i = 0; i < GameManagerScript.currentNumbersLevel; i++)
        {
            listOfCurrentLevelStudyCards.Add(arrayOfAllStudyCards[i]);
        }

        return listOfCurrentLevelStudyCards;
    }

    private StudyCard SelectAStudyCard()
    {
        StudyCard targetNumberWord;
        int randomStudyCardDictionaryIndex = UnityEngine.Random.Range(0, listOfCurrentLevelStudyCards.Count);
        targetNumberWord = listOfCurrentLevelStudyCards[randomStudyCardDictionaryIndex];
        return targetNumberWord;
    }
}
