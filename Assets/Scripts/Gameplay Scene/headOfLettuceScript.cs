using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headOfLettuceScript : ToppingOnCountertopScript
{
    private GameObject lettuceOnBurgerGameObject;
    private SpriteRenderer lettuceOnBurgerSpriteRenderer;

    public override void Start()
    {
        base.Start();
        lettuceOnBurgerGameObject = GameObject.FindGameObjectWithTag("LettuceOnBurger");
        lettuceOnBurgerSpriteRenderer = lettuceOnBurgerGameObject.GetComponent<SpriteRenderer>();

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpLettuceEvent, ActualMethodHandlerOnPickupEvent);
    }

    public override void HandleChefPicksMeUpEvent()
    {
        EventManagerScript.chefPicksUpLettuceEvent.Invoke();
    }

    private void ActualMethodHandlerOnPickupEvent()
    {
        GameManagerScript.burgerHasLettuce = true;
        lettuceOnBurgerSpriteRenderer.enabled = true;
        Disappear();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["lettuce pickup"]);
    }
}
