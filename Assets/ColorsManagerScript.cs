using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using TMPro;

public class ColorsManagerScript : MonoBehaviour
{
    [SerializeField] private StudyCard[] arrayOfAllStudyCards;
    private List<StudyCard> listOfCurrentLevelStudyCards = new List<StudyCard>();
    private StudyCard targetStudyCard;
    public string currentTargetColorString;
    [SerializeField] GameObject colorButtonPrefab;
    [SerializeField] GameObject colorButtonsHorizontalLayoutGroup;
    private string concatenatedColorsString;

    // Start is called before the first frame update
    void Start()
    {
        ResetListOfCurrentLevelStudyCards();
        ResetDisplay();
    }

    public void ResetDisplay()
    {
        foreach (Transform child in colorButtonsHorizontalLayoutGroup.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (targetStudyCard != null)
        {
            targetStudyCard.gameObject.SetActive(false);
        }
        targetStudyCard = SelectAStudyCard();
        targetStudyCard.gameObject.SetActive(true);


        GameManagerScript.currentLanguage = Language.Georgian;

        //Debug.Log("targetStudyCard.dictionaryOfTextMeshProObjects[Language.English]: " + targetStudyCard.dictionaryOfTextMeshProObjects[Language.English]);
        Debug.Log("targetStudyCard.dictionaryOfTextMeshProObjects[Language.Albanian]: " + targetStudyCard.dictionaryOfTextMeshProObjects[Language.Albanian]);
        Debug.Log("targetStudyCard.dictionaryOfTextMeshProObjects[Language.Georgian]: " + targetStudyCard.dictionaryOfTextMeshProObjects[Language.Georgian]);

        currentTargetColorString = targetStudyCard.dictionaryOfTextMeshProObjects[GameManagerScript.currentLanguage].text;
        if (GameManagerScript.currentLanguage != Language.Georgian)
        {
            currentTargetColorString = currentTargetColorString.ToLower();
        }

        Debug.Log("currentWordToSpellString: " + currentTargetColorString);


        foreach (StudyCard studyCard in listOfCurrentLevelStudyCards)
        {
            concatenatedColorsString += studyCard.dictionaryOfTextMeshProObjects[GameManagerScript.currentLanguage].text.ToString();
            concatenatedColorsString += " ";
        }

        Debug.Log("concatenatedNumbersString: " + concatenatedColorsString);
        string[] arrayOfIndividualColors = concatenatedColorsString.Split();

        for (int i = 0; i < arrayOfIndividualColors.Length - 1; i++)
        {
            Debug.Log("arrayOfIndividualColors[i]: " + arrayOfIndividualColors[i]);
        }

        //shuffle the array
        for (int i = 0; i < arrayOfIndividualColors.Length - 1; i++)
        {
            int rnd = UnityEngine.Random.Range(i, arrayOfIndividualColors.Length);
            var tempNumber = arrayOfIndividualColors[rnd];
            arrayOfIndividualColors[rnd] = arrayOfIndividualColors[i];
            arrayOfIndividualColors[i] = tempNumber;
        }

        for (int i = 0; i < arrayOfIndividualColors.Length; i++)
        {
            var colorButton = Instantiate(colorButtonPrefab);
            colorButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = arrayOfIndividualColors[i].ToString();
            Debug.Log("colorButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text: " + colorButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
            if (colorButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text != "")
            {
                colorButton.transform.parent = colorButtonsHorizontalLayoutGroup.transform;
            }
            else
            {
                Destroy(colorButton);
            }
        }

        if (arrayOfIndividualColors.Length == 1)
        {
            colorButtonsHorizontalLayoutGroup.GetComponent<RectTransform>().localPosition = new Vector3(75, 50, 0.0f);
        }
        concatenatedColorsString = "";
    }

    public List<StudyCard> ResetListOfCurrentLevelStudyCards()
    {
        listOfCurrentLevelStudyCards.Clear();
        Debug.Log("listOfCurrentLevelStudyCards: " + listOfCurrentLevelStudyCards);
        Debug.Log("arrayOfAllStudyCards: " + arrayOfAllStudyCards[0]);
        for (int i = 0; i < GameManagerScript.currentColorsLevel; i++)
        {
            listOfCurrentLevelStudyCards.Add(arrayOfAllStudyCards[i]);
        }

        return listOfCurrentLevelStudyCards;
    }
    private StudyCard SelectAStudyCard()
    {
        StudyCard targetColorWord;
        
        int randomStudyCardDictionaryIndex = UnityEngine.Random.Range(0, listOfCurrentLevelStudyCards.Count);
        targetColorWord = listOfCurrentLevelStudyCards[randomStudyCardDictionaryIndex];
        return targetColorWord;
    }
}
