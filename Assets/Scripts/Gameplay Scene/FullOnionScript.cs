using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullOnionScript : ToppingOnCountertopScript
{
    private GameObject onionOnBurgerGameObject;
    private SpriteRenderer onionOnBurgerSpriteRenderer;

    private GameObject onionOnBurgerScriptablePrefab;
    private SpriteRenderer onionOnBurgerScriptablePrefabSpriteRenderer;

    [SerializeField] SpriteRenderer onionOnDonerSpriteRenderer;

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
        if (!GameManagerScript.chefHasBaseFood)
        {
            return;
        }
        else
        {
            Debug.Log("GameManagerScript.burgerHasOnion: " + GameManagerScript.burgerHasOnion);
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
                Debug.Log("GameManagerScript.chickenDonerHasOnion: " + GameManagerScript.chickenDonerHasOnion);
                if (GameManagerScript.chickenDonerHasOnion)//preventing multiple calls, mainly for infinite audio one shots
                {
                    return;
                }
                GameManagerScript.chickenDonerHasOnion = true;
                //lettuceOnBurgerSpriteRenderer.enabled = true;
                onionOnDonerSpriteRenderer.enabled = true;
                Disappear();
            }
            Debug.Log("GameManagerScript.chickenDonerHasOnion: " + GameManagerScript.chickenDonerHasOnion);

            Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["onion pickup"]);
        }
    }
    //Itch
    //private void OnMouseUp()
    //{
    //    HandleChefPicksMeUpEvent();
    //}
}
