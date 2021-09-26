using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullTomatoeScript : ToppingOnCountertopScript
{
    private GameObject tomatoeOnBurgerGameObject;
    private SpriteRenderer tomatoeOnBurgerSpriteRenderer;
    private SpriteRenderer fullTomatoeSpriteRenderer;

    public override void Start()
    {
        base.Start();
        tomatoeOnBurgerGameObject = GameObject.FindGameObjectWithTag("TomatoeOnBurger");
        tomatoeOnBurgerSpriteRenderer = tomatoeOnBurgerGameObject.GetComponent<SpriteRenderer>();

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpTomatoeEvent, ActualMethodHandlerOnPickupEvent);
    }

    private void Reappear()
    {
        fullTomatoeSpriteRenderer.enabled = true;
    }

    public override void HandleChefPicksMeUpEvent()
    {
        Debug.Log("inside chef picks me up event");
        EventManagerScript.chefPicksUpTomatoeEvent.Invoke();
    }


    private void ActualMethodHandlerOnPickupEvent()
    {
        Debug.Log("anything");
        GameManagerScript.burgerHasTomatoe = true;
        tomatoeOnBurgerSpriteRenderer.enabled = true;
        Disappear();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["tomatoe pickup"]);
    }
}
