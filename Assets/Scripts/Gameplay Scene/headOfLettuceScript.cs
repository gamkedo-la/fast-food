using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headOfLettuceScript : ToppingOnCountertopScript
{
    private GameObject lettuceOnBurgerGameObject;
    private SpriteRenderer lettuceOnBurgerSpriteRenderer;

    private GameObject lettuceOnBurgerScriptablePrefab;
    private SpriteRenderer lettuceOnBurgerScriptablePrefabSpriteRenderer;

    [SerializeField] SpriteRenderer chickenDonerLettuceSpriteRenderer;
    private CircleCollider2D myCircleCollider;

    public override void Start()
    {
        base.Start();
        //lettuceOnBurgerGameObject = GameObject.FindGameObjectWithTag("LettuceOnBurger");
        //lettuceOnBurgerSpriteRenderer = lettuceOnBurgerGameObject.GetComponent<SpriteRenderer>();

        lettuceOnBurgerScriptablePrefab = GameObject.FindGameObjectWithTag("LettuceOnBurgerScriptablePrefab");
        lettuceOnBurgerScriptablePrefabSpriteRenderer = lettuceOnBurgerScriptablePrefab.GetComponent<SpriteRenderer>();

        myCircleCollider = gameObject.GetComponent<CircleCollider2D>();

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpLettuceEvent, ActualMethodHandlerOnPickupEvent);
    }

    public override void Update()
    {
        base.Update();
        if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Itch)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (myCircleCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                HandleMouseUp();
        }        
    }

    public override void HandleChefPicksMeUpEvent()
    {
        EventManagerScript.chefPicksUpLettuceEvent.Invoke();
    }

    public override void Reappear()
    {
        mySpriteRenderer.enabled = true;
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

        //Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["lettuce pickup"]);
        AudioController.instance.PlayAudio(GameSoundEnum.Lettuce_Chop);
    }
    
    //Itch
    private void HandleMouseUp()
    {
        Debug.Log("anything from headOfLettuce.cs onMouseUp");
        if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Itch)
        {
            return;
        }
        HandleChefPicksMeUpEvent();
    }
}
