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

        concatenatedColorsString = "";
        
        currentTargetColorString = targetStudyCard.arrayOfTextMeshProUGUI[(int)GameManagerScript.currentLanguage].text;
        if (GameManagerScript.currentLanguage != Language.Georgian)
        {
            currentTargetColorString = currentTargetColorString.ToLower();
        }

        foreach (StudyCard studyCard in listOfCurrentLevelStudyCards)
        {
            concatenatedColorsString += studyCard.arrayOfTextMeshProUGUI[(int)GameManagerScript.currentLanguage].text.ToString();
            concatenatedColorsString += " ";
        }

        string[] arrayOfIndividualColors = concatenatedColorsString.Split();

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
            if (colorButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text != "")
            {
                colorButton.transform.SetParent(colorButtonsHorizontalLayoutGroup.transform, false);
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
