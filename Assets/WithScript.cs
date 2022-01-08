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
        if (GameManagerScript.currentLanguage != Language.Georgian && GameManagerScript.currentLanguage != Language.Turkish)
        {
            myTextMeshProUIObject.text = "with = " + LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with"];
        }
        else if (GameManagerScript.currentLanguage == Language.Georgian)
        {
            myTextMeshProUIObject.text = "food item + ით, \nexample: lettuce = სალათის ფურწლი \nwith lettuce = სალათის ფურწლით";
        }
        else if (GameManagerScript.currentLanguage == Language.Turkish)
        {
            myTextMeshProUIObject.text = "food item + lu or li, \n example: lettuce = marul \nwith lettuce = marullu";
        }
    }


}
