using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headOfLettuceScript : ToppingOnCountertopScript
{
    private GameObject lettuceOnBurgerGameObject;
    private SpriteRenderer lettuceOnBurgerSpriteRenderer;

    private GameObject lettuceOnBurgerScriptablePrefab;
    private SpriteRenderer lettuceOnBurgerScriptablePrefabSpriteRenderer;

    [SerializeField] SpriteRenderer chickenDonerLettuceSpriteRenderer;

    public override void Start()
    {
        base.Start();
        //lettuceOnBurgerGameObject = GameObject.FindGameObjectWithTag("LettuceOnBurger");
        //lettuceOnBurgerSpriteRenderer = lettuceOnBurgerGameObject.GetComponent<SpriteRenderer>();

        lettuceOnBurgerScriptablePrefab = GameObject.FindGameObjectWithTag("LettuceOnBurgerScriptablePrefab");
        lettuceOnBurgerScriptablePrefabSpriteRenderer = lettuceOnBurgerScriptablePrefab.GetComponent<SpriteRenderer>();

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpLettuceEvent, ActualMethodHandlerOnPickupEvent);
    }

    public override void HandleChefPicksMeUpEvent()
    {
        EventManagerScript.chefPicksUpLettuceEvent.Invoke();
    }

    private void ActualMethodHandlerOnPickupEvent()
    {
        if (!GameManagerScript.chefHasBaseFood)
        {
            return;
        }
        else
        {
            if (GameManagerScript.chefHasBurger)
            {
                if (GameManagerScript.burgerHasLettuce)
                {
                    return;
                }
                GameManagerScript.burgerHasLettuce = true;
                //lettuceOnBurgerSpriteRenderer.enabled = true;
                lettuceOnBurgerScriptablePrefabSpriteRenderer.enabled = true;
                Disappear();
            }
            else
            {
                if (GameManagerScript.chickenDonerHasLettuce)
                {
                    return;
                }
                GameManagerScript.chickenDonerHasLettuce = true;
                //lettuceOnBurgerSpriteRenderer.enabled = true;
                chickenDonerLettuceSpriteRenderer.enabled = true;
                Disappear();
            }
        }
        
        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["lettuce pickup"]);
    }
    //Itch
    //private void OnMouseUp()
    //{
    //    HandleChefPicksMeUpEvent();
    //}
}
