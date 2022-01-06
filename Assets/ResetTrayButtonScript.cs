using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrayButtonScript : ButtonScript
{
    [SerializeField] GameObject burgerScriptablePrefab;
    [SerializeField] GameObject chickenDonerScriptablePrefab;

    [SerializeField] GameObject fullHeadOfLettuce;
    [SerializeField] GameObject fullOnion;
    [SerializeField] GameObject fullTomato;

    [SerializeField] GameObject beer;
    [SerializeField] GameObject water;
    [SerializeField] GameObject redWine;
    [SerializeField] GameObject whiteWine;

    public override void HandleButtonClick()
    {
        AudioController.instance.PlayAudio(GameSoundEnum.Reset_Tray);

        if (GameManagerScript.burgerHasLettuce || GameManagerScript.chickenDonerHasLettuce)
        {
            fullHeadOfLettuce.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GameManagerScript.burgerHasOnion || GameManagerScript.chickenDonerHasOnion)
        {
            fullOnion.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GameManagerScript.burgerHasTomatoe || GameManagerScript.chickenDonerHasTomatoe)
        {
            fullTomato.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GameManagerScript.chefHasBeer)
        {
            beer.GetComponent<BeerScript>().ResetMeAfterSubmission();
        }
        if (GameManagerScript.chefHasWater)
        {
            water.GetComponent<WaterScript>().ResetMeAfterSubmission();
        }
        if (GameManagerScript.chefHasRedWine)
        {
            redWine.GetComponent<RedWineScript>().ResetMeAfterSubmission();
        }
        if (GameManagerScript.chefHasWhiteWine)
        {
            whiteWine.GetComponent<WhiteWineScript>().ResetMeAfterSubmission();
        }

        if (GameManagerScript.chefHasBurger)
        {
            burgerScriptablePrefab.GetComponent<HamburgerBaseFoodScript>().ResetBaseFood();
        }
        if (GameManagerScript.chefHasChickenDoner)
        {
            chickenDonerScriptablePrefab.GetComponent<ChickenDonerBaseFoodScript>().ResetBaseFood();
        }

        

        GameManagerScript.chefHasBaseFood = false;
        GameManagerScript.chefHasBurger = false;
        GameManagerScript.chefHasChickenDoner = false;
        GameManagerScript.burgerHasLettuce = false;
        GameManagerScript.burgerHasTomatoe = false;
        GameManagerScript.burgerHasOnion = false;
        GameManagerScript.chickenDonerHasTomatoe = false;
        GameManagerScript.chickenDonerHasOnion = false;
        GameManagerScript.chickenDonerHasLettuce = false;
        GameManagerScript.chefHasBeer = false;
        GameManagerScript.chefHasRedWine = false;
        GameManagerScript.chefHasWhiteWine = false;

        
    }
}
