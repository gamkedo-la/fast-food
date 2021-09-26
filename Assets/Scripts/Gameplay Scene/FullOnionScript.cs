using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullOnionScript : ToppingOnCountertopScript
{
    private GameObject onionOnBurgerGameObject;
    private SpriteRenderer onionOnBurgerSpriteRenderer;

    public override void Start()
    {
        onionOnBurgerGameObject = GameObject.FindGameObjectWithTag("OnionOnBurger");
        onionOnBurgerSpriteRenderer = onionOnBurgerGameObject.GetComponent<SpriteRenderer>();
        base.Start();
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpOnionEvent, ActualMethodHandlerOnPickupEvent);
    }

    public override void HandleChefPicksMeUpEvent()
    {
        EventManagerScript.chefPicksUpOnionEvent.Invoke();
    }

    private void ActualMethodHandlerOnPickupEvent()
    {
        GameManagerScript.burgerHasOnion = true;
        onionOnBurgerSpriteRenderer.enabled = true;
        Disappear();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["onion pickup"]);
    }
}
