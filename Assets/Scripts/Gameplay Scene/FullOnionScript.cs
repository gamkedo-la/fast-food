using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FullOnionScript : ToppingOnCountertopScript
{
    private GameObject onionOnBurgerGameObject;
    private SpriteRenderer onionOnBurgerSpriteRenderer;

    private GameObject onionOnBurgerScriptablePrefab;
    private SpriteRenderer onionOnBurgerScriptablePrefabSpriteRenderer;

    [SerializeField] SpriteRenderer onionOnDonerSpriteRenderer;

    PlayerPicksUpOnionEvent playerPicksUpOnionEvent = new PlayerPicksUpOnionEvent();
    
    public override void Start()
    {
        //onionOnBurgerGameObject = GameObject.FindGameObjectWithTag("OnionOnBurger");
        //onionOnBurgerSpriteRenderer = onionOnBurgerGameObject.GetComponent<SpriteRenderer>();

        onionOnBurgerScriptablePrefab = GameObject.FindGameObjectWithTag("OnionOnBurgerScriptablePrefab");
        onionOnBurgerScriptablePrefabSpriteRenderer = onionOnBurgerScriptablePrefab.GetComponent<SpriteRenderer>();

        base.Start();
        //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpOnionEvent, ActualMethodHandlerOnPickupEvent);

        EventManagerScript2.AddPlayerPicksUpOnionEventInvoker(this);
        EventManagerScript2.AddPlayerPicksUpOnionEventHandler(ActualMethodHandlerOnPickupEvent);
    }

    public void AddPlayerPicksUpOnionEventHandler(UnityAction handler)
    {
        playerPicksUpOnionEvent.AddListener(handler);
    }
    public override void HandleChefPicksMeUpEvent()
    {
        playerPicksUpOnionEvent.Invoke();
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
                if (GameManagerScript.burgerHasOnion)//preventing multiple calls, mainly for infinite audio one shots
                {
                    return;
                }
                GameManagerScript.burgerHasOnion = true;
                //lettuceOnBurgerSpriteRenderer.enabled = true;
                onionOnBurgerScriptablePrefabSpriteRenderer.enabled = true;
                Disappear();
            }
            else
            {
                if (GameManagerScript.chickenDonerHasOnion)//preventing multiple calls, mainly for infinite audio one shots
                {
                    return;
                }
                GameManagerScript.chickenDonerHasOnion = true;
                //lettuceOnBurgerSpriteRenderer.enabled = true;
                onionOnDonerSpriteRenderer.enabled = true;
                Disappear();
            }
            Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["onion pickup"]);
        }
    }
    //Itch
    //private void OnMouseUp()
    //{
    //    HandleChefPicksMeUpEvent();
    //}
}
