using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FullHeadOfLettuceScript : ToppingOnCountertopScript
{
    private GameObject lettuceOnBurgerGameObject;
    private SpriteRenderer lettuceOnBurgerSpriteRenderer;

    private GameObject lettuceOnBurgerScriptablePrefab;
    private SpriteRenderer lettuceOnBurgerScriptablePrefabSpriteRenderer;

    [SerializeField] SpriteRenderer chickenDonerLettuceSpriteRenderer;

    PlayerPicksUpLettuceEvent playerPicksUpLettuceEvent = new PlayerPicksUpLettuceEvent();

    public override void Start()
    {
        base.Start();

        lettuceOnBurgerScriptablePrefab = GameObject.FindGameObjectWithTag("LettuceOnBurgerScriptablePrefab");
        lettuceOnBurgerScriptablePrefabSpriteRenderer = lettuceOnBurgerScriptablePrefab.GetComponent<SpriteRenderer>();

        //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpLettuceEvent, ActualMethodHandlerOnPickupEvent);
        EventManagerScript2.AddPlayerPicksUpLettuceEventInvoker(this);
        EventManagerScript2.AddPlayerPicksUpLettuceEventHandler(ActualMethodHandlerOnPickupEvent);
    }

    public void AddPlayerPicksUpLettuceEventHandler(UnityAction handler)
    {
        playerPicksUpLettuceEvent.AddListener(handler);
    }
    public override void HandleChefPicksMeUpEvent()
    {
        playerPicksUpLettuceEvent.Invoke();
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
