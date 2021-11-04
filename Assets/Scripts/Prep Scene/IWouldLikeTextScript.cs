using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IWouldLikeTextScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI myTextMeshProUIObject;
    // Start is called before the first frame update
    void Start()
    {
        myTextMeshProUIObject.text = "I would like a = " + LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I would like a"];
    }

    
}
