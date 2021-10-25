using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FullTomatoeScript : ToppingOnCountertopScript
{
    private GameObject tomatoeOnBurgerGameObject;
    private SpriteRenderer tomatoeOnBurgerSpriteRenderer;
    private SpriteRenderer fullTomatoeSpriteRenderer;

    private GameObject tomatoeOnBurgerScriptableObject;
    private SpriteRenderer tomatoeOnBurgerScriptableObjectSpriteRenderer;
    [SerializeField] SpriteRenderer tomatoOnDonerSpriteRenderer;

    PlayerPicksUpTomatoEvent playerPicksUpTomatoEvent = new PlayerPicksUpTomatoEvent();

    public override void Start()
    {
        base.Start();
        
        tomatoeOnBurgerScriptableObject = GameObject.FindGameObjectWithTag("TomatoeOnBurgerScriptablePrefab");
        tomatoeOnBurgerScriptableObjectSpriteRenderer = tomatoeOnBurgerScriptableObject.GetComponent<SpriteRenderer>();

        //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpTomatoeEvent, ActualMethodHandlerOnPickupEvent);
        EventManagerScript2.AddPlayerPicksUpTomatoEventInvoker(this);
        EventManagerScript2.AddPlayerPicksUpTomatoEventHandler(ActualMethodHandlerOnPickupEvent);
    }

    public void AddPlayerPicksUpTomatoEventHandler(UnityAction handler)
    {
        playerPicksUpTomatoEvent.AddListener(handler);
    }
    private void Reappear()
    {
        fullTomatoeSpriteRenderer.enabled = true;
    }

    public override void HandleChefPicksMeUpEvent()
    {
        playerPicksUpTomatoEvent.Invoke();
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
                if (GameManagerScript.burgerHasTomatoe)//preventing multiple calls
                {
                    return;
                }
                GameManagerScript.burgerHasTomatoe = true;
                //lettuceOnBurgerSpriteRenderer.enabled = true;
                tomatoeOnBurgerScriptableObjectSpriteRenderer.enabled = true;
                Disappear();
            }
            else
            {
                if (GameManagerScript.chickenDonerHasTomatoe)//preventing multiple calls
                {
                    return;
                }
                GameManagerScript.chickenDonerHasTomatoe = true;
                //lettuceOnBurgerSpriteRenderer.enabled = true;
                tomatoOnDonerSpriteRenderer.enabled = true;
                Disappear();
            }
        }
        
        //Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["tomato pickup"]);
    }

    //private void OnMouseUp()
    //{
    //    HandleChefPicksMeUpEvent();
    //}
}
