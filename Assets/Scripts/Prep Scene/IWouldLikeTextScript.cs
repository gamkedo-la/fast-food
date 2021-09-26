using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IWouldLikeTextScript : MonoBehaviour
{
    [SerializeField] Text myTextBoxUIObject;
    // Start is called before the first frame update
    void Start()
    {
        myTextBoxUIObject.text = "I would like a = " + LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I would like a"];
    }

    
}
