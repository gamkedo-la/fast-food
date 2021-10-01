using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullOnionScript : ToppingOnCountertopScript
{
    private GameObject onionOnBurgerGameObject;
    private SpriteRenderer onionOnBurgerSpriteRenderer;

    private GameObject onionOnBurgerScriptablePrefab;
    private SpriteRenderer onionOnBurgerScriptablePrefabSpriteRenderer;

    public override void Start()
    {
        //onionOnBurgerGameObject = GameObject.FindGameObjectWithTag("OnionOnBurger");
        //onionOnBurgerSpriteRenderer = onionOnBurgerGameObject.GetComponent<SpriteRenderer>();

        onionOnBurgerScriptablePrefab = GameObject.FindGameObjectWithTag("OnionOnBurgerScriptablePrefab");
        onionOnBurgerScriptablePrefabSpriteRenderer = onionOnBurgerScriptablePrefab.GetComponent<SpriteRenderer>();

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
        //onionOnBurgerSpriteRenderer.enabled = true;
        onionOnBurgerScriptablePrefabSpriteRenderer.enabled = true;
        Disappear();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["onion pickup"]);
    }
}
