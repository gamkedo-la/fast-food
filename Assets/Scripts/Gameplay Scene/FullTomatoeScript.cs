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
    [SerializeField] SpriteRenderer tomatoOnDonerSpriteRenderer;

    public override void Start()
    {
        base.Start();
        //tomatoeOnBurgerGameObject = GameObject.FindGameObjectWithTag("TomatoeOnBurger");
        //tomatoeOnBurgerSpriteRenderer = tomatoeOnBurgerGameObject.GetComponent<SpriteRenderer>();
        tomatoeOnBurgerScriptableObject = GameObject.FindGameObjectWithTag("TomatoeOnBurgerScriptablePrefab");
        tomatoeOnBurgerScriptableObjectSpriteRenderer = tomatoeOnBurgerScriptableObject.GetComponent<SpriteRenderer>();


        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpTomatoeEvent, ActualMethodHandlerOnPickupEvent);
    }

    public override void Reappear()
    {
        if (GameManagerScript.currentLevel >= 2)
        {
            Debug.Log("inside reappear of full tomato");
            mySpriteRenderer.enabled = true;
        }
    }

    public override void HandleChefPicksMeUpEvent()
    {
        EventManagerScript.chefPicksUpTomatoeEvent.Invoke();
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
