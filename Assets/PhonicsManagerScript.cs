using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using TMPro;

public class PhonicsManagerScript : MonoBehaviour
{
    [SerializeField] private StudyPhonicScript[] arrayOfEnglishStudyPhonicsCards;
    [SerializeField] private StudyPhonicScript[] arrayOfAlbanianStudyPhonicsCards;
    [SerializeField] private StudyPhonicScript[] arrayOfGeorgianStudyPhonicsCards;
    [SerializeField] private StudyPhonicScript[] arrayOfTurkishStudyPhonicsCards;

    private List<StudyPhonicScript> listOfCurrentLevelStudyPhonics = new List<StudyPhonicScript>();
    private StudyPhonicScript targetPhonic;
    public string currentPhonicString;

    private string concatenatedPhonicsString;

    [SerializeField] GameObject phonicButtonPrefab;
    [SerializeField] GameObject phonicButtonsHorizontalLayoutGroup;
    [SerializeField] GameObject phonicButtonsHorizontalLayoutGroup2;
    [SerializeField] GameObject phonicButtonsHorizontalLayoutGroup3;


    // Start is called before the first frame update
    void Start()
    {
        ResetListOfCurrentLevelStudyCards();
        ResetDisplay();
    }

    public void ResetDisplay()
    {
        concatenatedPhonicsString = "";

        foreach (Transform child in phonicButtonsHorizontalLayoutGroup.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in phonicButtonsHorizontalLayoutGroup2.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (targetPhonic != null)
        {
            targetPhonic.gameObject.SetActive(false);
        }
        targetPhonic = SelectAPhonic();
        targetPhonic.gameObject.SetActive(true);


        //GameManagerScript.currentLanguage = Language.English;

        //Debug.Log("targetStudyCard.dictionaryOfTextMeshProObjects[Language.English]: " + targetStudyCard.dictionaryOfTextMeshProObjects[Language.English]);
        //Debug.Log("targetStudyCard.dictionaryOfTextMeshProObjects[Language.Albanian]: " + targetStudyCard.dictionaryOfTextMeshProObjects[Language.Albanian]);
        //Debug.Log("targetStudyCard.dictionaryOfTextMeshProObjects[Language.Georgian]: " + targetStudyCard.dictionaryOfTextMeshProObjects[Language.Georgian]);

        currentPhonicString = targetPhonic.GetComponent<StudyPhonicScript>().myCharacter;
        if (GameManagerScript.currentLanguage != Language.Georgian)
        {
            currentPhonicString = currentPhonicString.ToLower();
        }

        foreach (StudyPhonicScript phonic in listOfCurrentLevelStudyPhonics)
        {
            concatenatedPhonicsString += phonic.GetComponent<StudyPhonicScript>().myCharacter;
            concatenatedPhonicsString += " ";
        }

        //Debug.Log("currentPhonicString: " + currentPhonicString);

        var shuffledCurrentPhonicString = new string(concatenatedPhonicsString.OrderBy(x => Guid.NewGuid()).ToArray());
        char[] arrayOfShuffledCharacters = shuffledCurrentPhonicString.ToCharArray();
        for (int i = 0; i < arrayOfShuffledCharacters.Length; i++)
        {
            if (arrayOfShuffledCharacters[i].ToString() != " ")
            {
                var phonicButton = Instantiate(phonicButtonPrefab);
                phonicButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = arrayOfShuffledCharacters[i].ToString();
                if (i < 22)
                {
                    phonicButton.transform.SetParent(phonicButtonsHorizontalLayoutGroup.transform, false);
                }
                else if (i >= 22 && i < 44)
                {
                    phonicButton.transform.SetParent(phonicButtonsHorizontalLayoutGroup2.transform, false);
                }
                else
                {
                    phonicButton.transform.SetParent(phonicButtonsHorizontalLayoutGroup3.transform, false);
                }
            }  
        }
    }

    public List<StudyPhonicScript> ResetListOfCurrentLevelStudyCards()
    {
        listOfCurrentLevelStudyPhonics.Clear();

        if (GameManagerScript.currentLanguage == Language.English)
        {
            for (int i = 0; i < GameManagerScript.currentEnglishPhonicsLevel; i++)
            {
                listOfCurrentLevelStudyPhonics.Add(arrayOfEnglishStudyPhonicsCards[i]);
            }
            //Debug.Log("listOfCurrentLevelStudyCards.Count: " + listOfCurrentLevelStudyPhonics.Count);
            return listOfCurrentLevelStudyPhonics;
        }
        else if (GameManagerScript.currentLanguage == Language.Albanian)
        {
            for (int i = 0; i < GameManagerScript.currentAlbanianPhonicsLevel; i++)
            {
                listOfCurrentLevelStudyPhonics.Add(arrayOfAlbanianStudyPhonicsCards[i]);
            }
            //Debug.Log("listOfCurrentLevelStudyCards.Count: " + listOfCurrentLevelStudyPhonics.Count);
            return listOfCurrentLevelStudyPhonics;
        }
        else if (GameManagerScript.currentLanguage == Language.Georgian)
        {
            for (int i = 0; i < GameManagerScript.currentGeorgianPhonicsLevel; i++)
            {
                listOfCurrentLevelStudyPhonics.Add(arrayOfGeorgianStudyPhonicsCards[i]);
            }
            //Debug.Log("listOfCurrentLevelStudyCards.Count Georgian: " + listOfCurrentLevelStudyPhonics.Count);
            return listOfCurrentLevelStudyPhonics;
        }
        else if (GameManagerScript.currentLanguage == Language.Turkish)
        {
            for (int i = 0; i < GameManagerScript.currentTurkishPhonicsLevel; i++)
            {
                listOfCurrentLevelStudyPhonics.Add(arrayOfTurkishStudyPhonicsCards[i]);
            }
            return listOfCurrentLevelStudyPhonics;
        }
        else //default to english
        {
            for (int i = 0; i < GameManagerScript.currentEnglishPhonicsLevel; i++)
            {
                listOfCurrentLevelStudyPhonics.Add(arrayOfEnglishStudyPhonicsCards[i]);
            }
            //Debug.Log("listOfCurrentLevelStudyCards.Count: " + listOfCurrentLevelStudyPhonics.Count);
            return listOfCurrentLevelStudyPhonics;
        }
    }

    private StudyPhonicScript SelectAPhonic()
    {
        StudyPhonicScript targetPhonic;
        int randomStudyCardDictionaryIndex = UnityEngine.Random.Range(0, listOfCurrentLevelStudyPhonics.Count);
        targetPhonic = listOfCurrentLevelStudyPhonics[randomStudyCardDictionaryIndex];
        return targetPhonic;
    }
}

