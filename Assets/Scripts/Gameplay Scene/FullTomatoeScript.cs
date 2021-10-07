using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullTomatoeScript : ToppingOnCountertopScript
{
    private GameObject tomatoeOnBurgerGameObject;
    private SpriteRenderer tomatoeOnBurgerSpriteRenderer;
    private SpriteRenderer fullTomatoeSpriteRenderer;

    private GameObject tomatoeOnBurgerScriptableObject;
    private SpriteRenderer tomatoeOnBurgerScriptableObjectSpriteRenderer;

    public override void Start()
    {
        base.Start();
        //tomatoeOnBurgerGameObject = GameObject.FindGameObjectWithTag("TomatoeOnBurger");
        //tomatoeOnBurgerSpriteRenderer = tomatoeOnBurgerGameObject.GetComponent<SpriteRenderer>();
        tomatoeOnBurgerScriptableObject = GameObject.FindGameObjectWithTag("TomatoeOnBurgerScriptablePrefab");
        tomatoeOnBurgerScriptableObjectSpriteRenderer = tomatoeOnBurgerScriptableObject.GetComponent<SpriteRenderer>();

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpTomatoeEvent, ActualMethodHandlerOnPickupEvent);
    }

    private void Reappear()
    {
        fullTomatoeSpriteRenderer.enabled = true;
    }

    public override void HandleChefPicksMeUpEvent()
    {
        EventManagerScript.chefPicksUpTomatoeEvent.Invoke();
    }


    private void ActualMethodHandlerOnPickupEvent()
    {
        if (GameManagerScript.burgerHasTomatoe)
        {
            return;
        }
        GameManagerScript.burgerHasTomatoe = true;
        //tomatoeOnBurgerSpriteRenderer.enabled = true;
        tomatoeOnBurgerScriptableObjectSpriteRenderer.enabled = true;
        Disappear();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["tomato pickup"]);
    }

    //private void OnMouseUp()
    //{
    //    HandleChefPicksMeUpEvent();
    //}
}
