using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WithScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI myTextMeshProUIObject;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManagerScript.currentLanguage != Language.Georgian)
        {
            myTextMeshProUIObject.text = "with = " + LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with"];
        }
        else
        {
            myTextMeshProUIObject.text = "food item + თ, \nexample: lettuce = სალათის ფურწლი \nwith lettuce = სალათის ფურწლით";
        }
    }


}
