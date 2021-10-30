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

    private CircleCollider2D myCircleCollider;

    public override void Start()
    {
        base.Start();
        //tomatoeOnBurgerGameObject = GameObject.FindGameObjectWithTag("TomatoeOnBurger");
        //tomatoeOnBurgerSpriteRenderer = tomatoeOnBurgerGameObject.GetComponent<SpriteRenderer>();
        tomatoeOnBurgerScriptableObject = GameObject.FindGameObjectWithTag("TomatoeOnBurgerScriptablePrefab");
        tomatoeOnBurgerScriptableObjectSpriteRenderer = tomatoeOnBurgerScriptableObject.GetComponent<SpriteRenderer>();

        myCircleCollider = gameObject.GetComponent<CircleCollider2D>();

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpTomatoeEvent, ActualMethodHandlerOnPickupEvent);
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (myCircleCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                HandleMouseUp();
        }
            
        base.Update();
    }

    public override void Reappear()
    {
        if (GameManagerScript.currentLevel >= 2)
        {
            mySpriteRenderer.enabled = true;
        }
    }

    public override void HandleChefPicksMeUpEvent()
    {
        Debug.Log("inside HandleChefPicksMeUpEvent from tomato script");
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

    //Itch
    private void HandleMouseUp()
    {
        Debug.Log("anything from tomato mouseup");
        if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Itch)
        {
            return;
        }
        HandleChefPicksMeUpEvent();
    }
}
